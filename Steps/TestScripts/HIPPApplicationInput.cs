// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps.StartUp;
using NUnit.Tests1.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Tests1.Utilities;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Threading;
using System.Linq;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Windows.Forms;
using RequirementsTraceability;
using TFSCommon.Data;
using TFSCommon.Common;
using OpenQA.Selenium.Support.UI;

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
        string bryar = "bryar.h.cole";
        string screenshotLocation = @"C:\\Users\\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HIPPSubmit\images\";
        int sucessCount = 1;
        int errorCount = 1;

        [Test]
        [Category("HIPP WF Paper App")]
        public void TC_IT03_HIPP_Workflow_Approve_Initial_Paper_Application()
        {

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
        

        [Test]
        [Category("HIPP Submission")]
        public void HIPPSubmissionDev()
        {

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
