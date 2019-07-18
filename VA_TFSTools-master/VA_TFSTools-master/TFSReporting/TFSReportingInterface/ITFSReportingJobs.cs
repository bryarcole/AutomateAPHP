using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
using Hangfire;

namespace TFSReportingInterface
{
    public interface ITFSReportingJobs
    {
        [Queue("TFS_Reporting")]
        void UpdateExcelTestCaseId(Properties props);

        [Queue("TFS_Reporting")]
        void GatherTestRunAndResultsAndWriteToDb(Properties props);

        [Queue("TFS_Reporting")]
        void UpdateExcelDailyDefect(string startDate, string endDate, Properties props);

        [Queue("TFS_Reporting")]
        void UpdateExcelExecutionInputData(Properties props);
    }
}
