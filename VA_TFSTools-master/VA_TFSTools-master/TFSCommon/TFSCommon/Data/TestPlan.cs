using System.Collections.Generic;

namespace TFSCommon.Data
{
    public class TestPlan
    {
        public string TestPlanName { get; set; }

        public string TestPlanId { get; set; }

        public ICollection<TestSuite> TestSuites { get; set; }
    }
}
