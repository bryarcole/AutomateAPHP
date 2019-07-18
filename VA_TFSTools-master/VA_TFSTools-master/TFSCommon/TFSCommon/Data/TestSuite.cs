using System.Collections.Generic;

namespace TFSCommon.Data
{
    public class TestSuite
    {
        public TestSuite()
        {
            TestCases = new List<TestCase>();
            SubTestSuite = new List<TestSuite>();
        }

        public TestSuite(int suiteId, string suiteName, List<string> path)
        {
            this.TestSuiteId = suiteId;
            this.TestSuiteName = suiteName;
            this.TestPath = path;
            TestCases = new List<TestCase>();
            SubTestSuite = new List<TestSuite>();
        }

        public int TestSuiteId { set; get; }

        public string TestSuiteName { set; get; }

        public ICollection<string> TestPath { get; set; }

        public ICollection<TestSuite> SubTestSuite { get; set; }

        public ICollection<TestCase> TestCases { get; set; }

        public void AddTestCase(TestCase testCase)
        {
            TestCases.Add(testCase);
        }
    }
}
