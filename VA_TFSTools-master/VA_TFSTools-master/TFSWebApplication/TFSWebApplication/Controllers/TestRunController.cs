using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFSCommon.Data;
using TFSWebApplication.Repository.TestRunRepo;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRunController : ControllerBase
    {
        private ITestRunRepository _testRunRepository;

        public TestRunController(ITestRunRepository testRunRepo)
        {
            _testRunRepository = testRunRepo;
        }

        // GET: api/TestRun
        [HttpGet]
        public IEnumerable<TestRun> Get()
        {
            var testRuns = _testRunRepository.GetAllAsync().Result;
            return testRuns;
        }

        // GET: api/TestRun/5
        [HttpGet("{id}")]
        public TestRun Get(int id)
        {
            var testRuns = _testRunRepository.GetAsync(id).Result;
            return testRuns;
        }

        // PATCH: api/TestRun
        [HttpPatch]
        public void Patch([FromBody] TestRun value)
        {
            _testRunRepository.InsertAsync(value);
        }

        // POST: api/TestRun
        [HttpPost]
        public void Post([FromBody] TestRun value)
        {
            _testRunRepository.InsertAsync(value);
        }

        // DELETE: api/TestRun/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _testRunRepository.DeleteAsync(id);
        }
    }
}