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

namespace NUnit.Tests1
{
    [TestFixture]
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class hIPPSearchTest
    {
        ExtentReports extent = null;
        string reportLocation = @"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HiPPSearch\Index.html";
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(reportLocation);
            extent.AttachReporter(htmlReporter);
            
        

        }


        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        /////////////////////////////////////////
      



        static public IWebDriver context;
        string screenshotLocation = @"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HippSearch\images\";

        int TestCount = 0;
        int errorCount = 0;
        //Data Set up
        static IList Where()
        {
            ArrayList list = new ArrayList();

            list.Add("Application ID");
            list.Add("Member ID");
            list.Add("Policyholder/Employee Name");
            list.Add("SSN");

            return list;
        }
        static IList How()
        {
            ArrayList list = new ArrayList();
            list.Add("Equals");
            list.Add("Contains");
            list.Add("Starts With");
            return list;
        }

        //Pages


        [Test, Category("HIPP Search"), Category("Contains Search")]
        [TestCaseSource("Where")]
        public void HIPPContainsSearchTest(string where)
        {
            
            ExtentTest test = null;
            IWebDriver context = new ChromeDriver();
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            StartUp startUp = new StartUp(context);
            Utility utility = new Utility(context);
            Generic generic = new Generic(context);


            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();

            TestCount = TestCount + 1;

            try
            {

                test = extent.CreateTest("Contains search test with " + where).Pass("Contains Search Test " + TestCount + " Begin");

                loginPage.LoginPage("bryar.h.cole", "Password123");
                utility.RecordPassStatus("Loggin in APHP Success", Status.Pass, screenshotLocation, TestCount, "LoginSuccess", test);

                landingPage.HippApplicationSearch();
                //Opens Additional Criteria Cheveron
                utility.RecordPassStatus("Sucess Navigating To HIPP Application Search Page", Status.Pass, screenshotLocation, TestCount, "ApplicationSearchPageSucess", test);
                hIPPSearch.SearchHiPPCase("Contains", where, "0");

                utility.RecordPassStatus("Entered All Data Sucessfully", Status.Pass, screenshotLocation, TestCount, "EnterDataSuccess", test);
                hIPPSearch.SearchButtonClick();
                utility.RecordPassStatus("Clicked Search", Status.Pass, screenshotLocation, TestCount, "hIPPSearchSS", test);

                if (hIPPSearch.SearchResults.Displayed)
                {
                    utility.RecordPassStatus("Search found results", Status.Pass, screenshotLocation, TestCount, "RecordTableCheck", test);

                }
                else if (hIPPSearch.ReturnNoRecords.Displayed)
                {
                    utility.RecordPassStatus("No results found", Status.Warning, screenshotLocation, TestCount, "NoResultFound", test);
                }
                generic.signoutBtn.Click();
                
                context.Close();
                test.Log(Status.Pass, "Successfully Searched with " + where + " property");


            }
            catch (Exception e)
            {
                errorCount = errorCount + 1;
                Screenshots.TakeSreenShot(context, screenshotLocation + "Error" + errorCount + ".png");
                test.Log(Status.Fatal, e.Message + '\n' + e.InnerException + '\n' + e.StackTrace).AddScreenCaptureFromPath("images\\" + "Error" + errorCount + ".png");
                try
                {
                    generic.signoutBtn.Click();
                }
                catch (Exception er)
                {
                    context.Close();
                }
                context.Close();
                throw;

            }
            finally
            {

            }

        }
        [Test, Category("HIPP Search"), Category("Equals Search")]
        [TestCaseSource("Where")]
        public void HiPPEqualsSearchTest(string where)
        {

            ExtentTest test = null;
            IWebDriver context = new ChromeDriver();
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            Generic generic = new Generic(context);
            StartUp startUp = new StartUp(context);
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            TestCount = TestCount + 1;

            try
            {

                test = extent.CreateTest("Equals search test with " + where).Pass("Equals Search Test " + TestCount + " Begin");
                loginPage.LoginPage("bryar.h.cole", "Password123");
                utility.RecordPassStatus("Loggin in APHP Success", Status.Pass, screenshotLocation, TestCount, "LoginSuccess", test);
                landingPage.HippApplicationSearch();
                //Opens Additional Criteria Cheveron
                utility.RecordPassStatus("Sucess Navigating To HIPP Application Search Page", Status.Pass, screenshotLocation, TestCount, "ApplicationSearchPageSucess", test);
                hIPPSearch.SearchHiPPCase("Equals", where, "10000001");
                utility.RecordPassStatus("Entered All Data Sucessfully", Status.Pass, screenshotLocation, TestCount, "EnterDataSuccess", test);
                hIPPSearch.SearchButtonClick();
                utility.RecordPassStatus("Clicked Search", Status.Pass, screenshotLocation, TestCount, "hIPPSearchSS", test);

                if (hIPPSearch.SearchResults.Displayed)
                {
                    utility.RecordPassStatus("Search found results", Status.Pass, screenshotLocation, TestCount, "RecordTableCheck", test);

                }
                else if (hIPPSearch.ReturnNoRecords.Displayed)
                {
                    utility.RecordPassStatus("No results found", Status.Warning, screenshotLocation, TestCount, "NoResultFound", test);
                }
                generic.signoutBtn.Click();

                context.Close();
                test.Log(Status.Pass, "Successfully Searched with " + where + " property");


            }
            catch (Exception e)
            {
                errorCount = errorCount + 1;
                Screenshots.TakeSreenShot(context, screenshotLocation + "Error" + errorCount + ".png");
                test.Log(Status.Fatal, e.Message + '\n' + e.InnerException + '\n' + e.StackTrace).AddScreenCaptureFromPath("images\\" + "Error" + errorCount + ".png");
                try
                {
                    generic.signoutBtn.Click();
                }
                catch (Exception er)
                {
                    context.Close();
                }
                context.Close();
                throw;

            }
            finally
            {

            }

        }

        [Test, Category("HIPP Search"), Category("Starts With Search")]
        [TestCaseSource("Where")]
        public void HiPPStartsWithHowTest(string where)
        {

            ExtentTest test = null;
            IWebDriver context = new ChromeDriver();
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            StartUp startUp = new StartUp(context);
            Utility utility = new Utility(context);
            Generic generic = new Generic(context);
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();

            TestCount = TestCount + 1;

            try
            {

                test = extent.CreateTest("Starts With search test " + where).Pass("Starts With Search Test " + TestCount + " Begin");
                test.CreateNode("Test ENV" + context.Url);
                test.AssignAuthor("Bryar Cole");
                loginPage.LoginPage("bryar.h.cole", "Password123");
                utility.RecordPassStatus("Loggin in APHP Success", Status.Pass, screenshotLocation, TestCount, "LoginSuccess", test);
                landingPage.HippApplicationSearch();
                //Opens Additional Criteria Cheveron
                utility.RecordPassStatus("Sucess Navigating To HIPP Application Search Page", Status.Pass, screenshotLocation, TestCount, "ApplicationSearchPageSucess", test);
                hIPPSearch.SearchHiPPCase("Starts With", where, "1");

                utility.RecordPassStatus("Entered All Data Sucessfully", Status.Pass, screenshotLocation, TestCount, "EnterDataSuccess", test);
                hIPPSearch.SearchButtonClick();
                utility.RecordPassStatus("Clicked Search", Status.Pass, screenshotLocation, TestCount, "hIPPSearchSS", test);

                if (hIPPSearch.SearchResults.Displayed)
                {
                    utility.RecordPassStatus("Search found results", Status.Pass, screenshotLocation, TestCount, "RecordTableCheck", test);

                }
                else if (hIPPSearch.ReturnNoRecords.Displayed)
                {
                    utility.RecordPassStatus("No results found", Status.Warning, screenshotLocation, TestCount, "NoResultFound", test);
                }
                generic.signoutBtn.Click();

                context.Close();
                test.Log(Status.Pass, "Successfully Searched with " + where + " property");


            }
            catch (Exception e)
            {
                errorCount = errorCount + 1;
                Screenshots.TakeSreenShot(context, screenshotLocation + "Error" + errorCount + ".png");
                test.Log(Status.Fatal, e.Message + '\n' + e.InnerException + '\n' + e.StackTrace).AddScreenCaptureFromPath("images\\" + "Error" + errorCount + ".png");
    
                generic.signoutBtn.Click();
                context.Close();
                throw;

            }
            finally
            {

            }

        }

        [Test, Category("HIPP Search"), Category("Double Search")]
        public void HIPPDoubleSearchTest()
        {

            ExtentTest test = null;
            IWebDriver context = new ChromeDriver();
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            StartUp startUp = new StartUp(context);
            Utility utility = new Utility(context);
            Generic generic = new Generic(context);
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();

            TestCount = TestCount + 1;

            try
            {

                test = extent.CreateTest("HIPP Double Search").Pass("Double Search " + TestCount + " Begin");

                test.AssignAuthor("Bryar Cole");
                
                loginPage.LoginPage("bryar.h.cole", "Password123");
                utility.RecordPassStatus("Loggin in APHP Success", Status.Pass, screenshotLocation, TestCount, "LoginSuccess", test);
                landingPage.HippApplicationSearch();
                //Opens Additional Criteria Cheveron
                utility.RecordPassStatus("Sucess Navigating To HIPP Application Search Page", Status.Pass, screenshotLocation, TestCount, "ApplicationSearchPageSucess", test);
                hIPPSearch.SearchHiPPCase("Contains", "SSN", "0");

                utility.RecordPassStatus("Entered All Data Sucessfully", Status.Pass, screenshotLocation, TestCount, "EnterDataSuccess", test);
                hIPPSearch.SearchButtonClick();
                utility.RecordPassStatus("Clicked Search", Status.Pass, screenshotLocation, TestCount, "hIPPSearchSS", test);

                if (hIPPSearch.SearchResults.Displayed)
                {
                    utility.RecordPassStatus("Search found results", Status.Pass, screenshotLocation, TestCount, "RecordTableCheck", test);

                }
                else if (hIPPSearch.ReturnNoRecords.Displayed)
                {
                    utility.RecordPassStatus("No results found", Status.Warning, screenshotLocation, TestCount, "NoResultFound", test);
                }
                test.Log(Status.Pass, "Successfully Searched Pass one");

                hIPPSearch.SearchHiPPCase("Contains", "SSN", "1");
                hIPPSearch.SearchButtonClick();
                Assert.True(hIPPSearch.SearchResults.Displayed || hIPPSearch.ReturnNoRecords.Displayed);
                if (hIPPSearch.SearchResults.Displayed)
                {
                    utility.RecordPassStatus("Search found results", Status.Pass, screenshotLocation, TestCount, "RecordTableCheck", test);

                }
                else if (hIPPSearch.ReturnNoRecords.Displayed)
                {
                    utility.RecordPassStatus("No results found", Status.Warning, screenshotLocation, TestCount, "NoResultFound", test);
                }
                generic.signoutBtn.Click();

                context.Close();
                test.Log(Status.Pass, "Successfully Searched Twice");


            }
            catch (Exception e)
            {
                errorCount = errorCount + 1;
                Screenshots.TakeSreenShot(context, screenshotLocation + "Error" + errorCount + ".png");
                test.Log(Status.Fatal, e.Message + '\n' + e.InnerException + '\n' + e.StackTrace).AddScreenCaptureFromPath("images\\" + "Error" + errorCount + ".png");
                generic.signoutBtn.Click();

                context.Close();
                throw;

            }
            finally
            {

            }


        }

        [Test, Category("HIPP Search"), Category("Application Type")]
        [TestCaseSource("How")]
        public void HiPPApplicationType(string how)
        {

            ExtentTest test = null;
            IWebDriver context = new ChromeDriver();
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            StartUp startUp = new StartUp(context);
            Utility utility = new Utility(context);
            Generic generic = new Generic(context);
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();

            TestCount = TestCount + 1;

            try
            {

                test = extent.CreateTest("Application Type " + how).Pass("Application Type " + TestCount + " Begin");
                test.CreateNode("Test ENV" + context.Url);
                test.AssignAuthor("Bryar Cole");
                loginPage.LoginPage("bryar.h.cole", "Password123");
                utility.RecordPassStatus("Loggin in APHP Success", Status.Pass, screenshotLocation, TestCount, "LoginSuccess", test);
                landingPage.HippApplicationSearch();
                //Opens Additional Criteria Cheveron
                utility.RecordPassStatus("Sucess Navigating To HIPP Application Search Page", Status.Pass, screenshotLocation, TestCount, "ApplicationSearchPageSucess", test);
                hIPPSearch.SearchHiPPCase(how, "Member ID", "0", "Electronic", "Renewal");

                utility.RecordPassStatus("Entered All Data Sucessfully", Status.Pass, screenshotLocation, TestCount, "EnterDataSuccess", test);
                hIPPSearch.SearchButtonClick();
                utility.RecordPassStatus("Clicked Search", Status.Pass, screenshotLocation, TestCount, "hIPPSearchSS", test);

                if (hIPPSearch.SearchResults.Displayed)
                {
                    utility.RecordPassStatus("Search found results", Status.Pass, screenshotLocation, TestCount, "RecordTableCheck", test);
                }
                else if (hIPPSearch.ReturnNoRecords.Displayed)
                {
                    utility.RecordPassStatus("No results found", Status.Warning, screenshotLocation, TestCount, "NoResultFound", test);
                }
                generic.signoutBtn.Click();

                context.Close();
                test.Log(Status.Pass, "Successfully Searched with " + how + " property");


            }
            catch (Exception e)
            {
                errorCount = errorCount + 1;
                Screenshots.TakeSreenShot(context, screenshotLocation + "Error" + errorCount + ".png");
                test.Log(Status.Fatal, e.Message + '\n' + e.InnerException + '\n' + e.StackTrace).AddScreenCaptureFromPath("images\\" + "Error" + errorCount + ".png");

                generic.signoutBtn.Click();
                context.Close();
                throw;

            }
            finally
            {

            }

        }

        [Test, Category("HIPP Search"), Category("Application Mode")]
        [TestCaseSource("How")]
        public void HiPPApplicationMode(string how)
        {

            ExtentTest test = null;
            IWebDriver context = new ChromeDriver();
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            StartUp startUp = new StartUp(context);
            Utility utility = new Utility(context);
            Generic generic = new Generic(context);
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();

            TestCount = TestCount + 1;

            try
            {

                test = extent.CreateTest("Application Mode " + how).Pass("Application Mode " + TestCount + " Begin");
                test.CreateNode("Test ENV" + context.Url);
                test.AssignAuthor("Bryar Cole");
                loginPage.LoginPage("bryar.h.cole", "Password123");
                utility.RecordPassStatus("Loggin in APHP Success", Status.Pass, screenshotLocation, TestCount, "LoginSuccess", test);
                landingPage.HippApplicationSearch();
                //Opens Additional Criteria Cheveron
                utility.RecordPassStatus("Sucess Navigating To HIPP Application Search Page", Status.Pass, screenshotLocation, TestCount, "ApplicationSearchPageSucess", test);
                hIPPSearch.SearchHiPPCase(how, "Member ID", "0", "Paper", "New");

                utility.RecordPassStatus("Entered All Data Sucessfully", Status.Pass, screenshotLocation, TestCount, "EnterDataSuccess", test);
                hIPPSearch.SearchButtonClick();
                utility.RecordPassStatus("Clicked Search", Status.Pass, screenshotLocation, TestCount, "hIPPSearchSS", test);

                if (hIPPSearch.SearchResults.Displayed)
                {
                    utility.RecordPassStatus("Search found results", Status.Pass, screenshotLocation, TestCount, "RecordTableCheck", test);

                }
                else if (hIPPSearch.ReturnNoRecords.Displayed)
                {
                    utility.RecordPassStatus("No results found", Status.Warning, screenshotLocation, TestCount, "NoResultFound", test);
                }
                generic.signoutBtn.Click();

                context.Close();
                test.Log(Status.Pass, "Successfully Searched with " + how + " property");


            }
            catch (Exception e)
            {
                errorCount = errorCount + 1;
                Screenshots.TakeSreenShot(context, screenshotLocation + "Error" + errorCount + ".png");
                test.Log(Status.Fatal, e.Message + '\n' + e.InnerException + '\n' + e.StackTrace).AddScreenCaptureFromPath("images\\" + "Error" + errorCount + ".png");

                generic.signoutBtn.Click();
                context.Close();
                throw;

            }
            finally
            {

            }

        }
    }
}
   
