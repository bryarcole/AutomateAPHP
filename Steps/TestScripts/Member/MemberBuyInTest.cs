// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps.StartUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Tests1.Utilities;
using System;
using AventStack.ExtentReports;
using System.Threading;
using Xceed.Words.NET;
using System.Diagnostics;
using TFSCommon.Data;
using NUnit.Tests1.Pages.WorkerPortal;
using static NUnit.Tests1.Pages.WorkerPortal.MemberEligibilityDetails;

namespace NUnit.Tests1
{
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class MemberBuyIn
    {
        static string userName = "bryar.h.cole";
        public IWebDriver context;
        string screenshotLocation = @"C:\\Users\\ " + userName + "\\Desktop\\TestResults\\images\\";


        //Finished
        [Test]
        //[TestCase("Denied", 152500, true)]
        [TestCase("000000002053", 155378)]
        [Category("Member Buy In WorkFlow")]
        public void TC_IT04_HIPP_BuyIn_17(string memberId, int testCaseID)
        {
            string location = "C:\\Users\\" + userName + "\\Desktop\\EvidenceDocsforcase " + testCaseID;
            string screenshotLocation = location + "\\images\\";

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            InitiateTest startUp = new InitiateTest(context);
            WordDocGen genWordDoc = new WordDocGen();
            MemberSearchPage membersearch = new MemberSearchPage(context);
            MedicareBuyIn buyIn = new MedicareBuyIn(context);
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
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();

                generic.genericLinkTextClick(memberId);
                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Add new item displayed", screenshotLocation, "Buy in displayed", doc);
                generic.genericLinkTextClick("Add new item");
                utility.RecordStepStatusMAIN("Add new item", screenshotLocation, "Grid is displayed", doc);

                //input info
                buyIn.MedicarePartInput("A");
                buyIn.TransactionCodeInput(utility.RandomNumericString(9));
                buyIn.BuyInEligibilityCodeInput("A");
                buyIn.SentRecievedDateInput(now.ToString("MM/dd/yyyy"));
                utility.RecordStepStatusMAIN("Input before insert", screenshotLocation, "InfoInput", doc);

                generic.genericLinkTextClick("Insert");
                utility.RecordStepStatusMAIN("Input after insert", screenshotLocation, "Afterinput", doc);

                buyIn.clickSaveButton();
                utility.RecordStepStatusMAIN("Save Button", screenshotLocation, "AfterSave", doc);
                //input info
                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();
                generic.genericLinkTextClick(memberId);

                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Results", screenshotLocation, "ResultDisplayed", doc);


            }

            #region try catch logic

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
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }

            #endregion
        }
        [TestCase("000000002053", 155379)]
        [Category("Member Buy In WorkFlow")]
        public void TC_IT04_HIPP_BuyIn_18(string memberId, int testCaseID)
        {
            string location = "C:\\Users\\" + userName + "\\Desktop\\EvidenceDocsforcase " + testCaseID;
            string screenshotLocation = location + "\\images\\";

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            InitiateTest startUp = new InitiateTest(context);
            WordDocGen genWordDoc = new WordDocGen();
            MemberSearchPage membersearch = new MemberSearchPage(context);
            MedicareBuyIn buyIn = new MedicareBuyIn(context);
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
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains",memberId);
                membersearch.SearchButtonClick();

                generic.genericLinkTextClick(memberId);
                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Add new item displayed", screenshotLocation, "Buy in displayed", doc);
                generic.genericLinkTextClick("Add new item");
                utility.RecordStepStatusMAIN("Add new item", screenshotLocation, "Grid is displayed", doc);

                buyIn.MedicarePartInput("A");
                buyIn.TransactionCodeInput(utility.RandomNumericString(9));
                buyIn.BuyInEligibilityCodeInput("A");
                buyIn.TransactionEffectiveDateFromInput(now.AddMonths(-9).ToString("MM/dd/yyyy"));
                buyIn.SentRecievedDateInput(now.ToString("MM/dd/yyyy"));
                utility.RecordStepStatusMAIN("Input before insert", screenshotLocation, "InfoInput", doc);

                generic.genericLinkTextClick("Insert");
                utility.RecordStepStatusMAIN("Input after insert", screenshotLocation, "Afterinput", doc);

                buyIn.clickSaveButton();
                utility.RecordStepStatusMAIN("Save Button", screenshotLocation, "AfterSave", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();
                generic.genericLinkTextClick(memberId);

                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Results", screenshotLocation, "ResultDisplayed", doc);


            }

            #region try catch logic

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
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }

            #endregion
        }

        [TestCase("000000002039", 155380)]
        [Category("Member Buy In WorkFlow")]
        public void TC_IT04_HIPP_BuyIn_19(string memberId, int testCaseID)
        {
            string location = "C:\\Users\\" + userName + "\\Desktop\\EvidenceDocsforcase " + testCaseID;
            string screenshotLocation = location + "\\images\\";

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            InitiateTest startUp = new InitiateTest(context);
            WordDocGen genWordDoc = new WordDocGen();
            MemberSearchPage membersearch = new MemberSearchPage(context);
            MedicareBuyIn buyIn = new MedicareBuyIn(context);
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
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();

                generic.genericLinkTextClick(memberId);
                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Add new item displayed", screenshotLocation, "Buy in displayed", doc);
                generic.genericLinkTextClick("Add new item");
                utility.RecordStepStatusMAIN("Add new item", screenshotLocation, "Grid is displayed", doc);

                buyIn.MedicarePartInput("A");
                buyIn.TransactionCodeInput(utility.RandomNumericString(9));
                buyIn.BuyInEligibilityCodeInput("A");
                buyIn.TransactionEffectiveDateFromInput(now.AddMonths(-9).ToString("MM/dd/yyyy"));
                buyIn.SentRecievedDateInput(now.ToString("CC/"+ "MM/dd/yyyy"));
                utility.RecordStepStatusMAIN("Input before insert", screenshotLocation, "InfoInput", doc);

                generic.genericLinkTextClick("Insert");
                utility.RecordStepStatusMAIN("Input after insert", screenshotLocation, "Afterinput", doc);

                buyIn.clickSaveButton();
                utility.RecordStepStatusMAIN("Save Button", screenshotLocation, "AfterSave", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();
                generic.genericLinkTextClick(memberId);

                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Results", screenshotLocation, "ResultDisplayed", doc);


            }

            #region try catch logic

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
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }

            #endregion
        }

        [TestCase("000000002039", 155381)]
        [Category("Member Buy In WorkFlow")]
        public void TC_IT04_HIPP_BuyIn_20(string memberId, int testCaseID)
        {
            string location = "C:\\Users\\" + userName + "\\Desktop\\EvidenceDocsforcase " + testCaseID;
            string screenshotLocation = location + "\\images\\";

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            InitiateTest startUp = new InitiateTest(context);
            WordDocGen genWordDoc = new WordDocGen();
            MemberSearchPage membersearch = new MemberSearchPage(context);
            MedicareBuyIn buyIn = new MedicareBuyIn(context);
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
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();

                generic.genericLinkTextClick(memberId);
                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Add new item displayed", screenshotLocation, "Buy in displayed", doc);
                generic.genericLinkTextClick("Add new item");
                utility.RecordStepStatusMAIN("Add new item", screenshotLocation, "Grid is displayed", doc);

                //Inputs
                buyIn.MedicarePartInput("A");
                buyIn.TransactionCodeInput(utility.RandomNumericString(9));
                buyIn.BuyInEligibilityCodeInput("A");
               
                buyIn.TransactionEffectiveDateFromInput(now.AddMonths(-9).ToString("MM/dd/yyyy"));
                buyIn.PremiumInput("001200");
                //end Inputs

                utility.RecordStepStatusMAIN("Input before insert", screenshotLocation, "InfoInput", doc);

                generic.genericLinkTextClick("Insert");
                utility.RecordStepStatusMAIN("Input after insert", screenshotLocation, "Afterinput", doc);

                buyIn.clickSaveButton();
                utility.RecordStepStatusMAIN("Save Button", screenshotLocation, "AfterSave", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();
                generic.genericLinkTextClick(memberId);

                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Results", screenshotLocation, "ResultDisplayed", doc);


            }

            #region try catch logic

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
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }

            #endregion
        }
        [TestCase("000000002039", 155382)]
        [Category("Member Buy In WorkFlow")]
        public void TC_IT04_HIPP_BuyIn_21(string memberId, int testCaseID)
        {
            string location = "C:\\Users\\" + userName + "\\Desktop\\EvidenceDocsforcase " + testCaseID;
            string screenshotLocation = location + "\\images\\";

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            InitiateTest startUp = new InitiateTest(context);
            WordDocGen genWordDoc = new WordDocGen();
            MemberSearchPage membersearch = new MemberSearchPage(context);
            MedicareBuyIn buyIn = new MedicareBuyIn(context);
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
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();

                generic.genericLinkTextClick(memberId);
                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Add new item displayed", screenshotLocation, "Buy in displayed", doc);
                generic.genericLinkTextClick("Add new item");
                utility.RecordStepStatusMAIN("Add new item", screenshotLocation, "Grid is displayed", doc);

                //Inputs
                buyIn.MedicarePartInput("A");
                buyIn.TransactionCodeInput(utility.RandomNumericString(9));
                buyIn.BuyInEligibilityCodeInput("A");
                buyIn.TransactionEffectiveDateFromInput(now.AddMonths(-9).ToString("MM/dd/yyyy"));
                buyIn.PremiumInput("00120$");
                //end Inputs

                utility.RecordStepStatusMAIN("Input before insert", screenshotLocation, "InfoInput", doc);

                generic.genericLinkTextClick("Insert");
                utility.RecordStepStatusMAIN("Input after insert", screenshotLocation, "Afterinput", doc);

                buyIn.clickSaveButton();
                utility.RecordStepStatusMAIN("Save Button", screenshotLocation, "AfterSave", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();
                generic.genericLinkTextClick(memberId);

                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Results", screenshotLocation, "ResultDisplayed", doc);


            }

            #region try catch logic

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
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }

            #endregion
        }
        [TestCase("000000002039", 155383)]
        [Category("Member Buy In WorkFlow")]

        public void TC_IT04_HIPP_BuyIn_22(string memberId, int testCaseID)
        {
            string location = "C:\\Users\\" + userName + "\\Desktop\\EvidenceDocsforcase " + testCaseID;
            string screenshotLocation = location + "\\images\\";

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            InitiateTest startUp = new InitiateTest(context);
            WordDocGen genWordDoc = new WordDocGen();
            MemberSearchPage membersearch = new MemberSearchPage(context);
            MedicareBuyIn buyIn = new MedicareBuyIn(context);
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
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();

                generic.genericLinkTextClick(memberId);
                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Add new item displayed", screenshotLocation, "Buy in displayed", doc);
                generic.genericLinkTextClick("Add new item");
                utility.RecordStepStatusMAIN("Add new item", screenshotLocation, "Grid is displayed", doc);

                //Inputs
                buyIn.MedicarePartInput("A");
                buyIn.TransactionCodeInput(utility.RandomNumericString(9));
                buyIn.BuyInEligibilityCodeInput("A");
                buyIn.TransactionEffectiveToFromInput(now.ToString("MM/dd/yyyy"));

                buyIn.TransactionEffectiveDateFromInput(now.AddMonths(-9).ToString("MM/dd/yyyy"));
                buyIn.PremiumInput("00120$");
                //end Inputs

                utility.RecordStepStatusMAIN("Input before insert", screenshotLocation, "InfoInput", doc);

                generic.genericLinkTextClick("Insert");
                utility.RecordStepStatusMAIN("Input after insert", screenshotLocation, "Afterinput", doc);

                buyIn.clickSaveButton();
                utility.RecordStepStatusMAIN("Save Button", screenshotLocation, "AfterSave", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();
                generic.genericLinkTextClick(memberId);

                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Results", screenshotLocation, "ResultDisplayed", doc);


            }

            #region try catch logic

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
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }

            #endregion
        }
        [TestCase("000000002039", 155379)]
        [Category("Member Buy In WorkFlow")]
        public void General_test(string memberId, int testCaseID)
        {


            string location = "C:\\Users\\" + userName + "\\Desktop\\EvidenceDocsforcase " + testCaseID + "GeneralTest";
            string screenshotLocation = location + "\\images\\";

            #region Start up
            ExtentTest test = null;
            context = new ChromeDriver();
            context.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            InitiateTest startUp = new InitiateTest(context);
            WordDocGen genWordDoc = new WordDocGen();
            MemberSearchPage membersearch = new MemberSearchPage(context);
            MedicareBuyIn buyIn = new MedicareBuyIn(context);
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
                loginPage.LoginPage("bryar.h.wrkr", "Password123");
                utility.RecordStepStatusMAIN("Login APHP success", screenshotLocation, "LoginSuccess", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();

                generic.genericLinkTextClick(memberId);
                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Add new item displayed", screenshotLocation, "Buy in displayed", doc);
                generic.genericLinkTextClick("Add new item");
                utility.RecordStepStatusMAIN("Add new item", screenshotLocation, "Grid is displayed", doc);

                //Inputs
                buyIn.RICInput("A");
                buyIn.MedicarePartInput("A");

                buyIn.TransactionCodeInput(utility.RandomNumericString(9));
                buyIn.BuyInEligibilityCodeInput("A");
                buyIn.SentRecievedDateInput(now.ToString("MM/dd/yyyy"));
                buyIn.TransactionEffectiveToFromInput(now.ToString("01/01/1991"));
                //buyIn.TransactionEffectiveToFromInput(now.ToString("MM/dd/yyyy"));

                buyIn.SubCodeInput("B");
                buyIn.TransactionEffectiveDateFromInput(now.AddMonths(-9).ToString("01/01/1991"));
                //buyIn.TransactionEffectiveDateFromInput(now.AddMonths(-9).ToString("MM/dd/yyyy"));
                buyIn.PremiumInput("00120$");
                //end Inputs

                utility.RecordStepStatusMAIN("Input before insert", screenshotLocation, "InfoInput", doc);

                generic.genericLinkTextClick("Insert");
                utility.RecordStepStatusMAIN("Input after insert", screenshotLocation, "Afterinput", doc);

                buyIn.clickSaveButton();
                utility.RecordStepStatusMAIN("Save Button", screenshotLocation, "AfterSave", doc);

                landingPage.MemberHover();
                generic.genericLinkTextClick("Member Search");
                membersearch.SearchMember("Member ID", "Contains", memberId);
                membersearch.SearchButtonClick();
                generic.genericLinkTextClick(memberId);

                generic.genericLinkTextClick("Transactions");
                utility.RecordStepStatusMAIN("Results", screenshotLocation, "ResultDisplayed", doc);


            }

            #region try catch logic

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
                    doc.SaveAs("C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Process.Start("WINWORD.EXE", "C:\\Users\\" + userName + "\\Desktop\\TestResults\\" + testName);
                    Generic.signoutBtn.Click();
                    context.Close();
                }
                catch
                {
                    context.Close();
                }

            }

            #endregion
        }

    }

}
