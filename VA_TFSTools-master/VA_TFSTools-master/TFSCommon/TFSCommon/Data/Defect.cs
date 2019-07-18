using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSCommon.Data
{
    public class Defect
    {
        public Defect() { }

        [ExplicitKey]
        public int DefectId { get; set; }

        public string DefectName { get; set; }

        public string DefectSeverity { get; set; }

        public string DefectHistory { get; set; }

        public string DefectType { get; set; }

        public string Status { get; set; }

        public string AssignedTo { get; set; }

        public DateTime DefectCreateDate { get; set; }

        public string DefectCreatedBy { get; set; }

        public DateTime DiscussionDate { get; set; }

        public string Iteration { get; set; }

        public List<TestCase> TestCases { get; set; }

        public List<DefectHistory> DefectHistories { get; set; }

        public string TfsVersion { get; set; }

        public string ApplicationArea { get; set; }

        public string ApplicationProcess { get; set; }

        public string FoundInEnvironment { get; set; }
    }

    public class DefectHistory
    {
        public DefectHistory() { }

        [Key]
        public int DefectHistoryId { get; set; }

        public int DefectId { get; set; }

        public DateTime Timestamp { get; set; }

        public string History { get; set; }
    }

    public class DefectRevisionHistory
    {
        public DefectRevisionHistory() { }

        [Key]
        public int DefectRevisionHistoryId { get; set; }

        public int Revision { get; set; }

        public DateTime DateRevised { get; set; }

        public string RevisedBy { get; set; }

        public string Reason { get; set; }

        public string State { get; set; }
    }
}
