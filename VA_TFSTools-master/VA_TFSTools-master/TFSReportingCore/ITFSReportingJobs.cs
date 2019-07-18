using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSReporting
{
    public interface ITFSReportingJobs
    {
        void UpdateExcelTestCaseId(Properties props);

        void GatherTestRunAndResultsAndWriteToDb(Properties props);

        void UpdateExcelDailyDefect(string startDate, string endDate, Properties props);

        void UpdateExcelExecutionInputData(Properties props);
    }
}
