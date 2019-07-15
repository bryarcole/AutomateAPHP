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
        public void SubmitHIPPCaseSubmissionUltimate(IWebDriver context, bool renewal, string screenshotLocation, DocX doc)
        {
            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            DateTime now = DateTime.Today;
            #region New or Renewal Logic
            if (renewal)
            {
                submitApp.ApplicationOverviewInput(
                    DateTime.Today.AddMonths(+2).AddYears(-1).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    utility.RandomNumericString(9)
                    )   ;
            }
            else
            {
                submitApp.ApplicationOverviewInput(
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    utility.RandomNumericString(9)
                    );
            }
#endregion

            #region Required Input
            utility.RecordStepStatusMAIN("Input application Overview Sucess", screenshotLocation,  "ApplicationOverview", doc);
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
                utility.RandomNumericString(3));
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

            utility.RecordStepStatus("Application Saved", screenshotLocation, "ApplicationSaveStatus", doc);
            #endregion

            #region Approve/Deny/Pend Logic

            #endregion
        }


    }
}
