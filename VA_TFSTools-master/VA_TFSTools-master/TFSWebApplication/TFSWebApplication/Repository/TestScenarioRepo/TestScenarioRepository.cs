using Dapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSWebApplication.Models.Mappings;

namespace TFSWebApplication.Repository.TestScenarioRepo
{
    public class TestScenarioRepository : SqlRepository<TestScenario>, ITestScenarioRepository
    {
        public TestScenarioRepository(string connectionString) : base(connectionString) { }

        public async override void DeleteAsync(int id)
        {
            var sql = @"DELETE FROM TFS_TestScenario AS TestScenario WHERE TestScenario.TestScenarioId = @id";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var conn = GetOpenConnection())
            {
                try
                {
                    var temp = await conn.ExecuteAsync(sql, parameters);
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public async override Task<IEnumerable<TestScenario>> GetAllAsync()
        {
            var sql = @"SELECT TestScenario.*, TestCase.* FROM TFS_TestScenario AS TestScenario 
JOIN MP_TestScenarioTestCaseMap AS TestScenarioTestCaseMap ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
JOIN TFS_TestCase AS TestCase ON TestScenarioTestCaseMap.TestCaseId = TestCase.TestCaseId";

            Dictionary<int, TestScenario> res = await GetAsyncHelper(sql);
            return res.Values.ToList<TestScenario>();
        }

        public async override Task<TestScenario> GetAsync(int id)
        {
            var sql = @"SELECT TestScenario.*, TestCase.* FROM TFS_TestScenario AS TestScenario 
JOIN MP_TestScenarioTestCaseMap AS TestScenarioTestCaseMap ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
JOIN TFS_TestCase AS TestCase ON TestScenarioTestCaseMap.TestCaseId = TestCase.TestCaseId
WHERE TestScenario.TestScenarioId = @id";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            Dictionary<int, TestScenario> res = await GetAsyncHelper(sql, parameters);

            return res.Values.FirstOrDefault<TestScenario>();
        }

        private async Task<Dictionary<int, TestScenario>> GetAsyncHelper(string sql, DynamicParameters parameters = null)
        {
            using (var conn = GetOpenConnection())
            {
                var testScenarioDictionary = new Dictionary<int, TestScenario>();

                var testCaseDictionary = new Dictionary<int, List<int>>();

                await conn.QueryAsync<TestScenario, TestCase, TestScenario>(
                        sql,
                        (testScenario, testCase) =>
                        {
                            TestScenario testScenarioEntry;

                            if (!testScenarioDictionary.TryGetValue(testScenario.TestScenarioId, out testScenarioEntry))
                            {
                                testScenarioEntry = testScenario;
                                if (testCase != null && testCase.TestCaseId != 0)
                                {
                                    testScenarioEntry.TestCases = new List<TestCase>();
                                    testCaseDictionary.Add(testScenario.TestScenarioId, new List<int>());
                                }

                                testScenarioDictionary.Add(testScenario.TestScenarioId, testScenario);
                            }

                            var testScenarioId = testScenario.TestScenarioId;

                            if (testCaseDictionary.ContainsKey(testScenarioId)
                                    && !testCaseDictionary[testScenarioId].Contains(testCase.TestCaseId))
                            {
                                testScenarioEntry.TestCases.Add(testCase);
                                testCaseDictionary[testScenarioId].Add(testCase.TestCaseId);
                            }

                            return testScenarioEntry;
                        },
                        parameters,
                        splitOn: "TestCaseId"
                    );

                return testScenarioDictionary;
            }
        }

        public override void InsertAsync(TestScenario entity)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_TestScenario AS TestScenario 
(TestScenarioId, ContractRequirementId, ScenarioDescription, ScenarioName, ApplicationArea, ApplicationProcess)
VALUES
(@TestScenarioId, @ContractRequirementId, @ScenarioDescription, @ScenarioName, @ApplicationArea, @ApplicationProcess)";

            using (var conn = GetOpenConnection())
            {
                try
                {
                    conn.ExecuteAsync(sql, entity);

                    if (entity.TestCases != null)
                    {
                        foreach (TestCase testCase in entity.TestCases)
                        {
                            TestScenarioTestCaseMap currMap = new TestScenarioTestCaseMap
                            {
                                TestCaseId = testCase.TestCaseId,
                                TestScenarioId = entity.TestScenarioId
                            };

                            InsertTestScenarioTestCaseMap(currMap);
                        }
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        private void InsertTestScenarioTestCaseMap(TestScenarioTestCaseMap testScenarioTestCaseMap)
        {
            var sql = @"INSERT OR REPLACE INTO MP_TestScenarioTestCaseMap AS TestScenarioTestCaseMap
(TestScenarioTestCaseId, TestScenarioId, TestCaseId)
VALUES
(@TestScenarioTestCaseId, @TestScenarioId, @TestCaseId)";

            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, testScenarioTestCaseMap);
            }
        }

        public override void UpdateAsync(TestScenario entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
