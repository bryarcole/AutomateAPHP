using NUnit.Tests1.Pages;
using OpenQA.Selenium;
using NUnit.Tests1.Utilities;
using System;
using System.Threading;
using Xceed.Words.NET;
using static NUnit.Tests1.Pages.MemberPortal.HIPPSubmitApplicationPageMember;
using NUnit.Tests1.Pages.MemberPortal;

namespace NUnit.Tests1.Steps
{
    public class CreateHIPPApplicationMember
    {
        public void SubmitHIPPCaseSubmissionMember(IWebDriver context, string screenshotLocation, DocX doc)
        {

            #region Pages and Sections
            EmployeeStatusAndHiringDetails employeeStatusAndHiringDetails = new EmployeeStatusAndHiringDetails(context);
            HouseholdInformation householdInformation = new HouseholdInformation(context);
            HIPPSubmitApplicationPageMember submitApp = new HIPPSubmitApplicationPageMember(context);
            CompanyInformation companyInformation = new CompanyInformation(context);
            PlanInformation planInformation = new PlanInformation(context);
            EmployerAndResourcesInformation employerAndResourcesInformation = new EmployerAndResourcesInformation(context);
            PolicyHolderEmployeeInformation policyHolderEmployeeInformation = new PolicyHolderEmployeeInformation(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            #endregion
            DateTime now = DateTime.Today;
            #region Required Input
            utility.RecordStepStatusMAIN("Input application Overview Sucess", screenshotLocation,  "ApplicationOverview", doc);
            householdInformation.HouseHoldInformationInput(
                "Self",
                "Test",
                "",
                "Person",
                now.AddYears(-35).ToString("MM/dd/yyyy"),
                "0298443004",
                "333402593",
                "Yes",
                "Yes");
            policyHolderEmployeeInformation.PolicyHolderEmployerInformationInput(
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
            employerAndResourcesInformation.EmploymentHumanResourcesInformationInput(
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
            companyInformation.CompanyInformationInput(
                "Insurance Co.",
                utility.RandomNumericString(9),
                "Address Line One",
                "Address line two",
                "Charlotesvill",
                "VA",
                "23019",
                "Mike Adams",
                "8883930023");
            planInformation.PlanInformationInput(
                "COBRA",
                "No",
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                utility.RandomNumericString(3));

            submitApp.ClickAgree();
            Thread.Sleep(2000);
            submitApp.ClickSave();


            Thread.Sleep(2000);
            utility.RecordStepStatus("Application Saved", screenshotLocation, "ApplicationSaveStatus", doc);
            #endregion

            #region Approve/Deny/Pend Logic

            #endregion
        }
        public void SubmitHIPPCaseSubmissionMember(IWebDriver context)
        {

            #region Pages and Sections
            EmployeeStatusAndHiringDetails employeeStatusAndHiringDetails = new EmployeeStatusAndHiringDetails(context);
            HouseholdInformation householdInformation = new HouseholdInformation(context);
            HIPPSubmitApplicationPageMember submitApp = new HIPPSubmitApplicationPageMember(context);
            CompanyInformation companyInformation = new CompanyInformation(context);
            PlanInformation planInformation = new PlanInformation(context);
            EmployerAndResourcesInformation employerAndResourcesInformation = new EmployerAndResourcesInformation(context);
            PolicyHolderEmployeeInformation policyHolderEmployeeInformation = new PolicyHolderEmployeeInformation(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            #endregion
            DateTime now = DateTime.Today;
            #region Required Input
            householdInformation.HouseHoldInformationInput(
                "Self",
                "No",
                utility.GetRandomFirstName(),
                "",
                utility.GetRandomSurName(),
                now.AddYears(-35).ToString("MM/dd/yyyy"),
                utility.RandomNumberAlphaString(10),
                utility.RandomNumericString(10),
                utility.GetRandomYesNo(),
                utility.GetRandomYesNo()
                );
            policyHolderEmployeeInformation.PolicyHolderEmployerInformationInput(
                "No",
                "",
                utility.GetRandomFirstName(),
                utility.GetRandomFirstName(),
                utility.GetRandomSurName(),
                "233 buchanan",
                "",
                utility.GetRandomCity(),
                "VA",
                "22314",
                "202" + utility.RandomNumericString(7),
                "703" + utility.RandomNumericString(7),
                "703" + utility.RandomNumericString(7),
                "TestPerson@gmail.com");
            employerAndResourcesInformation.EmploymentHumanResourcesInformationInput(
                utility.GetRandomCompanyName(),
                utility.RandomNumericString(9),
                "Made Up Street",
                "Apt101",
                utility.GetRandomCity(),
                "VA",
                "22314",
                utility.GetRandomFirstName() + utility.GetRandomSurName(),
                "technology",
                "703" + utility.RandomNumericString(7));
            employeeStatusAndHiringDetails.EmploymentStatusHiringInput(
                utility.GetRandomYesNo(),
                now.AddYears(-5).ToString("MM/dd/yyyy"),
                utility.GetRandomYesNo(),
                "No",
                null
                );
            companyInformation.CompanyInformationInput(
                utility.GetRandomCompanyName(),
                utility.RandomNumericString(9),
                "Address Line One",
                "Address line two",
                utility.GetRandomCity(),
                "VA",
                "23019",
                utility.GetRandomFirstName() + utility.GetRandomSurName(),
                "301" + utility.RandomNumericString(7));
            planInformation.PlanInformationInput(
                utility.GetRandomInsuranceType(),
                utility.GetRandomYesNo(),
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                utility.RandomNumericString(3));

            submitApp.ClickAgree();
            Thread.Sleep(2000);
            submitApp.ClickSave();


            Thread.Sleep(2000);
            #endregion

            #region Approve/Deny/Pend Logic

            #endregion
        }
    }
}
