using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSCommon.Data.Mappings;
using TFSCommon.Common;
using TFSWebApplication.Repository.TestCaseRepo;

namespace TFSWebApplication.Repository.DefectRepo
{
    public class DefectRepository : SqlRepository<Defect>, IDefectRepository
    {
        private readonly string _connectionString;
        public DefectRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IEnumerable<Defect>> GetAllAsync()
        {
            string sql = @"SELECT Defect.*, DefectHistory.*, TestCaseDefectMap.* FROM TFS_Defect AS Defect
                            LEFT JOIN TFS_DefectHistory AS DefectHistory ON Defect.DefectId = DefectHistory.DefectId
                            LEFT JOIN MP_TestCaseDefectMap AS TestCaseDefectMap ON Defect.DefectId = TestCaseDefectMap.DefectId
                            ORDER BY DefectCreateDate DESC";
            IEnumerable<Defect> res = GetAsyncHelper(sql).Result.Values.AsEnumerable();
            return res;
        }

        public async override Task<Defect> GetAsync(int id)
        {
            string sql = @"SELECT TFS_Defect.*, TFS_DefectHistory.* FROM TFS_Defect 
                            LEFT JOIN TFS_DefectHistory ON TFS_Defect.DefectId = TFS_DefectHistory.DefectId
                            WHERE TFS_Defect.DefectId = @id
                            ORDER BY DefectCreateDate DESC";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);

            Dictionary<int, Defect> defectDictionary = await GetAsyncHelper(sql, parameters);
            return defectDictionary.Values.FirstOrDefault<Defect>();
        }

        private async Task<Dictionary<int, Defect>> GetAsyncHelper(string sql, DynamicParameters parameters = null)
        {
            TestCaseRepository testCaseRepository = new TestCaseRepository(_connectionString);
            using (var conn = GetOpenConnection())
            {
                var defectDictionary = new Dictionary<int, Defect>();

                var defectHistoryDictionary = new Dictionary<int, List<int>>();
                var testCaseDefectDictionary = new Dictionary<int, List<int>>();

                await conn.QueryAsync<Defect, DefectHistory, TestCaseDefectMap, Defect>(
                        sql,
                        (defect, defectHistory, testCaseDefectMap) =>
                        {
                            Defect defectEntry;

                            if (!defectDictionary.TryGetValue(defect.DefectId, out defectEntry))
                            {
                                defectEntry = defect;
                                if (defectHistory != null && defectHistory.DefectHistoryId != 0)
                                {
                                    defectEntry.DefectHistories = new List<DefectHistory>();
                                    defectHistoryDictionary.Add(defect.DefectId, new List<int>());
                                }
                                if (testCaseDefectMap != null && testCaseDefectMap.TestCaseDefectId != 0)
                                {
                                    defectEntry.TestCases = new List<TestCase>();
                                    testCaseDefectDictionary.Add(testCaseDefectMap.DefectId, new List<int>());
                                }
                                defectDictionary.Add(defect.DefectId, defect);
                            }

                            var defectId = defect.DefectId;

                            if (defectHistoryDictionary.ContainsKey(defectId)
                                    && !defectHistoryDictionary[defectId].Contains(defectHistory.DefectHistoryId))
                            {
                                defectEntry.DefectHistories.Add(defectHistory);
                                defectHistoryDictionary[defectId].Add(defectHistory.DefectHistoryId);
                            }

                            if (testCaseDefectDictionary.ContainsKey(defectId)
                                    && !testCaseDefectDictionary[defectId].Contains(testCaseDefectMap.TestCaseDefectId))
                            {
                                TestCase testCase = testCaseRepository.GetAsync(testCaseDefectMap.TestCaseId).Result;
                                defectEntry.TestCases.Add(testCase);

                                testCaseDefectDictionary[defectId].Add(testCaseDefectMap.TestCaseDefectId);
                            }

                            return defectEntry;
                        },
                        parameters,
                        splitOn: "DefectHistoryId, TestCaseDefectId"
                    );

                return defectDictionary;
            }
        }

        public override void InsertAsync(Defect entity)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_Defect AS Defect 
                        (DefectId, DefectName, DefectSeverity, DefectHistory, Status, AssignedTo, 
                        DefectCreateDate, DefectCreatedBy, DiscussionDate, Iteration, DefectType,
                        ApplicationArea, ApplicationProcess, FoundInEnvironment)
                        VALUES 
                        (@DefectId, @DefectName, @DefectSeverity, @DefectHistory, @Status, @AssignedTo, 
                        @DefectCreateDate, @DefectCreatedBy, @DiscussionDate, @Iteration, @DefectType,
                        @ApplicationArea, @ApplicationProcess, @FoundInEnvironment)";

            var historySql = @"INSERT OR REPLACE INTO TFS_DefectHistory AS DefectHistory 
                                (DefectId, History, Timestamp)
                                VALUES 
                                (@DefectId, @History, @Timestamp)";

            var testCaseDefectSql = @"INSERT OR REPLACE INTO MP_TestCaseDefectMap AS TestCaseDefectMap 
                                    (TestCaseId, DefectId)
                                    VALUES
                                    (@TestCaseId, @DefectId);";

            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, entity);
            }

            if (entity.DefectHistories != null)
            {
                DeleteDefectHistoryById(entity.DefectId);

                foreach (DefectHistory history in entity.DefectHistories)
                {
                    if (!CheckForDuplicateHistory(history))
                    {
                        DefectHistory copyHistory = history.CloneJson<DefectHistory>();
                        copyHistory.DefectId = entity.DefectId;

                        using (var conn = GetOpenConnection())
                        {
                            conn.Execute(historySql, copyHistory);
                        }
                    }
                }
            }

            if (entity.TestCases != null)
            {
                foreach (TestCase testCase in entity.TestCases)
                {
                    if (!CheckForDuplicateTestCaseDefectMap(entity, testCase))
                    {
                        TestCaseDefectMap testCaseDefectMap = new TestCaseDefectMap
                        {
                            DefectId = entity.DefectId,
                            TestCaseId = testCase.TestCaseId
                        };

                        using (var conn = GetOpenConnection())
                        {
                            conn.Execute(testCaseDefectSql, testCaseDefectMap);
                        }
                    }
                }
            }
        }

        private Boolean CheckForDuplicateHistory(DefectHistory defectHistory)
        {
            var checkHistorySql = @"SELECT COUNT(*) FROM TFS_DefectHistory AS DefectHistory
                                    WHERE DefectHistory.DefectId = @id
                                    AND DefectHistory.History = @history";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", defectHistory.DefectId);
            parameters.Add("history", defectHistory.History);

            using (var conn = GetOpenConnection())
            {
                int count = conn.ExecuteScalar<int>(checkHistorySql, parameters);

                if (count >= 1)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        private Boolean CheckForDuplicateTestCaseDefectMap(Defect defect, TestCase testCase)
        {
            var checkMapSql = @"SELECT COUNT(*) FROM MP_TestCaseDefectMap
                                WHERE TestCaseId = @testCaseId
                                AND DefectId = @defectId;";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@testCaseId", testCase.TestCaseId);
            parameters.Add("@defectId", defect.DefectId);

            using (var conn = GetOpenConnection())
            {
                int count = conn.ExecuteScalar<int>(checkMapSql, parameters);

                if (count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void DeleteDefectHistoryById(int defectId)
        {
            var sql = @"DELETE FROM TFS_DefectHistory WHERE DefectId = @defectId";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@defectId", defectId);

            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, parameters);
            }
        }

        public override void UpdateAsync(Defect entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
