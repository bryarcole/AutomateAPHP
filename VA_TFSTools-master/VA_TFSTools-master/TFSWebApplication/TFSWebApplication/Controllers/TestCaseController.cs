using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TFSCommon.Data;
using TFSWebApplication.Repository.TestCaseRepo;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCaseController : ControllerBase
    {
        private ITestCaseRepository _testCaseRepository;

        public TestCaseController(ITestCaseRepository testCaseRepo)
        {
            _testCaseRepository = testCaseRepo;
        }

        // GET: api/TestCase
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TestCase> testCases = _testCaseRepository.GetAllAsync().Result;
            return Ok(new
            {
                count = testCases.Count<TestCase>(),
                values = testCases
            });
        }

        // GET: api/TestCase/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var testCase = _testCaseRepository.GetAsync(id).Result;

            if (testCase == null)
            {
                return NotFound("Test Case ID #" + id + " does not exist");
            }
            return Ok(testCase);
        }

        [HttpGet("Iteration/{iteration}")]
        public IEnumerable<TestCase> GetByIteration(int iteration)
        {
            var testCases = _testCaseRepository.GetByIterationAsync(iteration).Result;
            return testCases;
        }

        [HttpGet("Plan/{planId}")]
        public IActionResult GetByPlan(int planId)
        {
            var testCases = _testCaseRepository.GetByPlanAsync(planId).Result;
            return Ok(new
            {
                count = testCases.Count<TestCase>(),
                values = testCases
            }); ;
        }

        [HttpGet("TestCaseName/{testCaseName}")]
        public TestCase GetByTestCaseName(string testCaseName)
        {
            var testCase = _testCaseRepository.GetByTestCaseName(testCaseName).Result;
            return testCase;
        }

        // GET: api/TestCase/ByResultDateAndPath?dateTime=06/19/2019&statuses=Passed,Failed&cumulative=1
        [HttpGet("ByResultDate")]
        public IActionResult GetByTestResultDate(string dateTime, string statuses, int cumulative = 0)
        {
            string[] statusesArray = statuses.Split(',').ToArray();
            DateTime parsedDateTime = DateTime.Parse(dateTime);
            string convertedDateTime = parsedDateTime.ToString("yyyy-MM-dd");

            //System.Diagnostics.Trace.WriteLine(statusesArray.ToString());
            //System.Diagnostics.Trace.WriteLine(parsedDateTime.ToString());

            var testCases = _testCaseRepository.GetTestCasesExecutedOnDate(convertedDateTime, statusesArray, cumulative).Result;

            return Ok(new
            {
                count = testCases.Count<TestCase>(),
                values = testCases
            });
        }

        // GET: api/TestCase/ByResultDateAndPath?dateTime=2019-06-19&statuses=Passed,Failed&cumulative=1&path=VA SIT,Iteration 3%
        [HttpGet("ByResultDateAndPath")]
        public IActionResult GetByTestResultDateAndPath(string dateTime, string statuses, string path, int cumulative = 0)
        {
            string[] statusesArray = statuses.Split(',').ToArray();
            DateTime parsedDateTime = DateTime.Parse(dateTime);
            string convertedDateTime = parsedDateTime.ToString("yyyy-MM-dd");

            //System.Diagnostics.Trace.WriteLine(statusesArray.ToString());
            //System.Diagnostics.Trace.WriteLine(parsedDateTime.ToString());

            var testCases = _testCaseRepository.GetTestCasesExecutedOnDate(convertedDateTime, statusesArray, cumulative, path).Result;

            return Ok(new
            {
                count = testCases.Count<TestCase>(),
                values = testCases
            });
        }

        // GET: api/TestCase/ReadyForTest?statuses=1 - Critical,2 - High&testCaseStatuses=Blocked,Failed
        [HttpGet("ReadyForTest")]
        public IActionResult GetTestCaseReadyForTest(string severity, string testCaseStatuses)
        {
            string[] severityArray = severity.Split(',').ToArray();
            string[] testCaseStatusesArray = testCaseStatuses.Split(',').ToArray();
            var testCases = _testCaseRepository.GetReadyForTestTestCases(severityArray, testCaseStatusesArray).Result;

            return Ok(new
            {
                count = testCases.Count<TestCase>(),
                values = testCases
            });
        }

        // GET: api/TestCase/FailedWithMinorDefects?testCasePath=VA SIT,Iteration 3,IT3-Member,EV
        [HttpGet("FailedWithMinorDefects")]
        public IActionResult GetTestCasesPathWithMinorDefect(string testCasePath)
        {
            var testCases = _testCaseRepository.GetTestCasesPassedWithMinorDefects(testCasePath).Result;

            return Ok(new
            {
                count = testCases.Count<TestCase>(),
                values = testCases
            });
        }

        // POST: api/TestCase
        [HttpPost]
        public void Post([FromBody] TestCase value)
        {
            _testCaseRepository.InsertAsync(value);
        }

        // PATCH: api/TestCase
        [HttpPatch]
        public void Patch([FromBody] TestCase value)
        {
            _testCaseRepository.InsertAsync(value);
        }

        //// PUT: api/TestCase/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] TestCase value)
        //{
        //    _testCaseRepository.InsertAsync(value);
        //}

        // DELETE: api/TestCase/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _testCaseRepository.DeleteAsync(id);
        }
    }
}