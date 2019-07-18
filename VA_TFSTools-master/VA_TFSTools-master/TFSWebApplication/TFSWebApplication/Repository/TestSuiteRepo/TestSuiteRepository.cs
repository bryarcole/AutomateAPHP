using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSWebApplication.Repository.TestSuiteRepo
{
    public class TestSuiteRepository : SqlRepository<TestSuite>, ITestSuiteRepository
    {
        public TestSuiteRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<TestSuite>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<TestSuite> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TestCase>> GetTestCaseBySuiteId_AllLevel(int suiteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TestCase>> GetTestCaseBySuiteId_SingleLevel(int suiteId)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(TestSuite entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(TestSuite entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
