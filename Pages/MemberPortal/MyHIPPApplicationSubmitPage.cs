using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Tests1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace NUnit.Tests1.Pages.MemberPortal
{
    public class HIPPSubmitApplicationPage
    {
        IWebDriver context;

        public HIPPSubmitApplicationPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        class PolicyolderEmployeeInformation
        {
            IWebDriver context;
            public PolicyolderEmployeeInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }
            private Generic Generic
            {
                get
                {
                    Generic generic = new Generic(context);
                    return generic;
                }
            }
            #region Elements
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AccountYN_0')]")]
            private IWebElement PolicyHolderYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AccountYN_1')]")]
            private IWebElement PolicyHolderNo { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, MemAccount_Input")]
            private IWebElement MemAccount_Input { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, btnBeginApp")]
            private IWebElement BeginAppButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Prefix_Input')]")]
            private IWebElement Prefix_Input { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'FirstName')]")]
            private IWebElement FirstName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'MiddleName')]")]
            private IWebElement MiddleName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'LastName')]")]
            private IWebElement LastName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddOne')]")]
            private IWebElement AddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddTwo')]")]
            private IWebElement AddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCity')]")]
            private IWebElement txtCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'State_Input')]")]
            private IWebElement State_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ZipCode_wrapper')]")]
            private IWebElement ZipCode_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ZipCode')]")]
            private IWebElement ZipCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'HomePhone_wrapper')]")]
            private IWebElement HomePhone_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HomePhone')]")]
            private IWebElement HomePhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'CellPhone_wrapper')]")]
            private IWebElement CellPhone_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CellPhone')]")]
            private IWebElement CellPhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'WorkPhone_wrapper')]")]
            private IWebElement WorkPhone_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'WorkPhone')]")]
            private IWebElement WorkPhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Email')]")]
            private IWebElement Email { get; set; }
            #endregion

            #region Methods and Calls
            public void PolicyHolderEmployerInformationInput(
                    string firstName,
                    string midddleName,
                    string lastName,
                    string addressLineOne,
                    string addressLineTwo,
                    string city,
                    string state,
                    string zip,
                    string homePhone,
                    string cellPhone,
                    string workPhone,
                    string emailAddress)
            {

                FirstName.SendKeys(firstName);
                MiddleName.SendKeys(midddleName);
                LastName.SendKeys(lastName);
                AddOne.SendKeys(addressLineOne);
                AddTwo.SendKeys(addressLineTwo);
                txtCity.SendKeys(city);
                State_Input.SendKeys(state);
                ZipCode_wrapper.Click();
                ZipCode.SendKeys(zip);
                HomePhone_wrapper.Click();
                HomePhone.SendKeys(homePhone);
                CellPhone_wrapper.Click();
                CellPhone.SendKeys(cellPhone);
                WorkPhone_wrapper.Click();
                WorkPhone.SendKeys(workPhone);
                Email.SendKeys(emailAddress);

            }

            
            #endregion

        }
        class HouseholdInformation
        {
            IWebDriver context;
            public HouseholdInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }

            private Generic Generic
            {
                get
                {
                    Generic generic = new Generic(context);
                    return generic;
                }
            }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbMemPortAcc_0')]")]
            private IWebElement rbMemPortAcc_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbMemPortAcc_1')]")]
            private IWebElement rbMemPortAcc_1 { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'FirstNameHHI')]")]
            private IWebElement FirstNameHHI { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'MiddleNameHHI')]")]
            private IWebElement MiddleNameHHI { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'LastNameHHI')]")]
            private IWebElement LastNameHHI { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, '$cboRelation')]")]
            private IWebElement Relation { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'HHI_dateInput_wrapper')]")]
            private IWebElement HHI_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HHI_dateInput')]")]
            private IWebElement HHI_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HouseholdInformationMemberID')]")]
            private IWebElement HouseholdInformationMemberID { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'SSN_wrapper')]")]
            private IWebElement SSN_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SSN')]")]
            private IWebElement SSN { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonMedicareYN_0')]")]
            private IWebElement rbPersonMedicareYN_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'rbPersonMedicareYN_0')]")]
            private IWebElement rbPersonMedicareYN_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'rbPersonCoveredInsurance_0')]")]
            private IWebElement rbPersonCoveredInsurance_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'rbPersonCoveredInsurance_1')]")]
            private IWebElement rbPersonCoveredInsurance_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboMemOnAccount_Input')]")]
            private IWebElement cboMemOnAccount_Input { get; set; }

            #region Methods and Calls
            public void MemeberAccountYesNo(string yesno) => Generic.DecisionClick(rbMemPortAcc_0, rbMemPortAcc_1, yesno);

            public void InputFirstName(string text) => Generic.SendKeys(FirstNameHHI, text);
            public void InputLastName(string text) => Generic.SendKeys(LastNameHHI, text);
            public void InputMiddleName(string text) => Generic.SendKeys(MiddleNameHHI, text);

            public void InputRelationInfo(string text) => Generic.AccessElement(Relation, Relation, text);

            public void InputDate(string text) => Generic.AccessElement(HHI_dateInput, HHI_dateInput_wrapper, text);

            public void InputSSN(string text) => Generic.AccessElement(SSN, SSN_wrapper, text);
            public void PersonMedicareYesNo(string yesno) => Generic.DecisionClick(rbPersonMedicareYN_0, rbPersonMedicareYN_1, yesno);
            public void PersonCoveredInsuranceYesNo(string yesno) => Generic.DecisionClick(rbPersonCoveredInsurance_0, rbPersonCoveredInsurance_1, yesno);

            public void InputMemberInfo(string text) => Generic.AccessElement(cboMemOnAccount_Input, cboMemOnAccount_Input, text);
            #endregion

        }

        class EmployeeStatusAndHiringDetails
        {
            IWebDriver context;
            public EmployeeStatusAndHiringDetails(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }

            private Generic Generic
            {
                get
                {
                    Generic generic = new Generic(context);
                    return generic;
                }
            }
            /// <summary>
            /// Employer and Resources Information
            /// </summary>
            /// <param name="employerName"></param>
            /// <param name="federalEmployIDNumber"></param>
            /// <param name="addressLineOne"></param>
            /// <param name="addressLineTwo"></param>
            /// <param name="city"></param>
            /// <param name="state"></param>
            /// <param name="zip"></param>
            /// <param name="humanResourcesRep"></param>
            /// <param name="department"></param>
            /// <param name="phoneNumber"></param>
            public void InputEmploymentHumanResourcesInformation(
                string employerName,
                string federalEmployIDNumber,
                string addressLineOne,
                string addressLineTwo,
                string city,
                string state,
                string zip,
                string humanResourcesRep,
                string department,
                string phoneNumber)
            {
                txtEmployerName.SendKeys(employerName);
                txtFedEmp.SendKeys(federalEmployIDNumber);
                txtEmpAddOne.SendKeys(addressLineOne);
                txtEmpAddTwo.SendKeys(addressLineTwo);
                txtEmpCity.SendKeys(city);
                EmpState_Input.SendKeys(state);
                txtEmpZip_wrapper.Click();
                txtEmpZip.SendKeys(zip);
                txtHuman.SendKeys(humanResourcesRep);
                txtDepartment.SendKeys(department);
                txtPhoneNum_wrapper.Click();
                txtPhoneNum.SendKeys(phoneNumber);
            }
            #region Employment Info Elements
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmployerName')]")]
            private IWebElement txtEmployerName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFedEmp')]")]
            private IWebElement txtFedEmp { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpAddOne')]")]
            private IWebElement txtEmpAddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpAddTwo')]")]
            private IWebElement txtEmpAddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpCity')]")]
            private IWebElement txtEmpCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmpState_Input')]")]
            private IWebElement EmpState_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEmpZip_wrapper')]")]
            private IWebElement txtEmpZip_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpZip')]")]
            private IWebElement txtEmpZip { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtHuman')]")]
            private IWebElement txtHuman { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDepartment')]")]
            private IWebElement txtDepartment { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtPhoneNum_wrapper')]")]
            private IWebElement txtPhoneNum_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtPhoneNum')]")]
            private IWebElement txtPhoneNum { get; set; }
            #endregion

            #region Method and Calls
            public void InputEmployerName(string text) => Generic.SendKeys(txtEmployerName, text);
            public void InputFedEmployerID(string text) => Generic.SendKeys(txtFedEmp, text);
            public void InputEmployeeAddressOne(string text) => Generic.SendKeys(txtEmpAddOne, text);
            public void InputEmployeeAddressTwo(string text) => Generic.SendKeys(txtEmpAddTwo, text);
            public void InputEmployeeCity(string text) => Generic.SendKeys(txtEmpCity, text);
            public void InputEmployeeState(string text) => Generic.SendKeys(txtEmpCity, text);
            public void InputEmployerZipCode(string text) => Generic.SendKeys(txtEmpZip, text);
            public void ClickEmployerZip() => Generic.Click(txtEmpZip_wrapper);
            public void InputHumanResource(string text) => Generic.SendKeys(txtHuman, text);
            public void InputEmployerDepartment(string text) => Generic.SendKeys(txtDepartment, text);
            public void ClickEmployerPhoneNumber() => Generic.Click(txtPhoneNum_wrapper);
            public void InputEmployerPhoneNumber(string text) => Generic.SendKeys(txtPhoneNum, text);


            #endregion
        }

        class CompanyInformation
        {
            IWebDriver context;
            public CompanyInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }
            #region Company Information
            /// <summary>
            /// Company Information
            /// Cheveron ID: 15
            /// </summary>
            /// <param name="companyName"></param>
            /// <param name="FEIN"></param>
            /// <param name="addressLineOne"></param>
            /// <param name="addressLineTwo"></param>
            /// <param name="city"></param>
            /// <param name="state"></param>
            /// <param name="zip"></param>
            /// <param name="contactPerson"></param>
            /// <param name="phoneNumber"></param>
            public void CompanyInformationInput(
                string companyName,
                string FEIN,
                string addressLineOne,
                string addressLineTwo,
                string city,
                string state,
                string zip,
                string contactPerson,
                string phoneNumber)
            {
                txtCompName.SendKeys(companyName);
                txtFEIN.SendKeys(FEIN);
                txtCompAddOne.SendKeys(addressLineOne);
                txtCompAddTwo.SendKeys(addressLineTwo);
                txtCompCity.SendKeys(city);
                CompState_Input.SendKeys(state);
                txtCompZip.Click();
                txtCompZip.SendKeys(zip);
                txtContactPer.SendKeys(contactPerson);
                txtCompPhoneNum.Click();
                txtCompPhoneNum.SendKeys(phoneNumber);

            }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompName')]")]
            private IWebElement txtCompName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFEIN')]")]
            private IWebElement txtFEIN { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompAddOne')]")]
            private IWebElement txtCompAddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompAddTwo')]")]
            private IWebElement txtCompAddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompCity')]")]
            private IWebElement txtCompCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CompState_Input')]")]
            private IWebElement CompState_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompZip')]")]
            private IWebElement txtCompZip { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtContactPer')]")]
            private IWebElement txtContactPer { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompPhoneNum')]")]
            private IWebElement txtCompPhoneNum { get; set; }
            [FindsBy(How = How.Id, Using = "//div[contains(@id, 'txtCompZip_wrapper')]")]
            private IWebElement txtCompZip_wrapper { get; set; }
            [FindsBy(How = How.Id, Using = "//div[contains(@id, 'txtCompPhoneNum_wrapper')]")]
            private IWebElement txtCompPhoneNumWrapper { get; set; }
            #endregion
        }

        class PlanInformation
        {
            IWebDriver context;
            Generic generic;
            public PlanInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }

            private Generic Generic
            {
                get
                {
                    Generic generic = new Generic(context);
                    return generic;
                }
            }
            #region Plan Information
            /// <summary>
            /// Plan Information
            /// Cheveron ID: 16
            /// </summary>
            /// <param name="insuranceType"></param>
            /// <param name="selfEmployed"></param>
            /// <param name="planDate"></param>
            /// <param name="premiumPayFrequency"></param>
            /// <param name="amountEachPayPeriod"></param>
            public void PlanInformationInput(
                string insuranceType,
                bool selfEmployed,
                string planDate,
                string premiumPayFrequency,
                string amountEachPayPeriod)
            {
                //Monthly

            }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_0')]")]
            private IWebElement EmployerPlan { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_1')]")]
            private IWebElement COBRARadio { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_2')]")]
            private IWebElement IndividualPolicyRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_0')]")]
            private IWebElement SelfemployedYesRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_1')]")]
            private IWebElement SelfEmployedNoRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_2')]")]
            private IWebElement SelfEmployedNARadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PlanEff_dateInput')]")]
            private IWebElement PlanEff_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dateInput_wrapper')]")]
            private IWebElement dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboPayInsur_Input')]")]
            private IWebElement cboPayInsur_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOtherFrequency')]")]
            private IWebElement txtOtherFrequency { get; set; }
            [FindsBy(How = How.Id, Using = "//div[contains(@id, txtAmountPaid_wrapper')]")]
            private IWebElement txtAmountPaidWrapper { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAmountPaid')]")]
            private IWebElement txtAmountPaid { get; set; }

            #endregion

            #region Methods and Calls

            public void ClickEmployerPlan() => Generic.Click(EmployerPlan);
            public void ClickCOBRA() => Generic.Click(COBRARadio);
            public void ClickIndividualPolicy() => Generic.Click(IndividualPolicyRadioButton);
            public void ClickYesRadioButton() => Generic.Click(SelfemployedYesRadioButton);
            public void ClickNoRadioButton() => Generic.Click(SelfEmployedNoRadioButton);
            public void ClickNotApplicableRadioButton() => Generic.Click(SelfEmployedNARadioButton);
            public void InputEffectiveDate(string date)
            {
                Generic.Click(dateInput_wrapper);
                Generic.Click(PlanEff_dateInput);
            }
            public void InputInsurancePaymentFrequency() => Generic.Click(cboPayInsur_Input);
            public void InputAmountEachPayPeriod(string text)
            {
                Generic.Click(txtAmountPaidWrapper);
                Generic.SendKeys(txtAmountPaid, text);
            }

            #endregion

        }

    }

}
