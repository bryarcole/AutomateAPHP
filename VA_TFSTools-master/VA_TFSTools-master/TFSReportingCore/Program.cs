using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;

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

            ITFSReportingJobs reportingJobs = new TFSReportingJobs();

            //// If there is no Case ID for a Test Case on the Execution Input Data Sheet, 
            //// then we will update the Test Case ID for that row (needs both Test Case Name and Test Suite ID)
            //reportingJobs.UpdateExcelTestCaseId(props);

            ////Gathers the 200 most recent Test Runs under the Test Plan ID and writes them to the DB
            //reportingJobs.GatherTestRunAndResultsAndWriteToDb(props);

            //// If the system sees that there are Test Cases in TFS for a certain iteration but it is not in the sheet, 
            //// then we will add a row onto the spreadsheet for that single case. 
            //// NOTE: It is possible to have duplicate Test Cases here if we have Test Cases without a Test Suite ID that 
            //// match to a Test Case in TFS
            //reportingJobs.UpdateExcelExecutionInputData(props);

            // Update the Execution Actuals and Execution Input Data with the Test Results from the DB. 
            reportingJobs.UpdateExcelDailyDefect(inputtedStartDateTime, inputtedEndDateTime, props);

            Console.WriteLine("All Tasks have finished...");
            Console.ReadLine();
        }
    }
}
