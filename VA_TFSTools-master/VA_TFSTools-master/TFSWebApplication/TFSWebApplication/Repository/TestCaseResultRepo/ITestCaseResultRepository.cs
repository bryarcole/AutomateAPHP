using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSWebApplication.Repository.TestCaseResultRepo
{
    public interface ITestCaseResultRepository: IGenericRepository<TestCaseResult>
    {
        Task<IEnumerable<TestCaseResult>> GetByTestCaseIdAsync(int id);
    }
}
