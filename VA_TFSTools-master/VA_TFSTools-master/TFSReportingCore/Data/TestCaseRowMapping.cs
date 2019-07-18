using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSReporting.Data
{
    public class TestCaseRowMapping
    {
        public int TestCaseId { get; set; }

        public int RowNumber { get; set; }

        public string TestCaseName { get; set; }

        public int TestSuiteId { get; set; }

        public override string ToString()
        {
            return "TestCaseId: " + TestCaseId + " \t RowNumber: " + RowNumber + " \t TestCaseName: " + TestCaseName + " \t TestSuiteId: " + TestSuiteId;
        }
    }
}
