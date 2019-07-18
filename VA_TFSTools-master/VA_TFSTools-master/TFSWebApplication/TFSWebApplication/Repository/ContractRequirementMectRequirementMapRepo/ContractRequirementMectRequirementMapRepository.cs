using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data.Mappings;

namespace TFSWebApplication.Repository.ContractRequirementMectRequirementMapRepo
{
    public class ContractRequirementMectRequirementMapRepository : SqlRepository<ContractRequirementMectRequirementMap>, IContractRequirementMectRequirementMapRepository
    {
        public ContractRequirementMectRequirementMapRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ContractRequirementMectRequirementMap>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<ContractRequirementMectRequirementMap> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(ContractRequirementMectRequirementMap entity)
        {
            string sql = @"INSERT OR REPLACE INTO MP_ContractRequirementMectRequirementMap AS ContractRequirementMectRequirementMap
                            (ParentContractRequirementId, ChildContractRequirementId)
                            VALUES
                            (@ParentContractRequirementId, @ChildContractRequirementId)";
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, entity);
            }
        }

        public override void UpdateAsync(ContractRequirementMectRequirementMap entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
