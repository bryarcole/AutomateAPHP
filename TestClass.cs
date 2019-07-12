// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
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
using TFSCommon.Common;
using TFSCommon.Data;


namespace NUnit.Tests1
{
    [TestFixture]
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class TestClass
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
        [Category("Nav to HIPP Submission"), TestCaseSource("testCount")]
        public void NavToHIPPSubmission(int testCount)
        {
            ExtentTest test = null;
            string scenario = "Nav to HIPP Submission";
            context = new ChromeDriver();
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            context.Url = "https://10.3.36.214:44305";
            context.Manage().Window.Maximize();
            try
            {
                test = extent.CreateTest("Test " + scenario).Pass("Access Data " + testCount + " Begin");
                loginPage.LoginPage("robert", "user@123A");
                Screenshots.TakeSreenShot(context, screenshotLocation + "LoginSuccess" + testCount + ".png");
                test.Log(Status.Pass, "Loggin in APHP Sucess").AddScreenCaptureFromPath("images\\" + "LoginSuccess" + testCount + ".png");
                landingPage.HippApplicationSearch();
                hIPPSearch.ClickBeginNewApp();

                utility.RecordPassStatus("Navigate to Page successfully", Status.Pass, screenshotLocation, testCount, "NavtoPageSucess", test);

                generic.HoverByLinkText("Member");
                utility.RecordPassStatus("Top menu appears", Status.Pass, screenshotLocation, testCount, "InputDateSucess", test);



                //hIPPSearch.SearchHiPPCase("Contains", "Member ID", "0");               
                //hIPPSearch.SearchButtonClick();
                //utility.RecordPassStatus("Search button clicked", Status.Pass, screenshotLocation, sucessCount, scenario, test);
                //Thread.Sleep(200);
                ////*[@id="ctl00_ctl00_pageContentMaster_criteria1_grdHippSearchResults_ctl00_ctl04_lnkColumn"]
                //hIPPSearch.SearchResults.FindElement(By.Id("ctl00_ctl00_pageContentMaster_criteria1_grdHippSearchResults_ctl00_ctl04_lnkColumn")).Click();
                //utility.RecordPassStatus("Able to Click on Cell", Status.Pass, screenshotLocation, sucessCount, "Able to Click on Cell", test);

            }
            catch(NoSuchElementException e)
            {
                utility.RecordPassStatus(e.Message, Status.Fail, screenshotLocation, errorCount, "fail", test);
                throw;
            }
            catch(Exception e)
            {
                utility.RecordPassStatus(e.Message + "/n" + e.InnerException + "/n" + e.StackTrace, Status.Fail, screenshotLocation, errorCount, "error", test);
                throw;

            }

            finally
            {
                context.Close();
                
            }
        }



        [Test]
        [Category("TestTest")]
        public void TestTest()
        {

            #region config test
            ExtentTest test = null;
            string scenario = "Nav to HIPP Submission";
            context = new ChromeDriver();
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            context.Url = startUp.AssetPTWorker;
            context.Manage().Window.Maximize();
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
