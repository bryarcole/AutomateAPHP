using Dapper.Contrib.Extensions;

namespace TFSCommon.Data
{
    public class MectRequirement
    {
        public MectRequirement() { }

        public MectRequirement(int id, string name)
        {
            MectRequirementId = id;
            MectName = name;
        }

        [ExplicitKey]
        public int MectRequirementId { get; set; }

        public string MectTitle { get; set; }

        public string Description { get; set; }

        public string MectName { get; set; }

        public string MectCriteria { get; set; }

        public string MectSource { get; set; }

        public string Scope { get; set; }
    }
}
