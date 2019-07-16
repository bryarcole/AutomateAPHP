using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Reflection;
using TestProject.Common;
using TestProject.SDK.PageObjects;
using SeleniumExtras.PageObjects;

namespace AutomateAPHP
{
    public class HIPPSubmitApplicationPage
    {
        IWebDriver context;
        WebDriverWait wait;

        DateTime today = new DateTime();
        //utility utility = new utility(context);



        public HIPPSubmitApplicationPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }


        #region Application Overivew
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
            string appRecieveDate,
            string eIVRecieveDate,
            string annualRenewalDate,
            string annualToDate,
            string quarterlyValidationDueDate,
            string hippCaseNo)
        {

            clickAppRecieveDate();
            ApplicationReceiveDate.SendKeys(appRecieveDate);
            EIVRecievedDateOverlay.Click();
            EIVRecieveDate.SendKeys(eIVRecieveDate);
            AnnualRenewalDatesOverlay.Click();
            AnnualRenewalDates.SendKeys(annualRenewalDate);
            AnnualToDateOverlay.Click();
            AnnualToDate.SendKeys(DateTime.Today.ToString(annualToDate));
            QuarterlyValidationDueDatesOverlay.Click();
            QuarterlyValidationDueDates.SendKeys(quarterlyValidationDueDate);
            HIPPCaseNo.Click();
            HIPPCaseNo.SendKeys(hippCaseNo);

            ApplicationType.SendKeys("New");

        }

        public void clickAppRecieveDate()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            
            wait.Until(context =>
            {
                try
                {
                    ApplicationRecieveDateOverlay.Click();
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
                        Console.Write(ex);
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }

                return true;
            });
        }
        public void ApplicationTypeInput(string input)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));

            wait.Until(context =>
            {
                try
                {
                    ApplicationType.SendKeys(input);
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
        }

        /// <summary>
        /// Application OverView
        /// Cheveron ID: 7
        /// </summary>
        /// 

        //Applicate recieve date  (needs overlay click to be invovable.)
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ApplicationRecievedDate_dateInput_wrapper')]")]
        public IWebElement ApplicationRecieveDateOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ApplicationRecievedDate_dateInput')]")]
        public IWebElement ApplicationReceiveDate;
        //Annual Date  (needs overlay click to be invovable.)
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'AnnualToDate_dateInput_wrapper')]")]
        public IWebElement AnnualRenewalDatesOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AnnualToDate_dateInput')]")]
        public IWebElement AnnualRenewalDates;
        //EIV recievedDate  (needs overlay click to be invovable.)
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'EIVRecievedDate_dateInput_wrapper')]")]
        public IWebElement EIVRecievedDateOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EIVRecievedDate_dateInput')]")]
        public IWebElement EIVRecieveDate;

        //Anunnual TO date  (needs overlay click to be invovable.)

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'AnnualRenewalDates_dateInput_wrapper')]")]
        public IWebElement AnnualToDateOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AnnualRenewalDates_dateInput')]")]
        public IWebElement AnnualToDate;

        //Application Type (needs overlay click to be invovable.)
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ApplicationType')]")]
        public IWebElement ApplicationType;


        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HIPPCaseNo')]")]
        public IWebElement HIPPCaseNo;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'QuarterlyValidationDueDates_dateInput_wrapper')]")]
        public IWebElement QuarterlyValidationDueDatesOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'QuarterlyValidationDueDates_dateInput')]")]
        public IWebElement QuarterlyValidationDueDates;

        #endregion
        #region Validation Overview
        /// <summary>
        /// Validation Overview
        /// Cheveron ID: 8
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnAddSchool')]")]
        public IWebElement btnAddSchool;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnAddCobra')]")]
        public IWebElement btnAddCobra;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnAddReEval')]")]
        public IWebElement btnAddReEval;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnAddQuarterlyValidation')]")]
        public IWebElement btnAddQuarterlyValidation;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnAddCostSharingValidation')]")]
        public IWebElement btnAddCostSharingValidation;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnAddAnnualRewnewalValidation')]")]
        public IWebElement btnAddAnnualRewnewalValidation;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnValid')]")]
        public IWebElement btnValid;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnNotValid')]")]
        public IWebElement btnNotValid;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'ValidationUd')]")]
        public IWebElement ValidationUd;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ValidationStatusUd')]")]
        public IWebElement ValidationStatusUd;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ValidatedBy')]")]
        public IWebElement ValidatedBy;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'RDIPFDateValidated_dateInput')]")]
        public IWebElement RDIPFDateValidated_dateInput;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ValidationReason')]")]
        public IWebElement ValidationReason;

        #endregion
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

            txtFirstName.SendKeys(firstName);
            txtMiddleName.SendKeys(midddleName);
            txtLastName.SendKeys(lastName);
            txtAddOne.SendKeys(addressLineOne);
            txtAddTwo.SendKeys(addressLineTwo);
            txtCity.SendKeys(city);
            State_Input.SendKeys(state);
            txtZipCodeOverlay.Click();
            txtZipCode.SendKeys(zip);
            HomePhoneOverlay.Click();
            HomePhone.SendKeys(homePhone);
            CellPhoneOverlay.Click();
            CellPhone.SendKeys(cellPhone);
            WorkPhoneOverlay.Click();
            WorkPhone.SendKeys(workPhone);
            txtEmail.SendKeys(emailAddress);

        }



        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboPrefix_Input')]")]
        public IWebElement cboPrefix_Input;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFirstName')]")]
        public IWebElement txtFirstName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMiddleName')]")]
        public IWebElement txtMiddleName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtLastName')]")]
        public IWebElement txtLastName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboSuffix_Input')]")]
        public IWebElement cboSuffix_Input;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAddOne')]")]
        public IWebElement txtAddOne;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAddTwo')]")]
        public IWebElement txtAddTwo;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCity')]")]
        public IWebElement txtCity;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'State_Input')]")]
        public IWebElement State_Input;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtZipCode_wrapper')]")]
        public IWebElement txtZipCodeOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtZipCode')]")]
        public IWebElement txtZipCode;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtHomePhone_wrapper')]")]
        public IWebElement HomePhoneOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HomePhone')]")]
        public IWebElement HomePhone;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CellPhone')]")]
        public IWebElement CellPhone;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'WorkPhone')]")]
        public IWebElement WorkPhone;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtCellPhone_wrapper')]")]
        public IWebElement CellPhoneOverlay;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtWorkPhone_wrapper')]")]
        public IWebElement WorkPhoneOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmail')]")]
        public IWebElement txtEmail;
        #endregion
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
            string relation,
            string firstName,
            string middleName,
            string lastName,
            string DOB,
            string MedicaidID,
            string SSN,
            string MedicareStatus,
            string InsuranceStatus)
        {
            ClickHouseHoldAdd();
            InputRelation(relation);
            InputName( firstName, middleName,  lastName);
            HouseHoldDOBInput(DOB);
            HouseholdInformationMemberID.SendKeys(MedicaidID);
            txtSSN_wrapper.Click();
            txtSSN.SendKeys(SSN);



            //Radio Buttons
            ClickRadioButtonsHHI(MedicareStatus, InsuranceStatus);
            ClickHouseholdSave();
        }
        public void InputRelation(string relation)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {

                    Relation.Click();
                    Relation.SendKeys(relation);
                    Relation.SendKeys(OpenQA.Selenium.Keys.Tab);
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

        }
        public void ClickHouseholdSave()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    btnHouseHoldSave.Click();
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
            
        }
        public void ClickHouseHoldAdd()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    HouseHoldAdd.Click();
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
            
        }
        public void InputName(string firstName, string middleName, string lastName)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    txtFirstNameHHI.Clear();
                    txtFirstNameHHI.SendKeys(firstName);
                    txtMiddleNameHHI.Clear();
                    txtMiddleNameHHI.SendKeys(middleName);
                    txtLastNameHHI.Clear();
                    txtLastNameHHI.SendKeys(lastName);
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

        }
        public void HouseHoldDOBInput(string DOB)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(DOBHHI_wrapperOverlay));
            DOBHHI_wrapperOverlay.Click();
            dpDOBHHI_dateInput.SendKeys(DOB);
        }

        public void ClickRadioButtonsHHI(string MedicareStatus, string InsuranceStatus)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    if (MedicareStatus == "Yes")
                    {
                        PersonMedicareYesRadioButton.Click();
                    }
                    else
                    {
                        PersonMedicareNoRadioButton.Click();
                    }
                    if (InsuranceStatus == "Yes")
                    {
                        YesPersonCoveredInsurance.Click();
                    }
                    else
                    {
                        NoPersonCoveredInsurance.Click();
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
            //Radio Buttons
 
        }
        #endregion

        #region Household Elements
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'HouseHoldAdd')]")]
        public IWebElement HouseHoldAdd;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboRelation_ClientState')]")]
        public IWebElement RelationOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboRelation_Input')]")]
        public IWebElement Relation;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFirstNameHHI')]")]
        public IWebElement txtFirstNameHHI;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMiddleNameHHI')]")]
        public IWebElement txtMiddleNameHHI;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtLastNameHHI')]")]
        public IWebElement txtLastNameHHI;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'dpDOBHHI_dateInput')]")]
        public IWebElement dpDOBHHI_dateInput;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DOBHHI_wrapper')]")]
        public IWebElement DOBHHI_wrapperOverlay;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HouseholdInformationMemberID')]")]
        public IWebElement HouseholdInformationMemberID;
        //txtSSN_wrapper
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtSSN_wrapper')]")]
        public IWebElement txtSSN_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtSSN')]")]
        public IWebElement txtSSN;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonMedicareYN')]")]
        public IWebElement PersonMedicareYesRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonMedicareYN_1')]")]
        public IWebElement PersonMedicareNoRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonCoveredInsurance_0')]")]
        public IWebElement YesPersonCoveredInsurance;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPersonCoveredInsurance_1')]")]
        public IWebElement NoPersonCoveredInsurance;
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnHouseHoldSave')]")]
        public IWebElement btnHouseHoldSave;
        #endregion

        #endregion


        #region Employment Information > Employment Status/Hiring Details
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
        public void EmploymentStatusHiringInput(
            bool employmentStatus,
            string dateHired,
            bool retired,
            bool schoolEmployment,
            bool employmentPeriod)
        {

            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    txtDateHired_dateInput_wrapper.Click();
                    DateHired_dateInput.Clear();
                    DateHired_dateInput.SendKeys(dateHired);
  
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
                    if (schoolEmployment == true)
                    {
                        SchoolEmpYes.Click();
                    }
                    else
                    {
                        SchoolEmpNo.Click();
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
                    if (employmentStatus == true)
                    {
                        EmpStatusYes.Click();
                    }
                    else
                    {
                        EmpStatusNo.Click();
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
                    if (retired == true)
                    {
                        RetiredYes.Click();

                    }
                    else
                    {
                        RetiredNo.Click();

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
                    if (employmentPeriod == true)
                    {

                        SchoolEmpPeriod.Click();

                    }
                    else
                    {
                        SchoolEmpPeriod2.Click();
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

        }


        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpStatus')]")]
        public IWebElement EmpStatusYes;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpStatus_1')]")]
        public IWebElement EmpStatusNo;
        //txtDateHired_dateInput_wrapper
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtDateHired_dateInput_wrapper')]")]
        public IWebElement txtDateHired_dateInput_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDateHired_dateInput')]")]
        public IWebElement DateHired_dateInput;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbRetired_0')]")]
        public IWebElement RetiredYes;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbRetired_1')]")]
        public IWebElement RetiredNo;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbSchoolEmp_0')]")]
        public IWebElement SchoolEmpYes;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchoolEmp_1')]")]
        public IWebElement SchoolEmpNo;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchoolEmpPeriod')]")]
        public IWebElement SchoolEmpPeriod;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchoolEmpPeriod')]")]
        public IWebElement SchoolEmpPeriod2;

        #endregion
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
        #endregion
        #region Employment Info Elements
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmployerName')]")]
        public IWebElement txtEmployerName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFedEmp')]")]
        public IWebElement txtFedEmp;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpAddOne')]")]
        public IWebElement txtEmpAddOne;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpAddTwo')]")]
        public IWebElement txtEmpAddTwo;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpCity')]")]
        public IWebElement txtEmpCity;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmpState_Input')]")]
        public IWebElement EmpState_Input;
        //txtEmpZip_wrapper
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEmpZip_wrapper')]")]
        public IWebElement txtEmpZip_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpZip')]")]
        public IWebElement txtEmpZip;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtHuman')]")]
        public IWebElement txtHuman;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDepartment')]")]
        public IWebElement txtDepartment;
        //txtPhoneNum_wrapper
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtPhoneNum_wrapper')]")]
        public IWebElement txtPhoneNum_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtPhoneNum')]")]
        public IWebElement txtPhoneNum;
        #endregion
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
        public IWebElement txtCompName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFEIN')]")]
        public IWebElement txtFEIN;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompAddOne')]")]
        public IWebElement txtCompAddOne;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompAddTwo')]")]
        public IWebElement txtCompAddTwo;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompCity')]")]
        public IWebElement txtCompCity;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CompState_Input')]")]
        public IWebElement CompState_Input;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompZip')]")]
        public IWebElement txtCompZip;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtContactPer')]")]
        public IWebElement txtContactPer;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompPhoneNum')]")]
        public IWebElement txtCompPhoneNum;
        [FindsBy(How = How.Id, Using = "//div[contains(@id, 'txtCompZip_wrapper')]")]
        public IWebElement txtCompZip_wrapper;
        [FindsBy(How = How.Id, Using = "//div[contains(@id, 'txtCompPhoneNum_wrapper')]")]
        public IWebElement txtCompPhoneNumWrapper;
        #endregion
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
        public IWebElement EmployerPlan;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_1')]")]
        public IWebElement COBRARadio;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbInsuranceType_2')]")]
        public IWebElement IndividualPolicyRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_0')]")]
        public IWebElement SelfemployedYesRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_1')]")]
        public IWebElement SelfEmployedNoRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbPolHold_2')]")]
        public IWebElement SelfEmployedNARadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PlanEff_dateInput')]")]
        public IWebElement PlanEff_dateInput;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dateInput_wrapper')]")]
        public IWebElement dateInput_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboPayInsur_Input')]")]
        public IWebElement cboPayInsur_Input;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOtherFrequency')]")]
        public IWebElement txtOtherFrequency;
        [FindsBy(How = How.Id, Using = "//div[contains(@id, txtAmountPaid_wrapper')]")]
        public IWebElement txtAmountPaidWrapper;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAmountPaid')]")]
        public IWebElement txtAmountPaid;

        #endregion
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
            string firstName,
            string middleName,
            string lastName,
            string SSN,
            string DOB,
            string DateHired,
            bool retired,
            bool schoolEmployed,
            bool employedTime)
        {

            txtEmpFName.SendKeys(firstName);
            txtEmpMName.SendKeys(middleName);
            txtEmpLName.SendKeys(lastName);
            txtEmpSSN_wrapper.Click();
            txtEmpSSN.SendKeys(SSN);
            dpEmpDOB_dateInput_wrapper.Click();
            EmpDOB_dateInput.SendKeys(DOB);
            dpEmpDateH_dateInput_wrapper.Click();
            EmpDateH_dateInput.SendKeys(DateHired);



            if (retired)
            {
                rbEmpRetired_0.Click();
            }
            else
            {
                rbEmpRetired_1.Click();
            }
            if (schoolEmployed)
            {
                EmployeeInformationSchoolEmpYes.Click();
                Thread.Sleep(2000);
                if (employedTime)
                {
                    SchoolEmployeeLength10Month.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    SchoolEmployeeLength12Month.Click();
                    Thread.Sleep(2000);
                }
            }
            else
            {
                EmployeeInformationSchoolEmpNo.Click();
                Thread.Sleep(2000);
            }

        }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpFName')]")]
        public IWebElement txtEmpFName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpMName')]")]
        public IWebElement txtEmpMName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpLName')]")]
        public IWebElement txtEmpLName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEmpSSN')]")]
        public IWebElement txtEmpSSN;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEmpSSN_wrapper')]")]
        public IWebElement txtEmpSSN_wrapper;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dpEmpDOB_dateInput_wrapper')]")]
        public IWebElement dpEmpDOB_dateInput_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmpDOB_dateInput')]")]
        public IWebElement EmpDOB_dateInput;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dpEmpDateH_dateInput_wrapper')]")]
        public IWebElement dpEmpDateH_dateInput_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmpDateH_dateInput')]")]
        public IWebElement EmpDateH_dateInput;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpRetired_0')]")]
        public IWebElement rbEmpRetired_0;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpRetired_1')]")]
        public IWebElement rbEmpRetired_1;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchEmp_0')]")]
        public IWebElement EmployeeInformationSchoolEmpYes;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SchEmp_1')]")]
        public IWebElement EmployeeInformationSchoolEmpNo;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpLen_0')]")]
        public IWebElement SchoolEmployeeLength10Month;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEmpLen_1')]")]
        public IWebElement SchoolEmployeeLength12Month;
        #endregion
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
            string firstName, 
            string middleName,
            string lastName,
            string date,
            string relationShipToPolicy,
            bool enrolled
            )
        {
            btnMembershipAdd.Click();
            txtMemFName.SendKeys(firstName);
            txtMemMName.SendKeys(middleName);
            txtMemLName.SendKeys(lastName);
            dpMemDOB_dateInput_wrapper.Click();
            dpMemDOB_dateInput.SendKeys(date);
            cboRelPolHold_Input.SendKeys(relationShipToPolicy);
            if (enrolled)
            {
                rbEnrPlan_0.Click();
            }
            else
            {
                rbEnrPlan_1.Click();
            }
            btnMembershipSav.Click();
            Thread.Sleep(2000);

        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnMembershipAdd')]")]
        public IWebElement btnMembershipAdd;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemFName')]")]
        public IWebElement txtMemFName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemMName')]")]
        public IWebElement txtMemMName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemLName')]")]
        public IWebElement txtMemLName;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dpMemDOB_dateInput_wrapper')]")]
        public IWebElement dpMemDOB_dateInput_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'dpMemDOB_dateInput')]")]
        public IWebElement dpMemDOB_dateInput;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboRelPolHold_Input')]")]
        
        public IWebElement cboRelPolHold_Input;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEnrPlan_0')]")]

        public IWebElement rbEnrPlan_0;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbEnrPlan_1')]")]

        public IWebElement rbEnrPlan_1;
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnMembershipSav')]")]
        
        public IWebElement btnMembershipSav;
        #endregion


        #region Coverage Areas
        /// <summary>
        /// Coverage
        /// Cheveron ID: 20
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeAndSpouse"></param>
        /// <param name="employeeAndChild"></param>
        /// <param name="employeeAndChildren"></param>
        /// <param name="family"></param>
        /// <param name="other"></param>
        /// <param name="COBRA"></param>
        public void CoverageSelection(
            bool employee,
            bool employeeAndSpouse,
            bool employeeAndChild,
            bool employeeAndChildren,
            bool family,
            bool other,
            bool COBRA)
        {
            if (employee)
            {
                EmployeeOnlyRadioButton.Click();
            }
            else
            {
                EmployeeOnlyRadioButton.Clear();
            }
            if (employeeAndSpouse)
            {
                EmployeeSpouseRadioButton.Click();
            }
            if (employeeAndChild)
            {
                EmployeeChildRadioButton.Click();
            }
            if (employeeAndChildren)
            {
                EmployeeChildrenRadioButton.Click();
            }
            if (family)
            {
                FamilyRadioButton.Click();
            }
            if (other)
            {
                OtherRadioButton.Click();
            }
            if (COBRA)
            {
                COBRARadioButton.Click();
            }
        }

        /// <summary>
        /// Coverage
        /// Cheveron ID: 20
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_0')]")]
        public IWebElement EmployeeOnlyRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_1')]")]
        public IWebElement EmployeeSpouseRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_2')]")]
        public IWebElement EmployeeChildRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_3')]")]
        public IWebElement EmployeeChildrenRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_4')]")]
        public IWebElement FamilyRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_5')]")]
        public IWebElement OtherRadioButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCovType_6')]")]
        public IWebElement COBRARadioButton;


        #endregion
        #region Open Enrollment Input

        /// <summary>
        /// Cheveron ID: 21
        /// </summary>
        /// <param name="PlanEffectiveDate"></param>
        /// <param name="EnrollmentEffectiveFromDate"></param>
        /// <param name="EnrollmentEffectiveToDate"></param>
        public void OpenEnrollmentInformationInput(
            string PlanEffectiveDate,
            string EnrollmentEffectiveFromDate,
            string EnrollmentEffectiveToDate)
        {
            PlanEffD_dateInput_wrapper.Click();
            PlanEffD_dateInput.SendKeys(PlanEffectiveDate);
            EnrollEffD_dateInput_wrapper.Click();
            EnrollEffD_dateInput.SendKeys(EnrollmentEffectiveFromDate);
            EnrollEffTD_dateInput_wrapper.Click();
            EnrollEffTD_dateInput.SendKeys(EnrollmentEffectiveToDate);
        }
        /// <summary>
        /// Open enrollment Information
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PlanEffD_dateInput')]")]
        public IWebElement PlanEffD_dateInput;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'PlanEffD_dateInput_wrapper')]")]
        public IWebElement PlanEffD_dateInput_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EnrollEffD_dateInput')]")]
        public IWebElement EnrollEffD_dateInput;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'EnrollEffD_dateInput_wrapper')]")]
        public IWebElement EnrollEffD_dateInput_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EnrollEffTD_dateInput')]")]
        public IWebElement EnrollEffTD_dateInput;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'EnrollEffTD_dateInput_wrapper')]")]
        public IWebElement EnrollEffTD_dateInput_wrapper;
#endregion

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
        public void InsuranceType(
            string InsuranceType,
            string companyName,
            string addressLineOne,
            string addressLineTwo,
            string city,
            string state,
            string zipCode,
            string phoneNumber,
            string insurancePolicyGroupNumber
            )
        {
            switch (InsuranceType)
            {
                case "Medical":
                    MedicalEditLink.Click();
                    txtCompanyName.SendKeys(companyName);
                    txtInsurAddOne.SendKeys(addressLineOne);
                    txtInsurAddTwo.SendKeys(addressLineTwo);
                    txtInsurCity.SendKeys(city);
                    cboInsurState_wrapper.Click();
                    cboInsurState_Input.SendKeys(state);
                    txtInsurZip_wrapper.Click();
                    txtInsurZip.SendKeys(zipCode);
                    txtInsurPNum_wrapper.Click();
                    txtInsurPNum.SendKeys(phoneNumber);
                    txtInsurPol.SendKeys(insurancePolicyGroupNumber);
                    btnPlanBenefitsSave.Click();

                    break;
                case "Dental":
                    DentalEditLink.Click();
                    txtCompanyName.SendKeys(companyName);
                    txtInsurAddOne.SendKeys(addressLineOne);
                    txtInsurAddTwo.SendKeys(addressLineTwo);
                    txtInsurCity.SendKeys(city);
                    cboInsurState_wrapper.Click();
                    cboInsurState_Input.SendKeys(state);
                    txtInsurZip_wrapper.Click();
                    txtInsurZip.SendKeys(zipCode);
                    txtInsurPNum_wrapper.Click();
                    txtInsurPNum.SendKeys(phoneNumber);
                    txtInsurPol.SendKeys(insurancePolicyGroupNumber);
                    btnPlanBenefitsSave.Click();
                    break;
                case "Vision":
                    VisionEditLink.Click();

                    txtCompanyName.SendKeys(companyName);
                    txtInsurAddOne.SendKeys(addressLineOne);
                    txtInsurAddTwo.SendKeys(addressLineTwo);
                    txtInsurCity.SendKeys(city);
                    cboInsurState_wrapper.Click();
                    cboInsurState_Input.SendKeys(state);
                    txtInsurZip_wrapper.Click();
                    txtInsurZip.SendKeys(zipCode);
                    txtInsurPNum_wrapper.Click();
                    txtInsurPNum.SendKeys(phoneNumber);
                    txtInsurPol.SendKeys(insurancePolicyGroupNumber);
                    btnPlanBenefitsSave.Click();
                    break;
            }
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'grdPlanBenefits_ctl00_ctl04_Edit')]")]
        public IWebElement MedicalEditLink;
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'grdPlanBenefits_ctl00_ctl06_Edit')]")]
        public IWebElement DentalEditLink;
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'grdPlanBenefits_ctl00_ctl08_Edit')]")]
        public IWebElement VisionEditLink;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCompanyName')]")]
        public IWebElement txtCompanyName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurAddOne')]")]
        public IWebElement txtInsurAddOne;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurAddOne')]")]
        public IWebElement txtInsurAddTwo;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurCity')]")]
        public IWebElement txtInsurCity;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'cboInsurState')]")]
        public IWebElement cboInsurState_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboInsurState_Input')]")]
        public IWebElement cboInsurState_Input;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtInsurZip_wrapper')]")]
        public IWebElement txtInsurZip_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurZip')]")]
        public IWebElement txtInsurZip;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtInsurPNum_wrapper')]")]
        public IWebElement txtInsurPNum_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurPNum')]")]
        public IWebElement txtInsurPNum;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtInsurPol')]")]
        public IWebElement txtInsurPol;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnPlanBenefitsSave')]")]
        public IWebElement btnPlanBenefitsSave;


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
            bool HSA,
            string IAD,
            string FAD,
            bool CompMajorMedical,
            bool HMOPPO,
            bool hospitalOnly,
            bool other,
            bool medical,
            bool pharmacy,
            bool vision,
            bool dental)
        {

            if (HSA)
            {
                HSAYes.Click();
            }
            else
            {
                HSANo.Click();
            }
            if (CompMajorMedical)
            {
                comprehensiveMajorMedical.Click();
            }
            if (HMOPPO)
            {
                hmoPPO.Click();
            }
            if (hospitalOnly)
            {
                hospitalOnlyHealPlan.Click();
            }
            if (other)
            {
                healthPlanOther.Click();
            }
            if (medical)
            {
                medicalCovered.Click();
            }
            if (pharmacy)
            {
                pharmacyCovered.Click();
            }
            if (vision)
            {
                visionCovered.Click();
            }
            if (dental)
            {
                dentalCovered.Click();
            }
            txtIndDeduct_wrapper.Click();
            txtIndDeduct.SendKeys(IAD);
            txtFamDeduct_wrapper.Click();
            txtFamDeduct.SendKeys(FAD);
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbHSA_0')]")]
        public IWebElement HSAYes;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'rbHSA_1')]")]
        public IWebElement HSANo;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtIndDeduct_wrapper')]")]
        public IWebElement txtIndDeduct_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtIndDeduct')]")]
        public IWebElement txtIndDeduct;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtFamDeduct_wrapper')]")]
        public IWebElement txtFamDeduct_wrapper;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFamDeduct')]")]
        public IWebElement txtFamDeduct;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_0')]")]
        public IWebElement comprehensiveMajorMedical;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_1')]")]
        public IWebElement hmoPPO;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_2')]")]
        public IWebElement hospitalOnlyHealPlan;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbHealthPlan_3')]")]
        public IWebElement healthPlanOther;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_0')]")]
        public IWebElement medicalCovered;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_1')]")]
        public IWebElement pharmacyCovered;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_2')]")]
        public IWebElement visionCovered;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cbCoveredServ_3')]")]
        public IWebElement dentalCovered;

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
        public IWebElement lnkSavePanel;
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnWorkItemTop')]")]
        public IWebElement HiPPWorkItemTop;
        [FindsBy(How = How.ClassName, Using = "errorTitle")]
        public IWebElement errorTitle;


    }

}
