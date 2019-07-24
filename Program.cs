using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps;
using NUnit.Tests1.Utilities;
using NUnit.Tests1;

using System;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Tests1.Pages.WorkerPortal;
using NUnit.Tests1.Steps.StartUp;
using NUnit.Tests1.Pages.WorkerPortal.Claims;
using static NUnit.Tests1.Pages.WorkerPortal.Claims.SubmitClaimApplicationPage;
using System.Threading;

namespace NUnit.Tests1
{
    class Program
    {
        IWebDriver context;
        static void Main(string[] args)
        {


            //Console.WriteLine("Enter Username and Password");
            //string username = Console.ReadLine();

            //string password = Console.ReadLine();

            //CreateHIPPApplication app = new CreateHIPPApplication();
            //IWebDriver context = new ChromeDriver();
            //app.SubmitHIPPCaseSubmissionUltimate(context, false, username, password);


            GenericTestMethod();
            //docs.CreateWordDocSuite("Bryar.h.cole", 149579, 152261);
            void GenericTestMethod()
            {
                IWebDriver context = new ChromeDriver();

                #region Start up
                ExtentTest test = null;
                context = new ChromeDriver();
                context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                Generic generic = new Generic(context);
                Utility utility = new Utility(context);
                APHPHomePage loginPage = new APHPHomePage(context);
                WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
                _ = new HIPPSearchPage(context);
                InitiateTest startUp = new InitiateTest(context);
                _ = new CreateHIPPApplication();
                _ = new HIPPWorkFlow();
                _ = new WordDocGen();
                ClaimsSearchPage claimsSearchPage = new ClaimsSearchPage(context);
                _ = new SubmitClaimApplicationPage();
                SummaryInformation summaryInformation = new SummaryInformation(context);
                BeginNewClaimPage beginNewClaimPage = new BeginNewClaimPage(context);
                context.Url = startUp.AWSINTWoker;
                context.Manage().Window.Maximize();
                DateTime now = DateTime.Now;

                #endregion

                //System.IO.Directory.CreateDirectory(screenshotLocation);

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
                    generic.genericLinkTextClick("Claim Search");
                    claimsSearchPage.BeginNewClaimClick();
                    beginNewClaimPage.SelectClaimType("Professional");
                    beginNewClaimPage.ClickBeginNewClaim();
                    generic.GenericCheveronClick("9");
                    Console.WriteLine(summaryInformation.GetAdjustedStatus());
                    Console.WriteLine(summaryInformation.GetBenefitPlan());
                    Console.WriteLine(summaryInformation.GetClaimEncounterStatus());




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

}