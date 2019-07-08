// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using NUnit.Tests1.Pages;

using NUnit.Tests1.Steps.StartUp;
using NUnit.Tests1.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Tests1.Utilities;
using System;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Threading;
using System.Linq;
using Xceed.Words.NET;
using System.Diagnostics;

namespace NUnit.Tests1
{
    [TestFixture]
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class HIPPWorkerPortalValidations
    {
        #region Start up
        ExtentReports extent = null;
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentV3HtmlReporter(@"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HIPPNegativeValidations\index.html");
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        public IWebDriver context;
        string bryar = "bryar.h.cole";
        string screenshotLocation = @"C:\\Users\\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HIPPNegativeValidations\images\";
        int sucessCount = 1;
        int errorCount = 1;
        private static Random random = new Random();
        #endregion

        [Test]
        [Category("HIPP Negative Validation for App Submissin")]
        public void HIPPWorkerPortalNegativeValidations()
        {

            #region Test Load
            ExtentTest test = null;
            string scenario = "HIPP Negative Validation for App Submission";
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string fileName = "TestDoc";
            var doc = DocX.Create(fileName);
            //Steps used
            StartUp startUp = new StartUp(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);


            ///Pages Used

            APHPHomePage loginPage = new APHPHomePage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            HIPPWorkerPortalNegativeValidation validate = new HIPPWorkerPortalNegativeValidation(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);


            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();

            #endregion

            try
            {
                test = extent.CreateTest("Test " + scenario).Pass("Access Data " + sucessCount + " Begin");
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordPassStatus("Loggin in APHP Sucess", Status.Pass, screenshotLocation, sucessCount, "LoginSuccess", "The user is successfully able to log into APHP.", test, doc);
                landingPage.HippApplicationSearch();
                hIPPSearch.ClickBeginNewApp();



                utility.RecordPassStatus("Navigate to Page successfully", Status.Pass, screenshotLocation, sucessCount, "NavtoPageSucess", "Successfully able to navigate to submit application page", test, doc);
                validate.ValidateApplicationOverveiw(test, utility);
                generic.GenericCheveronClick("9");
                validate.ValidatePolicyHolderEmployerInformaton(test, utility);
                utility.RecordPassStatus("Policy Holder Information Validated", Status.Pass, screenshotLocation, sucessCount, "PolicyHolderValidation", "PolicyholderValidation", test, doc);
                generic.GenericCheveronClick("9");


                generic.GenericCheveronClick("10");
                validate.ValidateHouseHoldInformationInput(test, utility);
                generic.GenericCheveronClick("10");


                generic.GenericCheveronClick("11");
                generic.GenericCheveronClick("12");
                validate.ValidateEmploymentStatusHiringInput( test,  utility);
                generic.GenericCheveronClick("13");
                validate.ValidateEmploymentHumanResourcesInformationInput(test, utility);
                generic.GenericCheveronClick("11");


                generic.GenericCheveronClick("14");
                generic.GenericCheveronClick("15");
                validate.ValidateCompanyInformationInput(test, utility);
                generic.GenericCheveronClick("16");
                validate.ValidatePlanInformationInput(test, utility);
                generic.GenericCheveronClick("14");

                generic.GenericCheveronClick("17");
                generic.GenericCheveronClick("18");
                validate.ValidateEmployeeInformationInput(test, utility);
                generic.GenericCheveronClick("19");
                validate.ValidateEmployeeMemberInput(test, utility);
                generic.GenericCheveronClick("20");
                validate.ValidateCoverageSelectionInput(test, utility);
                generic.GenericCheveronClick("21");
                validate.ValidateOpenEnrollmentInformationInput(test, utility);
                generic.GenericCheveronClick("22");
                validate.ValidateInsuranceType(test, utility);


                submitApp.ClickSave();
                Thread.Sleep(3000);
                generic.HoverByElement(submitApp.errorTitle);
                utility.RecordPassStatus("Errors Shown", Status.Pass, screenshotLocation, sucessCount, "ErrorsShown", "Errors Shown", test, doc);
                doc.Save();
                Process.Start("WINWORD.EXE", fileName);

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
                
                generic.signoutBtn.Click(); ;
                context.Close();
                doc.SaveAs("TestDoc");
                Process.Start("WINWORD.EXE", fileName);
            }
        }

    }

}
