using NUnit.Tests1.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using NUnit.Tests1.Utilities;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace NUnit.Tests1.Pages.WorkerPortal
{
    public class HIPPSubmitApplicationPageWorker
    {
        IWebDriver context;
        WebDriverWait wait;

        DateTime today = new DateTime();
        //utility utility = new utility(context);

        public HIPPSubmitApplicationPageWorker(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }
        public class ApplicationOverview
        {
            IWebDriver context;

            public ApplicationOverview(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }
            Generic Generic
            {
                get
                {
                    Generic generic = new Generic(context);
                    return generic;
                }
            }

            #region Methods and Calls
            /// <summary>
            /// Cheveron ID: 7
            /// </summary>
            /// <param name="appRecieveDate"></param>
            /// <param name="eIVRecieveDate"></param>
            /// <param name="annualRenewalDate"></param>
            /// <param name="annualToDate"></param>
            /// <param name="quarterlyValidationDueDate"></param>
            /// <param name="hippCaseNo"></param>
            public void ApplicationOverviewInput(
                string appRecieveDate = null,
                string eIVRecieveDate = null,
                string annualRenewalDate = null,
                string annualToDate = null,
                string quarterlyValidationDueDate = null,
                string hippCaseNo = null,
                string applicationType = null)
            {

                InputApplicationRecieveDate(appRecieveDate);
                InputEIVRecieveDate(eIVRecieveDate);
                InputRenewalDates(annualRenewalDate);
                InputAnnualToDate(annualToDate);
                InputQuarterlyValidationDueDates(quarterlyValidationDueDate);
                InputHIPPCaseNumber(hippCaseNo);
                InputApplicationType(applicationType);

            }

            public IWebElement InputApplicationRecieveDate(string text = null) => Generic.SendKeys(ApplicationReceiveDate, ApplicationRecieveDateOverlay, text);
            public IWebElement InputEIVRecieveDate(string text = null) => Generic.SendKeys(EIVRecieveDate, EIVRecievedDateOverlay, text);
            public IWebElement InputRenewalDates(string text = null) => Generic.SendKeys(AnnualRenewalDates, AnnualRenewalDatesOverlay, text);
            public IWebElement InputAnnualToDate(string text = null) => Generic.SendKeys(AnnualToDate, AnnualToDateOverlay, text);
            public IWebElement InputQuarterlyValidationDueDates(string text = null) => Generic.SendKeys(QuarterlyValidationDueDates, QuarterlyValidationDueDatesOverlay, text);
            public IWebElement InputHIPPCaseNumber(string text = null) => Generic.SendKeys(HIPPCaseNo, HIPPCaseNo, text);
            public IWebElement InputApplicationType(string text = null) => Generic.SendKeys(ApplicationType, text);
            #endregion

            #region elements
            /// <summary>
            /// Application OverView
            /// Cheveron ID: 7
            /// </summary>
            /// 
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ApplicationRecievedDate_dateInput_wrapper')]")]
            private IWebElement ApplicationRecieveDateOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ApplicationRecievedDate_dateInput')]")]
            private IWebElement ApplicationReceiveDate { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'AnnualToDate_dateInput_wrapper')]")]
            private IWebElement AnnualRenewalDatesOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AnnualToDate_dateInput')]")]
            private IWebElement AnnualRenewalDates { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'EIVRecievedDate_dateInput_wrapper')]")]
            private IWebElement EIVRecievedDateOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EIVRecievedDate_dateInput')]")]
            private IWebElement EIVRecieveDate { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'AnnualRenewalDates_dateInput_wrapper')]")]
            private IWebElement AnnualToDateOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AnnualRenewalDates_dateInput')]")]
            private IWebElement AnnualToDate { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ApplicationType')]")]
            private IWebElement ApplicationType { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HIPPCaseNo')]")]
            private IWebElement HIPPCaseNo { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'QuarterlyValidationDueDates_dateInput_wrapper')]")]
            private IWebElement QuarterlyValidationDueDatesOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'QuarterlyValidationDueDates_dateInput')]")]
            private IWebElement QuarterlyValidationDueDates { get; set; }
            #endregion
        }


        public class PolicyHolderEmployeeInformation
        {
            IWebDriver context;
            public PolicyHolderEmployeeInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }

            Generic Generic
            {
                get
                {
                    Generic generic = new Generic(context);
                    return generic;
                }
            }
            #region PolicyHolder/Employee Information
            /// <summary>
            /// Policyholder/Employee Information
            /// Cheveron ID: 9
            /// </summary>
            /// <param name="firstName"></param>
            /// <param name="midddleName"></param>
            /// <param name="lastName"></param>
            /// <param name="addressLineOne"></param>
            /// <param name="addressLineTwo"></param>
            /// <param name="city"></param>
            /// <param name="state"></param>
            /// <param name="zip"></param>
            /// <param name="homePhone"></param>
            /// <param name="cellPhone"></param>
            /// <param name="workPhone"></param>
            /// <param name="emailAddress"></param>
            public void PolicyHolderEmployerInformationInput(
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
            public IWebElement InputFirstName(string text = null) => Generic.SendKeys(txtFirstName, text);
            public IWebElement InputMiddleName(string text = null) => Generic.SendKeys(txtMiddleName, text);
            public IWebElement InputLastName(string text = null) => Generic.SendKeys(txtLastName, text);
            public IWebElement InputAddressLineOne(string text = null) => Generic.SendKeys(txtAddOne, text);
            public IWebElement InputAddressLineTwo(string text = null) => Generic.SendKeys(txtAddTwo, text);
            public IWebElement InputCity(string text = null) => Generic.SendKeys(txtCity, text);
            public IWebElement InputState(string text = null) => Generic.SendKeys(State_Input, text);
            public IWebElement InputZipCode(string text = null) => Generic.SendKeys(txtZipCode, txtZipCodeOverlay, text);
            public IWebElement InputHomePhone(string text = null) => Generic.SendKeys(HomePhone, HomePhoneOverlay, text);
            public IWebElement InputCellPhone(string text = null) => Generic.SendKeys(CellPhone, CellPhoneOverlay, text);
            public IWebElement InputWorkPhone(string text = null) => Generic.SendKeys(WorkPhone, WorkPhoneOverlay, text);
            public IWebElement InputEmail(string text = null) => Generic.SendKeys(txtEmail, txtEmail, text);


            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboPrefix_Input')]")]
            private IWebElement cboPrefix_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFirstName')]")]
            private IWebElement txtFirstName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMiddleName')]")]
            private IWebElement txtMiddleName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtLastName')]")]
            private IWebElement txtLastName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboSuffix_Input')]")]
            private IWebElement cboSuffix_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAddOne')]")]
            private IWebElement txtAddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAddTwo')]")]
            private IWebElement txtAddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCity')]")]
            private IWebElement txtCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'State_Input')]")]
            private IWebElement State_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtZipCode_wrapper')]")]
            private IWebElement txtZipCodeOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtZipCode')]")]
            private IWebElement txtZipCode { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtHomePhone_wrapper')]")]
            private IWebElement HomePhoneOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HomePhone')]")]
            private IWebElement HomePhone { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CellPhone')]")]
            private IWebElement CellPhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'WorkPhone')]")]
            private IWebElement WorkPhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtCellPhone_wrapper')]")]
            private IWebElement CellPhoneOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtWorkPhone_wrapper')]")]
            private IWebElement WorkPhoneOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmail')]")]
            private IWebElement txtEmail { get; set; }
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
            public IWebElement InputFirstName(string text = null) => Generic.SendKeys(txtFirstNameHHI, text);
            public IWebElement InputMiddleName(string text = null) => Generic.SendKeys(txtMiddleNameHHI, text);
            public IWebElement InputLastName(string text = null) => Generic.SendKeys(txtLastNameHHI, text);
            public IWebElement InputRelation(string text = null) => Generic.SendKeys(Relation, Relation, text);
            public IWebElement InputSSN(string text = null) => Generic.SendKeys(txtSSN, txtSSN_wrapper, text);
            public IWebElement ClickHouseholdSave() => Generic.Click(btnHouseHoldSave, 10);
            public IWebElement ClickHouseHoldAdd() => Generic.Click(HouseHoldAdd, 10);
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonMedicareYN')]")]
            private IWebElement PersonMedicareYesRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonMedicareYN_1')]")]
            private IWebElement PersonMedicareNoRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonCoveredInsurance_0')]")]
            private IWebElement YesPersonCoveredInsurance { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonCoveredInsurance_1')]")]
            private IWebElement NoPersonCoveredInsurance { get; set; }
            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnHouseHoldSave')]")]
            private IWebElement btnHouseHoldSave { get; set; }
            #endregion
            #endregion
        }
        public class EmploymentStatusHiringDetails
        {
            IWebDriver context;
            public EmploymentStatusHiringDetails(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpStatus')]")]
            private IWebElement EmpStatusYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpStatus_1')]")]
            private IWebElement EmpStatusNo { get; set; }
            //txtDateHired_dateInput_wrapper
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtDateHired_dateInput_wrapper')]")]
            private IWebElement txtDateHired_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDateHired_dateInput')]")]
            private IWebElement DateHired_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbRetired_0')]")]
            private IWebElement RetiredYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbRetired_1')]")]
            private IWebElement RetiredNo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbSchoolEmp_0')]")]
            private IWebElement SchoolEmpYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchoolEmp_1')]")]
            private IWebElement SchoolEmpNo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchoolEmpPeriod_0')]")]
            private IWebElement SchoolEmpPeriod { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchoolEmpPeriod_1')]")]
            private IWebElement SchoolEmpPeriod2 { get; set; }
            #endregion
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

        }
        public class EmployeeInformation
        {
            IWebDriver context;
            public EmployeeInformation(IWebDriver context)
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
            #region Insurnace Verification > Employee Information
            /// <summary>
            /// Employer Insurance Verification
            /// Cheveron ID: 17
            /// Employee Information
            /// Cheveron ID: 18
            /// </summary>
            /// <param name="firstName"></param>
            /// <param name="middleName"></param>
            /// <param name="lastName"></param>
            /// <param name="SSN"></param>
            /// <param name="DOB"></param>
            /// <param name="DateHired"></param>
            /// <param name="retired"></param>
            /// <param name="schoolEmployed"></param>
            /// <param name="employedTime"></param>
            public void EmployeeInformationInput(
                string firstName = null,
                string middleName = null,
                string lastName = null,
                string SSN = null,
                string DOB = null,
                string DateHired = null,
                string retired = null,
                string schoolEmployed = null,
                string employedTime = null)
            {

                InputFirstName(firstName);
                InputMiddleName(middleName);
                InputLastName(lastName);
                InputSSN(SSN);
                InputDOB(DOB);
                InputDateofHire(DateHired);
                SelectRetiredStatus(retired);
                SelectSchoolEmployent(schoolEmployed);

                if (employedTime == "Yes")
                {
                    ClickSchoolEmploymentLenth10Month();
                }
                else
                {
                    ClickSchoolEmploymentLenth12Month();
                }
 

            }

            public IWebElement InputFirstName(string text = null) => Generic.SendKeys(txtEmpFName, text);
            public IWebElement InputMiddleName(string text = null) => Generic.SendKeys(txtEmpMName, text);
            public IWebElement InputLastName(string text = null) => Generic.SendKeys(txtEmpLName, text);
            public IWebElement InputDOB(string text = null) => Generic.SendKeys(EmpDOB_dateInput, dpEmpDOB_dateInput_wrapper, text);
            public IWebElement InputDateofHire(string text = null) => Generic.SendKeys(EmpDateH_dateInput, dpEmpDateH_dateInput_wrapper, text);
            public IWebElement InputSSN(string text = null) => Generic.SendKeys(txtEmpSSN, txtEmpSSN_wrapper, text);
            public IWebElement ClickRetiredRYes() => Generic.Click(rbEmpRetired_0);
            public IWebElement ClickRetiredNo() => Generic.Click(rbEmpRetired_1);
            public IWebElement ClickEmploymentStatusYes() => Generic.Click(EmployeeInformationSchoolEmpYes);
            public IWebElement ClickEmploymentStatusNo() => Generic.Click(EmployeeInformationSchoolEmpNo);
            public IWebElement SelectSchoolEmployent(string yesno = null) => Generic.DecisionClick(EmployeeInformationSchoolEmpYes, EmployeeInformationSchoolEmpNo, yesno);
            public IWebElement ClickSchoolEmploymentLenth10Month() => Generic.Click(SchoolEmployeeLength10Month);
            public IWebElement ClickSchoolEmploymentLenth12Month() => Generic.Click(SchoolEmployeeLength12Month);

            public IWebElement SelectSchoolEmploymentLength(string tenOrTwelve = null) => Generic.DecisionClick(SchoolEmployeeLength10Month, SchoolEmployeeLength12Month, tenOrTwelve);



            /// <summary>
            /// Yes or NO
            /// </summary>
            /// <param name="yesno"></param>
            /// <returns></returns>
            public IWebElement SelectRetiredStatus(string yesno = null) => Generic.DecisionClick(ClickRetiredRYes(), ClickRetiredNo(), yesno);

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpFName')]")]
            private IWebElement txtEmpFName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpMName')]")]
            private IWebElement txtEmpMName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpLName')]")]
            private IWebElement txtEmpLName { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpSSN')]")]
            private IWebElement txtEmpSSN { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEmpSSN_wrapper')]")]
            private IWebElement txtEmpSSN_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dpEmpDOB_dateInput_wrapper')]")]
            private IWebElement dpEmpDOB_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmpDOB_dateInput')]")]
            private IWebElement EmpDOB_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dpEmpDateH_dateInput_wrapper')]")]
            private IWebElement dpEmpDateH_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmpDateH_dateInput')]")]
            private IWebElement EmpDateH_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpRetired_0')]")]
            private IWebElement rbEmpRetired_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpRetired_1')]")]
            private IWebElement rbEmpRetired_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchEmp_0')]")]
            private IWebElement EmployeeInformationSchoolEmpYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchEmp_1')]")]
            private IWebElement EmployeeInformationSchoolEmpNo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpLen_0')]")]
            private IWebElement SchoolEmployeeLength10Month { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpLen_1')]")]
            private IWebElement SchoolEmployeeLength12Month { get; set; }
            #endregion
        }
        public class MembershipInformation
        {
            IWebDriver context;
            public MembershipInformation(IWebDriver context)
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
            #region Membership (Starting with employee)
            /// <summary>
            /// MemberShip (Starting with Employee)
            /// Work Item Showing Cheveron ID: 19 
            /// </summary>
            /// <param name="firstName"></param>
            /// <param name="middleName"></param>
            /// <param name="lastName"></param>
            /// <param name="date"></param>
            /// <param name="relationShipToPolicy"></param>
            /// <param name="enrolled"></param>
            public void EmployeeMemberInput(
                string enrolled = null,
                string firstName = null,
                string middleName = null,
                string lastName = null,
                string date = null,
                string relationShipToPolicy = null
                )
            {
                ClickMembershipAddButton();

                InputFirstName(firstName);
                InputMiddleName(middleName);
                InputLastName(lastName);
                InputDOB(date);
                InputRelationShipToPolicyHolder(relationShipToPolicy);
                SelectkMemberEnrolled(enrolled);
                ClickMembershipSave();
                Thread.Sleep(2000);

            }
            public IWebElement ClickMembershipAddButton() => Generic.Click(btnMembershipAdd);
            public IWebElement InputFirstName(string text = null) => Generic.SendKeys(txtMemFName, text);
            public IWebElement InputMiddleName(string text = null) => Generic.SendKeys(txtMemMName, text);
            public IWebElement InputLastName(string text = null) => Generic.SendKeys(txtMemLName, text);
            public IWebElement ClickMemberEnrolledYes() => Generic.Click(rbEnrPlan_0);
            public IWebElement ClickMemberEnrolledNo() => Generic.Click(rbEnrPlan_1);
            public IWebElement SelectkMemberEnrolled(string yesno = null) => Generic.DecisionClick(rbEnrPlan_0, rbEnrPlan_1, yesno);
            public IWebElement InputDOB(string text = null) => Generic.SendKeys(dpMemDOB_dateInput, dpMemDOB_dateInput_wrapper, text);
            public IWebElement ClickMembershipSave() => Generic.Click(btnMembershipSav);
            public IWebElement InputRelationShipToPolicyHolder(string text = null) => Generic.SendKeys(cboRelPolHold_Input, text);


            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnMembershipAdd')]")]
            private IWebElement btnMembershipAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemFName')]")]
            private IWebElement txtMemFName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemMName')]")]
            private IWebElement txtMemMName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemLName')]")]
            private IWebElement txtMemLName { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dpMemDOB_dateInput_wrapper')]")]
            private IWebElement dpMemDOB_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'dpMemDOB_dateInput')]")]
            private IWebElement dpMemDOB_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboRelPolHold_Input')]")]
            private IWebElement cboRelPolHold_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEnrPlan_0')]")]
            private IWebElement rbEnrPlan_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEnrPlan_1')]")]
            private IWebElement rbEnrPlan_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnMembershipSav')]")]
            private IWebElement btnMembershipSav { get; set; }
            #endregion

        }
        public class CoverageAreasInformation
        {
            IWebDriver context;
            public CoverageAreasInformation(IWebDriver context)
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
            #region Coverage Areas
            /// <summary>
            /// Coverage
            /// Cheveron ID: 20
            /// </summary>
            /// <param 0 = "employee"></param>
            /// <param 1 = "employeeAndSpouse"></param>
            /// <param 2 = "employeeAndChild"></param>
            /// <param 3 = "employeeAndChildren"></param>
            /// <param 4 = "family"></param>
            /// <param 5 = "other"></param>
            /// <param 6 = "COBRA"></param>
            public void CoverageSelection(
                string text = null)
            {
                switch (text)
                {
                    case "0":
                        ClickEmployeeRadioButton();
                        break;
                    case "1":
                        ClickEmployeeSpouseRadioButton();
                        break;
                    case "2":
                        ClickEmployeeChildRadioButton();
                        break;
                    case "3":
                        ClickEmployeeChildrenRadioButton();
                        break;
                    case "4":
                        ClickFamilyRadioButton();
                        break;
                    case "5":
                        ClickOtherRadioButton();
                        break;
                    case "6":
                        ClickCOBRARadioButton();
                        break;
                    default:
                        return;
                }
            }
            public IWebElement ClickEmployeeRadioButton() => Generic.Click(EmployeeOnlyRadioButton);
            public IWebElement ClickEmployeeSpouseRadioButton() => Generic.Click(EmployeeSpouseRadioButton);
            public IWebElement ClickEmployeeChildRadioButton() => Generic.Click(EmployeeChildRadioButton);
            public IWebElement ClickEmployeeChildrenRadioButton() => Generic.Click(EmployeeChildrenRadioButton);
            public IWebElement ClickFamilyRadioButton() => Generic.Click(FamilyRadioButton);
            public IWebElement ClickOtherRadioButton() => Generic.Click(OtherRadioButton);
            public IWebElement ClickCOBRARadioButton() => Generic.Click(COBRARadioButton);



            /// <summary>
            /// Coverage
            /// Cheveron ID: 20
            /// </summary>
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_0')]")]
            private IWebElement EmployeeOnlyRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_1')]")]
            private IWebElement EmployeeSpouseRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_2')]")]
            private IWebElement EmployeeChildRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_3')]")]
            private IWebElement EmployeeChildrenRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_4')]")]
            private IWebElement FamilyRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_5')]")]
            private IWebElement OtherRadioButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_6')]")]
            private IWebElement COBRARadioButton { get; set; }


            #endregion
        }
        public class OpenEnrollmentInformation
        {
            IWebDriver context;
            public OpenEnrollmentInformation(IWebDriver context)
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
            #region Open Enrollment Input

            /// <summary>
            /// Cheveron ID: 21
            /// </summary>
            /// <param name="PlanEffectiveDate"></param>
            /// <param name="EnrollmentEffectiveFromDate"></param>
            /// <param name="EnrollmentEffectiveToDate"></param>
            public void OpenEnrollmentInformationInput(
                string PlanEffectiveDate = null,
                string EnrollmentEffectiveFromDate = null,
                string EnrollmentEffectiveToDate = null)
            {
                InputPlanEffDateInput(PlanEffectiveDate);
                InputEnrollEffDateInput(EnrollmentEffectiveFromDate);
                InputEnrollEffTDDateInput(EnrollmentEffectiveToDate);
            }

            public IWebElement InputPlanEffDateInput(string text = null) => Generic.SendKeys(PlanEffD_dateInput, PlanEffD_dateInput_wrapper, text);
            public IWebElement InputEnrollEffDateInput(string text = null) => Generic.SendKeys(EnrollEffD_dateInput, EnrollEffD_dateInput_wrapper, text);
            public IWebElement InputEnrollEffTDDateInput(string text = null) => Generic.SendKeys(EnrollEffTD_dateInput, EnrollEffTD_dateInput_wrapper, text);
            /// <summary>
            /// Open enrollment Information
            /// </summary>
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PlanEffD_dateInput')]")]
            private IWebElement PlanEffD_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'PlanEffD_dateInput_wrapper')]")]
            private IWebElement PlanEffD_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EnrollEffD_dateInput')]")]
            private IWebElement EnrollEffD_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'EnrollEffD_dateInput_wrapper')]")]
            private IWebElement EnrollEffD_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EnrollEffTD_dateInput')]")]
            private IWebElement EnrollEffTD_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'EnrollEffTD_dateInput_wrapper')]")]
            private IWebElement EnrollEffTD_dateInput_wrapper { get; set; }
            #endregion

        }
        public class InsuranceType
        {
            IWebDriver context;
            public InsuranceType(IWebDriver context)
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
            #region InsuranceType
            /// <summary>
            /// "Medical, Dental, Vision"
            /// </summary>
            /// <param name="InsuranceType"></param>
            /// <param name="companyName"></param>
            /// <param name="addressLineOne"></param>
            /// <param name="addressLineTwo"></param>
            /// <param name="city"></param>
            /// <param name="state"></param>
            /// <param name="zipCode"></param>
            /// <param name="phoneNumber"></param>
            /// <param name="insurancePolicyGroupNumber"></param>
            public void InsuranceTypeInput(
                string InsuranceType = null,
                string companyName = null,
                string addressLineOne = null,
                string addressLineTwo = null,
                string city = null,
                string state = null,
                string zipCode = null,
                string phoneNumber = null,
                string insurancePolicyGroupNumber = null
                )
            {
                switch (InsuranceType)
                {
                    case "Medical":
                        ClickMedicalLink();
                        InputCompanyName(companyName);
                        InputAddressLineOne(addressLineOne);
                        InputAddressLineOne(addressLineTwo);
                        InputCity(city);
                        InputState(state);
                        InputZipCode(zipCode);
                        InputHomePhone(phoneNumber);
                        InputInsurancePolicy(insurancePolicyGroupNumber);
                        ClickPlanBenefitSave();
                        return;
                    case "Dental":
                        ClickDentalLink();
                        InputCompanyName(companyName);
                        InputAddressLineOne(addressLineOne);
                        InputAddressLineOne(addressLineTwo);
                        InputCity(city);
                        InputState(state);
                        InputZipCode(zipCode);
                        InputHomePhone(phoneNumber);
                        InputInsurancePolicy(insurancePolicyGroupNumber);
                        ClickPlanBenefitSave();
                        return;
                    case "Vision":
                        ClickVisionLink();
                        InputCompanyName(companyName);
                        InputAddressLineOne(addressLineOne);
                        InputAddressLineOne(addressLineTwo);
                        InputCity(city);
                        InputState(state);
                        InputZipCode(zipCode);
                        InputHomePhone(phoneNumber);
                        InputInsurancePolicy(insurancePolicyGroupNumber);
                        ClickPlanBenefitSave();
                        return;
                }
            }

            public IWebElement ClickMedicalLink() => Generic.Click(MedicalEditLink);
            public IWebElement ClickDentalLink() => Generic.Click(DentalEditLink);
            public IWebElement ClickVisionLink() => Generic.Click(VisionEditLink);
            public IWebElement InputCompanyName(string text = null) => Generic.SendKeys(txtCompanyName, text);
            public IWebElement InputInsurancePolicy(string text = null) => Generic.SendKeys(txtInsurPol, text);
            public IWebElement InputAddressLineOne(string text = null) => Generic.SendKeys(txtInsurAddOne, text);
            public IWebElement InputAddressLineTwo(string text = null) => Generic.SendKeys(txtInsurAddTwo, text);
            public IWebElement InputCity(string text = null) => Generic.SendKeys(txtInsurCity, text);
            public IWebElement InputState(string text = null) => Generic.SendKeys(cboInsurState_Input, cboInsurState_wrapper, text);
            public IWebElement InputZipCode(string text = null) => Generic.SendKeys(txtInsurZip, txtInsurZip_wrapper, text);
            public IWebElement InputHomePhone(string text = null) => Generic.SendKeys(txtInsurPNum, txtInsurPNum_wrapper, text);
            public IWebElement ClickPlanBenefitSave() => Generic.Click(btnPlanBenefitsSave);

            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'grdPlanBenefits_ctl00_ctl04_Edit')]")]
            private IWebElement MedicalEditLink { get; set; }
            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'grdPlanBenefits_ctl00_ctl06_Edit')]")]
            private IWebElement DentalEditLink { get; set; }
            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'grdPlanBenefits_ctl00_ctl08_Edit')]")]
            private IWebElement VisionEditLink { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompanyName')]")]
            private IWebElement txtCompanyName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurAddOne')]")]
            private IWebElement txtInsurAddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurAddOne')]")]
            private IWebElement txtInsurAddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurCity')]")]
            private IWebElement txtInsurCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'cboInsurState')]")]
            private IWebElement cboInsurState_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboInsurState_Input')]")]
            private IWebElement cboInsurState_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtInsurZip_wrapper')]")]
            private IWebElement txtInsurZip_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurZip')]")]
            private IWebElement txtInsurZip { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtInsurPNum_wrapper')]")]
            private IWebElement txtInsurPNum_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurPNum')]")]
            private IWebElement txtInsurPNum { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurPol')]")]
            private IWebElement txtInsurPol { get; set; }

            [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnPlanBenefitsSave')]")]
            private IWebElement btnPlanBenefitsSave { get; set; }

            #endregion
        }
        public class PlanBenefit
        {
            IWebDriver context;
            public PlanBenefit(IWebDriver context)
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
            #region Plan benefit
            /// <summary>
            /// Plan Benefits
            /// </summary>
            /// <param name="HSA"></param>
            /// <param name="IAD"></param>
            /// <param name="FAD"></param>
            /// <param name="CompMajorMedical"></param>
            /// <param name="HMOPPO"></param>
            /// <param name="hospitalOnly"></param>
            /// <param name="other"></param>
            /// <param name="medical"></param>
            /// <param name="pharmacy"></param>
            /// <param name="vision"></param>
            /// <param name="dental"></param>
            public void PlanBenifitsInput(
                string HSA = null,
                string IAD = null,
                string FAD = null)
            {
                SelectHSA(HSA);
                InputIndDeduct(IAD);
                InputFamDeduct(FAD);
            }
            /// <summary>
            /// 0 = Comprehensive Major Medical;
            /// 1 = HMOPPO;
            /// 2 = Hospital Only health plan;
            /// 3 = Health Plan other;
            /// 4 = Medical Covered;
            /// 5 = Pharmacy Covered;
            /// 6 = Vision Covered;
            /// 7 = Dental Covred;
            /// </summary>
            /// <param name="selection"></param>
            public void SelectPlansBenefitsCoverage(string selection = null)
            {
                switch (selection)
                {
                    case "0":
                        ClickComprehensiveMajorMedical();
                        break;
                    case "1":
                        ClickHmoPPO();
                        break;
                    case "2":
                        ClickHospitalOnlyHealPlan();
                        break;
                    case "3":
                        ClickHealthPlanOther();
                        break;
                    case "4":
                        ClickMedicalCovered();
                        break;
                    case "5":
                        ClickPharmacyCovered();
                        break;
                    case "6":
                        ClickVisionCovered();
                        break;
                    case "7":
                        ClickDentalCovered();
                        break;
                }
            }


            public IWebElement ClickHSAYes() => Generic.Click(HSAYes);
            public IWebElement ClickHSANo() => Generic.Click(HSANo);
            public IWebElement SelectHSA(string yesno = null) => Generic.DecisionClick(HSAYes, HSANo, yesno);
            public IWebElement InputIndDeduct(string text = null) => Generic.SendKeys(txtIndDeduct, txtIndDeduct_wrapper, text);
            public IWebElement InputFamDeduct(string text = null) => Generic.SendKeys(txtFamDeduct, txtFamDeduct_wrapper, text);
            public IWebElement ClickComprehensiveMajorMedical() => Generic.Click(ComprehensiveMajorMedical);
            public IWebElement ClickHmoPPO() => Generic.Click(HmoPPO);
            public IWebElement ClickHospitalOnlyHealPlan() => Generic.Click(HospitalOnlyHealPlan);
            public IWebElement ClickHealthPlanOther() => Generic.Click(HealthPlanOther);
            public IWebElement ClickMedicalCovered() => Generic.Click(MedicalCovered);
            public IWebElement ClickPharmacyCovered() => Generic.Click(PharmacyCovered);
            public IWebElement ClickVisionCovered() => Generic.Click(VisionCovered);
            public IWebElement ClickDentalCovered() => Generic.Click(DentalCovered);


            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbHSA_0')]")]
            private IWebElement HSAYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbHSA_1')]")]
            private IWebElement HSANo { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtIndDeduct_wrapper')]")]
            private IWebElement txtIndDeduct_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtIndDeduct')]")]
            private IWebElement txtIndDeduct { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtFamDeduct_wrapper')]")]
            private IWebElement txtFamDeduct_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFamDeduct')]")]
            private IWebElement txtFamDeduct { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_0')]")]
            private IWebElement ComprehensiveMajorMedical { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_1')]")]
            private IWebElement HmoPPO { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_2')]")]
            private IWebElement HospitalOnlyHealPlan { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_3')]")]
            private IWebElement HealthPlanOther { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_0')]")]
            private IWebElement MedicalCovered { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_1')]")]
            private IWebElement PharmacyCovered { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_2')]")]
            private IWebElement VisionCovered { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_3')]")]
            private IWebElement DentalCovered { get; set; }

            #endregion
        }
        /// <summary>
        /// Click Save
        /// </summary>
        public void ClickSave()
        {
            //wait.Until(ExpectedConditions.ElementToBeClickable(lnkSavePanel));
            lnkSavePanel.Click();
        }
        public bool checkSave()
        {
            return lnkSavePanel.Displayed;
        }
        /// <summary>
        /// Buttons
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'lnkSavePanel')]")]
        private IWebElement lnkSavePanel { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnWorkItemTop')]")]
        private IWebElement HiPPWorkItemTop { get; set; }
        [FindsBy(How = How.ClassName, Using = "errorTitle")]
        private IWebElement errorTitle { get; set; }


    }

}
