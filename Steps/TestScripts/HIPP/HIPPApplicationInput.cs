﻿// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Xceed.Words.NET;
using System.Windows.Forms;
using RequirementsTraceability;
using TFSCommon.Data;
using TFSCommon.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Tests1.Utilities;
using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps.StartUp;
using NUnit.Tests1.Steps;
using NUnit.Tests1.Pages.WorkerPortal;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace NUnit.Tests1
{
    [TestFixture]
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class HIPPApplicationInput
    {
        ExtentReports extent = null;
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentV3HtmlReporter(@"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HIPPSubmit\index.html");
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        public IWebDriver context;

        string screenshotLocation = @"C:\\Users\\bryar.h.cole\Desktop\AutomationProjects\NUnit.Tests1\Reports\HIPPSubmit\images\";
        int sucessCount = 1;
        int errorCount = 1;
        [TestCase("Approved", 152492, false)]
        [Category("HIPP WorkFlow"), Category("Paper Initial")]
        public void TC_IT03_HIPP_Workflow(string stat, int testCaseID, bool renewalStatus)
        {
            ScreenCaputres caputres = new ScreenCaputres();
            //caputres.TakeVideo(@"C:\\Users\\bryar.h.cole\Desktop\\TestResults\\");
            string userName = "bryar.h.cole";
            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            CreateHIPPApplicationWorker app = new CreateHIPPApplicationWorker();
            HIPPWorkFlow workFlow = new HIPPWorkFlow();
            WordDocGen genWordDoc = new WordDocGen();
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;

            #endregion

            System.IO.Directory.CreateDirectory(screenshotLocation);

            DocX doc = genWordDoc.CreateWordDoc(testCaseID, 152045);
            TestCase testCase = utility.GetTestCase(testCaseID, 152045);
            string testName = testCase.TestCaseId.ToString() + "_" + testCase.TestCaseName.Replace(" ", "_") + ".docx";
            string scenario = testCase.TestCaseName;


            try
            {
                doc.InsertBookmark("Pass 1");
                doc.InsertBookmark("Pass 2");
                loginPage.LoginPage("bryar.h.wrkr", "user@123A", startUp.AWSINTWoker);
                //loginPage.LoginPage("harish.ne.wrkr", "user@1234");
                
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);
                landingPage.HippApplicationSearch();
                hIPPSearch.ClickBeginNewApp();
                //hIPPSearch.ClickBeginNewApp();

                app.SubmitHIPPCaseSubmissionWorker(context, renewalStatus, screenshotLocation, doc);
                string appNumber = workFlow.HippWorkFlow(stat, context, screenshotLocation, doc);


            }


            catch (NoSuchElementException e)
            {

                utility.RecordStepStatusMAIN("Element you are looking for does not exist, error mssage is as follows: " + e.Message, screenshotLocation, "NoSuchElement", doc);
                //caputres.StopVideo();
                throw;
            }
            catch (Exception e)
            {

                utility.RecordStepStatusMAIN("An exception occurred within the code, please see error message: " + e.Message, screenshotLocation, "Error", doc);
                //caputres.StopVideo();

                throw;
            }

            finally
            {

                try
                {
                    Thread.Sleep(3000);
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    //Generic.signoutBtn.Click();
                    //context.Close();
                }
                catch
                {
                    //context.Close();
                }

            }
        }
        [Test]
        [Category("HIPP WF Paper App")]
        public void TC_IT03_HIPP_Workflow_Deny_Initial_Paper_Application()
        {

        }
        [Test]
        [Category("HIPP WF Paper App")]
        public void TC_IT03_HIPP_Workflow_Pend_Initial_Paper_Application()
        {

        }
        [Test]
        [Category("HIPP WF Paper App")]
        public void TC_IT03_HIPP_Workflow_Valid_Quarterly_Documents_Recieved()
        { 

        }

        #region deadcode
        //[Test]
        //[Category("HIPP WF Paper App")]
        //public void TC_IT03_HIPP_Workflow_Approve_Initial_Paper_Application()
        //{

        //    #region Start up
        //    ExtentTest test = null;
        //    string scenario = "Nav to HIPP Submission";
        //    context = new ChromeDriver();
        //    context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        //    Generic generic = new Generic(context);
        //    Utility utility = new Utility(context);

        //    APHPHomePage loginPage = new APHPHomePage(context);
        //    WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
        //    HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
        //    StartUp startUp = new StartUp(context);
        //    HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
        //    WorkItemComponent workitem = new WorkItemComponent(context);
        //    CreateHIPPApplication app = new CreateHIPPApplication();

        //    context.Url = startUp.AWSINTWoker;
        //    context.Manage().Window.Maximize();
        //    DateTime now = DateTime.Now;

        //    #endregion


        //    #region Pull Test Case from TFS
        //    PropertiesReader config = new PropertiesReader("config.txt");

        //    Properties props = new Properties();
        //    props.PersonalAccessToken = config.get("personalaccesstoken");
        //    props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
        //    props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
        //    props.Project = config.get("project");
        //    props.Uri = config.get("server");
        //    props.SaveLocation = config.get("saveLocation");
        //    props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
        //    props.ExecutionSheetName = config.get("executionsheetname");
        //    props.ScriptSheetName = config.get("scriptsheetname");
        //    props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
        //    props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

        //    Logger logger = new Logger(props.SaveLocation);

        //    props.Logger = logger;

        //    TestCase thisTestCase = new TestCase();
        //    RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);

        //    thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(152492, 152045);
        //    string testName = thisTestCase.TestCaseId.ToString() + "_" + thisTestCase.TestCaseName.Replace(" ", "_") + ".docx";
        //    DocX doc = DocX.Create(testName);
        //    var columnWidths = new float[] { 225f, 225f, 225f };
        //    Table testSummary = doc.AddTable(2, 3);
        //    //Test Objective table
        //    doc.InsertParagraph("Test Objective").FontSize(16);
        //    testSummary.Rows[0].Cells[0].Paragraphs.First().Append("#");
        //    testSummary.Rows[0].Cells[1].Paragraphs.First().Append("Title");
        //    testSummary.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective");

        //    testSummary.Rows[1].Cells[0].Paragraphs.First().Append(thisTestCase.TestCaseId.ToString());
        //    testSummary.Rows[1].Cells[1].Paragraphs.First().Append(thisTestCase.TestDescription);
        //    testSummary.Rows[1].Cells[2].Paragraphs.First().Append(thisTestCase.TestObjective);
        //    testSummary.SetWidths(columnWidths);
        //    doc.InsertTable(testSummary);
        //    doc.InsertParagraph("Steps to follow").FontSize(16);

        //    Table testActionResult = doc.AddTable(thisTestCase.TestSteps.Count + 1, 3);

        //    testActionResult.SetWidths(columnWidths);
        //    testActionResult.Rows[0].Cells[0].Paragraphs.First().Append("Steps");
        //    testActionResult.Rows[0].Cells[1].Paragraphs.First().Append("Action");
        //    testActionResult.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result");

        //    int i = 0;
        //    foreach (TestStep testStep in thisTestCase.TestSteps)
        //    {
        //        i++;
        //        string action = Utility.RemoveTags(testStep.Action);
        //        string expected = Utility.RemoveTags(testStep.Expected);

        //        testActionResult.Rows[i].Cells[0].Paragraphs.First().Append(testStep.StepNumber.ToString());
        //        testActionResult.Rows[i].Cells[1].Paragraphs.First().Append(action);
        //        testActionResult.Rows[i].Cells[2].Paragraphs.First().Append(expected);


        //    }

        //    doc.InsertTable(testActionResult);
        //    #endregion

        //    try
        //    {
        //        doc.InsertBookmark("Pass 1");
        //        doc.InsertBookmark("Pass 2");
        //        test = extent.CreateTest("Test " + scenario).Pass("Access Data " + sucessCount + " Begin");
        //        loginPage.LoginPage("bryar.h.wrkr", "Password123");
        //        utility.RecordPassStatus("Loggin in APHP Sucess", Status.Pass, screenshotLocation, sucessCount, "LoginSuccess", "The user is successfully able to log into APHP.", test, doc);
        //        landingPage.HippApplicationSearch();
        //        hIPPSearch.ClickBeginNewApp();
        //        //hIPPSearch.ClickBeginNewApp();

        //        app.SubmitHIPPCaseRenewalLight(context, doc, testName, screenshotLocation, sucessCount, test);



        //        //Gather Data from app
        //        generic.GenericCheveronClick("2");
        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");

        //        ///Pend Application
        //        workitem.ActivitystatusResn_Input.Click();
        //        workitem.ActivitystatusResn_Input.SendKeys("Approve");
        //        workitem.btnActivityApprove.Click();

        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");
        //        generic.HoverByElement(workitem.CompletedBottom);
        //        string appNumber = workitem.applicationNumber.Text;
        //        string workItem = workitem.txtWorkItemType.Text;
        //        string appQueue = workitem.txtQueueStatus.Text;
        //        doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Pass 1");
        //        utility.RecordPassStatus("App in " + appQueue, Status.Pass, screenshotLocation, sucessCount, "CheckAppStaus", test, doc);
        //        workitem.ClickCompletedButton();
        //        utility.RecordPassStatus("Applciation Completed", Status.Pass, screenshotLocation, sucessCount, "Application Completed", test, doc);
        //        context.Navigate().Refresh();
        //        workitem.ClickExitButton();

        //        landingPage.HippApplicationSearch();
        //        hIPPSearch.SearchHiPPCase("Contains", "Application ID", appNumber);
        //        hIPPSearch.SearchButtonClick();
        //        generic.HoverByLinkText(appNumber);
        //        utility.RecordPassStatus("Search Results 2", Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);
        //        generic.genericLinkTextClick(appNumber);
        //        workitem.ClickWorkItemButton();
        //        Thread.Sleep(3000);
        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");
        //        generic.HoverByElement(workitem.CompletedBottom);

        //        string appNumber2 = workitem.applicationNumber.Text;
        //        string workItem2 = workitem.txtWorkItemType.Text;
        //        string appQueue2 = workitem.txtQueueStatus.Text;

        //        utility.RecordPassStatus("App in " + appQueue2, Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);

        //        doc.InsertAtBookmark(appNumber2 + "\n " + workItem2 + "\n " + appQueue2, "Pass 2");

        //    }


        //    catch (NoSuchElementException e)
        //    {
        //        utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "fail", e.InnerException + "/n" + e.StackTrace, test, doc);
        //        throw;
        //    }
        //    catch (Exception e)
        //    {
        //        utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "error", e.InnerException + "/n" + e.StackTrace, test, doc);
        //        throw;
        //    }

        //    finally
        //    {

        //        try
        //        {
        //            Thread.Sleep(3000);
        //            doc.SaveAs("C:\\Users\\bryar.h.cole\\Desktop\\TestResults\\" + testName);
        //            Process.Start("WINWORD.EXE", "C:\\Users\\bryar.h.cole\\Desktop\\TestResults\\" + testName);
        //            //generic.signoutBtn.Click();
        //            //context.Close();
        //        }
        //        catch
        //        {
        //            //context.Close();
        //        }

        //    }

        //}
        //[Test]
        //[Category("HIPP WF Paper App")]
        //public void TC_IT03_HIPP_Workflow_Approve_Initial_Paper_Application()
        //{

        //    #region Start up
        //    ExtentTest test = null;
        //    string scenario = "Nav to HIPP Submission";
        //    context = new ChromeDriver();
        //    context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        //    Generic generic = new Generic(context);
        //    Utility utility = new Utility(context);

        //    APHPHomePage loginPage = new APHPHomePage(context);
        //    WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
        //    HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
        //    StartUp startUp = new StartUp(context);
        //    HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
        //    WorkItemComponent workitem = new WorkItemComponent(context);
        //    CreateHIPPApplication app = new CreateHIPPApplication();

        //    context.Url = startUp.AWSINTWoker;
        //    context.Manage().Window.Maximize();
        //    DateTime now = DateTime.Now;

        //    #endregion


        //    #region Pull Test Case from TFS
        //    PropertiesReader config = new PropertiesReader("config.txt");

        //    Properties props = new Properties();
        //    props.PersonalAccessToken = config.get("personalaccesstoken");
        //    props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
        //    props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
        //    props.Project = config.get("project");
        //    props.Uri = config.get("server");
        //    props.SaveLocation = config.get("saveLocation");
        //    props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
        //    props.ExecutionSheetName = config.get("executionsheetname");
        //    props.ScriptSheetName = config.get("scriptsheetname");
        //    props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
        //    props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

        //    Logger logger = new Logger(props.SaveLocation);

        //    props.Logger = logger;

        //    TestCase thisTestCase = new TestCase();
        //    RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);

        //    thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(152492, 152045);
        //    string testName = thisTestCase.TestCaseId.ToString() + "_" + thisTestCase.TestCaseName.Replace(" ", "_") + ".docx";
        //    DocX doc = DocX.Create(testName);
        //    var columnWidths = new float[] { 225f, 225f, 225f };
        //    Table testSummary = doc.AddTable(2, 3);
        //    //Test Objective table
        //    doc.InsertParagraph("Test Objective").FontSize(16);
        //    testSummary.Rows[0].Cells[0].Paragraphs.First().Append("#");
        //    testSummary.Rows[0].Cells[1].Paragraphs.First().Append("Title");
        //    testSummary.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective");

        //    testSummary.Rows[1].Cells[0].Paragraphs.First().Append(thisTestCase.TestCaseId.ToString());
        //    testSummary.Rows[1].Cells[1].Paragraphs.First().Append(thisTestCase.TestDescription);
        //    testSummary.Rows[1].Cells[2].Paragraphs.First().Append(thisTestCase.TestObjective);
        //    testSummary.SetWidths(columnWidths);
        //    doc.InsertTable(testSummary);
        //    doc.InsertParagraph("Steps to follow").FontSize(16);

        //    Table testActionResult = doc.AddTable(thisTestCase.TestSteps.Count + 1, 3);

        //    testActionResult.SetWidths(columnWidths);
        //    testActionResult.Rows[0].Cells[0].Paragraphs.First().Append("Steps");
        //    testActionResult.Rows[0].Cells[1].Paragraphs.First().Append("Action");
        //    testActionResult.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result");

        //    int i = 0;
        //    foreach (TestStep testStep in thisTestCase.TestSteps)
        //    {
        //        i++;
        //        string action = Utility.RemoveTags(testStep.Action);
        //        string expected = Utility.RemoveTags(testStep.Expected);

        //        testActionResult.Rows[i].Cells[0].Paragraphs.First().Append(testStep.StepNumber.ToString());
        //        testActionResult.Rows[i].Cells[1].Paragraphs.First().Append(action);
        //        testActionResult.Rows[i].Cells[2].Paragraphs.First().Append(expected);


        //    }

        //    doc.InsertTable(testActionResult);
        //    #endregion

        //    try
        //    {
        //        doc.InsertBookmark("Pass 1");
        //        doc.InsertBookmark("Pass 2");
        //        test = extent.CreateTest("Test " + scenario).Pass("Access Data " + sucessCount + " Begin");
        //        loginPage.LoginPage("bryar.h.wrkr", "Password123");
        //        utility.RecordPassStatus("Loggin in APHP Sucess", Status.Pass, screenshotLocation, sucessCount, "LoginSuccess", "The user is successfully able to log into APHP.", test, doc);
        //        landingPage.HippApplicationSearch();
        //        hIPPSearch.ClickBeginNewApp();
        //        //hIPPSearch.ClickBeginNewApp();

        //        app.SubmitHIPPCaseRenewalLight(context, doc, testName, screenshotLocation, sucessCount, test);



        //        //Gather Data from app
        //        generic.GenericCheveronClick("2");
        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");

        //        ///Pend Application
        //        workitem.ActivitystatusResn_Input.Click();
        //        workitem.ActivitystatusResn_Input.SendKeys("Approve");
        //        workitem.btnActivityApprove.Click();

        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");
        //        generic.HoverByElement(workitem.CompletedBottom);
        //        string appNumber = workitem.applicationNumber.Text;
        //        string workItem = workitem.txtWorkItemType.Text;
        //        string appQueue = workitem.txtQueueStatus.Text;
        //        doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Pass 1");
        //        utility.RecordPassStatus("App in " + appQueue, Status.Pass, screenshotLocation, sucessCount, "CheckAppStaus", test, doc);
        //        workitem.ClickCompletedButton();
        //        utility.RecordPassStatus("Applciation Completed", Status.Pass, screenshotLocation, sucessCount, "Application Completed", test, doc);
        //        context.Navigate().Refresh();
        //        workitem.ClickExitButton();

        //        landingPage.HippApplicationSearch();
        //        hIPPSearch.SearchHiPPCase("Contains", "Application ID", appNumber);
        //        hIPPSearch.SearchButtonClick();
        //        generic.HoverByLinkText(appNumber);
        //        utility.RecordPassStatus("Search Results 2", Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);
        //        generic.genericLinkTextClick(appNumber);
        //        workitem.ClickWorkItemButton();
        //        Thread.Sleep(3000);
        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");
        //        generic.HoverByElement(workitem.CompletedBottom);

        //        string appNumber2 = workitem.applicationNumber.Text;
        //        string workItem2 = workitem.txtWorkItemType.Text;
        //        string appQueue2 = workitem.txtQueueStatus.Text;

        //        utility.RecordPassStatus("App in " + appQueue2, Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);

        //        doc.InsertAtBookmark(appNumber2 + "\n " + workItem2 + "\n " + appQueue2, "Pass 2");

        //    }


        //    catch (NoSuchElementException e)
        //    {
        //        utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "fail", e.InnerException + "/n" + e.StackTrace, test, doc);
        //        throw;
        //    }
        //    catch (Exception e)
        //    {
        //        utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "error", e.InnerException + "/n" + e.StackTrace, test, doc);
        //        throw;
        //    }

        //    finally
        //    {

        //        try
        //        {
        //            Thread.Sleep(3000);
        //            doc.SaveAs("C:\\Users\\bryar.h.cole\\Desktop\\TestResults\\" + testName);
        //            Process.Start("WINWORD.EXE", "C:\\Users\\bryar.h.cole\\Desktop\\TestResults\\" + testName);
        //            //generic.signoutBtn.Click();
        //            //context.Close();
        //        }
        //        catch
        //        {
        //            //context.Close();
        //        }

        //    }

        //}
        //[Test]
        //[Category("HIPP WF Paper App")]
        //public void TC_IT03_HIPP_Workflow_Approve_Initial_Paper_Application()
        //{

        //    #region Start up
        //    ExtentTest test = null;
        //    string scenario = "Nav to HIPP Submission";
        //    context = new ChromeDriver();
        //    context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        //    Generic generic = new Generic(context);
        //    Utility utility = new Utility(context);

        //    APHPHomePage loginPage = new APHPHomePage(context);
        //    WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
        //    HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
        //    StartUp startUp = new StartUp(context);
        //    HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
        //    WorkItemComponent workitem = new WorkItemComponent(context);
        //    CreateHIPPApplication app = new CreateHIPPApplication();

        //    context.Url = startUp.AWSINTWoker;
        //    context.Manage().Window.Maximize();
        //    DateTime now = DateTime.Now;

        //    #endregion


        //    #region Pull Test Case from TFS
        //    PropertiesReader config = new PropertiesReader("config.txt");

        //    Properties props = new Properties();
        //    props.PersonalAccessToken = config.get("personalaccesstoken");
        //    props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
        //    props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
        //    props.Project = config.get("project");
        //    props.Uri = config.get("server");
        //    props.SaveLocation = config.get("saveLocation");
        //    props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
        //    props.ExecutionSheetName = config.get("executionsheetname");
        //    props.ScriptSheetName = config.get("scriptsheetname");
        //    props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
        //    props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

        //    Logger logger = new Logger(props.SaveLocation);

        //    props.Logger = logger;

        //    TestCase thisTestCase = new TestCase();
        //    RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);

        //    thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(152492, 152045);
        //    string testName = thisTestCase.TestCaseId.ToString() + "_" + thisTestCase.TestCaseName.Replace(" ", "_") + ".docx";
        //    DocX doc = DocX.Create(testName);
        //    var columnWidths = new float[] { 225f, 225f, 225f };
        //    Table testSummary = doc.AddTable(2, 3);
        //    //Test Objective table
        //    doc.InsertParagraph("Test Objective").FontSize(16);
        //    testSummary.Rows[0].Cells[0].Paragraphs.First().Append("#");
        //    testSummary.Rows[0].Cells[1].Paragraphs.First().Append("Title");
        //    testSummary.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective");

        //    testSummary.Rows[1].Cells[0].Paragraphs.First().Append(thisTestCase.TestCaseId.ToString());
        //    testSummary.Rows[1].Cells[1].Paragraphs.First().Append(thisTestCase.TestDescription);
        //    testSummary.Rows[1].Cells[2].Paragraphs.First().Append(thisTestCase.TestObjective);
        //    testSummary.SetWidths(columnWidths);
        //    doc.InsertTable(testSummary);
        //    doc.InsertParagraph("Steps to follow").FontSize(16);

        //    Table testActionResult = doc.AddTable(thisTestCase.TestSteps.Count + 1, 3);

        //    testActionResult.SetWidths(columnWidths);
        //    testActionResult.Rows[0].Cells[0].Paragraphs.First().Append("Steps");
        //    testActionResult.Rows[0].Cells[1].Paragraphs.First().Append("Action");
        //    testActionResult.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result");

        //    int i = 0;
        //    foreach (TestStep testStep in thisTestCase.TestSteps)
        //    {
        //        i++;
        //        string action = Utility.RemoveTags(testStep.Action);
        //        string expected = Utility.RemoveTags(testStep.Expected);

        //        testActionResult.Rows[i].Cells[0].Paragraphs.First().Append(testStep.StepNumber.ToString());
        //        testActionResult.Rows[i].Cells[1].Paragraphs.First().Append(action);
        //        testActionResult.Rows[i].Cells[2].Paragraphs.First().Append(expected);


        //    }

        //    doc.InsertTable(testActionResult);
        //    #endregion

        //    try
        //    {
        //        doc.InsertBookmark("Pass 1");
        //        doc.InsertBookmark("Pass 2");
        //        test = extent.CreateTest("Test " + scenario).Pass("Access Data " + sucessCount + " Begin");
        //        loginPage.LoginPage("bryar.h.wrkr", "Password123");
        //        utility.RecordPassStatus("Loggin in APHP Sucess", Status.Pass, screenshotLocation, sucessCount, "LoginSuccess", "The user is successfully able to log into APHP.", test, doc);
        //        landingPage.HippApplicationSearch();
        //        hIPPSearch.ClickBeginNewApp();
        //        //hIPPSearch.ClickBeginNewApp();

        //        app.SubmitHIPPCaseRenewalLight(context, doc, testName, screenshotLocation, sucessCount, test);



        //        //Gather Data from app
        //        generic.GenericCheveronClick("2");
        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");

        //        ///Pend Application
        //        workitem.ActivitystatusResn_Input.Click();
        //        workitem.ActivitystatusResn_Input.SendKeys("Approve");
        //        workitem.btnActivityApprove.Click();

        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");
        //        generic.HoverByElement(workitem.CompletedBottom);
        //        string appNumber = workitem.applicationNumber.Text;
        //        string workItem = workitem.txtWorkItemType.Text;
        //        string appQueue = workitem.txtQueueStatus.Text;
        //        doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Pass 1");
        //        utility.RecordPassStatus("App in " + appQueue, Status.Pass, screenshotLocation, sucessCount, "CheckAppStaus", test, doc);
        //        workitem.ClickCompletedButton();
        //        utility.RecordPassStatus("Applciation Completed", Status.Pass, screenshotLocation, sucessCount, "Application Completed", test, doc);
        //        context.Navigate().Refresh();
        //        workitem.ClickExitButton();

        //        landingPage.HippApplicationSearch();
        //        hIPPSearch.SearchHiPPCase("Contains", "Application ID", appNumber);
        //        hIPPSearch.SearchButtonClick();
        //        generic.HoverByLinkText(appNumber);
        //        utility.RecordPassStatus("Search Results 2", Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);
        //        generic.genericLinkTextClick(appNumber);
        //        workitem.ClickWorkItemButton();
        //        Thread.Sleep(3000);
        //        generic.GenericCheveronClick("3");
        //        generic.GenericCheveronClick("4");
        //        generic.HoverByElement(workitem.CompletedBottom);

        //        string appNumber2 = workitem.applicationNumber.Text;
        //        string workItem2 = workitem.txtWorkItemType.Text;
        //        string appQueue2 = workitem.txtQueueStatus.Text;

        //        utility.RecordPassStatus("App in " + appQueue2, Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);

        //        doc.InsertAtBookmark(appNumber2 + "\n " + workItem2 + "\n " + appQueue2, "Pass 2");

        //    }


        //    catch (NoSuchElementException e)
        //    {
        //        utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "fail", e.InnerException + "/n" + e.StackTrace, test, doc);
        //        throw;
        //    }
        //    catch (Exception e)
        //    {
        //        utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "error", e.InnerException + "/n" + e.StackTrace, test, doc);
        //        throw;
        //    }

        //    finally
        //    {

        //        try
        //        {
        //            Thread.Sleep(3000);
        //            doc.SaveAs("C:\\Users\\bryar.h.cole\\Desktop\\TestResults\\" + testName);
        //            Process.Start("WINWORD.EXE", "C:\\Users\\bryar.h.cole\\Desktop\\TestResults\\" + testName);
        //            //generic.signoutBtn.Click();
        //            //context.Close();
        //        }
        //        catch
        //        {
        //            //context.Close();
        //        }

        //    }

        //}

        #endregion
        [Test]
        [TestCase("Approved", 1, true)]
        [TestCase("Approved", 10, false)]
        [TestCase("Approved", 15, true)]
        [TestCase("Approved", 25, true)]
        [TestCase("Approved", 30, true)]
        [TestCase("Approved", 35, true)]
        [TestCase("Approved", 45, true)]
        [TestCase("Approved", 50, false)]
        [TestCase("Approved", 55, true)]
        [TestCase("Approved", 60, false)]
        [TestCase("Approved", 65, false)]
        [TestCase("Approved", 70, false)]
        [TestCase("Approved", 1, false)]
        [TestCase("Approved", 10, false)]
        [TestCase("Approved", 15, true)]
        [TestCase("Approved", 25, false)]
        [TestCase("Approved", 30, false)]
        [TestCase("Approved", 35, false)]
        [TestCase("Approved", 45, true)]
        [TestCase("Approved", 50, false)]
        [TestCase("Approved", 55, true)]
        [TestCase("Approved", 60, true)]
        [TestCase("Approved", 65, true)]
        [TestCase("Approved", 70, true)]
        [Category("HIPP Submission")]
        public void HIPPSubmissionDev(string stat, int age, bool renewalStatus)
        {
            ScreenCaputres caputres = new ScreenCaputres();
            //caputres.TakeVideo(@"C:\\Users\\bryar.h.cole\Desktop\\TestResults\\");
            string userName = "bryar.h.cole";
            #region Start up
            ExtentTest test = null;
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            context = new ChromeDriver(options);
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            CreateHIPPApplicationWorker app = new CreateHIPPApplicationWorker();
            HIPPWorkFlow workFlow = new HIPPWorkFlow();
            WordDocGen genWordDoc = new WordDocGen();
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;

            #endregion
            StringBuilder stringBuilder = new StringBuilder();
            string screenshotLocation = @"C:\Users\bryar.h.cole\Desktop\TestResults\";


            try
            {

                loginPage.LoginPage("bryar.h.wrkr", "user@123A", startUp.AWSINTWoker);
                //loginPage.LoginPage("harish.ne.wrkr", "user@1234");

                landingPage.HippApplicationSearch();

                while (context.Title == "HIPP Application Search")
                    hIPPSearch.ClickBeginNewApp();
                if (context.Title == "HIPP Application")
                    try
                    {
                        app.SubmitHIPPCaseSubmissionWorker(context, renewalStatus, age);
                    }
                    catch (WebDriverTimeoutException e)
                    {
                        stringBuilder.AppendLine("Seems like a timeout exception occured. For this test. Status was " + stat + ", age: " + age);
                        ScreenCaputres.TakeSreenShot(context, screenshotLocation + stat + age + "error.png");
                    }
                else
                {
                    hIPPSearch.ClickBeginNewApp();
                }
                string appNumber = workFlow.HippWorkFlow(stat, context);
                stringBuilder.AppendLine("Appnumber is " + appNumber + " for candidate who is age: " + age + "\n" + "Time of test: " + now + "\n" + "***********");


            }

            finally
            {

                try
                {
                    Thread.Sleep(3000);
                    Generic.signoutBtn.Click();
                    context.Close();
                    System.IO.File.AppendAllText(@"C:\Users\bryar.h.cole\Desktop\testResults.txt", stringBuilder.ToString());

                }
                catch
                {
                    System.IO.File.AppendAllText(@"C:\Users\bryar.h.cole\Desktop\testResults.txt", stringBuilder.ToString());
                    context.Close();
                }

            }

        }

        [TestCase("Pended", 60, true)]
        [Category("HIPP Submission")]
        public void HIPPSubmissionPend(string stat, int age, bool renewalStatus)
        {
            ScreenCaputres caputres = new ScreenCaputres();
            //caputres.TakeVideo(@"C:\\Users\\bryar.h.cole\Desktop\\TestResults\\");
            string userName = "bryar.h.cole";
            #region Start up
            ExtentTest test = null;
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            context = new ChromeDriver(options);
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            CreateHIPPApplicationWorker app = new CreateHIPPApplicationWorker();
            HIPPWorkFlow workFlow = new HIPPWorkFlow();
            WordDocGen genWordDoc = new WordDocGen();
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;

            #endregion
            StringBuilder stringBuilder = new StringBuilder();
            string screenshotLocation = @"C:\Users\bryar.h.cole\Desktop\TestResults\";


            try
            {

                loginPage.LoginPage("bryar.h.wrkr", "user@123A", startUp.AWSINTWoker);
                //loginPage.LoginPage("harish.ne.wrkr", "user@1234");

                landingPage.HippApplicationSearch();

                while (context.Title == "HIPP Application Search")
                    hIPPSearch.ClickBeginNewApp();
                if (context.Title == "HIPP Application")
                    try
                    {
                        app.SubmitHIPPCaseSubmissionWorker(context, renewalStatus, age);
                    }
                    catch (WebDriverTimeoutException e)
                    {
                        stringBuilder.AppendLine("Seems like a timeout exception occured. For this test. Status was " + stat + ", age: " + age);
                        ScreenCaputres.TakeSreenShot(context, screenshotLocation + stat + age + "error.png");
                    }
                else
                {
                    hIPPSearch.ClickBeginNewApp();
                }
                try
                {
                    string appNumber = workFlow.HippWorkFlow(stat, context);
                    stringBuilder.AppendLine("Appnumber is " + appNumber + " for candidate who is age: " + age + "\n" + "Time of test: " + now + "\n" + "***********");
                }
                catch (WebDriverTimeoutException e)
                {

                    WorkItemComponent workItemComponent = new WorkItemComponent(context);
                   
                    string appNumber = workItemComponent.GatherAppNumber();

                    stringBuilder.AppendLine("Appnumber is " + appNumber + " for candidate who is age: " + age + "\n" + "Time of test: " + now + "\n" + "***********");

                }


            }


            catch (NoSuchElementException e)
            {

                //caputres.StopVideo();
                throw;
            }
            catch (Exception e)
            {

                //caputres.StopVideo();

                throw;
            }

            finally
            {

                try
                {
                    Thread.Sleep(3000);
                    //Generic.signoutBtn.Click();
                    //context.Close();
                    System.IO.File.AppendAllText(@"C:\Users\bryar.h.cole\Desktop\testResults.txt", stringBuilder.ToString());

                }
                catch
                {
                    //context.Close();
                }

            }

        }
        [Test]
        [Category("SubmitSuperLightApplication")]
        public void SubmitSuperLightApplication()
        {

        }
        [Test]
        [Category("Test TFS")]
        public void TestTFS()
        {

            #region Start up
            ExtentTest test = null;

            DateTime now = DateTime.Now;
            string testName = "TFSDoc";
            DocX doc = DocX.Create(testName);

            // Test Case Pull
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
            thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(152599, 152048);
            foreach (TestStep testStep in thisTestCase.TestSteps)
            {
                string action = testStep.Action;
                string expected = testStep.Expected;
            }
            #endregion

            using (context)
            {
                context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                context.Url = "http://somedomain/url_that_delays_loading";
                IWebElement myDynamicElement = context.FindElement(By.Id("someDynamicElement"));
            }
            using (context)
            {
                context.Url = "http://somedomain/url_that_delays_loading";
                WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id("someDynamicElement")));
            }

            try
            {
                foreach(TestStep testStep in thisTestCase.TestSteps)
                { 
                    string action = testStep.Action;
                    string expected = testStep.Expected;
                    Paragraph par = doc.InsertParagraph(action + ": " + expected);
                    
                }
                doc.Save();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

    }

}
