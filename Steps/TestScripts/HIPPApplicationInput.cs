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
        [Category("HIPP Submission")]
        public void HIPPSubmission()
        {

            #region Start up
            ExtentTest test = null;
            string scenario = "Nav to HIPP Submission";
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            StartUp startUp = new StartUp(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            CreateHIPPApplication app = new CreateHIPPApplication();

            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;
            string testName = "SubmitApp";
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
                Paragraph par = doc.InsertParagraph(action + ":" + expected);

            }


            #endregion

            try
            {
                doc.InsertBookmark("Page");
                test = extent.CreateTest("Test " + scenario).Pass("Access Data " + sucessCount + " Begin");
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordPassStatus("Loggin in APHP Sucess", Status.Pass, screenshotLocation, sucessCount, "LoginSuccess", "The user is successfully able to log into APHP.", test, doc);
                landingPage.HippApplicationSearch();
                hIPPSearch.ClickBeginNewApp();
                //hIPPSearch.ClickBeginNewApp();
                
                app.SubmitHIPPCaseLight(context, doc, testName, screenshotLocation, sucessCount, test);


                generic.GenericCheveronClick("2");
                generic.GenericCheveronClick("3");
                generic.GenericCheveronClick("4");
                string appNumber = workitem.applicationNumber.Text;
                string workItem = workitem.txtWorkItemType.Text;
                string appQueue = workitem.txtQueueStatus.Text;
                Paragraph par = doc.InsertParagraph(appNumber + "\n " + workItem + "\n " + appQueue);
                doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Page");
                workitem.ActivitystatusResn_Input.Click();
                workitem.ActivitystatusResn_Input.SendKeys("Approved");
                workitem.btnActivityApprove.Click();
                Thread.Sleep(2000);

                generic.GenericCheveronClick("3");
                generic.GenericCheveronClick("4");
                Thread.Sleep(2000);
                utility.RecordPassStatus("Check App Status", Status.Pass, screenshotLocation, sucessCount, "CheckAppStaus", test, doc);
                workitem.CompletedBottom.Click();
                context.Navigate().Refresh();
                Thread.Sleep(2000);
                workitem.btnExitBottom.Click();
                landingPage.HippApplicationSearch();
                hIPPSearch.SearchHiPPCase("Contains", "Application ID", appNumber);
                hIPPSearch.SearchButtonClick();
                Thread.Sleep(1500);
                utility.RecordPassStatus("Search Results", Status.Pass, screenshotLocation, sucessCount, "SearchResults", test, doc);
                generic.genericLinkTextClick(appNumber);
                MessageBox.Show(appNumber + "\n " + workItem + "\n " + appQueue);


            }


            catch (NoSuchElementException e)
            {
                utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "fail", e.InnerException + "/n" + e.StackTrace, test, doc);
                throw;
            }
            catch (Exception e)
            {
                utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "error", e.InnerException + "/n" + e.StackTrace, test, doc);
                throw;
            }

            finally
            {
                Thread.Sleep(3000);
                doc.SaveAs(testName);
                Process.Start("WINWORD.EXE", testName);
                //generic.signoutBtn.Click();
                //context.Close();
            }
        }

        [Test]
        [Category("HIPP Submission")]
        public void HIPPSubmissionDev()
        {

            #region Start up
            ExtentTest test = null;
            string scenario = "Nav to HIPP Submission";
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            StartUp startUp = new StartUp(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            CreateHIPPApplication app = new CreateHIPPApplication();

            context.Url = "https://10.3.38.19:44305";
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;
            string testName = "SubmitAppDev";
            DocX doc = DocX.Create(testName);
            #endregion
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

            TestCase thisTestCase = new TestCase();
            RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);
            thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(152599, 152048);
            foreach (TestStep testStep in thisTestCase.TestSteps)
            {
                string action = testStep.Action;
                string expected = testStep.Expected;
                Paragraph par = doc.InsertParagraph(action + ":" + expected);

            }


            #endregion

            try
            {
                doc.InsertBookmark("Page");
                test = extent.CreateTest("Test " + scenario).Pass("Access Data " + sucessCount + " Begin");
                loginPage.LoginPage("antony.wrkr", "Password123");
                utility.RecordPassStatus("Loggin in APHP Sucess", Status.Pass, screenshotLocation, sucessCount, "LoginSuccess", "The user is successfully able to log into APHP.", test, doc);
                landingPage.HippApplicationSearch();
                hIPPSearch.ClickBeginNewApp();

                //hIPPSearch.ClickBeginNewApp();



                generic.GenericCheveronClick("2");
                generic.GenericCheveronClick("3");
                generic.GenericCheveronClick("4");
                string workItem = workitem.txtWorkItemType.Text;
                string appQueue = workitem.txtQueueStatus.Text;
                doc.InsertAtBookmark("\n " + workItem + "\n " + appQueue, "Page");
                workitem.ActivitystatusResn_Input.Click();
                workitem.ActivitystatusResn_Input.SendKeys("Approved");
                workitem.btnActivityApprove.Click();
                Thread.Sleep(2000);

                generic.GenericCheveronClick("3");
                generic.GenericCheveronClick("4");
                Thread.Sleep(2000);
                utility.RecordPassStatus("Check App Status", Status.Pass, screenshotLocation, sucessCount, "CheckAppStaus", test, doc);
                workitem.CompletedBottom.Click();
                string appNumber = workitem.applicationNumber.Text;
                doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Page");
                context.Navigate().Refresh();
                Thread.Sleep(2000);

            }


            catch (NoSuchElementException e)
            {
                utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "fail", e.InnerException + "/n" + e.StackTrace, test, doc);
                throw;
            }
            catch (Exception e)
            {
                utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "error", e.InnerException + "/n" + e.StackTrace, test, doc);
                throw;
            }

            finally
            {
                Thread.Sleep(3000);
                doc.SaveAs(testName);
                Process.Start("WINWORD.EXE", testName);
                //generic.signoutBtn.Click();
                //context.Close();
            }
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
