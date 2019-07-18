using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSWebApplication.Repository.TestSuiteRepo
{
    interface ITestSuiteRepository
    {
        Task<List<TestCase>> GetTestCaseBySuiteId_SingleLevel(int suiteId);
        Task<List<TestCase>> GetTestCaseBySuiteId_AllLevel(int suiteId);
    }
}
