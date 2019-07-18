using System;

namespace TFSCommon.Data
{
    public class TestCaseResult
    {
        public TestCaseResult()
        {

        }

        public TestCaseResult(int testCaseId, string result, DateTime dateTime)
        {
            TestCaseId = TestCaseId;
            Result = result;
            ResultDT = dateTime;
        }

        public int TestCaseResultId { get; set; }

        public int TestRunId { get; set; }

        public int TestCaseId { get; set; }

        public string Result { get; set; }

        public string RunByName { get; set; }

        public DateTime ResultDT { get; set; }
    }
}
