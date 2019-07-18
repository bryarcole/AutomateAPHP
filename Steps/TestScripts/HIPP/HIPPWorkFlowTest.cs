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
using System.Collections;
using TFSCommon.Common;
using RequirementsTraceability;
using TFSCommon.Data;
using System.IO;
using NUnit.Tests1.Pages.WorkerPortal;

namespace NUnit.Tests1
{
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class HIPPWorkFlowTest
    {
        static string userName = "bryar.h.cole";
        public IWebDriver context;
        string screenshotLocation = @"C:\\Users\\ " + userName + "\\Desktop\\TestResults\\images\\";


        //Finished
        [Test]
        [TestCase("Approved", 152492, false)]
        [TestCase("Denied", 152493, false)]
        [TestCase("Pended", 152494, false)]
        [TestCase("Approved", 152499, true)]
        [TestCase("Denied", 152500, true)]
        [TestCase("Pended", 152501, true)]
        [Category("HIPP WorkFlow"), Category("Paper Initial")]
        public void TC_IT03_HIPP_Workflow(string stat, int testCaseID, bool renewalStatus)
        {

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            CreateHIPPApplication app = new CreateHIPPApplication();
            HIPPWorkFlow workFlow = new HIPPWorkFlow();
            WordDocGen genWordDoc = new WordDocGen();
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;

            #endregion

            System.IO.Directory.CreateDirectory(screenshotLocation);

            DocX doc = genWordDoc.CreateWordDoc(testCaseID, 152045 );
            TestCase testCase = utility.GetTestCase(testCaseID, 152045);
            string testName = testCase.TestCaseId.ToString() + "_" + testCase.TestCaseName.Replace(" ", "_") + ".docx";
            string scenario = testCase.TestCaseName;


            try
            {
                doc.InsertBookmark("Pass 1");
                doc.InsertBookmark("Pass 2");
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);
                landingPage.HippApplicationSearch();
                hIPPSearch.ClickBeginNewApp();
                //hIPPSearch.ClickBeginNewApp();
                
                app.SubmitHIPPCaseSubmissionUltimate(context, false,  screenshotLocation, doc);
                string appNumber = workFlow.HippWorkFlow(stat, context,screenshotLocation, doc);


            }


            catch (NoSuchElementException e)
            {

                utility.RecordStepStatusMAIN("Element you are looking for does not exist, error mssage is as follows: " + e.Message, screenshotLocation, "NoSuchElement", doc);

                throw;
            }
            catch (Exception e)
            {

                utility.RecordStepStatusMAIN("An exception occurred within the code, please see error message: " + e.Message, screenshotLocation, "Error", doc);

                throw;
            }

            finally
            {

                try
                {
                    Thread.Sleep(3000);
                    doc.SaveAs("C:\\Users\\"  + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\"  + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }
        }




        [Test]
        [Category("Fill Info")]
        public void FillInfo()
        {

            #region Start up
            ExtentTest test = null;
            string scenario = "HIPP Submisssion WorkFlow";
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            CreateHIPPApplication app = new CreateHIPPApplication();

            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;
            string testName = "FillData";
            DocX doc = DocX.Create(testName);


            #endregion

            doc.InsertBookmark("Pass 1");
            doc.InsertBookmark("Pass 2");
            loginPage.LoginPage("bryar.h.wrkr", "Password123");
            utility.RecordStepStatusMAIN("Log in in APHP Sucess", screenshotLocation, "LoginSuccess", doc);
            landingPage.HippApplicationSearch();
            hIPPSearch.SearchHiPPCase("Contains", "Application ID", "10000156");
            hIPPSearch.SearchButtonClick();
            utility.RecordStepStatusMAIN("Search results", screenshotLocation, "SearchResults", doc);
            generic.genericLinkTextClick("10000156");
            
            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);
            //hIPPSearch.ClickBeginNewApp();



        }
    }

}
