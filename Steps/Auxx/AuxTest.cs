// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Tests1.Utilities;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TFSCommon.Common;
using TFSCommon.Data;
using Xceed.Words.NET;
using RequirementsTraceability;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace NUnit.Tests1
{
    [TestFixture]
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class Aux
    {
        ExtentReports extent = null;
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Testing\index.html");
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        public IWebDriver context;
        string bryar = "bryar.h.cole";
        string screenshotLocation = @"C:\\Users\\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Testing\images\";
        static IList testCount()
        {
            ArrayList list = new ArrayList();
            int number = 10;

            for(int i = 1; i < number; i++)
            {
                list.Add(i);
            }
            return list;
        }
        int sucessCount = 1;
        int errorCount = 1;
        [Test]
        [Category("CreateDoctest")]
        public void CreateDoctest()
        {
            
            // Test Case Pull
            #region Pull Test Case from TFS
            PropertiesReader config = new PropertiesReader("config.txt");
            Utility utility = new Utility(context);
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
            thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(152501, 152045);

            List<TestCase> cases = new List<TestCase>();
            cases = requirementsTraceabilityJob.GetTestCaseGivenPlanSuite(149579, 152045);

            string testName = thisTestCase.TestCaseId.ToString() + "_" + thisTestCase.TestCaseName.Replace(" ", "_");
            DocX doc = DocX.Create(testName);
            var columnWidths = new float[] { 225f, 225f, 225f };
            Table testSummary = doc.AddTable(2, 3);
            //Test Objective table

            doc.InsertParagraph("Test Objective").FontSize(16);
            testSummary.Rows[0].Cells[0].Paragraphs.First().Append("#");
            testSummary.Rows[0].Cells[1].Paragraphs.First().Append("Title");
            testSummary.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective");

            testSummary.Rows[1].Cells[0].Paragraphs.First().Append(thisTestCase.TestCaseId.ToString());
            testSummary.Rows[1].Cells[1].Paragraphs.First().Append(thisTestCase.TestDescription);
            testSummary.Rows[1].Cells[2].Paragraphs.First().Append(thisTestCase.TestObjective);
            testSummary.SetWidths(columnWidths);
            doc.InsertTable(testSummary);
            doc.InsertParagraph("Steps to follow").FontSize(16);

            Table testActionResult = doc.AddTable(thisTestCase.TestSteps.Count + 1, 3);
            testActionResult.SetWidths(columnWidths);
            testActionResult.Rows[0].Cells[0].Paragraphs.First().Append("Steps");
            testActionResult.Rows[0].Cells[1].Paragraphs.First().Append("Action");
            testActionResult.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result");

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
            doc.Save();
            Process.Start("WINWORD.EXE", testName);
            #endregion
        }

        [Test]
        [Category("CreateWordDocSuite")]
        public void CreateWordDocSuite()
        {
            WordDocGen docs = new WordDocGen();
            docs.CreateWordDocSuite("Bryar.h.cole", 149579, 153580, true);
            #region Boring stuff
            //// Test Case Pull
            //#region Pull Test Case from TFS
            //PropertiesReader config = new PropertiesReader("config.txt");

            //Properties props = new Properties();
            //props.PersonalAccessToken = config.get("personalaccesstoken");
            //props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            //props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
            //props.Project = config.get("project");
            //props.Uri = config.get("server");
            //props.SaveLocation = config.get("saveLocation");
            //props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
            //props.ExecutionSheetName = config.get("executionsheetname");
            //props.ScriptSheetName = config.get("scriptsheetname");
            //props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            //props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

            //Logger logger = new Logger(props.SaveLocation);

            //props.Logger = logger;
            //#endregion

            //Color royalBlue = Color.FromName("RoyalBlue");
            //Color white = Color.FromName("White");
            //RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);

            //string location = "C:\\Users\\bryar.h.cole\\Desktop\\Evidence Docs for Suite " + 150885;
            //System.IO.Directory.CreateDirectory(location);

            //List<TestCase> cases = new List<TestCase>();
            //cases = requirementsTraceabilityJob.GetTestCaseGivenPlanSuite(149579, 150885);

            //foreach (TestCase testCase in cases)
            //{
            //    string testName = testCase.TestCaseId.ToString() + "_" + testCase.TestCaseName.Replace(" ", "_");
            //    DocX doc = DocX.Create(testName);
            //    var columnWidths = new float[] { 225f, 225f, 225f };
            //    Table testSummary = doc.AddTable(2, 3);
            //    //Test Objective table

            //    doc.InsertParagraph("Test Objective").FontSize(16);
            //    testSummary.Rows[0].Cells[0].Paragraphs.First().Append("#").Color(white);
            //    testSummary.Rows[0].Cells[1].Paragraphs.First().Append("Title").Color(white);
            //    testSummary.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective").Color(white);
            //    testSummary.Rows[0].Cells[0].FillColor = royalBlue;
            //    testSummary.Rows[0].Cells[1].FillColor = royalBlue;
            //    testSummary.Rows[0].Cells[2].FillColor = royalBlue;

            //    testSummary.Rows[1].Cells[0].Paragraphs.First().Append(testCase.TestCaseId.ToString());
            //    testSummary.Rows[1].Cells[1].Paragraphs.First().Append(testCase.TestDescription);
            //    testSummary.Rows[1].Cells[2].Paragraphs.First().Append(testCase.TestObjective);
            //    testSummary.SetWidths(columnWidths);
            //    doc.InsertTable(testSummary);


            //    doc.InsertParagraph("Steps to follow").FontSize(16);
            //    Table testActionResult = doc.AddTable(testCase.TestSteps.Count + 1, 3);
            //    testActionResult.SetWidths(columnWidths);
            //    testActionResult.Rows[0].Cells[0].Paragraphs.First().Append("Steps").Color(white);
            //    testActionResult.Rows[0].Cells[1].Paragraphs.First().Append("Action").Color(white);
            //    testActionResult.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result").Color(white);
            //    testActionResult.Rows[0].Cells[0].FillColor = royalBlue;
            //    testActionResult.Rows[0].Cells[1].FillColor = royalBlue;
            //    testActionResult.Rows[0].Cells[2].FillColor = royalBlue;
            //    Console.WriteLine(testName);
            //    int i = 0;
            //    Console.WriteLine("Test Case Count " + testCase.TestSteps.Count);
            //    foreach (TestStep testStep in testCase.TestSteps)
            //    {

            //        i++;
            //        string action = Utility.RemoveTags(testStep.Action);
            //        string expected = Utility.RemoveTags(testStep.Expected);
            //        Console.WriteLine("Test Step " + i);

            //        testActionResult.Rows[i].Cells[0].Paragraphs[0].Append(testStep.StepNumber.ToString());
            //        testActionResult.Rows[i].Cells[1].Paragraphs.First().Append(action);
            //        testActionResult.Rows[i].Cells[2].Paragraphs.First().Append(expected);


            //    }

            //    doc.InsertTable(testActionResult);
            //    doc.SaveAs(location + "//" + testName + ".docx");
            //};
            #endregion
        }


        [Test]
        [Category("InterfaceTest")]
        public void InterfaceTest()
        {

            //PropertiesReader config = new PropertiesReader("config.txt");

            //Properties props = new Properties();
            //props.PersonalAccessToken = config.get("personalaccesstoken");
            //props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            //props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
            //props.Project = config.get("project");
            //props.Uri = config.get("server");
            //props.SaveLocation = config.get("saveLocation");
            //props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
            //props.ExecutionSheetName = config.get("executionsheetname");
            //props.ScriptSheetName = config.get("scriptsheetname");
            //props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            //props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

            //Logger logger = new Logger(props.SaveLocation);

            //props.Logger = logger;

            ////IRequirementsTracabilityJobs requirementsTracabilityJobs = new RequirementsTraceabilityJobs(props);

        }
        [Test]
        [Category("WordDocCreate")]
        public void CreaetWordDocuments()
        {
            REFERENCEONLYCreateWordDoc doc = new REFERENCEONLYCreateWordDoc();
            doc.CreateDocument2();

        }
    }

}
