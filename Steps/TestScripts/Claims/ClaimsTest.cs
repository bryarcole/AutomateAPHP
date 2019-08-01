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
using NUnit.Tests1.Pages.WorkerPortal.Claims;
using static NUnit.Tests1.Pages.WorkerPortal.Claims.SubmitClaimApplicationPage;

namespace NUnit.Tests1
{
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class Claims
    {
        static string userName = "bryar.h.cole";
        public IWebDriver context;
        string screenshotLocation = @"C:\\Users\\ " + userName + "\\Desktop\\TestResults\\images\\";


        //Finished
        [Test]
        [Category("Claims"), Category("UnitTest")]
        public void GenericTestMethod()
        {

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            InitiateTest startUp = new InitiateTest(context);
            CreateHIPPApplicationWorker app = new CreateHIPPApplicationWorker();
            HIPPWorkFlow workFlow = new HIPPWorkFlow();
            WordDocGen genWordDoc = new WordDocGen();
            ClaimsSearchPage claimsSearchPage = new ClaimsSearchPage(context);
            SubmitClaimApplicationPage submitClaimApplicationPage = new SubmitClaimApplicationPage();
            ClaimSummaryInformation summaryInformation = new ClaimSummaryInformation(context);
            BeginNewClaimPage beginNewClaimPage = new BeginNewClaimPage(context);
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;

            #endregion

            System.IO.Directory.CreateDirectory(screenshotLocation);

            //DocX doc = genWordDoc.CreateWordDoc();
            //TestCase testCase = utility.GetTestCase();
            //string testName = testCase.TestCaseId.ToString() + "_" + testCase.TestCaseName.Replace(" ", "_") + ".docx";
            //string scenario = testCase.TestCaseName;

            string usernameINTWorker = "bryar.h.wrkr";
            string passwordINTWorker = "Password123";
            try
            {

                loginPage.LoginPage(usernameINTWorker, passwordINTWorker);
                //utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);
                generic.HoverByLinkText("Claims And Authorizations");
                generic.LinkTextClick("Claim Search");
                claimsSearchPage.BeginNewClaimClick();
                beginNewClaimPage.SelectClaimType("Professional");
                beginNewClaimPage.ClickBeginNewClaim();
                generic.CheveronClick("9");
                Console.WriteLine(summaryInformation.GetAdjustedStatus);
                Console.WriteLine(summaryInformation.GetBenefitPlan);
                Console.WriteLine(summaryInformation.GetClaimEncounterStatus);

                


            }


            catch (NoSuchElementException e)
            {

               // utility.RecordStepStatusMAIN("Element you are looking for does not exist, error mssage is as follows: " + e.Message, screenshotLocation, "NoSuchElement", doc);

                throw;
            }
            catch (Exception e)
            {

               // utility.RecordStepStatusMAIN("An exception occurred within the code, please see error message: " + e.Message, screenshotLocation, "Error", doc);

                throw;
            }

            finally
            {

                try
                {
                    Thread.Sleep(3000);
                    //doc.SaveAs("C:\\Users\\"  + userName + "\\Desktop\\TestResults\\" + testName);
                    //Process.Start("WINWORD.EXE", "C:\\Users\\"  + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }
        }

    }

}
