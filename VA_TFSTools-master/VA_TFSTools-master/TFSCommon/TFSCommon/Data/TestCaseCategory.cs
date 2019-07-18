using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSCommon.Data
{
    public class TestCaseCategory
    {
        public TestCaseCategory() {
            TestCasePaths = new List<String>();
            DailyCumulativeActualExecuted = new Dictionary<DateTime, int>();
            DailyCumulativeActualPassed = new Dictionary<DateTime, int>();
        }

        public string Category { get; set; }

        public List<String> TestCasePaths { get; set; }

        public int SheetColumn { get; set; }

        public int CumulativeActualExecuted { get; set; }

        public int CumulativeActualPassed { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Dictionary<DateTime, int> DailyCumulativeActualExecuted { get; set; }

        public Dictionary<DateTime, int> DailyCumulativeActualPassed { get; set; }
    }


}
