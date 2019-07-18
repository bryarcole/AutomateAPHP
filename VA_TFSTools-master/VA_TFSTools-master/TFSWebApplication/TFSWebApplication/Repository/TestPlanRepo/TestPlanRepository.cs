using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;
using Dapper;

namespace TFSWebApplication.Repository.TestPlanRepo
{
    public class TestPlanRepository : SqlRepository<TestPlan>, ITestPlanRepository
    {
        public TestPlanRepository(string connectionString) : base(connectionString) { }

        public async override void DeleteAsync(int id)
        {
            var sql = @"DELETE FROM TFS_TestPlan WHERE TestPlanId = @id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var conn = GetOpenConnection())
            {
                await conn.ExecuteAsync(sql, parameters);
            }
        }

        public override Task<IEnumerable<TestPlan>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<TestPlan> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(TestPlan entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(TestPlan entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
