using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace TFSCommon.Data
{
    public class ContractRequirement
    {
        public ContractRequirement()
        {
            //RelatedMectRequirement = new List<RelatedMectRequirement>();
            //RelatedTasks = new List<Task>();
        }

        public ContractRequirement(int id, string title)
        {
            RequirementID = id;
            RequirementTitle = title;
        }

        [ExplicitKey]
        public int RequirementID { get; set; }

        public string RequirementTitle { get; set; }

        public string State { get; set; }

        public string PrimaryArea { get; set; }

        public string ProposedLanguage { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public string AssignedTo { get; set; }

        public List<MectRequirement> RelatedMectRequirement { get; set; }

        public List<Task> RelatedTasks { get; set; }

        public string Validated { get; set; }

        public string DeScopeDetails { get; set; }

        public string ValidationActionItem { get; set; }

        public string ValidationActionItemStatus { get; set; }

        public string ValidationAssumptions { get; set; }

        public string Deliverable { get; set; }

        public string CoveredInCrp { get; set; }

        public List<CrpSession> CrpSession { get; set; }

        public string SolutionUnderstanding { get; set; }

        public List<Playbook> Playbooks { get; set; }

        public List<WorkPackage> WorkPackages { get; set; }

        public List<ProductDsd> ProductDSD { get; set; }

        public string VendorIntegration { get; set; }

        public string Coverage { get; set; }
    }

    public class Playbook
    {
        [Key]
        public int PlaybookId { get; set; }

        public string PlaybookName { get; set; }
    }

    public class WorkPackage
    {
        [Key]
        public int WorkPackageId { get; set; }

        public string WorkPackageName { get; set; }
    }

    public class CrpSession
    {
        [Key]
        public int CrpSessionId { get; set; }

        public string CrpSessionName { get; set; }

        public string CrpSessionDescription { get; set; }
    }

    public class ProductDsd
    {
        [Key]
        public int ProductDsdId { get; set; }

        public string ProductDsdName { get; set; }
    }
}
