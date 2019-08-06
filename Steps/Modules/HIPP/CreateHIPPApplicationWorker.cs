using NUnit.Tests1.Pages;
using OpenQA.Selenium;
using NUnit.Tests1.Utilities;
using System;
using System.Threading;
using Xceed.Words.NET;
using NUnit.Tests1.Pages.WorkerPortal;
using static NUnit.Tests1.Pages.WorkerPortal.HIPPSubmitApplicationPageWorker;


namespace NUnit.Tests1.Steps
{
    public class CreateHIPPApplicationWorker
    {
        public void SubmitHIPPCaseSubmissionWorker(IWebDriver context, bool renewal, string screenshotLocation, DocX doc)
        {

            #region Pages and Sections
            HouseholdInformation householdInformation = new HouseholdInformation(context);
            HIPPSubmitApplicationPageWorker submitApp = new HIPPSubmitApplicationPageWorker(context);
            ApplicationOverview applicationOverview = new ApplicationOverview(context);
            EmploymentStatusHiringDetails hiringdetails = new EmploymentStatusHiringDetails(context);
            CompanyInformation companyInformation = new CompanyInformation(context);
            PlanInformation planInformation = new PlanInformation(context);
            CoverageAreasInformation coverageAreasInformation = new CoverageAreasInformation(context);
            OpenEnrollmentInformation openEnrollmentInformation = new OpenEnrollmentInformation(context);
            InsuranceType insuranceType = new InsuranceType(context);
            PlanBenefit planBenefit = new PlanBenefit(context);
            EmployerAndResourcesInformation employerAndResourcesInformation = new EmployerAndResourcesInformation(context);
            PolicyHolderEmployeeInformation policyHolderEmployeeInformation = new PolicyHolderEmployeeInformation(context);
            EmployeeInformation employeeInformation = new EmployeeInformation(context);
            MembershipInformation membershipInformation = new MembershipInformation(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            #endregion
            DateTime now = DateTime.Today;
            #region New or Renewal Logic
            if (renewal)
            {
                applicationOverview.ApplicationOverviewInput(
                    DateTime.Today.AddMonths(+2).AddYears(-1).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    utility.RandomNumericString(9),
                    "New"
                    )   ;
            }
            else
            {
                applicationOverview.ApplicationOverviewInput(
                    now.ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy"),
                    DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    utility.RandomNumericString(9),
                    "New"
                    );
            }
#endregion

            #region Required Input
            utility.RecordStepStatusMAIN("Input application Overview Sucess", screenshotLocation,  "ApplicationOverview", doc);
            generic.CheveronClick("10");
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
            generic.CheveronClick("10");
            generic.CheveronClick("9");
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
            generic.CheveronClick("9");

            generic.CheveronClick("11");
            generic.CheveronClick("12");
            hiringdetails.EmploymentStatusHiringInput(
                "Yes",
                now.AddYears(-9).ToString("MM/dd/yyyy"),
                "No",
                "Yes",
                "No");
            generic.CheveronClick("12");
            generic.CheveronClick("13");
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
            generic.CheveronClick("13");
            generic.CheveronClick("14");
            generic.CheveronClick("15");
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
            generic.CheveronClick("15");
            generic.CheveronClick("16");
            planInformation.PlanInformationInput(
                utility.GetRandomInsuranceType(),
                "No",
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                utility.RandomNumericString(3));
            generic.CheveronClick("16");
            generic.CheveronClick("14");
            generic.CheveronClick("17");

            generic.CheveronClick("18");
            employeeInformation.EmployeeInformationInput(
                "Employee",
                "Middle",
                "Worker",
                utility.RandomNumericString(9),
                now.AddYears(-43).ToString("MM/dd/yyyy"),
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "No",
                "No",
                "No");
            generic.CheveronClick("18");
            generic.CheveronClick("19");
            membershipInformation.EmployeeMemberInput(
                "Yes",
                utility.GetRandomFirstName(),
                "Middle",
                utility.GetRandomSurName(),
                DateTime.Today.AddYears(-25).ToString("MM/dd/yyyy"),
                "Guardian"
                ); 
            generic.CheveronClick("19");
            generic.CheveronClick("20");
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));

            generic.CheveronClick("20");
            generic.CheveronClick("21");
            openEnrollmentInformation.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            generic.CheveronClick("21");
            generic.CheveronClick("22");
            insuranceType.InsuranceTypeInput(
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
            insuranceType.InsuranceTypeInput(
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
            planBenefit.PlanBenifitsInput(
                "Yes",
                "300",
                "1,200"
                );
            planBenefit.SelectTypeOfHealthPlan(utility.RandomNumericString(1));
            planBenefit.SelectTypeOfHealthPlan(utility.RandomNumericString(1));
            planBenefit.SelectTypeOfHealthPlan(utility.RandomNumericString(1));

            planBenefit.SelectTypeOfHealthPlan(utility.RandomNumericString(1));

            Thread.Sleep(2000);
            submitApp.ClickSave();


            Thread.Sleep(2000);
            generic.HoverByElement(workitem.txtWorkItemType);

            utility.RecordStepStatus("Application Saved", screenshotLocation, "ApplicationSaveStatus", doc);
            #endregion

            #region Approve/Deny/Pend Logic

            #endregion
        }
        public void SubmitHIPPCaseSubmissionWorker(IWebDriver context, bool renewal)
        {

            #region Pages and Sections
            HouseholdInformation householdInformation = new HouseholdInformation(context);
            HIPPSubmitApplicationPageWorker submitApp = new HIPPSubmitApplicationPageWorker(context);
            ApplicationOverview applicationOverview = new ApplicationOverview(context);
            EmploymentStatusHiringDetails hiringdetails = new EmploymentStatusHiringDetails(context);
            CompanyInformation companyInformation = new CompanyInformation(context);
            PlanInformation planInformation = new PlanInformation(context);
            CoverageAreasInformation coverageAreasInformation = new CoverageAreasInformation(context);
            OpenEnrollmentInformation openEnrollmentInformation = new OpenEnrollmentInformation(context);
            InsuranceType insuranceType = new InsuranceType(context);
            PlanBenefit planBenefit = new PlanBenefit(context);
            EmployerAndResourcesInformation employerAndResourcesInformation = new EmployerAndResourcesInformation(context);
            PolicyHolderEmployeeInformation policyHolderEmployeeInformation = new PolicyHolderEmployeeInformation(context);
            EmployeeInformation employeeInformation = new EmployeeInformation(context);
            MembershipInformation membershipInformation = new MembershipInformation(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            #endregion
            DateTime now = DateTime.Today;
            #region New or Renewal Logic
            if (renewal)
            {
                applicationOverview.ApplicationOverviewInput(
                    DateTime.Today.AddMonths(+2).AddYears(-1).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    utility.RandomNumericString(9),
                    "New"
                    );
            }
            else
            {
                applicationOverview.ApplicationOverviewInput(
                    now.ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy"),
                    DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"),
                    DateTime.Today.ToString("MM/dd/yyyy"),
                    utility.RandomNumericString(9),
                    "New"
                    );
            }
            #endregion

            #region Required Input
            generic.CheveronClick("10");
            householdInformation.HouseHoldInformationInput(
                "Self",
                utility.GetRandomFirstName(),
                "",
                utility.GetRandomSurName(),
                now.AddYears(-35).ToString("MM/dd/yyyy"),
                utility.RandomNumberAlphaString(10),
                utility.RandomNumericString(9),
                "Yes",
                "Yes"); ;
            generic.CheveronClick("10");
            generic.CheveronClick("9");
            policyHolderEmployeeInformation.PolicyHolderEmployerInformationInput(
                utility.GetRandomFirstName(),
                "",
                utility.GetRandomSurName(),
                "233 Buchanan St",
                "Apt101",
                utility.GetRandomCity(),
                "VA",
                "22314",
                "703" + utility.RandomNumericString(7),
                "703" + utility.RandomNumericString(7),
                "202" + utility.RandomNumericString(7),
                "TestPerson@gmail.com"); ;
            generic.CheveronClick("9");

            generic.CheveronClick("11");
            generic.CheveronClick("12");
            hiringdetails.EmploymentStatusHiringInput(
                "Yes",
                now.AddYears(-9).ToString("MM/dd/yyyy"),
                "No",
                "Yes",
                "No");
            generic.CheveronClick("12");
            generic.CheveronClick("13");
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
                "2022213300"); ;
            generic.CheveronClick("13");
            generic.CheveronClick("14");
            generic.CheveronClick("15");
            companyInformation.CompanyInformationInput(
                utility.GetRandomCompanyName(),
                utility.RandomNumericString(9),
                "Address Line One",
                "Address line two",
                utility.GetRandomCity(),
                "VA",
                "23019",
                utility.GetRandomFirstName() + utility.GetRandomSurName(),
                "8883930023"); ;
            generic.CheveronClick("15");
            generic.CheveronClick("16");
            planInformation.PlanInformationInput(
                "COBRA",
                "No",
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                utility.RandomNumericString(3));
            generic.CheveronClick("16");
            generic.CheveronClick("14");
            generic.CheveronClick("17");

            generic.CheveronClick("18");
            employeeInformation.EmployeeInformationInput(
                "Employee",
                "Middle",
                "Worker",
                "4942005931",
                now.AddYears(-43).ToString("MM/dd/yyyy"),
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "No",
                "No",
                "No");
            generic.CheveronClick("18");
            generic.CheveronClick("19");
            membershipInformation.EmployeeMemberInput(
                "No",
                utility.GetRandomFirstName(),
                "Middle",
                utility.GetRandomSurName(),
                DateTime.Today.AddYears(-25).ToString("MM/dd/yyyy"),
                "Guardian"
                );
            generic.CheveronClick("19");
            generic.CheveronClick("20");
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));

            generic.CheveronClick("20");
            generic.CheveronClick("21");
            openEnrollmentInformation.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            generic.CheveronClick("21");
            generic.CheveronClick("22");
            insuranceType.InsuranceTypeInput(
                "Medical",
                utility.GetRandomCompanyName(),
                "Address One St.",
                "101",
                "Alexandria",
                "VA",
                "22314",
                "7034049911",
                "86903954");
            Thread.Sleep(2000);
            insuranceType.InsuranceTypeInput(
                "Dental",
                utility.GetRandomCompanyName(),
                "Maker St.",
                "202",
                utility.GetRandomCity(),
                "VA",
                "22" + utility.RandomNumericString(3),
                "7039837771",
                "86903954");
            Thread.Sleep(2000);
            planBenefit.PlanBenifitsInput(
                "Yes",
                utility.RandomNumericString(3),
                utility.RandomNumericString(4)
                );
            planBenefit.SelectTypeOfHealthPlan(utility.RandomNumericString(1));
            planBenefit.SelectTypeOfHealthPlan(utility.RandomNumericString(1));
            planBenefit.SelectServicesUnderHealthPlan(utility.RandomNumericString(1));
            planBenefit.SelectServicesUnderHealthPlan(utility.RandomNumericString(1));
            Thread.Sleep(2000);
            submitApp.ClickSave();
            Thread.Sleep(2000);
            generic.HoverByElement(workitem.txtWorkItemType);
            #endregion

            #region Approve/Deny/Pend Logic

            #endregion
        }

    }
}
