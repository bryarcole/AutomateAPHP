using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSWebApplication.Repository.TestStepRepo
{
    public class TestStepRepository : SqlRepository<TestStep>, ITestStepRepository
    {
        public TestStepRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<TestStep>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<TestStep> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(TestStep entity)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_TestStep AS TestStep 
                        (TestStepId, StepNumber, Action, Expected, TestCaseId)
                        VALUES
                        (@TestStepId, @StepNumber, @Action, @Expected, @TestCaseId)";
            using (var conn = GetOpenConnection())
            {
                conn.ExecuteAsync(sql, entity);
            }
        }

        public override void UpdateAsync(TestStep entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
