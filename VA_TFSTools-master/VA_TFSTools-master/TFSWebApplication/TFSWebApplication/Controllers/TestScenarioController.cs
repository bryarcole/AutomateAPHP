using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TFSCommon.Data;
using TFSWebApplication.Repository.TestScenarioRepo;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestScenarioController : ControllerBase
    {
        private ITestScenarioRepository _testScenarioRepository;

        public TestScenarioController(ITestScenarioRepository testScenarioRepo)
        {
            _testScenarioRepository = testScenarioRepo;
        }

        // GET: api/TestScenario
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TestScenario> res = _testScenarioRepository.GetAllAsync().Result;

            return Ok(res);
        }

        // GET: api/TestScenario/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TestScenario res = _testScenarioRepository.GetAsync(id).Result;
            return Ok(res);
        }

        // POST: api/TestScenario
        [HttpPost]
        public void Post([FromBody] TestScenario value)
        {
            _testScenarioRepository.InsertAsync(value);
        }

        // PATCH: api/TestScenario/5
        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] JsonPatchDocument<TestScenario> value, int id)
        {
            TestScenario curr = new TestScenario();
            try
            {
                curr = _testScenarioRepository.GetAsync(id).Result;
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

            if (value != null)
            {
                value.ApplyTo(curr, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _testScenarioRepository.InsertAsync(curr);

                return new ObjectResult(_testScenarioRepository.GetAsync(id).Result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}