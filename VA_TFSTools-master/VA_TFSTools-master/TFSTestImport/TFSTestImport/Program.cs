using System;
using TFSTestImport.ExcelTools;
using TFSTestImport.TFSTools;
using System.Collections.Generic;
using TFSCommon.Common;
using TFSCommon.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using TFSCommon.Network;
using TFSCommon.XMLTools;

namespace TFSTestImport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string fileLocation = "C:\\Users\\cody.hui\\Desktop\\APHP - Test Case Template.xlsx";
            Console.Write("Enter File Location then press Enter (ex: C:\\Users\\test.user\\Desktop): ");
            string fileLocation = StringTools.FixFileString(Console.ReadLine());
            Console.Write("Enter File Name then press Enter (ex: APHP Virginia - Test Case Template): ");
            string fileName = Console.ReadLine();

            ExcelTooling excelTooling = new ExcelTooling(fileLocation, fileName);

            Properties properties = new Properties();
            List<TestCase> testCases = new List<TestCase>();

            try
            {
                //Dictionary<string, string> props = excelExtractor.GetProps();
                properties.Logger = new Logger(fileLocation);
                properties = excelTooling.GetProps(properties);

                testCases = excelTooling.GetTestCases();

                excelTooling.ExcelCleanup();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Please validate the Sheet name.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            //string server = props["Server"];
            //string pat = props["Personal Access Token"];
            //string project = props["Project"];
            //int testPlan = Convert.ToInt32(props["Test Plan ID"]);
            //int testSuite = Convert.ToInt32(props["Test Suite ID"]);

            //Properties properties = new Properties();
            //properties.Uri = server;
            //properties.PersonalAccessToken = pat;
            //properties.Project = project;
            //properties.TestPlanId = testPlan;
            //properties.TestSuiteId = testSuite;

            CreateTestCase testCaseCreator = new CreateTestCase(properties);
            List<TestCase> testCasesCreated = testCaseCreator.TestCaseCreation(testCases);

            LinkTestCaseToRtm linkTestCaseToRtm = new LinkTestCaseToRtm(properties);
            List<TestCase> linkedTestCases = linkTestCaseToRtm.LinkListOfTestCaseToRtm(testCases).Result;

            //excelTooling.UpdateTestCaseId(testCasesCreated);
            //excelTooling.ExcelCleanup();

            Console.WriteLine("{0} out of {1} Test Cases have been created", testCasesCreated.Count, testCases.Count);

            //UpdateTestSteps updateTestSteps = new UpdateTestSteps(properties);
            //updateTestSteps.UpdateTestStepsForTestCaseList(testCases);

            Console.Write("Please press Enter to complete.");
            Console.ReadLine();
        }
    }
}

