using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSCommon.Data.Mappings;
using TFSWebApplication.Repository.MectRequirementRepo;
using TFSWebApplication.Repository.TaskRepo;

namespace TFSWebApplication.Repository.ContractRequirementRepo
{
    public class ContractRequirementRepository : SqlRepository<ContractRequirement>, IContractRequirementRepository
    {
        private string _connectionString;
        public ContractRequirementRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public override void DeleteAsync(int id)
        {
            string sql = @"DELETE FROM TFS_ContractRequirement WHERE ContractRequirementId = @id";
            string deleteFromContractRequirementSql = @"DELETE FROM MP_ContractRequirementMectRequirementMap WHERE ParentContractRequirementId = @id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, parameters);
                conn.Execute(deleteFromContractRequirementSql, parameters);
            }
        }

        public async override Task<IEnumerable<ContractRequirement>> GetAllAsync()
        {
            var sql = @"SELECT ContractRequirement.ContractRequirementId AS RequirementId,
ContractRequirement.RequirementTitle,
ContractRequirement.State,
ContractRequirement.PrimaryArea,
ContractRequirement.ProposedLanguage,
ContractRequirement.Priority,
ContractRequirement.Description,
ContractRequirement.AssignedTo,
ContractRequirement.Validated,
ContractRequirement.DeScopeDetails,
ContractRequirement.ValidationActionItem,
ContractRequirement.ValidationActionItemStatus,
ContractRequirement.ValidationAssumptions,
ContractRequirement.Deliverable,
ContractRequirement.CoveredInCrp,
ContractRequirement.CrpSession,
ContractRequirement.SolutionUnderstanding,
ContractRequirement.ProductDsd,
ContractRequirement.VendorIntegration,
ContractRequirement.Coverage,
MectRequirement.MectRequirementId,
MectRequirement.MectTitle,
MectRequirement.Description,
MectRequirement.MectName,
MectRequirement.MectCriteria,
MectRequirement.MectSource,
MectRequirement.Scope
FROM TFS_ContractRequirement AS ContractRequirement
LEFT JOIN MP_ContractRequirementMectRequirementMap ON ContractRequirement.ContractRequirementId = MP_ContractRequirementMectRequirementMap.ParentContractRequirementId
LEFT JOIN TFS_MectRequirement AS MectRequirement ON MP_ContractRequirementMectRequirementMap.ChildContractRequirementId = MectRequirement.MectRequirementId";

            Dictionary<int, ContractRequirement> res = await GetAsyncHelper(sql);
            return res.Values.ToList<ContractRequirement>();
        }

        public async override Task<ContractRequirement> GetAsync(int id)
        {
            var sql = @"SELECT ContractRequirement.ContractRequirementId AS RequirementId,
ContractRequirement.RequirementTitle,
ContractRequirement.State,
ContractRequirement.PrimaryArea,
ContractRequirement.ProposedLanguage,
ContractRequirement.Priority,
ContractRequirement.Description,
ContractRequirement.AssignedTo,
ContractRequirement.Validated,
ContractRequirement.DeScopeDetails,
ContractRequirement.ValidationActionItem,
ContractRequirement.ValidationActionItemStatus,
ContractRequirement.ValidationAssumptions,
ContractRequirement.Deliverable,
ContractRequirement.CoveredInCrp,
ContractRequirement.CrpSession,
ContractRequirement.SolutionUnderstanding,
ContractRequirement.ProductDsd,
ContractRequirement.VendorIntegration,
ContractRequirement.Coverage,
MectRequirement.MectRequirementId,
MectRequirement.MectTitle,
MectRequirement.Description,
MectRequirement.MectName,
MectRequirement.MectCriteria,
MectRequirement.MectSource,
MectRequirement.Scope
FROM TFS_ContractRequirement AS ContractRequirement
LEFT JOIN MP_ContractRequirementMectRequirementMap ON ContractRequirement.ContractRequirementId = MP_ContractRequirementMectRequirementMap.ParentContractRequirementId
LEFT JOIN TFS_MectRequirement AS MectRequirement ON MP_ContractRequirementMectRequirementMap.ChildContractRequirementId = MectRequirement.MectRequirementId
WHERE ContractRequirement.ContractRequirementId = @id";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            Dictionary<int, ContractRequirement> res = await GetAsyncHelper(sql, parameters);
            return res.Values.FirstOrDefault<ContractRequirement>();
        }

        private async Task<Dictionary<int, ContractRequirement>> GetAsyncHelper(string sql, DynamicParameters parameters = null)
        {
            using (var conn = GetOpenConnection())
            {
                var contractRequirementDictionary = new Dictionary<int, ContractRequirement>();

                var mectRequirementDictionary = new Dictionary<int, List<int>>();

                await conn.QueryAsync<ContractRequirement, MectRequirement, ContractRequirement>(
                        sql,
                        (contractRequirement, mectRequirement) =>
                        {
                            ContractRequirement contractRequirementEntry;

                            if (!contractRequirementDictionary.TryGetValue(contractRequirement.RequirementID, out contractRequirementEntry))
                            {
                                contractRequirementEntry = contractRequirement;
                                if (mectRequirement != null && mectRequirement.MectRequirementId != 0)
                                {
                                    contractRequirementEntry.RelatedMectRequirement = new List<MectRequirement>();
                                    mectRequirementDictionary.Add(contractRequirement.RequirementID, new List<int>());
                                }

                                contractRequirementDictionary.Add(contractRequirement.RequirementID, contractRequirement);
                            }

                            var requirementId = contractRequirement.RequirementID;

                            if (mectRequirementDictionary.ContainsKey(requirementId)
                                    && !mectRequirementDictionary[requirementId].Contains(mectRequirement.MectRequirementId))
                            {
                                contractRequirementEntry.RelatedMectRequirement.Add(mectRequirement);
                                mectRequirementDictionary[requirementId].Add(mectRequirement.MectRequirementId);
                            }

                            return contractRequirementEntry;
                        },
                        parameters,
                        splitOn: "MectRequirementId"
                    );

                return contractRequirementDictionary;
            }
        }

        public override void InsertAsync(ContractRequirement entity)
        {
            string sql = @"INSERT OR REPLACE INTO TFS_ContractRequirement AS ContractRequirement 
(ContractRequirementId, RequirementTitle, ProposedLanguage, Priority, Description, AssignedTo, State,
Validated, DeScopeDetails, ValidationActionItem, ValidationActionItemStatus, ValidationAssumptions,
Deliverable, CoveredInCrp, CrpSession, SolutionUnderstanding, ProductDsd, VendorIntegration, Coverage,
PrimaryArea)
VALUES 
(@RequirementId, @RequirementTitle, @ProposedLanguage, @Priority, @Description, @AssignedTo, @State,
@Validated, @DeScopeDetails, @ValidationActionItem, @ValidationActionItemStatus, @ValidationAssumptions,
@Deliverable, @CoveredInCrp, @CrpSession, @SolutionUnderstanding, @ProductDsd, @VendorIntegration, @Coverage,
@PrimaryArea)";

            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, entity);
            }

            IMectRequirementRepository mectRequirementRepository = new MectRequirementRepository(_connectionString);

            if (entity.RelatedMectRequirement != null)
            {
                foreach (MectRequirement subRequirement in entity.RelatedMectRequirement)
                {
                    ContractRequirementMectRequirementMap map = new ContractRequirementMectRequirementMap();
                    map.ParentContractRequirementId = entity.RequirementID;
                    map.ChildContractRequirementId = subRequirement.MectRequirementId;

                    InsertContractRequirementMectRequirementMapping(map);

                    mectRequirementRepository.InsertAsync(subRequirement);
                    //InsertMectRequirementAsync(subRequirement);
                }
            }

            //TaskRepository taskRepository = new TaskRepository(_connectionString);

            //foreach (TFSCommon.Data.Task subTask in entity.RelatedTasks)
            //{
            //    ContractRequirementTaskMap map = new ContractRequirementTaskMap();
            //    map.ContractRequirementId = entity.RequirementID;
            //    map.TaskId = subTask.TaskId;

            //    InsertContractRequirementTaskMapping(map);

            //    taskRepository.InsertAsync(subTask);
            //}
        }

        //private Boolean CheckIfContractRequirementExists(int id)
        //{
        //    string sql = @"SELECT COUNT(*) FROM TFS_ContractRequirement AS ContractRequirement WHERE RequirementId = @id";
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@id", id);

        //    using (var conn = GetOpenConnection())
        //    {
        //        int countContractRequirements = conn.ExecuteScalar<int>(sql, parameters);
        //        if (countContractRequirements > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        private void InsertMectRequirementAsync(MectRequirement entity)
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

        private void InsertContractRequirementMectRequirementMapping(ContractRequirementMectRequirementMap map)
        {
            string sql = @"INSERT OR REPLACE INTO MP_ContractRequirementMectRequirementMap AS ContractRequirementMectRequirementMap
                            (ParentContractRequirementId, ChildContractRequirementId)
                            VALUES
                            (@ParentContractRequirementId, @ChildContractRequirementId)";
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, map);
            }
        }

        private void InsertContractRequirementTaskMapping(ContractRequirementTaskMap map)
        {
            string sql = @"INSERT OR REPLACE INTO TFS_ContractRequirementTaskMap AS ContractRequirementTaskMap
                            (ContractRequirementId, TaskId)
                            VALUES
                            (@ContractRequirementId, @TaskId)";
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, map);
            }
        }

        public override void UpdateAsync(ContractRequirement entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
