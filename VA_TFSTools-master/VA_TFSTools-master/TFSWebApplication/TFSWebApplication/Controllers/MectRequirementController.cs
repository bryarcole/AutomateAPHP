using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFSCommon.Data;
using TFSWebApplication.Repository.MectRequirementRepo;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MectRequirementController : ControllerBase
    {
        private IMectRequirementRepository _mectRequirementRepository;

        public MectRequirementController(IMectRequirementRepository contractRequirementRepo)
        {
            _mectRequirementRepository = contractRequirementRepo;
        }

        // PATCH: api/ContractRequirement
        [HttpPatch]
        public void Patch(MectRequirement entity)
        {
            _mectRequirementRepository.InsertAsync(entity);
        }

        // POST: api/ContractRequirement
        [HttpPost]
        public void Post(MectRequirement entity)
        {
            _mectRequirementRepository.InsertAsync(entity);
        }
    }
}