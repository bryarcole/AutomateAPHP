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
            Generic generic;
            public HouseholdInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
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
            public void MemeberAccountYesNo(string yesno)
            {
                switch (yesno)
                {
                    case "Yes":
                        generic.ProtectedElementClick(rbMemPortAcc_0);
                        break;
                    case "No":
                        generic.ProtectedElementClick(rbMemPortAcc_1);
                        break;
                }
            }

            public void InputFirstName(string text)
            {
                generic.ProtectedElementSendKeys(FirstNameHHI, text);
            }
            public void InputLastName(string text)
            {
                generic.ProtectedElementSendKeys(LastNameHHI, text);

            }
            public void InputMiddleName(string text)
            {
                generic.ProtectedElementSendKeys(MiddleNameHHI, text);
            }

            public void InputRelationInfo( string text)
            {
                generic.ProtectedElementClick(Relation);
                generic.ProtectedElementSendKeys(Relation, text);
            }
            #endregion

            public void InputDate(string text)
            {
                generic.ProtectedElementClick(HHI_dateInput_wrapper);
                generic.ProtectedElementSendKeys(HHI_dateInput, text);
            }

            public void InputSSN(string text)
            {
                generic.ProtectedElementClick(SSN_wrapper);
                generic.ProtectedElementSendKeys(SSN, text);
            }
            public void PersonMedicareYesNo(string yesno)
            {
                switch (yesno)
                {
                    case "Yes":
                        generic.ProtectedElementClick(rbPersonMedicareYN_0);
                        break;
                    case "No":
                        generic.ProtectedElementClick(rbPersonMedicareYN_1);
                        break;
                }
            }
            public void PersonCoveredInsuranceYesNo(string yesno)
            {
                switch (yesno)
                {
                    case "Yes":
                        generic.ProtectedElementClick(rbPersonCoveredInsurance_0);
                        break;
                    case "No":
                        generic.ProtectedElementClick(rbPersonCoveredInsurance_1);
                        break;
                }
            }

            public void InputMemberInfo(string text)
            {
                generic.ProtectedElementClick(cboMemOnAccount_Input);
                generic.ProtectedElementSendKeys(cboMemOnAccount_Input, text);
            }

        }

        class EmployeeStatusAndHiringDetails
        {
            IWebDriver context;
            Generic generic;
            public EmployeeStatusAndHiringDetails(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }
            /// <summary>
            /// Employer and Resources Information
            /// Cheveron  ID: 11 > 13
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
            public void EmploymentHumanResourcesInformation(
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
            public IWebElement txtEmployerName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFedEmp')]")]
            public IWebElement txtFedEmp { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpAddOne')]")]
            public IWebElement txtEmpAddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpAddTwo')]")]
            public IWebElement txtEmpAddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpCity')]")]
            public IWebElement txtEmpCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmpState_Input')]")]
            public IWebElement EmpState_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEmpZip_wrapper')]")]
            public IWebElement txtEmpZip_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpZip')]")]
            public IWebElement txtEmpZip { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtHuman')]")]
            public IWebElement txtHuman { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDepartment')]")]
            public IWebElement txtDepartment { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtPhoneNum_wrapper')]")]
            public IWebElement txtPhoneNum_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtPhoneNum')]")]
            public IWebElement txtPhoneNum { get; set; }
            #endregion
        }

        class CompanyInformation
        {
            IWebDriver context;
            Generic generic;
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
            public IWebElement txtCompName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFEIN')]")]
            public IWebElement txtFEIN { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompAddOne')]")]
            public IWebElement txtCompAddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompAddTwo')]")]
            public IWebElement txtCompAddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompCity')]")]
            public IWebElement txtCompCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CompState_Input')]")]
            public IWebElement CompState_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompZip')]")]
            public IWebElement txtCompZip { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtContactPer')]")]
            public IWebElement txtContactPer { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompPhoneNum')]")]
            public IWebElement txtCompPhoneNum { get; set; }
            [FindsBy(How = How.Id, Using = "//div[contains(@id, 'txtCompZip_wrapper')]")]
            public IWebElement txtCompZip_wrapper { get; set; }
            [FindsBy(How = How.Id, Using = "//div[contains(@id, 'txtCompPhoneNum_wrapper')]")]
            public IWebElement txtCompPhoneNumWrapper { get; set; }
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

                WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));

                wait.Until(context =>
                {
                    try
                    {
                        switch (insuranceType)
                        {
                            case "Employer Plan":
                                EmployerPlan.Click();
                                SelfEmployedNARadioButton.Click();
                                break;
                            case "COBRA":
                                COBRARadio.Click();
                                SelfEmployedNARadioButton.Click();
                                break;
                            case "Individual Policy":
                                IndividualPolicyRadioButton.Click();
                                if (selfEmployed == true)
                                {
                                    SelfemployedYesRadioButton.Click();
                                }
                                else
                                {
                                    SelfEmployedNoRadioButton.Click();
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Type exType = ex.GetType();
                        if (exType == typeof(TargetInvocationException) ||
                            exType == typeof(NoSuchElementException) ||
                            exType == typeof(ElementClickInterceptedException) ||
                            exType == typeof(ElementNotVisibleException) ||
                            exType == typeof(InvalidOperationException))
                        {
                            return false; //By returning false, wait will still rerun the func.
                        }
                        else
                        {
                            throw; //Rethrow exception if it's not ignore type.
                        }
                    }

                    return true;
                });


                wait.Until(context =>
                {
                    try
                    {
                        dateInput_wrapper.Click();
                        PlanEff_dateInput.Clear();
                        PlanEff_dateInput.SendKeys(planDate);
                        //Monthly

                        cboPayInsur_Input.Clear();
                        cboPayInsur_Input.SendKeys(premiumPayFrequency);
                        cboPayInsur_Input.SendKeys(OpenQA.Selenium.Keys.Tab);
                        txtAmountPaid.Clear();
                        txtAmountPaid.SendKeys(amountEachPayPeriod);
                        txtAmountPaid.SendKeys(OpenQA.Selenium.Keys.Tab);
                    }
                    catch (Exception ex)
                    {
                        Type exType = ex.GetType();
                        if (exType == typeof(TargetInvocationException) ||
                            exType == typeof(NoSuchElementException) ||
                            exType == typeof(ElementClickInterceptedException) ||
                            exType == typeof(ElementNotVisibleException) ||
                            exType == typeof(InvalidOperationException))
                        {
                            return false; //By returning false, wait will still rerun the func.
                        }
                        else
                        {
                            throw; //Rethrow exception if it's not ignore type.
                        }
                    }

                    return true;
                });
                //Monthly

            }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_0')]")]
            public IWebElement EmployerPlan { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_1')]")]
            public IWebElement COBRARadio { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_2')]")]
            public IWebElement IndividualPolicyRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_0')]")]
            public IWebElement SelfemployedYesRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_1')]")]
            public IWebElement SelfEmployedNoRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_2')]")]
            public IWebElement SelfEmployedNARadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PlanEff_dateInput')]")]
            public IWebElement PlanEff_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dateInput_wrapper')]")]
            public IWebElement dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboPayInsur_Input')]")]
            public IWebElement cboPayInsur_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOtherFrequency')]")]
            public IWebElement txtOtherFrequency { get; set; }
            [FindsBy(How = How.Id, Using = "//div[contains(@id, txtAmountPaid_wrapper')]")]
            public IWebElement txtAmountPaidWrapper { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAmountPaid')]")]
            public IWebElement txtAmountPaid { get; set; }

            #endregion

        }

    }

}

        


  







        //public void InputSelectType(string text)
        //{
        //    Generic.ProtectedElementClick(SelectTypeInput);
        //    Generic.ProtectedElementSendKeys(SelectTypeInput, text);
        //}
        //public void BeginApplicationClick()
        //{
        //    Generic.ProtectedElementClick(BeginAppButton);
        //}
//    }
//}
