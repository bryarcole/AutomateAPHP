using Dapper.Contrib.Extensions;

namespace TFSCommon.Data.Mappings
{
    public class ContractRequirementTaskMap
    {
        [Key]
        public int ContractRequirementTaskId { get; set; }

        public int ContractRequirementId { get; set; }

        public int TaskId { get; set; }
    }
}
