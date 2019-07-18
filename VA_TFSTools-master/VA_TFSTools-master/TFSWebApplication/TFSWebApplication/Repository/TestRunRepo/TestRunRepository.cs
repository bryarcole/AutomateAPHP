using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSWebApplication.Repository.TestRunRepo;
using TFSWebApplication.Repository.TestCaseResultRepo;
using TFSCommon.Common;

namespace TFSWebApplication.Repository.TestRunRepo
{
    public class TestRunRepository : SqlRepository<TestRun>, ITestRunRepository
    {
        public TestRunRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            var sql = @"DELETE FROM TFS_TestRun AS TestRun
                        WHERE TestRunId = @id;

                        DELETE FROM TFS_TestCaseResult AS TestCaseResult
                        WHERE TestRunId = @id;";

            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, new { id });
            }
        }

        public async override Task<IEnumerable<TestRun>> GetAllAsync()
        {
            var sql = @"SELECT TestRun.*, TestCaseResult.*  FROM TFS_TestRun AS TestRun
                        JOIN TFS_TestCaseResult AS TestCaseResult ON TestRun.TestRunId = TestCaseResult.TestRunId";

            Dictionary<int, TestRun> testRunDictionary = await GetAsyncHelper(sql);

            return testRunDictionary.Values.AsEnumerable<TestRun>();

        }

        public async override Task<TestRun> GetAsync(int id)
        {
            var sql = @"SELECT TestRun.*, TestCaseResult.*  FROM TFS_TestRun AS TestRun
                        JOIN TFS_TestCaseResult AS TestCaseResult ON TestRun.TestRunId = TestCaseResult.TestRunId
                        WHERE TestRun.TestRunId = @id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            Dictionary<int, TestRun> testRunDictionary = await GetAsyncHelper(sql, parameters);

            return testRunDictionary.Values.FirstOrDefault<TestRun>();
        }

        private async Task<Dictionary<int, TestRun>> GetAsyncHelper(string sql, DynamicParameters parameters = null)
        {
            using (var conn = GetOpenConnection())
            {
                var testRunDictionary = new Dictionary<int, TestRun>();

                var testCaseResultDictionary = new Dictionary<int, List<int>>();

                //System.Diagnostics.Debug.WriteLine("Test");
                await conn.QueryAsync<TestRun, TestCaseResult, TestRun>(
                        sql,
                        (testRun, testCaseResult) =>
                        {
                            TestRun testRunEntry;

                            //System.Diagnostics.Debug.WriteLine(testRun.TestRunId);

                            if (!testRunDictionary.TryGetValue(testRun.TestRunId, out testRunEntry))
                            {
                                testRunEntry = testRun;
                                if (testCaseResult != null && testCaseResult.TestCaseResultId != 0)
                                {
                                    testRunEntry.TestCaseResults = new List<TestCaseResult>();
                                    testCaseResultDictionary.Add(testRun.TestRunId, new List<int>());
                                }
                                testRunDictionary.Add(testRun.TestRunId, testRunEntry);
                            }

                            var testRunId = testRun.TestRunId;

                            if (testCaseResultDictionary.ContainsKey(testRunId)
                                    && !testCaseResultDictionary[testRunId].Contains(testCaseResult.TestCaseResultId))
                            {
                                testRunEntry.TestCaseResults.Add(testCaseResult);
                                testCaseResultDictionary[testRunId].Add(testCaseResult.TestCaseResultId);
                            }

                            return testRunEntry;
                        },
                        parameters,
                        splitOn: "TestCaseResultId"
                    );

                return testRunDictionary;
            }
        }

        public async override void InsertAsync(TestRun entity)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_TestRun AS TestRun
                        (TestRunId, TestRunName, PassedTests, State, TotalTests, 
                        LastUpdatedBy, LastUpdatedDate, Owner, IncompleteTests,
                        NotApplicableTests, UnanalyzedTests, TestSuiteId, TestPlanId)
                        VALUES
                        (@TestRunId, @TestRunName, @PassedTests, @State, @TotalTests, 
                        @LastUpdatedBy, @LastUpdatedDate, @Owner, @IncompleteTests,
                        @NotApplicableTests, @UnanalyzedTests, @TestSuiteId, @TestPlanId)";
            using (var conn = GetOpenConnection())
            {
                await conn.ExecuteAsync(sql, entity);
            }

            foreach (TestCaseResult tempTestCaseResult in entity.TestCaseResults)
            {
                var currTestCaseResult = tempTestCaseResult;
                currTestCaseResult.TestRunId = entity.TestRunId;

                InsertTestCaseResultAsync(currTestCaseResult);
            }
        }

        private async void InsertTestCaseResultAsync(TestCaseResult testCaseResult)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_TestCaseResult AS TestCaseResult
                        (TestRunId, Result, RunByName, ResultDT, TestCaseId)
                        VALUES  
                        (@TestRunId, @Result, @RunByName, @ResultDT, @TestCaseId);";

            var sqlWithTestCaseResultId = @"INSERT OR REPLACE INTO TFS_TestCaseResult AS TestCaseResult
                        (TestCaseResultId, TestRunId, Result, RunByName, ResultDT, TestCaseId)
                        VALUES  
                        (@TestCaseResultId, @TestRunId, @Result, @RunByName, @ResultDT, @TestCaseId);";

            using (var conn = GetOpenConnection())
            {
                TestCaseResult gatheredTestCaseResult = CheckTestCaseResultExists(testCaseResult).Result;
                if (gatheredTestCaseResult != null)
                {
                    await conn.ExecuteAsync(sqlWithTestCaseResultId, gatheredTestCaseResult);
                }
                else
                {
                    await conn.ExecuteAsync(sql, testCaseResult);
                }
            }
        }

        private async Task<TestCaseResult> CheckTestCaseResultExists(TestCaseResult testCaseResult)
        {
            var sql = @"SELECT TestCaseResult.TestCaseResultId FROM TFS_TestCaseResult AS TestCaseResult
                        WHERE TestRunId = @TestRunId
                        AND TestCaseId = @TestCaseId";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TestRunId", testCaseResult.TestRunId);
            parameters.Add("@TestCaseId", testCaseResult.TestCaseId);

            using (var conn = GetOpenConnection())
            {
                int currentTestCaseResult = conn.ExecuteScalar<int>(sql, parameters);
                System.Diagnostics.Debug.WriteLine(currentTestCaseResult);

                if (currentTestCaseResult != 0) {
                    TestCaseResult newEntity = new TestCaseResult()
                    {
                        TestCaseResultId = currentTestCaseResult,
                        TestRunId = testCaseResult.TestRunId,
                        Result = testCaseResult.Result,
                        RunByName = testCaseResult.RunByName,
                        ResultDT = testCaseResult.ResultDT,
                        TestCaseId = testCaseResult.TestCaseId
                    };
                    return newEntity;
                }
                else {
                    return null;
                }
            }

        }

        public override void UpdateAsync(TestRun entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
