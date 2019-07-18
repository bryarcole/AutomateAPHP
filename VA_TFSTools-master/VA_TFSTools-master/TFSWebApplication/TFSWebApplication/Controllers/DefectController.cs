using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFSWebApplication.Repository.DefectRepo;
using TFSCommon.Data;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefectController : ControllerBase
    {
        private IDefectRepository _defectRepository;

        public DefectController(IDefectRepository defectRepository)
        {
            _defectRepository = defectRepository;
        }

        // GET: api/Defect
        [HttpGet]
        public IActionResult Get()
        {
            var defects = _defectRepository.GetAllAsync().Result;
            return Ok(new
            {
                count = defects.Count<Defect>(),
                values = defects
            });
        }

        // GET: api/Defect/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var defect = _defectRepository.GetAsync(id).Result;

            if (defect == null)
            {
                return NotFound("Defect ID #" + id + " does not exist");
            }
            return Ok(defect);
        }

        // POST: api/Defect
        [HttpPost]
        public void Post([FromBody] Defect value)
        {
            _defectRepository.InsertAsync(value);
        }
    }
}