using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TFSCommon.Data;

namespace TFSWebApplication.Repository.TestCaseResultRepo
{
    public class TestCaseResultRepository : SqlRepository<TestCaseResult>, ITestCaseResultRepository
    {
        public TestCaseResultRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<TestCaseResult>> GetAllAsync()
        {
            var sql = "SELECT * FROM TFS_TestCaseResult as TestCaseResult";

            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<TestCaseResult>(sql);
            }
        }

        public override Task<TestCaseResult> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TestCaseResult>> GetByTestCaseIdAsync(int id)
        {
            var sql = "SELECT * FROM TFS_TestCaseResult AS TestCaseResult WHERE TestCaseId = @id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var conn = GetOpenConnection())
            {
                IEnumerable<TestCaseResult> res = conn.QueryAsync<TestCaseResult>(sql, parameters).Result.AsEnumerable();
                return res;
            }
        }

        public override async void InsertAsync(TestCaseResult entity)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_TestCaseResult AS TestCaseResult
                        (TestRunId, Result, RunByName, ResultDT, TestCaseId)
                        VALUES  
                        (@TestRunId, @Result, @RunByName, @ResultDT, @TestCaseId);";
            using (var conn = GetOpenConnection())
            {
                await conn.ExecuteAsync(sql, entity);
            }
        }

        public override async void UpdateAsync(TestCaseResult entityToUpdate)
        {
            var updateSql = @"INSERT OR REPLACE INTO TFS_TestCaseResult AS TestCaseResult
                        (TestCaseResultId, TestRunId, Result, RunByName, ResultDT, TestCaseId)
                        VALUES  
                        (@TestCaseResultId, @TestRunId, @Result, @RunByName, @ResultDT, @TestCaseId);";

            var getIdSql = @"SELECT TestCaseResult.TestCaseResultId FROM TFS_TestCaseResult TestCaseResult WHERE TestCaseId = @TestCaseId AND TestRunId = @TestRunId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TestCaseId", entityToUpdate.TestCaseId);
            parameters.Add("@TestRunId", entityToUpdate.TestRunId);

            int testCaseResultId;

            using (var conn = GetOpenConnection())
            {
                testCaseResultId = conn.ExecuteScalar<int>(getIdSql, parameters);
            }

            TestCaseResult newEntity = new TestCaseResult()
            {
                TestCaseResultId = testCaseResultId,
                TestRunId = entityToUpdate.TestRunId,
                Result = entityToUpdate.Result,
                RunByName = entityToUpdate.RunByName,
                ResultDT = entityToUpdate.ResultDT,
                TestCaseId = entityToUpdate.TestCaseId
            };

            using (var conn = GetOpenConnection())
            {
                await conn.ExecuteAsync(updateSql, newEntity);
            }

            throw new NotImplementedException();
        }
    }
}
