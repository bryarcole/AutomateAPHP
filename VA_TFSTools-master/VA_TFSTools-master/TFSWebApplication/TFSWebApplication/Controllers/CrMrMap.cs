using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFSCommon.Data.Mappings;
using TFSWebApplication.Repository.ContractRequirementMectRequirementMapRepo;

namespace TFSWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrMrMap : ControllerBase
    {
        private IContractRequirementMectRequirementMapRepository _mappingRepository;

        public CrMrMap(IContractRequirementMectRequirementMapRepository contractRequirementRepo)
        {
            _mappingRepository = contractRequirementRepo;
        }

        // PATCH: api/ContractRequirement
        [HttpPatch]
        public void Patch(ContractRequirementMectRequirementMap entity)
        {
            _mappingRepository.InsertAsync(entity);
        }

        // PATCH: api/ContractRequirement
        [HttpPost]
        public void Post(ContractRequirementMectRequirementMap entity)
        {
            _mappingRepository.InsertAsync(entity);
        }
    }
}