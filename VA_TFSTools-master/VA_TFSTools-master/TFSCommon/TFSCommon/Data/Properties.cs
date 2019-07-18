using System;
using TFSCommon.Common;

namespace TFSCommon.Data
{
    public class Properties
    {
        public string PersonalAccessToken { get; set; }

        public string Uri { get; set; }

        public string Project { get; set; }

        public int TestPlanId { get; set; }

        public int TestSuiteId { get; set; }

        public string SaveLocation { get; set; }

        public string FileName { get; set; }

        public string BasePath { get; set; }

        public string LogFileName { get; set; }

        public string ExecutionSheetName { get; set; }

        public string ScriptSheetName { get; set; }

        public string TfsDefectsSheetName { get; set; }

        public string TfsTestCaseWithDefectSheetName { get; set; }

        public string TfsDefectsProposedSheetName { get; set; }

        public string FolderCountsSheetName { get; set; }

        public string IterationDailyMappingSheetName { get; set; }

        public string ReadyForTestCriticalHighSheetName { get; set; }

        public string ReadyForTestMediumLowSheetName { get; set; }

        public Logger Logger { get; set; }

        public int Iteration { get; set; }

        public int UseWebApi { get; set; }

        public int NumberOfTestRun { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
