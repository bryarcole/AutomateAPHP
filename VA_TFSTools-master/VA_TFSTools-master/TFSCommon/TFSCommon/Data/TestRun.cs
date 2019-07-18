using System.Collections.Generic;

namespace TFSCommon.Data
{
    public class TestRun
    {
        public int TestRunId { get; set; }

        public string TestRunName { get; set; }

        public int? PassedTests { get; set; }

        public int? IncompleteTests { get; set; }

        public int? NotApplicableTests { get; set; }

        public int? UnanalyzedTests { get; set; }

        public string State { get; set; }

        public int? TotalTests { get; set; }

        //// This should be the Test Run ID api call. 
        //public Uri Url { get; set; }

        public string LastUpdatedBy { get; set; }

        public string LastUpdatedDate { get; set; }

        public string Owner { get; set; }

        public int? TestPlanId { get; set; }

        public int? TestSuiteId { get; set; }

        private int TestCaseId { get; set; }

        public ICollection<TestCaseResult> TestCaseResults { get; set; }
    }
}
