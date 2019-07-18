using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSuiteController : ControllerBase
    {
        // GET: api/TestSuite
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestSuite/5
        [HttpGet("{id}")]
        public string Get(int id, string drilldown="0")
        {
            return "value";
        }
    }
}
