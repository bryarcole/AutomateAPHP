using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFSCommon.Data;
using TFSWebApplication.Repository.TestCaseResultRepo;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCaseResultController : ControllerBase
    {
        private ITestCaseResultRepository _testCaseResultRepository;

        public TestCaseResultController(ITestCaseResultRepository testCaseResultRepo)
        {
            _testCaseResultRepository = testCaseResultRepo;
        }

        // GET: api/TestCaseResult
        [HttpGet]
        public async Task<IEnumerable<TestCaseResult>> Get()
        {
            var testCaseResults = await _testCaseResultRepository.GetAllAsync();
            return testCaseResults;
        }

        // GET: api/TestCaseResult/5
        [HttpGet("TestCase/{id}")]
        public IEnumerable<TestCaseResult> GetByTestCaseId(int id)
        {
            var testCaseResults = _testCaseResultRepository.GetByTestCaseIdAsync(id).Result;
            return testCaseResults;
        }
    }
}
