using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSWebApplication.Repository.TestCaseRepo
{
    public interface ITestCaseRepository: IGenericRepository<TestCase>
    {
        Task<List<TestCase>> GetByIterationAsync(int iteration);

        Task<List<TestCase>> GetByPlanAsync(int planId);

        Task<TestCase> GetByTestCaseName(string name);

        Task<IEnumerable<TestCase>> GetTestCasesExecutedOnDate(string dateTime, string[] statuses, int cumulative = 0, string testCasePathStart = null);

        Task<IEnumerable<TestCase>> GetTestCaseTotalExecutedOnDate(string dateTime, string testCasePath);

        Task<IEnumerable<TestCase>> GetReadyForTestTestCases(string[] severity, string[] testCaseStatuses);

        Task<IEnumerable<TestCase>> GetTestCasesPassedWithMinorDefects(string testCasePath);

        // Need to delete test result links, test run links, test steps
        // DELETE
    }
}
