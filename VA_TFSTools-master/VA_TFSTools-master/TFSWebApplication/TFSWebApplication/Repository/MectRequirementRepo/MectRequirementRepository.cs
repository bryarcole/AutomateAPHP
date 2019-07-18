using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSWebApplication.Repository.MectRequirementRepo
{
    public class MectRequirementRepository : SqlRepository<MectRequirement>, IMectRequirementRepository
    {
        public MectRequirementRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<MectRequirement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<MectRequirement> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(MectRequirement entity)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_MectRequirement AS MectRequirement
(MectRequirementId, MectTitle, Description, MectName, MectCriteria, MectSource, Scope)
VALUES
(@MectRequirementId, @MectTitle, @Description, @MectName, @MectCriteria, @MectSource, @Scope)";

            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, entity);
            }
        }

        public override void UpdateAsync(MectRequirement entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
