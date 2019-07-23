//using NUnit.Tests1.Steps;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.Events;
//using OpenQA.Selenium.Support.PageObjects;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using NUnit.Tests1.Utilities;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Configuration;
//using NUnit.Tests1.Pages.WorkerPortal;

//namespace NUnit.Tests1.Pages.WorkerPortal
//{
//    public class HIPPWorkerPortalNegativeValidation : HIPPSubmitApplicationPage
//    {

//        IWebDriver context;
//        public HIPPWorkerPortalNegativeValidation(IWebDriver context) : base(context)
//        {
//            this.context = context;
//            PageFactory.InitElements(context, this);
//        }


//        string randomSpecial8CharacterString = Utility.RandomNumericStringStatic(8);
//        string random51CharacterString = Utility.RandomAlphaNumericSpecialCharacterStringStatic(51);
//        string random101CharacterString = Utility.RandomAlphaNumericSpecialCharacterStringStatic(101);
//        public void ValidateApplicationOverveiw(ExtentTest test, Utility utility)
//        {

            
//            #region Generate Random Nums
//            string randomSpecial8CharacterString = utility.RandomSpecialCharacterString(8);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            #endregion
//            #region Application Recieve Date Negative Check
//            ApplicationRecieveDateOverlay.Click();
//            ApplicationReceiveDate.SendKeys(randomSpecial8CharacterString);

//            if(ApplicationReceiveDate.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("Application Recieve Date Accepting Special Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Application Recieve Date not accepting Special Characters", Status.Pass, test);
//            }
//            #endregion
//            #region EIV Recieve Date
//            EIVRecievedDateOverlay.Click();
//            EIVRecieveDate.SendKeys(randomSpecial8CharacterString);

//            if (EIVRecieveDate.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Annual Renewal Date
//            AnnualRenewalDatesOverlay.Click();
//            AnnualRenewalDates.SendKeys(randomSpecial8CharacterString);

//            if (AnnualRenewalDates.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Annual To Date
//            AnnualToDateOverlay.Click();
//            AnnualToDate.SendKeys(randomSpecial8CharacterString);

//            if (AnnualToDate.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Queaterly Validation Due Dates
//            QuarterlyValidationDueDatesOverlay.Click();
//            QuarterlyValidationDueDates.SendKeys(randomSpecial8CharacterString);

//            if (QuarterlyValidationDueDates.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region HIPP Case Number
//            HIPPCaseNo.Click();
//            HIPPCaseNo.SendKeys(random51CharacterString);

//            if (HIPPCaseNo.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("HIPP Case No. Not Accepting more than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region Application Type Field
//            ApplicationType.SendKeys("Renewal");

//            if (ApplicationType.Text == "Renewal")
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion

//        }        
//        /// <summary>
//        /// Cheveron ID: 9
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidatePolicyHolderEmployerInformaton(ExtentTest test, Utility utility)
//        {

//            CreateHIPPApplication app = new CreateHIPPApplication();

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(10);
//            #endregion
//            #region First Name Field
//            FirstName.SendKeys(random51CharacterString);

//            if (txtFirstName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region MiddleName Field
//            txtMiddleName.SendKeys(random51CharacterString);

//            if (txtMiddleName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region LastName Field
//            txtLastName.SendKeys(random51CharacterString);

//            if (txtLastName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region AddressOne Field
//            txtAddOne.SendKeys(random51CharacterString);

//            if (txtAddOne.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region AddressTwo Field 
//            txtAddTwo.SendKeys(random51CharacterString);

//            if (txtAddTwo.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region City Field 
//            txtCity.SendKeys(random51CharacterString);

//            if (txtCity.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region State Input
//            app.State_Input.SendKeys(randomNumericSpecialString);

//            if (State_Input.Text == randomNumericSpecialString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Zipcode
//            txtZipCodeOverlay.Click();
//            txtZipCode.SendKeys(randomSpecial8CharacterString);

//            if (txtZipCode.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region HomePhone Field 
//            HomePhoneOverlay.Click();
//            HomePhone.SendKeys(randomSpecial8CharacterString);

//            if (HomePhone.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Cellphone Fields
//            CellPhoneOverlay.Click();
//            CellPhone.SendKeys(randomSpecial10CharacterString);

//            if (CellPhone.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region WorkPhone Fields
//            WorkPhoneOverlay.Click();
//            WorkPhone.SendKeys(randomSpecial10CharacterString);

//            if (WorkPhone.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Email Field
//            txtEmail.SendKeys(random51CharacterString);

//            if (txtEmail.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//        }
//        /// <summary>
//        /// Cheveron ID: 10
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateHouseHoldInformationInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(10);
//            #endregion

//            HouseHoldAdd.Click();
//            Thread.Sleep(4000);

//            #region Relation
//            Relation.Click();
//            Relation.SendKeys(randomSpecial10CharacterString);
//            Relation.SendKeys(Keys.Tab);
//            if (Relation.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region FirstName Field
//            txtFirstNameHHI.SendKeys(random51CharacterString);

//            if (txtFirstNameHHI.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region MiddleName Field
//            txtMiddleNameHHI.SendKeys(random51CharacterString);

//            if (txtMiddleNameHHI.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Lastname Field
//            txtLastNameHHI.SendKeys(random51CharacterString);

//            if (txtLastNameHHI.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region DOB Field
//            DOBHHI_wrapperOverlay.Click();
//            dpDOBHHI_dateInput.SendKeys(randomSpecial10CharacterString);

//            if (dpDOBHHI_dateInput.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region HeadofHousehold Field 
//            HouseholdInformationMemberID.SendKeys(random51CharacterString);

//            if (HouseholdInformationMemberID.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region SSN Input
//            txtSSN_wrapper.Click();
//            txtSSN.SendKeys(randomNumericSpecialString);

//            if (txtSSN.Text == randomNumericSpecialString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Medicare Status Yes Radio button
//            PersonMedicareYesRadioButton.Click();
//            if (PersonMedicareYesRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Medicare Status No Radio button
//            PersonMedicareNoRadioButton.Click();
//            if (PersonMedicareNoRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Insurance Status Yes Radio button
//            YesPersonCoveredInsurance.Click();
//            if (YesPersonCoveredInsurance.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Insurance Status No Radio button
//            NoPersonCoveredInsurance.Click();
//            if (NoPersonCoveredInsurance.Selected == false)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
           
//        }
//        /// <summary>
//        /// Cheveron ID: 11 > 12
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateEmploymentStatusHiringInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(10);
//            #endregion
//            Thread.Sleep(2000);

//            #region Date input
//            txtDateHired_dateInput_wrapper.Click();
//            DateHired_dateInput.SendKeys(randomSpecial10CharacterString);
//            if (Relation.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting Special Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion


//            #region Retirement Status
//            RetiredYes.Click();
//            if (RetiredYes.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            RetiredNo.Click();
//            if (RetiredNo.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region School Employment
//            SchoolEmpYes.Click();
//            Thread.Sleep(2000);
//            if (SchoolEmpYes.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            SchoolEmpNo.Click();
//            Thread.Sleep(2000);
//            if (SchoolEmpNo.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion 
//            #region SchoolEmployment Peiod
//            SchoolEmpYes.Click();
//            Thread.Sleep(2000);

//            SchoolEmpPeriod.Click();
//            if (SchoolEmpPeriod.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Clicked Button", Status.Pass, test);
//            }
//            SchoolEmpPeriod2.Click();
//            if (SchoolEmpPeriod2.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Clicked Button", Status.Pass, test);
//            }
//            #endregion
//        }
//        /// <summary>
//        /// Cheveron ID: 11 > 13
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateEmploymentHumanResourcesInformationInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string randomSpecial9CharacterString = utility.RandomSpecialCharacterString(9);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(10);
//            #endregion


//            #region Employer Name
//            txtEmployerName.SendKeys(random51CharacterString);

//            if (txtEmployerName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region FEd Employ number Field
//            txtFedEmp.SendKeys(randomSpecial10CharacterString);

//            if (txtFedEmp.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region txtEmpAddOne Field
//            txtEmpAddOne.SendKeys(random51CharacterString);

//            if (txtEmpAddOne.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region txtEmpAddTwo Field
//            txtEmpAddTwo.SendKeys(random51CharacterString);

//            if (txtEmpAddTwo.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region City Field

//            txtEmpCity.SendKeys(random51CharacterString);

//            if (txtEmpCity.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region State Field 
//            EmpState_Input.SendKeys(random51CharacterString);

//            if (EmpState_Input.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region ZipCode Input
//            txtEmpZip_wrapper.Click();
//            txtEmpZip.SendKeys(randomSpecial9CharacterString);

//            if (txtEmpZip.Text == randomSpecial9CharacterString)
//            {
//                utility.RecordSimpleStatus("Zipcode not accepting spcial Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Human Resources Rep field
//            txtHuman.SendKeys(random51CharacterString);
//            if (txtHuman.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region Department field
//            txtDepartment.SendKeys(random51CharacterString);
//            if (txtDepartment.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region Phone number field
//            txtPhoneNum_wrapper.Click();
//            txtPhoneNum.SendKeys(randomSpecial10CharacterString);
//            if (txtPhoneNum.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting 10 Special Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("NOT Accepting 10 Special Characters", Status.Pass, test);
//            }
//            #endregion
//        }

//        /// <summary>
//        /// Cheveron ID: 14 > 15
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateCompanyInformationInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string randomSpecial9CharacterString = utility.RandomSpecialCharacterString(9);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            #endregion

//            #region Employer Name
//            txtCompName.SendKeys(random51CharacterString);

//            if (txtCompName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region FEd Employ number Field
//            txtFEIN.SendKeys(randomSpecial10CharacterString);

//            if (txtFEIN.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region txtCompAddOne Field
//            txtCompAddOne.SendKeys(random51CharacterString);

//            if (txtCompAddOne.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region txtEmpAddTwo Field
//            txtCompAddTwo.SendKeys(random51CharacterString);

//            if (txtCompAddTwo.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region City Field

//            txtCompCity.SendKeys(random51CharacterString);

//            if (txtCompCity.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region State Field 
//            CompState_Input.SendKeys(random51CharacterString);

//            if (CompState_Input.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region ZipCode Input
//            txtCompZip.Click();
//            txtCompZip.SendKeys(randomSpecial9CharacterString);

//            if (txtCompZip.Text == randomSpecial9CharacterString)
//            {
//                utility.RecordSimpleStatus("Zipcode not accepting spcial Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Contact person field
//            txtContactPer.SendKeys(random51CharacterString);
//            if (txtContactPer.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region Department field
//            txtCompPhoneNum.Click();
//            txtCompPhoneNum.SendKeys(random51CharacterString);
//            if (txtCompPhoneNum.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//        }

//        /// <summary>
//        /// Cheveron ID: 14 > 16
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidatePlanInformationInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string randomSpecial9CharacterString = utility.RandomSpecialCharacterString(9);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string randomNumbericString = utility.RandomNumericString(9);
//            #endregion

//            #region Employme Status
//            EmployerPlan.Click();
//            if (EmployerPlan.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            COBRARadio.Click();
//            if (COBRARadio.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region Individual Policy Radio button
//            IndividualPolicyRadioButton.Click();
//            if (IndividualPolicyRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion
//            #region Self Employed Yes/No
//            SelfemployedYesRadioButton.Click();

//            if (SelfemployedYesRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button Self Employed Button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Clicked button Self Employed Button", Status.Pass, test);
//            }
//            SelfEmployedNoRadioButton.Click();
   
//            if (SelfEmployedNoRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            SelfEmployedNARadioButton.Click();
//            if (SelfEmployedNARadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Clicked NA Button fail", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Clicked NA Button success", Status.Pass, test);
//            }
//            #endregion
//            #region Employer Name
//            dateInput_wrapper.Click();
//            PlanEff_dateInput.SendKeys(randomSpecial10CharacterString);

//            if (txtCompName.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting Proper Date", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion
//            #region Payer insurance Field
//            cboPayInsur_Input.SendKeys(randomSpecial10CharacterString);

//            if (cboPayInsur_Input.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Not accepting special characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            cboPayInsur_Input.SendKeys(Keys.Tab);
//            #endregion
//            #region Amount Paid Field
//            txtAmountPaid.SendKeys(randomNumbericString);
//            Thread.Sleep(2000);
//            if (txtAmountPaid.Text == randomNumbericString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//            #region plan effective date Field
//            PlanEff_dateInput.Click();
//            PlanEff_dateInput.SendKeys(randomSpecial8CharacterString);
//            if (PlanEff_dateInput.Text == randomSpecial8CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 50 characters", Status.Pass, test);
//            }
//            #endregion
//        }

//        /// <summary>
//        /// Cheveron ID: 17 > 18
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateEmployeeInformationInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(8);
//            #endregion
//            #region First Name Field
//            txtEmpFName.SendKeys(random51CharacterString);

//            if (txtEmpFName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region MiddleName Field
//            txtEmpMName.SendKeys(random51CharacterString);

//            if (txtEmpMName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region LastName Field
//            txtEmpLName.SendKeys(random51CharacterString);

//            if (txtEmpLName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }

//            #endregion
//            #region City Field 
//            txtEmpSSN_wrapper.Click();
//            txtEmpSSN.SendKeys(random51CharacterString);

//            if (txtEmpSSN.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region DOB Input
//            dpEmpDOB_dateInput_wrapper.Click();
//            EmpDOB_dateInput.SendKeys(randomNumericSpecialString);

//            if (State_Input.Text == randomNumericSpecialString)
//            {
//                utility.RecordSimpleStatus("Accepting special characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion
//            #region Date hired input
//            dpEmpDateH_dateInput_wrapper.Click();
//            EmpDateH_dateInput.SendKeys(randomNumericSpecialString);

//            if (txtZipCode.Text == randomNumericSpecialString)
//            {
//                utility.RecordSimpleStatus("Accepting special characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion
//            #region Retired Status
//            rbEmpRetired_0.Click();
//            if (rbEmpRetired_0.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            rbEmpRetired_1.Click();
//            if (rbEmpRetired_1.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region School Employment Status
//            EmployeeInformationSchoolEmpYes.Click();
//            Thread.Sleep(2000);
//            if (EmployeeInformationSchoolEmpYes.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            EmployeeInformationSchoolEmpNo.Click();
//            Thread.Sleep(2000);
//            if (EmployeeInformationSchoolEmpNo.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion
//            #region 10/12 Month Test Status
//            EmployeeInformationSchoolEmpYes.Click();
//            Thread.Sleep(2000);
//            SchoolEmployeeLength10Month.Click();
//            if (SchoolEmployeeLength10Month.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            SchoolEmployeeLength12Month.Click();
//            if (SchoolEmployeeLength12Month.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion

//        }
//        /// <summary>
//        /// Cheveron ID: 17 > 19
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateEmployeeMemberInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(8);
//            #endregion
//            btnMembershipAdd.Click();


//            #region First Name Field
//            txtMemFName.SendKeys(random51CharacterString);

//            if (txtMemFName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region MiddleName Field
//            txtMemMName.SendKeys(random51CharacterString);

//            if (txtMemMName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region LastName Field
//            txtMemLName.SendKeys(random51CharacterString);

//            if (txtMemLName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }

//            #endregion
//            #region PolicyHolder Input
//            cboRelPolHold_Input.SendKeys(randomNumericSpecialString);

//            if (State_Input.Text == randomNumericSpecialString)
//            {
//                utility.RecordSimpleStatus("Accepting special characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion
//            #region member DOB input
//            dpMemDOB_dateInput_wrapper.Click();
//            dpMemDOB_dateInput.SendKeys(randomNumericSpecialString);

//            if (dpMemDOB_dateInput.Text == randomNumericSpecialString)
//            {
//                utility.RecordSimpleStatus("Accepting special characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion
//            #region Enrolled in Plan Status
//            rbEnrPlan_0.Click();
//            Thread.Sleep(2000);
//            if (rbEnrPlan_0.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            rbEnrPlan_1.Click();
//            Thread.Sleep(2000);
//            if (rbEnrPlan_1.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            #endregion

//        }
//        /// <summary>
//        /// Cheveron ID: 17 > 20
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateCoverageSelectionInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(10);
//            #endregion


//            #region Coverage Types
//            EmployeeOnlyRadioButton.Click();
//            if (EmployeeOnlyRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            EmployeeSpouseRadioButton.Click();
//            if (EmployeeSpouseRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("", Status.Pass, test);
//            }
//            EmployeeChildRadioButton.Click();
//            if (EmployeeChildRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            EmployeeChildrenRadioButton.Click();
//            if (EmployeeChildrenRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
             

//            FamilyRadioButton.Click();
//            if (FamilyRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            OtherRadioButton.Click();
//            if (OtherRadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            COBRARadioButton.Click();
//            if (COBRARadioButton.Selected == false)
//            {
//                utility.RecordSimpleStatus("Failed to click button", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Pass", Status.Pass, test);
//            }
//            #endregion


//        }
//        /// <summary>
//        /// Cheveron ID: 17 > 21
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        public void ValidateOpenEnrollmentInformationInput(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomNumericAndSpciaChracterString(10);
//            #endregion

//            #region Date input
//            PlanEffD_dateInput_wrapper.Click();
//            PlanEffD_dateInput.SendKeys(randomSpecial10CharacterString);
//            if (PlanEffD_dateInput.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting Special Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }

//            EnrollEffD_dateInput_wrapper.Click();
//            EnrollEffD_dateInput.SendKeys(randomSpecial10CharacterString);
//            if (EnrollEffD_dateInput.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting Special Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }

//            EnrollEffTD_dateInput_wrapper.Click();
//            EnrollEffTD_dateInput.SendKeys(randomSpecial10CharacterString);
//            if (EnrollEffTD_dateInput.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting Special Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion

//        }
//        /// <summary>
//        /// Cheveron ID: 22
//        /// </summary>
//        /// <param name="test"></param>
//        /// <param name="utility"></param>
//        /// 
//        public void ValidateInsuranceType(ExtentTest test, Utility utility)
//        {

//            #region Generate Random Nums
//            string randomSpecial10CharacterString = utility.RandomSpecialCharacterString(10);
//            string random51CharacterString = utility.RandomAlphaNumericSpecialCharacterString(51);
//            string random101CharacterString = utility.RandomAlphaNumericSpecialCharacterString(101);
//            string randomNumericSpecialString = utility.RandomSpecialCharacterString(10);
//            string number = utility.RandomOneTwoThree(1);
           
//            #endregion

//            switch (number)
//            {
//                case "1":
//                    MedicalEditLink.Click();
//                    break;
//                case "2":
//                    DentalEditLink.Click();
//                    break;
//                case "3":
//                    VisionEditLink.Click();
//                    break;
//            }
//            #region Company Name Field
//            txtCompanyName.SendKeys(random51CharacterString);

//            if (txtCompanyName.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region Address one Field
//            txtInsurAddOne.SendKeys(random51CharacterString);

//            if (txtInsurAddOne.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region ADdress 2 Field
//            txtInsurAddTwo.SendKeys(random51CharacterString);

//            if (txtInsurAddTwo.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region City Field
//            txtInsurCity.SendKeys(random51CharacterString);

//            if (txtInsurCity.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region AddressTwo Field 
//            cboInsurState_wrapper.Click();
//            cboInsurState_Input.SendKeys(randomSpecial10CharacterString);

//            if (cboInsurState_Input.Text == randomSpecial10CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region ZipCode Field
//            txtInsurZip_wrapper.Click();
//            txtInsurZip.SendKeys(random51CharacterString);

//            if (txtInsurZip.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region State Input
//            txtInsurPNum_wrapper.Click();
//            txtInsurPNum.SendKeys(randomNumericSpecialString);

//            if (State_Input.Text == randomNumericSpecialString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
//            #region txtInsurPol
//            txtInsurPol.SendKeys(random51CharacterString);

//            if (txtZipCode.Text == random51CharacterString)
//            {
//                utility.RecordSimpleStatus("Accepting more than 50 Characters", Status.Fail, test);
//            }
//            else
//            {
//                utility.RecordSimpleStatus("Not accepting mroe than 51 characters", Status.Pass, test);
//            }
//            #endregion
            
            
            
            
  
            
//        }
//    }

//}
