using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Tests1.Utilities;
using OpenQA.Selenium.Chrome;
using TFSCommon.Common;
using TFSCommon.Data;
using Xceed.Words.NET;
using System.Drawing;
using RequirementsTraceability;

namespace NUnit.Tests1.Utilities
{
    public class WordDocGen
    {
        public void CreateWordDocSuite(string userName, int planID, int suiteID)
        {
            
            #region Boring stuff
            // Test Case Pull
            #region Pull Test Case from TFS
            PropertiesReader config = new PropertiesReader("config.txt");

            Properties props = new Properties();
            props.PersonalAccessToken = config.get("personalaccesstoken");
            props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
            props.Project = config.get("project");
            props.Uri = config.get("server");
            props.SaveLocation = config.get("saveLocation");
            props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
            props.ExecutionSheetName = config.get("executionsheetname");
            props.ScriptSheetName = config.get("scriptsheetname");
            props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

            Logger logger = new Logger(props.SaveLocation);

            props.Logger = logger;
            #endregion

            Color royalBlue = Color.FromName("RoyalBlue");
            Color white = Color.FromName("White");
            RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);
            string location = "C:\\Users\\" + userName + "\\Desktop\\Evidence Docs for Suite " + suiteID;
            System.IO.Directory.CreateDirectory(location);

            List<TestCase> cases = new List<TestCase>();
            cases = requirementsTraceabilityJob.GetTestCaseGivenPlanSuite(planID, suiteID);

            foreach (TestCase testCase in cases)
            {
                string testName = testCase.TestCaseId.ToString() + "_" + testCase.TestCaseName.Replace(" ", "_").Replace(")", "_").Replace("(", "_").Replace("/", "_").Replace("\\", "_").Replace(" - ", "_").Replace("\"", "_").Replace("'", "_");
                DocX doc = DocX.Create(testName);
                var columnWidths = new float[] { 225f, 225f, 225f };
                Table testSummary = doc.AddTable(2, 3);
                //Test Objective table

                doc.InsertParagraph("Test Objective").FontSize(16);
                testSummary.Rows[0].Cells[0].Paragraphs.First().Append("#").Color(white);
                testSummary.Rows[0].Cells[1].Paragraphs.First().Append("Title").Color(white);
                testSummary.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective").Color(white);
                testSummary.Rows[0].Cells[0].FillColor = royalBlue;
                testSummary.Rows[0].Cells[1].FillColor = royalBlue;
                testSummary.Rows[0].Cells[2].FillColor = royalBlue;

                testSummary.Rows[1].Cells[0].Paragraphs.First().Append(testCase.TestCaseId.ToString());
                testSummary.Rows[1].Cells[1].Paragraphs.First().Append(testCase.TestDescription);
                testSummary.Rows[1].Cells[2].Paragraphs.First().Append(testCase.TestObjective);
                testSummary.SetWidths(columnWidths);
                doc.InsertTable(testSummary);


                doc.InsertParagraph("Steps to follow").FontSize(16);
                Table testActionResult = doc.AddTable(testCase.TestSteps.Count + 1, 3);
                testActionResult.SetWidths(columnWidths);
                testActionResult.Rows[0].Cells[0].Paragraphs.First().Append("Steps").Color(white);
                testActionResult.Rows[0].Cells[1].Paragraphs.First().Append("Action").Color(white);
                testActionResult.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result").Color(white);
                testActionResult.Rows[0].Cells[0].FillColor = royalBlue;
                testActionResult.Rows[0].Cells[1].FillColor = royalBlue;
                testActionResult.Rows[0].Cells[2].FillColor = royalBlue;
                Console.WriteLine(testName);
                int i = 0;
                Console.WriteLine("Test Case Count " + testCase.TestSteps.Count);
                foreach (TestStep testStep in testCase.TestSteps)
                {

                    i++;
                    string action = Utility.RemoveTags(testStep.Action);
                    string expected = Utility.RemoveTags(testStep.Expected);
                    Console.WriteLine("Test Step " + i);

                    testActionResult.Rows[i].Cells[0].Paragraphs[0].Append(testStep.StepNumber.ToString());
                    testActionResult.Rows[i].Cells[1].Paragraphs.First().Append(action);
                    testActionResult.Rows[i].Cells[2].Paragraphs.First().Append(expected);


                }

                doc.InsertTable(testActionResult);
                doc.SaveAs(location + "//" + testName + ".docx");
            };
            #endregion
        }

        public DocX CreateWordDoc( int testCaseId,int suiteID)
        {

            #region Pull Test Case from TFS
            PropertiesReader config = new PropertiesReader("config.txt");

            Properties props = new Properties();
            props.PersonalAccessToken = config.get("personalaccesstoken");
            props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
            props.Project = config.get("project");
            props.Uri = config.get("server");
            props.SaveLocation = config.get("saveLocation");
            props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
            props.ExecutionSheetName = config.get("executionsheetname");
            props.ScriptSheetName = config.get("scriptsheetname");
            props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

            Logger logger = new Logger(props.SaveLocation);

            props.Logger = logger;

            TestCase thisTestCase = new TestCase();
            RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);
            thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(testCaseId, suiteID);

            Color royalBlue = Color.FromName("RoyalBlue");
            Color white = Color.FromName("White");
            string testName = thisTestCase.TestCaseId.ToString() + "_" + thisTestCase.TestCaseName.Replace(" ", "_") + ".docx";
            DocX doc = DocX.Create(testName);
            var columnWidths = new float[] { 225f, 225f, 225f };
            Table testSummary = doc.AddTable(2, 3);
            //Test Objective table
            doc.InsertParagraph("Test Objective").FontSize(16);
            testSummary.Rows[0].Cells[0].Paragraphs.First().Append("#").Color(white);
            testSummary.Rows[0].Cells[1].Paragraphs.First().Append("Title").Color(white);
            testSummary.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective").Color(white);
            testSummary.Rows[0].Cells[0].FillColor = royalBlue;
            testSummary.Rows[0].Cells[1].FillColor = royalBlue;
            testSummary.Rows[0].Cells[2].FillColor = royalBlue;

            testSummary.Rows[1].Cells[0].Paragraphs.First().Append(thisTestCase.TestCaseId.ToString());
            testSummary.Rows[1].Cells[1].Paragraphs.First().Append(thisTestCase.TestDescription);
            testSummary.Rows[1].Cells[2].Paragraphs.First().Append(thisTestCase.TestObjective);
            testSummary.SetWidths(columnWidths);
            doc.InsertTable(testSummary);
            doc.InsertParagraph("Steps to follow").FontSize(16);

            Table testActionResult = doc.AddTable(thisTestCase.TestSteps.Count + 1, 3);

            testActionResult.SetWidths(columnWidths);
            testActionResult.Rows[0].Cells[0].Paragraphs.First().Append("Steps").Color(white);
            testActionResult.Rows[0].Cells[1].Paragraphs.First().Append("Action").Color(white);
            testActionResult.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result").Color(white);
            testActionResult.Rows[0].Cells[0].FillColor = royalBlue;
            testActionResult.Rows[0].Cells[1].FillColor = royalBlue;
            testActionResult.Rows[0].Cells[2].FillColor = royalBlue;

            int i = 0;
            foreach (TestStep testStep in thisTestCase.TestSteps)
            {
                i++;
                string action = Utility.RemoveTags(testStep.Action);
                string expected = Utility.RemoveTags(testStep.Expected);

                testActionResult.Rows[i].Cells[0].Paragraphs.First().Append(testStep.StepNumber.ToString());
                testActionResult.Rows[i].Cells[1].Paragraphs.First().Append(action);
                testActionResult.Rows[i].Cells[2].Paragraphs.First().Append(expected);


            }

            doc.InsertTable(testActionResult);
            #endregion
            return doc;
        }

    }
}
