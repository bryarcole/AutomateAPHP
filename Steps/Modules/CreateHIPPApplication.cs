using NUnit.Tests1.Pages;
using OpenQA.Selenium;
using NUnit.Tests1.Utilities;
using System;
using System.Threading;
using Xceed.Words.NET;
using NUnit.Tests1.Pages.WorkerPortal;
using static NUnit.Tests1.Pages.WorkerPortal.HIPPSubmitApplicationPage;


namespace NUnit.Tests1.Steps
{
    public class CreateHIPPApplication
    {
        public void SubmitHIPPCaseSubmissionUltimate(IWebDriver context, bool renewal, string screenshotLocation, DocX doc)
        {

            #region Pages and Sections
            HouseholdInformation householdInformation = new HouseholdInformation(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
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
            generic.GenericCheveronClick("10");
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
            generic.GenericCheveronClick("10");
            generic.GenericCheveronClick("9");
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
            generic.GenericCheveronClick("9");

            generic.GenericCheveronClick("11");
            generic.GenericCheveronClick("12");
            hiringdetails.EmploymentStatusHiringInput(
                "Yes",
                now.AddYears(-9).ToString("MM/dd/yyyy"),
                "No",
                "Yes",
                "No");
            generic.GenericCheveronClick("12");
            generic.GenericCheveronClick("13");
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
            generic.GenericCheveronClick("13");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("15");
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
            generic.GenericCheveronClick("15");
            generic.GenericCheveronClick("16");
            planInformation.PlanInformationInput(
                "COBRA",
                "No",
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                utility.RandomNumericString(3));
            generic.GenericCheveronClick("16");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("17");

            generic.GenericCheveronClick("18");
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
            generic.GenericCheveronClick("18");
            generic.GenericCheveronClick("19");
            membershipInformation.EmployeeMemberInput(
                "No",
                "Employee",
                "Middle",
                "Worker",
                DateTime.Today.AddYears(-15).ToString("MM/dd/yyyy"),
                "Guardian"
                
                );
            generic.GenericCheveronClick("19");
            generic.GenericCheveronClick("20");
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));

            generic.GenericCheveronClick("20");
            generic.GenericCheveronClick("21");
            openEnrollmentInformation.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            generic.GenericCheveronClick("21");
            generic.GenericCheveronClick("22");
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
            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));
            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));
            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));

            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));

            Thread.Sleep(2000);
            submitApp.ClickSave();


            Thread.Sleep(2000);
            generic.HoverByElement(workitem.txtWorkItemType);

            utility.RecordStepStatus("Application Saved", screenshotLocation, "ApplicationSaveStatus", doc);
            #endregion

            #region Approve/Deny/Pend Logic

            #endregion
        }
        public void SubmitHIPPCaseSubmissionUltimate(IWebDriver context, bool renewal)
        {

            #region Pages and Sections
            HouseholdInformation householdInformation = new HouseholdInformation(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
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
            generic.GenericCheveronClick("10");
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
            generic.GenericCheveronClick("10");
            generic.GenericCheveronClick("9");
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
            generic.GenericCheveronClick("9");

            generic.GenericCheveronClick("11");
            generic.GenericCheveronClick("12");
            hiringdetails.EmploymentStatusHiringInput(
                "Yes",
                now.AddYears(-9).ToString("MM/dd/yyyy"),
                "No",
                "Yes",
                "No");
            generic.GenericCheveronClick("12");
            generic.GenericCheveronClick("13");
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
            generic.GenericCheveronClick("13");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("15");
            companyInformation.CompanyInformationInput(
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
            planInformation.PlanInformationInput(
                "COBRA",
                "No",
                now.AddYears(-12).ToString("MM/dd/yyyy"),
                "Monthly",
                utility.RandomNumericString(3));
            generic.GenericCheveronClick("16");
            generic.GenericCheveronClick("14");
            generic.GenericCheveronClick("17");

            generic.GenericCheveronClick("18");
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
            generic.GenericCheveronClick("18");
            generic.GenericCheveronClick("19");
            membershipInformation.EmployeeMemberInput(
                "Employee",
                "Middle",
                "Worker",
                DateTime.Today.AddYears(-15).ToString("MM/dd/yyyy"),
                "Guardian",
                "No"
                );
            generic.GenericCheveronClick("19");
            generic.GenericCheveronClick("20");
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));
            coverageAreasInformation.CoverageSelection(utility.RandomNumericString(1));

            generic.GenericCheveronClick("20");
            generic.GenericCheveronClick("21");
            openEnrollmentInformation.OpenEnrollmentInformationInput(
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy"),
                DateTime.Today.ToString("MM/dd/yyyy")
                );
            Thread.Sleep(2000);
            generic.GenericCheveronClick("21");
            generic.GenericCheveronClick("22");
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
            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));
            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));
            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));
            planBenefit.SelectPlansBenefitsCoverage(utility.RandomNumericString(1));
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
