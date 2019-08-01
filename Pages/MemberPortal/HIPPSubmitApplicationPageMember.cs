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
    public class HIPPSubmitApplicationPageMember
    {
        IWebDriver context;

        public HIPPSubmitApplicationPageMember(IWebDriver context)
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
        public class PolicyHolderEmployeeInformation
        {
            IWebDriver context;
            public PolicyHolderEmployeeInformation(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'AccountYN_0')]")]
            private IWebElement PolicyHolderYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'AccountYN_1')]")]
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ZipCode')]")]
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
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbAccountYN_1')]")]
            private IWebElement rbAccountYN_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbAccountYN_0')]")]
            private IWebElement rbAccountYN_0 { get; set; }

            #endregion

            #region Methods and Calls
            public IWebElement InputMemAccount(string text = null) => Generic.SendKeys(MemAccount_Input, MemAccount_Input, text);
            public IWebElement SelectMemberPortalYesNo(string yesno = null) => Generic.DecisionClick(ClickMemberPortalYes(), ClickMemberProtalNo(), yesno);
            public IWebElement ClickMemberPortalYes() => Generic.Click(rbAccountYN_0);
            public IWebElement ClickMemberProtalNo() => Generic.Click(rbAccountYN_1);
            public IWebElement InputFirstName(string text = null) => Generic.SendKeys(FirstName, text);
            public IWebElement InputMiddleName(string text = null) => Generic.SendKeys(MiddleName, text);
            public IWebElement InputLastName(string text = null) => Generic.SendKeys(LastName, text);
            public IWebElement InputAddressLineOne(string text = null) => Generic.SendKeys(AddOne, text);
            public IWebElement InputAddressLineTwo(string text = null) => Generic.SendKeys(AddTwo, text);
            public IWebElement InputCity(string text = null) => Generic.SendKeys(txtCity, text);
            public IWebElement InputState(string text = null) => Generic.SendKeys(State_Input, text);
            public IWebElement InputZipCode(string text = null) => Generic.SendKeys(ZipCode, ZipCode_wrapper, text);
            public IWebElement InputHomePhone(string text = null) => Generic.SendKeys(HomePhone, HomePhone_wrapper, text);
            public IWebElement InputCellPhone(string text = null) => Generic.SendKeys(CellPhone, CellPhone_wrapper, text);
            public IWebElement InputWorkPhone(string text = null) => Generic.SendKeys(WorkPhone, WorkPhone_wrapper, text);
            public IWebElement InputEmail(string text = null) => Generic.SendKeys(Email, Email, text);
            #region Methods and Calls
            public void PolicyHolderEmployerInformationInput(
                   string selectMemberPortalYesNo = null,
                   string memberAccount = null,
                   string firstName = null,
                   string midddleName = null,
                   string lastName = null,
                   string addressLineOne = null,
                   string addressLineTwo = null,
                   string city = null,
                   string state = null,
                   string zip = null,
                   string homePhone = null,
                   string cellPhone = null,
                   string workPhone = null,
                   string emailAddress = null)
            {

                SelectMemberPortalYesNo(selectMemberPortalYesNo);
                if(selectMemberPortalYesNo == "Yes")
                {
                    InputMemAccount(memberAccount);
                }
                InputFirstName(firstName);
                InputMiddleName(midddleName);
                InputLastName(lastName);
                InputAddressLineOne(addressLineOne);
                InputAddressLineTwo(addressLineTwo);
                InputCity(city);
                InputState(state);
                InputZipCode(zip);
                InputHomePhone(homePhone);
                InputCellPhone(cellPhone);
                InputWorkPhone(workPhone);
                InputEmail(emailAddress);

            }
            #endregion
            #endregion

        }
        public class HouseholdInformation
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
            #region Household Info
            #region HouseHoldInformation Methods

            /// <summary>
            /// HouseHold Information
            /// Cheveron: 10
            /// </summary>
            /// <param name="relation"></param>
            /// <param name="firstName"></param>
            /// <param name="middleName"></param>
            /// <param name="lastName"></param>
            /// <param name="DOB"></param>
            /// <param name="MedicaidID"></param>
            /// <param name="SSN"></param>
            /// <param name="MedicareStatus"></param>
            /// <param name="InsuranceStatus"></param>
            public void HouseHoldInformationInput(
                string relation = null,
                string memberPortalAccount = null, 
                string firstName = null,
                string middleName = null,
                string lastName = null,
                string DOB = null,
                string MedicaidID = null,
                string SSN = null,
                string MedicareStatus = null,
                string InsuranceStatus = null)
            {
                ClickHouseHoldAdd();
                SelectMemberPortalYesNo(memberPortalAccount);
                InputRelation(relation);
                InputFirstName(firstName);
                InputMiddleName(middleName);
                InputLastName(lastName);
                InputDOB(DOB);
                InputHouseholdInformationMemberID(MedicaidID);
                InputSSN(SSN);
                //Radio Buttons
                SelectMedicareStatus(MedicareStatus);
                SelectPersonCoveredInsurance(InsuranceStatus);
                ClickHouseholdSave();
            }
            public IWebElement SelectMemberPortalYesNo(string yesno = null) => Generic.DecisionClick(MemPortAcc_0, MemPortAcc_1, yesno);
            public IWebElement ClickMemberPortalYes() => Generic.Click(MemPortAcc_0);
            public IWebElement ClickMemberProtalNo() => Generic.Click(MemPortAcc_1);
            public IWebElement InputFirstName(string text = null) => Generic.SendKeys(txtFirstNameHHI, text);
            public IWebElement InputMiddleName(string text = null) => Generic.SendKeys(txtMiddleNameHHI, text);
            public IWebElement InputLastName(string text = null) => Generic.SendKeys(txtLastNameHHI, text);
            public IWebElement InputRelation(string text = null) => Generic.SendKeys(Relation, Relation, text);
            public IWebElement InputSSN(string text = null) => Generic.SendKeys(txtSSN, txtSSN_wrapper, text);
            public void ClickHouseholdSave() => Generic.LinkTextClick("Insert");
            public void ClickHouseHoldAdd() => Generic.LinkTextClick("Add new item");
            public IWebElement InputDOB(string text = null) => Generic.SendKeys(dpDOBHHI_dateInput, DOBHHI_wrapperOverlay, text);
            public IWebElement InputHouseholdInformationMemberID(string text = null) => Generic.SendKeys(HouseholdInformationMemberID, text);
            public IWebElement ClickMedicareStatusYes() => Generic.Click(PersonMedicareYesRadioButton);
            public IWebElement ClickMedicareStatusNo() => Generic.Click(PersonMedicareNoRadioButton);
            public IWebElement ClickPersonCoveredInsuranceYes() => Generic.Click(YesPersonCoveredInsurance);
            public IWebElement ClickPersonCoveredInsuranceNo() => Generic.Click(NoPersonCoveredInsurance);
            public IWebElement SelectMedicareStatus(string yesno = null) => Generic.DecisionClick(PersonMedicareYesRadioButton, PersonMedicareNoRadioButton, yesno);
            public IWebElement SelectPersonCoveredInsurance(string yesno = null) => Generic.DecisionClick(YesPersonCoveredInsurance, NoPersonCoveredInsurance, yesno);
            #endregion
            #region Household Elements
            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'HouseHoldAdd')]")]
            private IWebElement HouseHoldAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboRelation_ClientState')]")]
            private IWebElement RelationOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboRelation_Input')]")]
            private IWebElement Relation { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFirstNameHHI')]")]
            private IWebElement txtFirstNameHHI { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMiddleNameHHI')]")]
            private IWebElement txtMiddleNameHHI { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtLastNameHHI')]")]
            private IWebElement txtLastNameHHI { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'dpDOBHHI_dateInput')]")]
            private IWebElement dpDOBHHI_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DOBHHI_wrapper')]")]
            private IWebElement DOBHHI_wrapperOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HouseholdInformationMemberID')]")]
            private IWebElement HouseholdInformationMemberID { get; set; }
            //txtSSN_wrapper
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtSSN_wrapper')]")]
            private IWebElement txtSSN_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtSSN')]")]
            private IWebElement txtSSN { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbPersonMedicareYN_0')]")]
            private IWebElement PersonMedicareYesRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbPersonMedicareYN_1')]")]
            private IWebElement PersonMedicareNoRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbPersonCoveredInsurance_0')]")]
            private IWebElement YesPersonCoveredInsurance { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbPersonCoveredInsurance_1')]")]
            private IWebElement NoPersonCoveredInsurance { get; set; }
            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnHouseHoldSave')]")]
            private IWebElement btnHouseHoldSave { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbMemPortAcc_1')]")]
            private IWebElement MemPortAcc_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbMemPortAcc_0')]")]
            private IWebElement MemPortAcc_0 { get; set; }
            
            #endregion
            #endregion
        }
        public class EmployeeStatusAndHiringDetails
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
            /// Employment Information
            /// Cheveron ID: 11
            /// Employee Status/Hiring Detials
            /// Cheveron ID: 12
            /// Employer and Resources Information
            /// Cheveron  ID: 13
            /// </summary>
            /// <param name="employmentStatus| Yes or No"></param>
            /// <param name="dateHired |Date"></param>
            /// <param name="retired| Yes or No"></param>
            /// <param name="schoolEmployment| Yes or No"></param>
            /// <param name="employmentPeriod| 10 or 12"></param>

            #region EmployeStatusHiring Methods

            public IWebElement InputDateHired(string text = null) => Generic.SendKeys(DateHired_dateInput, txtDateHired_dateInput_wrapper, text);
            public IWebElement ClickEmployeeStatusYes() => Generic.Click(EmpStatusYes);
            public IWebElement ClickEmployeeStatusNo() => Generic.Click(EmpStatusNo);
            public IWebElement ClickSchoolEmployedYes() => Generic.Click(SchoolEmpYes);
            public IWebElement ClickSchoolEmployedNo() => Generic.Click(SchoolEmpNo);
            public IWebElement ClickEmploymentPeriod10Months() => Generic.Click(SchoolEmpPeriod);
            public IWebElement ClickEmploymentPeriod12Months() => Generic.Click(SchoolEmpPeriod2);
            public IWebElement ClickRetiredYes() => Generic.Click(RetiredYes);
            public IWebElement ClickRetiredNo() => Generic.Click(RetiredNo);

            public IWebElement SelectRetiredStatus(string yesno = null) => Generic.DecisionClick(RetiredYes, RetiredNo, yesno);
            public IWebElement SelectEmploymentStatus(string yesno = null) => Generic.DecisionClick(EmpStatusYes, EmpStatusNo, yesno);
            public IWebElement SelectSchoolEmployMentStatus(string yesno = null) => Generic.DecisionClick(SchoolEmpYes, SchoolEmpNo, yesno);
            public IWebElement SelectEmploymentPeriod(string tenOrTwelve = null) => Generic.DecisionClick(SchoolEmpPeriod, SchoolEmpPeriod2, tenOrTwelve);
            public void EmploymentStatusHiringInput(
            string employmentStatus = null,
            string dateHired = null,
            string retired = null,
            string schoolEmployment = null,
            string employmentPeriod = null)
            {

                InputDateHired(dateHired);
                SelectEmploymentStatus(employmentStatus);
                SelectRetiredStatus(retired);
                SelectSchoolEmployMentStatus(schoolEmployment);
                SelectEmploymentPeriod(employmentPeriod);
            }
            #endregion
            #region EmployeeStatus Hiring Elements
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbEmpStatus')]")]
            private IWebElement EmpStatusYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbEmpStatus_1')]")]
            private IWebElement EmpStatusNo { get; set; }
            //txtDateHired_dateInput_wrapper
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtDateHired_dateInput_wrapper')]")]
            private IWebElement txtDateHired_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDateHired_dateInput')]")]
            private IWebElement DateHired_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbRetired_0')]")]
            private IWebElement RetiredYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbRetired_1')]")]
            private IWebElement RetiredNo { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbSchoolEmp_0')]")]
            private IWebElement SchoolEmpYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'SchoolEmp_1')]")]
            private IWebElement SchoolEmpNo { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'SchoolEmpPeriod_0')]")]
            private IWebElement SchoolEmpPeriod { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'SchoolEmpPeriod_1')]")]
            private IWebElement SchoolEmpPeriod2 { get; set; }
        }
        public class EmployerAndResourcesInformation
        {
            IWebDriver context;
            public EmployerAndResourcesInformation(IWebDriver context)
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
            #region Employment Information > EMployer and Resources Information
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
            public void EmploymentHumanResourcesInformationInput(
                string employerName = null,
                string federalEmployIDNumber = null,
                string addressLineOne = null,
                string addressLineTwo = null,
                string city = null,
                string state = null,
                string zip = null,
                string humanResourcesRep = null,
                string department = null,
                string phoneNumber = null)
            {
                InputEmployerName(employerName);
                InputFederalEmployeeID(federalEmployIDNumber);
                InputAddressLineOne(addressLineOne);
                InputAddressLineTwo(addressLineTwo);
                InputCity(city);
                InputState(state);
                InputZipCode(zip);
                InputHumanResoucesRep(humanResourcesRep);
                InputDepartment(department);
                InputPhoneNumber(phoneNumber);
            }
            #endregion

            public IWebElement InputEmployerName(string text = null) => Generic.SendKeys(txtEmployerName, text);
            public IWebElement InputFederalEmployeeID(string text = null) => Generic.SendKeys(txtFedEmp, txtFedEmp, text);
            public IWebElement InputAddressLineOne(string text = null) => Generic.SendKeys(txtEmpAddOne, text);
            public IWebElement InputAddressLineTwo(string text = null) => Generic.SendKeys(txtEmpAddTwo, text);
            public IWebElement InputCity(string text = null) => Generic.SendKeys(txtEmpCity, text);
            public IWebElement InputState(string text = null) => Generic.SendKeys(EmpState_Input, text);
            public IWebElement InputZipCode(string text = null) => Generic.SendKeys(txtEmpZip, txtEmpZip_wrapper, text);
            public IWebElement InputHumanResoucesRep(string text = null) => Generic.SendKeys(txtHuman, text);
            public IWebElement InputDepartment(string text = null) => Generic.SendKeys(txtDepartment, text);
            public IWebElement InputPhoneNumber(string text = null) => Generic.SendKeys(txtPhoneNum, txtPhoneNum_wrapper, text);
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
            //txtEmpZip_wrapper
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEmpZip_wrapper')]")]
            private IWebElement txtEmpZip_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpZip')]")]
            private IWebElement txtEmpZip { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtHuman')]")]
            private IWebElement txtHuman { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDepartment')]")]
            private IWebElement txtDepartment { get; set; }
            //txtPhoneNum_wrapper
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtPhoneNum_wrapper')]")]
            private IWebElement txtPhoneNum_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtPhoneNum')]")]
            private IWebElement txtPhoneNum { get; set; }
            #endregion
        }

        public class CompanyInformation
        {
            IWebDriver context;
            public CompanyInformation(IWebDriver context)
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
                string companyName = null,
                string FEIN = null,
                string addressLineOne = null,
                string addressLineTwo = null,
                string city = null,
                string state = null,
                string zip = null,
                string contactPerson = null,
                string phoneNumber = null)
            {
                InputCompanyName(companyName);
                InputFederalEmployeeID(FEIN);
                InputAddressLineOne(addressLineOne);
                InputAddressLineTwo(addressLineTwo);
                InputCity(city);
                InputState(state);
                InputZipCode(zip);
                InputContactPerson(contactPerson);
                InputPhoneNumber(phoneNumber);
            }

            public IWebElement InputCompanyName(string text = null) => Generic.SendKeys(txtCompName, text);
            public IWebElement InputFederalEmployeeID(string text = null) => Generic.SendKeys(txtFEIN, txtFEIN, text);
            public IWebElement InputAddressLineOne(string text = null) => Generic.SendKeys(txtCompAddOne, text);
            public IWebElement InputAddressLineTwo(string text = null) => Generic.SendKeys(txtCompAddTwo, text);
            public IWebElement InputCity(string text = null) => Generic.SendKeys(txtCompCity, text);
            public IWebElement InputState(string text = null) => Generic.SendKeys(CompState_Input, text);
            public IWebElement InputZipCode(string text = null) => Generic.SendKeys(txtCompZip, txtCompZip, text);
            public IWebElement InputContactPerson(string text = null) => Generic.SendKeys(txtContactPer, text);
            public IWebElement InputPhoneNumber(string text = null) => Generic.SendKeys(txtCompPhoneNum, txtCompPhoneNum, text);

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

        public class PlanInformation
        {
            IWebDriver context;
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
                string insuranceType = null,
                string selfEmployed = null,
                string planDate = null,
                string premiumPayFrequency = null,
                string amountEachPayPeriod = null)
            {
                SelectInsuranceType(insuranceType, selfEmployed);
                InputPlanEffectiveDate(planDate);
                InputPayInsurence(premiumPayFrequency);
                InputAmountPaid(amountEachPayPeriod);
            }
            public IWebElement InputPlanEffectiveDate(string text = null) => Generic.SendKeys(PlanEff_dateInput, dateInput_wrapper, text);
            public IWebElement InputAmountPaid(string text = null) => Generic.SendKeys(txtAmountPaid, txtAmountPaid, text);
            public IWebElement InputPayInsurence(string text = null) => Generic.SendKeys(cboPayInsur_Input, text);
            public IWebElement InputPaymentFrequency(string text = null) => Generic.SendKeys(txtOtherFrequency, text);
            public IWebElement ClickCOBRA() => Generic.Click(COBRARadio);
            public IWebElement ClickEmployerPlan() => Generic.Click(EmployerPlan);
            public IWebElement ClickIndividualPolicy() => Generic.Click(IndividualPolicyRadioButton);
            public IWebElement ClickSelfEmployedNA() => Generic.Click(SelfEmployedNARadioButton);
            public IWebElement ClickSelfEmployedNo() => Generic.Click(SelfEmployedNoRadioButton);
            public IWebElement ClickSelfEmployedYes() => Generic.Click(SelfemployedYesRadioButton);

            public void SelectInsuranceType(string text = null, string selfEmployed = null)
            {
                switch (text)
                {
                    case "Employer Plan":
                        ClickEmployerPlan();
                        ClickSelfEmployedNA();
                        break;
                    case "COBRA":
                        ClickCOBRA();
                        ClickSelfEmployedNA();
                        break;
                    case "Individual Policy":
                        ClickIndividualPolicy();
                        if (selfEmployed == "Yes")
                        {
                            ClickSelfEmployedYes();
                        }
                        else
                        {
                            ClickSelfEmployedNo();
                        }
                        break;
                }
            }

            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'cbInsuranceType_0')]")]
            private IWebElement EmployerPlan { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'cbInsuranceType_1')]")]
            private IWebElement COBRARadio { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'cbInsuranceType_2')]")]
            private IWebElement IndividualPolicyRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbPolHold_0')]")]
            private IWebElement SelfemployedYesRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbPolHold_1')]")]
            private IWebElement SelfEmployedNoRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbPolHold_2')]")]
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

        }

        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'ChkAgree')]")]
        private IWebElement ChkAgree { get; set; }
        public IWebElement ClickAgree() => Generic.Click(ChkAgree);
        public void ClickSave() => Generic.LinkTextClick("ubmit");
        #endregion
    }

}
