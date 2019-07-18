using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFSCommon.Data;
using TFSWebApplication.Repository.ContractRequirementRepo;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractRequirementController : ControllerBase
    {
        private IContractRequirementRepository _contractRequirementRepository;

        public ContractRequirementController(IContractRequirementRepository contractRequirementRepo)
        {
            _contractRequirementRepository = contractRequirementRepo;
        }

        // GET: api/ContractRequirement
        [HttpGet]
        [Authorize]
        public IEnumerable<ContractRequirement> Get()
        {
            return _contractRequirementRepository.GetAllAsync().Result;
        }

        // GET: api/ContractRequirement/5
        [HttpGet("{id}")]
        public ContractRequirement Get(int id)
        {
            return _contractRequirementRepository.GetAsync(id).Result;
        }

        // PATCH: api/ContractRequirement
        [HttpPatch]
        public void Patch(ContractRequirement entity)
        {
            _contractRequirementRepository.InsertAsync(entity);
        }

        // POST: api/ContractRequirement
        [HttpPost]
        public void Post(ContractRequirement entity)
        {
            _contractRequirementRepository.InsertAsync(entity);
        }
    }
}