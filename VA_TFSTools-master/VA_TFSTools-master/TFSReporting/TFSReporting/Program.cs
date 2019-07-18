using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSReporting.TFSTools;
using TFSReporting.ExcelTools;
using System.IO;
using TFSReporting.Data;
using TFSCommon.Network;
using System.Net.Http;
using Newtonsoft.Json;

namespace TFSReporting
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pat = "7wwgihgjbgchepkpvn4adotkd7bmt3ewtwsr7u4grny7yisrwe3a";
            //string server = "http://10.3.28.4/";
            //string project = "APHP Virginia";
            string saveLocation = "C:\\Users\\cody.hui\\Desktop\\";
            string fileName = "Test Status Report_Metrics_07MAY19";
            string fileNameWithExtension = StringTools.addExtension(fileName, "xlsx");
            //string testExecutionSheetName = "Test Execution";
            //string testScriptSheetName = "Test Script";
            //string inputtedStartDateTime = "4/1/2019";
            //string inputtedEndDateTime = "5/6/2019";
            //int testplan = 142838;
            //int testsuite = 149850;

            PropertiesReader config = new PropertiesReader("config.txt");

            Logger logger = new Logger(config.get("saveLocation"));

            Properties props = new Properties();
            props.Logger = logger;
            props.PersonalAccessToken = config.get("personalaccesstoken"); 
            props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
            props.Project = config.get("project");
            props.Uri = config.get("server");
            props.SaveLocation = config.get("saveLocation");
            props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx");
            props.ExecutionSheetName = config.get("executionsheetname");
            props.ScriptSheetName = config.get("scriptsheetname");
            props.UseWebApi = Convert.ToInt32(config.get("usewebapi"));
            props.NumberOfTestRun = Convert.ToInt32(config.get("numberoftestruns"));
            props.FolderCountsSheetName = config.get("folderCountsSheetName");
            props.TfsDefectsSheetName = config.get("tfsDefectsSheetName");
            props.TfsTestCaseWithDefectSheetName = config.get("tfsTestCaseWithDefectSheetName");
            props.TfsDefectsProposedSheetName = config.get("tfsDefectsProposedSheetName");
            props.ReadyForTestCriticalHighSheetName = config.get("readyForTestCritialHighSheetName");
            props.ReadyForTestMediumLowSheetName = config.get("readyForTestMediumLowSheetName");
            props.StartDate = DateTime.Parse(config.get("startdate"));
            props.EndDate = DateTime.Parse(config.get("enddate"));

            string inputtedStartDateTime = config.get("startdate");
            string inputtedEndDateTime = config.get("enddate");

            //if (!System.Diagnostics.Debugger.IsAttached)
            //{
            //    Console.Write("Enter file path: ");
            //    saveLocation = Console.ReadLine();

            //    Console.Write("Enter file name: ");
            //    fileName = Console.ReadLine();
            //    fileNameWithExtension = stringTool.addExtension(fileName, "xlsx");

            //    Console.Write("Enter Start Date: ");
            //    inputtedStartDateTime = Console.ReadLine();

            //    Console.Write("Enter End Date: ");
            //    inputtedEndDateTime = Console.ReadLine();
            //}

            ITFSReportingJobs reportingJobs = new TFSReportingJobs(props);

            //// If there is no Case ID for a Test Case on the Execution Input Data bSheet, 
            //// then we will update the Test Case ID for that row (needs both Test Case Name and Test Suite ID)
            //reportingJobs.UpdateExcelTestCaseId(props);

            //Gathers the 200 most recent Test Runs under the Test Plan ID and writes them to the DB
            // --> TFSTools
            // --> WebAPITools (not required)
            // --> ExcelTools
            if (config.get("GatherTestRunAndResultsAndWriteToDb") == "1")
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Starting GatherTestRunAndResultsAndWriteToDb");
                reportingJobs.GatherTestRunAndResultsAndWriteToDb();
                Console.WriteLine("Finished GatherTestRunAndResultsAndWriteToDb");
                Console.WriteLine("--------------------------------------------");
            }

            // If the system sees that there are Test Cases in TFS for a certain iteration but it is not in the sheet, 
            // then we will add a row onto the spreadsheet for that single case. 
            // NOTE: It is possible to have duplicate Test Cases here if we have Test Cases without a Test Suite ID that 
            // match to a Test Case in TFS
            // --> TFSTools
            // --> WebAPITools (not required)
            // --> ExcelTools
            if (config.get("UpdateExcelExecutionInputData") == "1")
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Starting UpdateExcelExecutionInputData");
                reportingJobs.UpdateExcelExecutionInputData();
                Console.WriteLine("Finished UpdateExcelExecutionInputData");
                Console.WriteLine("--------------------------------------------");
            }

            // Update the Execution Actuals and Execution Input Data with the Test Results from the DB. 
            // --> TFSTools
            // --> WebAPITools (not required)
            // --> ExcelTools
            if (config.get("UpdateExcelDailyTestCaseRun") == "1")
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Starting UpdateExcelDailyTestCaseRun");
                reportingJobs.UpdateExcelDailyTestCaseRun(inputtedStartDateTime, inputtedEndDateTime);
                Console.WriteLine("Finished UpdateExcelDailyTestCaseRun");
                Console.WriteLine("--------------------------------------------");
            }

            // Update the Daily Execution Status for the Overall and Daily Iteration status
            // --> WebAPITools
            // --> ExcelTools
            if (config.get("UpdateExcelDailyExecutionStatus") == "1")
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Starting UpdateExcelDailyExecutionStatus");
                reportingJobs.UpdateExcelDailyExecutionStatus();
                Console.WriteLine("Finished UpdateExcelDailyExecutionStatus");
                Console.WriteLine("--------------------------------------------");
            }

            // Update both the Defects With Test Case count as well as the Test Cases linked with Defect sheets.
            // --> TFSTools
            // --> WebAPITools (not required)
            // --> ExcelTools
            if (config.get("UpdateExcelDefectWithTestCaseCount") == "1")
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Starting UpdateExcelDefectWithTestCaseCount");
                reportingJobs.UpdateExcelDefectWithTestCaseCount();
                Console.WriteLine("Finished UpdateExcelDefectWithTestCaseCount");
                Console.WriteLine("--------------------------------------------");
            }

            // Update both of the Ready for Test Test Cases for Critical/High and Medium/Low defects.
            // --> WebAPITools
            // --> ExcelTools
            if (config.get("UpdateTestCasesReadyForTest") == "1")
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Starting UpdateTestCasesReadyForTest");
                reportingJobs.UpdateTestCasesReadyForTest();
                Console.WriteLine("Finished UpdateTestCasesReadyForTest");
                Console.WriteLine("--------------------------------------------");
            }

            // Update the Folder Counts sheet with the Failed with Minor Defects count
            // --> WebAPITools
            // --> ExcelTools
            if (config.get("UpdateExcelFolderCounts") == "1")
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Starting UpdateExcelFolderCounts");
                reportingJobs.UpdateExcelFolderCounts();
                Console.WriteLine("Finished UpdateExcelFolderCounts");
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine("All Tasks have finished...");
            Console.ReadLine();
        }
    }
}
