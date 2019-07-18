using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSTestCaseAttachments.Data
{
    class TestSuite
    {
        public TestSuite(int suiteId, string suiteName, List<string> path)
        {
            this.SuiteId = suiteId;
            this.SuiteName = suiteName;
            this.Path = path;
        }

        public int SuiteId { set; get; }

        public string SuiteName { set; get; }

        public List<string> Path { get; set; }
    }
}
