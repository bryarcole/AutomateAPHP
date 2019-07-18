using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
using Hangfire;

namespace TFSReporting
{
    public interface ITFSReportingJobs
    {
        /// <summary>
        /// Update Execution Input Sheet test case IDs if they do not exist
        /// </summary>
        void UpdateExcelTestCaseId();

        /// <summary>
        /// Get test runs from TFS and write to external database. 
        /// </summary>
        void GatherTestRunAndResultsAndWriteToDb();

        /// <summary>
        /// Update the Excel Daily Test Case runs between ranges
        /// </summary>
        /// <param name="startDate">First date where you want to start pulling results</param>
        /// <param name="endDate">Last date where you want to pull results</param>
        void UpdateExcelDailyTestCaseRun(string startDate, string endDate);

        /// <summary>
        /// Update Test Case Execution sheet with new defects in TFS that are not on the sheet yet. 
        /// </summary>
        void UpdateExcelExecutionInputData();

        /// <summary>
        /// Updates the Daily Execution Status with the number of scripts executed per folder/category execution 
        /// </summary>
        void UpdateExcelDailyExecutionStatus();

        /// <summary>
        /// Updates the Failed with Minor Defects column in the Folder Counts tab. 
        /// </summary>
        void UpdateExcelFolderCounts();

        /// <summary>
        /// Update the report for Defects and the number of linked test cases. 
        /// Also updates the Test Case With Defects sheet. Shows all Test Cases that are associated to a defect. 
        /// </summary>
        void UpdateExcelDefectWithTestCaseCount();

        /// <summary>
        /// Update the 2 Ready for Test sheets for different Severities
        /// </summary>
        void UpdateTestCasesReadyForTest();
    }
}
