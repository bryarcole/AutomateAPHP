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
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;

namespace NUnit.Tests1.Steps
{
    public class CreateHIPPApplication
    {

        /// <summary>
        /// Submit and Save a HIPP Application : Inclvudes screenshots of everyinput
        /// </summary>
        /// <param name="context"></param>
        /// <param name="doc"></param>
        /// <param name="testName"></param>
        /// <param name="screenshotLocation"></param>
        /// <param name="sucessCount"></param>
        /// <param name="test"></param>
        public void SubmitHIPPCaseGeneric(IWebDriver context,DocX doc ,string testName, string screenshotLocation, int sucessCount, ExtentTest test)
        {
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            DateTime now = DateTime.Now;
            doc.InsertBookmark("Top of Page");
            utility.RecordPassStatus("Navigate to Page Search successfully", Status.Pass, screenshotLocation, sucessCount, "NavtoPageSucess", test, doc);
            submitApp.ApplicationOverviewInput(
                now.ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                Utility.RandomNumericString(9)


                );
            utility.RecordPassStatus("Input application Overview Sucess", Status.Pass, screenshotLocation, sucessCount, "ApplicationOverview", test, doc);
            generic.GenericCheveronClick("10");
            submitApp.HouseHoldInformationInput(
                "Self",
                "Test",
                "",
                "Person",
                "01/03/1991",
                "0298443004",
                "333402593",
                "Yes",
                "Yes");
            utility.RecordPassStatus("Household information input", Status.Pass, screenshotLocation, sucessCount, "HouseholdHiringInput", test, doc);
            generic.GenericCheveronClick("10");
            generic.GenericCheveronClick("9");
            submitApp.PolicyHolderEmployerInformationInput(
                "Test",
                "",
                "Person",
                "233 Buchanan St",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "7033482934",
                "7034449999",
                "2020001111",
                "TestPerson@gmail.com");
            utility.RecordPassStatus("Policy Holder Employer Info Complete", Status.Pass, screenshotLocation, sucessCount, "PolicyHolderEmployerInfo", test, doc);
            generic.GenericCheveronClick("9");

            generic.GenericCheveronClick("11");
            generic.GenericCheveronClick("12");
            submitApp.EmploymentStatusHiringInput(
                true,
                "04/21/2017",
                false,
                true,
                false);
            utility.RecordPassStatus("Employment Status HiringInput", Status.Pass, screenshotLocation, sucessCount, "EmploymentStatus", test, doc);
            generic.GenericCheveronClick("12");
            generic.GenericCheveronClick("13");
            submitApp.EmploymentHumanResourcesInformation(
                "Accenture",
                "101010101",
                "Made Up Street",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "Dale Dimmadone",
                "technology",
                "2022213300");
            utility.RecordPassStatus("Employment Human Resources Input", Status.Pass, screenshotLocation, sucessCount, "EmploymenHumanResources", test, doc);
            generic.GenericCheveronClick("13");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("15");
            submitApp.CompanyInformationInput(
                "Insurance Co.",
                "9483924",
                "Address Line One",
                "Address line two",
                "Charlotesvill",
                "VA",
                "23019",
                "Mike Adams",
                "8883930023");
            utility.RecordPassStatus("Company Information Input", Status.Pass, screenshotLocation, sucessCount, "CompanyInformationInput", test, doc);
            generic.GenericCheveronClick("15");
            generic.GenericCheveronClick("16");
            submitApp.PlanInformationInput(
                "COBRA",
                false,
                "01/01/2000",
                "Monthly",
                "200");
            utility.RecordPassStatus("Plan Information Input", Status.Pass, screenshotLocation, sucessCount, "PlaninformationInput", test, doc);
            generic.GenericCheveronClick("16");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("17");

            generic.GenericCheveronClick("18");
            submitApp.EmployeeInformationInput(
                "Employee",
                "Middle",
                "Worker",
                "4942005931",
                "01/01/1976",
                "01/01/2017",
                false,
                false,
                false);
            utility.RecordPassStatus("Employee Information Input", Status.Pass, screenshotLocation, sucessCount, "EmployeeInfomrationInput", test, doc);
            generic.GenericCheveronClick("18");
            generic.GenericCheveronClick("19");
            submitApp.EmployeeMemberInput(
                "Employee",
                "Middle",
                "Worker",
                DateTime.Now.ToString("MM/dd/yyyy"),
                "Guardian",
                true
                );
            utility.RecordPassStatus("Membership Input Sucess", Status.Pass, screenshotLocation, sucessCount, "MemberShipinputSucess", test, doc);
            generic.GenericCheveronClick("19");
            generic.GenericCheveronClick("20");
            submitApp.CoverageSelection(
                true,
                false,
                false,
                false,
                true,
                false,
                false);
            utility.RecordPassStatus("Coverage Input", Status.Pass, screenshotLocation, sucessCount, "CoverageInput", test, doc);
            generic.GenericCheveronClick("20");
            generic.GenericCheveronClick("21");
            submitApp.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            utility.RecordPassStatus("Open Enrollment Information Input", Status.Pass, screenshotLocation, sucessCount, "OpenEnrollmentInformation", test, doc);
            generic.GenericCheveronClick("21");
            generic.GenericCheveronClick("22");
            submitApp.InsuranceType(
                "Medical",
                "Big Insurance Co.",
                "Address One St.",
                "101",
                "Alexandria",
                "VA",
                "22314",
                "7034049911",
                "86903954");
            Thread.Sleep(2000);
            utility.RecordPassStatus("Insurance Type Input Medical", Status.Pass, screenshotLocation, sucessCount, "InsuranceTypeInputMedical", test, doc);
            submitApp.InsuranceType(
                "Dental",
                "Big Dental Co.",
                "Maker St.",
                "202",
                "Potamic",
                "VA",
                "22314",
                "7039837771",
                "86903954");
            Thread.Sleep(2000);
            utility.RecordPassStatus("Insurance Type Input Dental", Status.Pass, screenshotLocation, sucessCount, "InsuranceTypeInputDental", test, doc);
            Thread.Sleep(2000);
            submitApp.PlanBenifitsInput(
                true,
                "300",
                "1,200",
                true,
                false,
                false,
                true,
                true,
                false,
                true,
                false);
            utility.RecordPassStatus("Plan Benefits", Status.Pass, screenshotLocation, sucessCount, "PlanBenefits", test, doc);
            Thread.Sleep(2000);
            submitApp.ClickSave();
            Thread.Sleep(2000);
            generic.HoverByElement(workitem.txtWorkItemType);
            utility.RecordPassStatus("Case Completed", Status.Pass, screenshotLocation, sucessCount, "Case completed", test, doc);


        }

        /// <summary>
        /// Submit and approve a renewal application
        /// </summary>
        /// <param name="context"></param>
        /// <param name="doc"></param>
        /// <param name="testName"></param>
        /// <param name="screenshotLocation"></param>
        /// <param name="sucessCount"></param>
        /// <param name="test"></param>
        public void SubmitHIPPCaseRenewal(IWebDriver context, WebDriverWait wait, DocX doc, string testName, string screenshotLocation, int sucessCount, ExtentTest test)
        {


            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            DateTime now = DateTime.Now;
            doc.InsertBookmark("Top of Page");
            utility.RecordPassStatus("Navigate to Page Search successfully", Status.Pass, screenshotLocation, sucessCount, "NavtoPageSucess", test, doc);
            submitApp.ApplicationOverviewInput(
                now.AddMonths(-10).ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                now.ToString("MM/dd/yyyy"),
                Utility.RandomNumericString(9)


                );
            utility.RecordPassStatus("Input application Overview Sucess", Status.Pass, screenshotLocation, sucessCount, "ApplicationOverview", test, doc);
            generic.GenericCheveronClick("10");
            submitApp.HouseHoldInformationInput(
                "Self",
                "Test",
                "",
                "Person",
                "01/03/1991",
                "0298443004",
                "333402593",
                "Yes",
                "Yes");
            utility.RecordPassStatus("Household information input", Status.Pass, screenshotLocation, sucessCount, "HouseholdHiringInput", test, doc);
            generic.GenericCheveronClick("10");
            generic.GenericCheveronClick("9");
            submitApp.PolicyHolderEmployerInformationInput(
                "Test",
                "",
                "Person",
                "233 Buchanan St",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "7033482934",
                "7034449999",
                "2020001111",
                "TestPerson@gmail.com");
            utility.RecordPassStatus("Policy Holder Employer Info Complete", Status.Pass, screenshotLocation, sucessCount, "PolicyHolderEmployerInfo", test, doc);
            generic.GenericCheveronClick("9");

            generic.GenericCheveronClick("11");
            generic.GenericCheveronClick("12");
            submitApp.EmploymentStatusHiringInput(
                true,
                "04/21/2017",
                false,
                true,
                false);
            utility.RecordPassStatus("Employment Status HiringInput", Status.Pass, screenshotLocation, sucessCount, "EmploymentStatus", test, doc);
            generic.GenericCheveronClick("12");
            generic.GenericCheveronClick("13");
            submitApp.EmploymentHumanResourcesInformation(
                "Accenture",
                "101010101",
                "Made Up Street",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "Dale Dimmadone",
                "technology",
                "2022213300");
            utility.RecordPassStatus("Employment Human Resources Input", Status.Pass, screenshotLocation, sucessCount, "EmploymenHumanResources", test, doc);
            generic.GenericCheveronClick("13");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("15");
            submitApp.CompanyInformationInput(
                "Insurance Co.",
                "9483924",
                "Address Line One",
                "Address line two",
                "Charlotesvill",
                "VA",
                "23019",
                "Mike Adams",
                "8883930023");
            utility.RecordPassStatus("Company Information Input", Status.Pass, screenshotLocation, sucessCount, "CompanyInformationInput", test, doc);
            generic.GenericCheveronClick("15");
            generic.GenericCheveronClick("16");
            submitApp.PlanInformationInput(
                "COBRA",
                false,
                "01/01/2000",
                "Monthly",
                "200");
            utility.RecordPassStatus("Plan Information Input", Status.Pass, screenshotLocation, sucessCount, "PlaninformationInput", test, doc);
            generic.GenericCheveronClick("16");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("17");

            generic.GenericCheveronClick("18");
            submitApp.EmployeeInformationInput(
                "Employee",
                "Middle",
                "Worker",
                "4942005931",
                "01/01/1976",
                "01/01/2017",
                false,
                false,
                false);
            utility.RecordPassStatus("Employee Information Input", Status.Pass, screenshotLocation, sucessCount, "EmployeeInfomrationInput", test, doc);
            generic.GenericCheveronClick("18");
            generic.GenericCheveronClick("19");
            submitApp.EmployeeMemberInput(
                "Employee",
                "Middle",
                "Worker",
                DateTime.Now.ToString("MM/dd/yyyy"),
                "Guardian",
                true
                );
            utility.RecordPassStatus("Membership Input Sucess", Status.Pass, screenshotLocation, sucessCount, "MemberShipinputSucess", test, doc);
            generic.GenericCheveronClick("19");
            generic.GenericCheveronClick("20");
            submitApp.CoverageSelection(
                true,
                false,
                false,
                false,
                true,
                false,
                false);
            utility.RecordPassStatus("Coverage Input", Status.Pass, screenshotLocation, sucessCount, "CoverageInput", test, doc);
            generic.GenericCheveronClick("20");
            generic.GenericCheveronClick("21");
            submitApp.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            utility.RecordPassStatus("Open Enrollment Information Input", Status.Pass, screenshotLocation, sucessCount, "OpenEnrollmentInformation", test, doc);
            generic.GenericCheveronClick("21");
            generic.GenericCheveronClick("22");
            submitApp.InsuranceType(
                "Medical",
                "Big Insurance Co.",
                "Address One St.",
                "101",
                "Alexandria",
                "VA",
                "22314",
                "7034049911",
                "86903954");
            Thread.Sleep(2000);
            utility.RecordPassStatus("Insurance Type Input Medical", Status.Pass, screenshotLocation, sucessCount, "InsuranceTypeInputMedical", test, doc);
            submitApp.InsuranceType(
                "Dental",
                "Big Dental Co.",
                "Maker St.",
                "202",
                "Potamic",
                "VA",
                "22314",
                "7039837771",
                "86903954");
            Thread.Sleep(2000);
            utility.RecordPassStatus("Insurance Type Input Dental", Status.Pass, screenshotLocation, sucessCount, "InsuranceTypeInputDental", test, doc);
            Thread.Sleep(2000);
            submitApp.PlanBenifitsInput(
                true,
                "300",
                "1,200",
                true,
                false,
                false,
                true,
                true,
                false,
                true,
                false);
            utility.RecordPassStatus("Plan Benefits", Status.Pass, screenshotLocation, sucessCount, "PlanBenefits", test, doc);
            Thread.Sleep(2000);
            submitApp.ClickSave();
            Thread.Sleep(2000);
            generic.HoverByElement(workitem.txtWorkItemType);
            utility.RecordPassStatus("Case Completed", Status.Pass, screenshotLocation, sucessCount, "Case completed", test, doc);


        }

        /// <summary>
        /// Only Includes Critial Screenshots
        /// </summary>
        /// <param name="context"></param>
        /// <param name="doc"></param>
        /// <param name="testName"></param>
        /// <param name="screenshotLocation"></param>
        /// <param name="sucessCount"></param>
        /// <param name="test"></param>
        public void SubmitHIPPCaseLight(IWebDriver context, DocX doc, string testName, string screenshotLocation, int sucessCount, ExtentTest test)
        {
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            DateTime now = DateTime.Today;
            submitApp.ApplicationOverviewInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                Utility.RandomNumericString(9)


                );
            utility.RecordPassStatus("Input application Overview Sucess", Status.Pass, screenshotLocation, sucessCount, "ApplicationOverview", test, doc);
            generic.GenericCheveronClick("10");
            submitApp.HouseHoldInformationInput(
                "Self",
                "Test",
                "",
                "Person",
                now.AddYears(-35).ToString("MM/dd/yyyy"),
                "0298443004",
                "333402593",
                "Yes",
                "Yes");
            utility.RecordPassStatus("Household information input", Status.Pass, screenshotLocation, sucessCount, "HouseholdHiringInput", test, doc);
            generic.GenericCheveronClick("10");
            generic.GenericCheveronClick("9");
            submitApp.PolicyHolderEmployerInformationInput(
                "Test",
                "",
                "Person",
                "233 Buchanan St",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "7033482934",
                "7034449999",
                "2020001111",
                "TestPerson@gmail.com");
            generic.GenericCheveronClick("9");

            generic.GenericCheveronClick("11");
            generic.GenericCheveronClick("12");
            submitApp.EmploymentStatusHiringInput(
                true,
                now.AddYears(-9).ToString("MM/dd/yyyy"),
                false,
                true,
                false);
            generic.GenericCheveronClick("12");
            generic.GenericCheveronClick("13");
            submitApp.EmploymentHumanResourcesInformation(
                "Accenture",
                "101010101",
                "Made Up Street",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "Dale Dimmadone",
                "technology",
                "2022213300");
            generic.GenericCheveronClick("13");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("15");
            submitApp.CompanyInformationInput(
                "Insurance Co.",
                "9483924",
                "Address Line One",
                "Address line two",
                "Charlotesvill",
                "VA",
                "23019",
                "Mike Adams",
                "8883930023");
            generic.GenericCheveronClick("15");
            generic.GenericCheveronClick("16");
            submitApp.PlanInformationInput(
                "COBRA",
                false,
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                "200");
            generic.GenericCheveronClick("16");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("17");

            generic.GenericCheveronClick("18");
            submitApp.EmployeeInformationInput(
                "Employee",
                "Middle",
                "Worker",
                "4942005931",
                now.AddYears(-43).ToString("MM/dd/yyyy"),
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                false,
                false,
                false);
            generic.GenericCheveronClick("18");
            generic.GenericCheveronClick("19");
            submitApp.EmployeeMemberInput(
                "Employee",
                "Middle",
                "Worker",
                DateTime.Today.AddYears(-15).ToString("MM/dd/yyyy"),
                "Guardian",
                true
                );
            generic.GenericCheveronClick("19");
            generic.GenericCheveronClick("20");
            submitApp.CoverageSelection(
                true,
                false,
                false,
                false,
                true,
                false,
                false);
            generic.GenericCheveronClick("20");
            generic.GenericCheveronClick("21");
            submitApp.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            generic.GenericCheveronClick("21");
            generic.GenericCheveronClick("22");
            submitApp.InsuranceType(
                "Medical",
                "Big Insurance Co.",
                "Address One St.",
                "101",
                "Alexandria",
                "VA",
                "22314",
                "7034049911",
                "86903954");
            Thread.Sleep(2000);
            submitApp.InsuranceType(
                "Dental",
                "Big Dental Co.",
                "Maker St.",
                "202",
                "Potamic",
                "VA",
                "22314",
                "7039837771",
                "86903954");
            Thread.Sleep(2000);
            Thread.Sleep(2000);
            submitApp.PlanBenifitsInput(
                true,
                "300",
                "1,200",
                true,
                false,
                false,
                true,
                true,
                false,
                true,
                false);
            utility.RecordPassStatus("Plan Benefits", Status.Pass, screenshotLocation, sucessCount, "PlanBenefits", test, doc);
            Thread.Sleep(2000);
            submitApp.ClickSave();
            Thread.Sleep(2000);
            generic.HoverByElement(workitem.txtWorkItemType);
            utility.RecordPassStatus("Case Completed", Status.Pass, screenshotLocation, sucessCount, "Case completed", test, doc);


        }

        public void SubmitHIPPCaseRenewalLight(IWebDriver context, DocX doc, string testName, string screenshotLocation, int sucessCount, ExtentTest test)
        {
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            DateTime now = DateTime.Today;
            submitApp.ApplicationOverviewInput(
                DateTime.Today.AddMonths(+2).AddYears(-1).ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                Utility.RandomNumericString(9)


                );
            utility.RecordPassStatus("Input application Overview Sucess", Status.Pass, screenshotLocation, sucessCount, "ApplicationOverview", test, doc);
            generic.GenericCheveronClick("10");
            submitApp.HouseHoldInformationInput(
                "Self",
                "Test",
                "",
                "Person",
                now.AddYears(-35).ToString("MM/dd/yyyy"),
                "0298443004",
                "333402593",
                "Yes",
                "Yes");
            generic.GenericCheveronClick("10");
            generic.GenericCheveronClick("9");
            submitApp.PolicyHolderEmployerInformationInput(
                "Test",
                "",
                "Person",
                "233 Buchanan St",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "7033482934",
                "7034449999",
                "2020001111",
                "TestPerson@gmail.com");
            generic.GenericCheveronClick("9");

            generic.GenericCheveronClick("11");
            generic.GenericCheveronClick("12");
            submitApp.EmploymentStatusHiringInput(
                true,
                now.AddYears(-9).ToString("MM/dd/yyyy"),
                false,
                true,
                false);
            generic.GenericCheveronClick("12");
            generic.GenericCheveronClick("13");
            submitApp.EmploymentHumanResourcesInformation(
                "Accenture",
                "101010101",
                "Made Up Street",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "Dale Dimmadone",
                "technology",
                "2022213300");
            generic.GenericCheveronClick("13");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("15");
            submitApp.CompanyInformationInput(
                "Insurance Co.",
                "9483924",
                "Address Line One",
                "Address line two",
                "Charlotesvill",
                "VA",
                "23019",
                "Mike Adams",
                "8883930023");
            generic.GenericCheveronClick("15");
            generic.GenericCheveronClick("16");
            submitApp.PlanInformationInput(
                "COBRA",
                false,
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                "200");
            generic.GenericCheveronClick("16");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("17");

            generic.GenericCheveronClick("18");
            submitApp.EmployeeInformationInput(
                "Employee",
                "Middle",
                "Worker",
                "4942005931",
                now.AddYears(-43).ToString("MM/dd/yyyy"),
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                false,
                false,
                false);
            generic.GenericCheveronClick("18");
            generic.GenericCheveronClick("19");
            submitApp.EmployeeMemberInput(
                "Employee",
                "Middle",
                "Worker",
                DateTime.Today.AddYears(-15).ToString("MM/dd/yyyy"),
                "Guardian",
                true
                );
            generic.GenericCheveronClick("19");
            generic.GenericCheveronClick("20");
            submitApp.CoverageSelection(
                true,
                false,
                false,
                false,
                true,
                false,
                false);
            generic.GenericCheveronClick("20");
            generic.GenericCheveronClick("21");
            submitApp.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            generic.GenericCheveronClick("21");
            generic.GenericCheveronClick("22");
            submitApp.InsuranceType(
                "Medical",
                "Big Insurance Co.",
                "Address One St.",
                "101",
                "Alexandria",
                "VA",
                "22314",
                "7034049911",
                "86903954");
            Thread.Sleep(2000);
            submitApp.InsuranceType(
                "Dental",
                "Big Dental Co.",
                "Maker St.",
                "202",
                "Potamic",
                "VA",
                "22314",
                "7039837771",
                "86903954");
            Thread.Sleep(2000);
            Thread.Sleep(2000);
            submitApp.PlanBenifitsInput(
                true,
                "300",
                "1,200",
                true,
                false,
                false,
                true,
                true,
                false,
                true,
                false);
            Thread.Sleep(2000);
            submitApp.ClickSave();
            Thread.Sleep(2000);
            generic.HoverByElement(workitem.txtWorkItemType);

        }

        public void SubmitHIPPCaseSuperLight(string url, string userName, string passWord)
        {

            IWebDriver context = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            APHPHomePage loginPage = new APHPHomePage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            APHPHomePage homepage = new APHPHomePage(context);

            context.Url = url;
            context.Manage().Window.Maximize();
            DateTime now = DateTime.Now;
            loginPage.LoginPage(userName, passWord);
            landingPage.HippApplicationSearch();
            hIPPSearch.ClickBeginNewApp();
            submitApp.ApplicationOverviewInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                Utility.RandomNumericString(9)
                
                );
            generic.GenericCheveronClick("10");
            submitApp.HouseHoldInformationInput(
                "Self",
                "Test",
                "",
                "Person",
                now.AddYears(-35).ToString("MM/dd/yyyy"),
                "0298443004",
                "333402593",
                "Yes",
                "Yes");
            generic.GenericCheveronClick("10");
            generic.GenericCheveronClick("9");
            submitApp.PolicyHolderEmployerInformationInput(
                "Test",
                "",
                "Person",
                "233 Buchanan St",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "7033482934",
                "7034449999",
                "2020001111",
                "TestPerson@gmail.com");
            generic.GenericCheveronClick("9");

            generic.GenericCheveronClick("11");
            generic.GenericCheveronClick("12");
            submitApp.EmploymentStatusHiringInput(
                true,
                now.AddYears(-9).ToString("MM/dd/yyyy"),
                false,
                true,
                false);
            generic.GenericCheveronClick("12");
            generic.GenericCheveronClick("13");
            submitApp.EmploymentHumanResourcesInformation(
                "Accenture",
                "101010101",
                "Made Up Street",
                "Apt101",
                "Alexandria",
                "VA",
                "22314",
                "Dale Dimmadone",
                "technology",
                "2022213300");
            generic.GenericCheveronClick("13");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("15");
            submitApp.CompanyInformationInput(
                "Insurance Co.",
                "9483924",
                "Address Line One",
                "Address line two",
                "Charlotesvill",
                "VA",
                "23019",
                "Mike Adams",
                "8883930023");
            generic.GenericCheveronClick("15");
            generic.GenericCheveronClick("16");
            submitApp.PlanInformationInput(
                "COBRA",
                false,
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                "200");
            generic.GenericCheveronClick("16");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("17");

            generic.GenericCheveronClick("18");
            submitApp.EmployeeInformationInput(
                "Employee",
                "Middle",
                "Worker",
                "4942005931",
                now.AddYears(-43).ToString("MM/dd/yyyy"),
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                false,
                false,
                false);
            generic.GenericCheveronClick("18");
            generic.GenericCheveronClick("19");
            submitApp.EmployeeMemberInput(
                "Employee",
                "Middle",
                "Worker",
                DateTime.Today.AddYears(-15).ToString("MM/dd/yyyy"),
                "Guardian",
                true
                );
            generic.GenericCheveronClick("19");
            generic.GenericCheveronClick("20");
            submitApp.CoverageSelection(
                true,
                false,
                false,
                false,
                true,
                false,
                false);
            generic.GenericCheveronClick("20");
            generic.GenericCheveronClick("21");
            submitApp.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            generic.GenericCheveronClick("21");
            generic.GenericCheveronClick("22");
            submitApp.InsuranceType(
                "Medical",
                "Big Insurance Co.",
                "Address One St.",
                "101",
                "Alexandria",
                "VA",
                "22314",
                "7034049911",
                "86903954");
            submitApp.InsuranceType(
                "Dental",
                "Big Dental Co.",
                "Maker St.",
                "202",
                "Potamic",
                "VA",
                "22314",
                "7039837771",
                "86903954");
            submitApp.PlanBenifitsInput(
                true,
                "300",
                "1,200",
                true,
                false,
                false,
                true,
                true,
                false,
                true,
                false);
            submitApp.ClickSave();
            generic.HoverByElement(workitem.txtWorkItemType);


        }


    }
}
