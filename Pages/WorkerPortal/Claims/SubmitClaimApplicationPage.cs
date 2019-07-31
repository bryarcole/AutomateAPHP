using NUnit.Tests1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
namespace NUnit.Tests1.Pages.WorkerPortal.Claims
{
    public class SubmitClaimApplicationPage
    {
        public class ClaimSummaryInformation
        {
            IWebDriver context;
            public ClaimSummaryInformation(IWebDriver context)
            {
                this.context = context;
#pragma warning disable CS0618 // Type or member is obsolete
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
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtClaimNo')]")]
            private IWebElement txtClaimNo { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtClaimStatus')]")]
            private IWebElement txtClaimStatus { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtBenefitPlan')]")]
            private IWebElement txtBenefitPlan { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtDuplicate')]")]
            private IWebElement txtDuplicate { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtAdjust')]")]
            private IWebElement txtAdjust { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtClean')]")]
            private IWebElement txtClean { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEncounter')]")]
            private IWebElement txtEncounter { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtCrossOver')]")]
            private IWebElement txtCrossOver { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMediaType')]")]
            private IWebElement txtMediaType { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtVoid')]")]
            private IWebElement txtVoid { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtRemittanceAdviceNumber')]")]
            private IWebElement txtRemittanceAdviceNumber { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtRemittanceAdviceDate')]")]
            private IWebElement txtRemittanceAdviceDate { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'AdjustmentReason_Input')]")]
            private IWebElement AdjustmentReason_Input { get; set; }

            #endregion
            #region Method and Calls
            public string ClaimNumber => Generic.GetText(txtClaimNo);
            public string GetCleanStatus => Generic.GetText(txtClean);
            public string GetClaimEncounterStatus => Generic.GetText(txtClaimStatus);
            public string GetBenefitPlan => Generic.GetText(txtBenefitPlan);
            public string GetDuplicateStatus => Generic.GetText(txtDuplicate);
            public string GetAdjustedStatus => Generic.GetText(txtAdjust);
            public string GetCrossoverStatus => Generic.GetText(txtCrossOver);
            public string GetMediaSource => Generic.GetText(txtMediaType);
            public string GetVoidStatus => Generic.GetText(txtVoid);
            public string RemittanceAdviceNumber => Generic.GetText(txtRemittanceAdviceNumber);
            public string RemittanceAdviceDate => Generic.GetText(txtRemittanceAdviceDate);
            public IWebElement InputAdjustmentReason(string text = null) => Generic.SendKeys(AdjustmentReason_Input, text);

            #endregion
        }
        public class ResultCodes
        {
            IWebDriver context;
            public ResultCodes(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }
            #region Elements
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtClaimNo')]")]
            private IWebElement txtClaimNo { get; set; }


            #endregion
            #region Method and Calls


            #endregion
        }
        public class ClaimDates
        {
            IWebDriver context;
            public ClaimDates(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DateOfRec_dateInput_wrapper')]")]
            private IWebElement DateOfRec_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DateOfRec_dateInput')]")]
            private IWebElement DateOfRec_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'tdCleanClaimDate')]")]
            private IWebElement tdCleanClaimDate { get; set; }
            
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DateofCur_dateInput_wrapper')]")]
            private IWebElement DateofCur_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DateofCur_dateInput')]")]
            private IWebElement DateofCur_dateInput { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'UnabletoWorkTo_dateInput_wrapper')]")]
            private IWebElement UnabletoWorkTo_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'UnabletoWorkTo_dateInput')]")]
            private IWebElement UnabletoWorkTo_dateInput { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'Unableto_dateInput_wrapper')]")]
            private IWebElement UnabletoFrom_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Unableto_dateInput')]")]
            private IWebElement UnabletoFrom_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'Hospitafrom_dateInput_wrapper')]")]
            private IWebElement Hospitafrom_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Hospitafrom_dateInput')]")]
            private IWebElement Hospitafrom_dateInput { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'Hospitato_dateInput_wrapper')]")]
            private IWebElement Hospitato_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Hospitato_dateInput')]")]
            private IWebElement Hospitato_dateInput { get; set; }
            
            //Application Type (needs overlay click to be invovable.)
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ApplicationType')]")]
            private IWebElement ApplicationType { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HIPPCaseNo')]")]
            private IWebElement HIPPCaseNo { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'QuarterlyValidationDueDates_dateInput_wrapper')]")]
            private IWebElement QuarterlyValidationDueDatesOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'QuarterlyValidationDueDates_dateInput')]")]
            private IWebElement QuarterlyValidationDueDates { get; set; }
            #endregion
            #region Method and Calls
            public IWebElement InputDateOfReciept(string text = null) => Generic.SendKeys(DateOfRec_dateInput, DateOfRec_dateInput_wrapper, text);
            public IWebElement InputDateOfCurrent(string text = null) => Generic.SendKeys(DateofCur_dateInput, DateofCur_dateInput_wrapper, text);
            public IWebElement InputUnableToWorkFrom(string text = null) => Generic.SendKeys(UnabletoFrom_dateInput, UnabletoFrom_dateInput_wrapper, text);
            public IWebElement InputUnableToWorkTo(string text = null) => Generic.SendKeys(UnabletoFrom_dateInput, UnabletoFrom_dateInput_wrapper, text);
            public IWebElement InputHospitalizationDateFrom(string text = null) => Generic.SendKeys(Hospitafrom_dateInput, Hospitafrom_dateInput_wrapper, text);
            public IWebElement InputHospitalizationDateTo(string text = null) => Generic.SendKeys(Hospitato_dateInput, Hospitato_dateInput_wrapper, text);

            #endregion
        }
        public class ClaimsAdmissionAndDischarge
        {
            IWebDriver context;
            public ClaimsAdmissionAndDischarge(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'TypeOfBill')]")]
            private IWebElement TypeOfBill { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'dpAdmissionDate_dateInput')]")]
            private IWebElement dpAdmissionDate_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'dpAdmissionDate_dateInput_wrapper')]")]
            private IWebElement dpAdmissionDate_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AdmissionHours_Input')]")]
            private IWebElement AdmissionHours_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'AdmissionHours_Arrow')]")]
            private IWebElement AdmissionHours_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboAdmissionType_Input')]")]
            private IWebElement AdmissionType_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'AdmissionType_Input_Arrow')]")]
            private IWebElement AdmissionType_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AdmissionSource_Input')]")]
            private IWebElement AdmissionSource_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'AdmissionSource_Arrow')]")]
            private IWebElement AdmissionSource_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DischargeHours_Input')]")]
            private IWebElement DischargeHours_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'DischargeHours_Arrow')]")]
            private IWebElement DischargeHours_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DischargeStatus_Input')]")]
            private IWebElement DischargeStatus_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DischargeStatus_Arrow')]")]
            private IWebElement DischargeStatus_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'TotalDays')]")]
            private IWebElement TotalDays { get; set; }
            #endregion
            #region Method and Calls

            public IWebElement InputAdmissionDate(string text = null) => Generic.SendKeys(dpAdmissionDate_dateInput, dpAdmissionDate_dateInput_wrapper, text);
            public string GetTypeOfBill => Generic.GetText(TypeOfBill);
            public string GetTotalDays => Generic.GetText(TotalDays);
            public IWebElement ClickAdmissionHoursArrow => Generic.Click(AdmissionHours_Arrow);
            public IWebElement ClickAdmissionTypeArrow => Generic.Click(AdmissionType_Arrow);
            public IWebElement ClickAdmissionSourceArrow => Generic.Click(AdmissionSource_Arrow);
            public IWebElement ClickDischargeHoursArrow => Generic.Click(DischargeHours_Arrow);
            public IWebElement ClickDischargeStatusArrow => Generic.Click(DischargeStatus_Arrow);
            public IWebElement InputDischargeHours(string text = null) => Generic.SendKeys(DischargeHours_Input, text);
            public IWebElement InputDischargeStatus(string text = null) => Generic.SendKeys(DischargeStatus_Input, text);
            public IWebElement InputAdmissionHours(string text = null) => Generic.SendKeys(AdmissionHours_Input, text);
            public IWebElement InputAdmissionType(string text = null) => Generic.SendKeys(AdmissionType_Input, text);
            public IWebElement InputAdmissionSource(string text = null) => Generic.SendKeys(AdmissionSource_Input, text);

            public void InputClaimsAdmissionAndDischarge(
                string admissionSource = null,
                string admissionType = null, 
                string admissionHours = null, 
                string dischargeStatus = null,
                string dischargeHours = null
                )
            {
                InputAdmissionSource(admissionHours);
                InputAdmissionType(admissionType);
                InputAdmissionHours(admissionHours);
            }
            #endregion
        }
        public class ClaimsDiagnosisCodes
        {
            IWebDriver context;

            public ClaimsDiagnosisCodes(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'PrincipalAnesthesiaProcDesc')]")]
            private IWebElement PrincipalAnesthesiaProcDesc { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PrincipalAnesthesiaProcedureCode')]")]
            private IWebElement PrincipalAnesthesiaProcedureCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtOtherAnesthesiaDesc')]")]
            private IWebElement txtOtherAnesthesiaDesc { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AdditionalAnesthesiaProcedureCode')]")]
            private IWebElement AdditionalAnesthesiaProcedureCode { get; set; }

            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkProfAdd')]")]
            private IWebElement lnkProfAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDiagnosisCode')]")]
            private IWebElement txtDiagnosisCode { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CodeType_Input')]")]
            private IWebElement CodeType_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtDesc')]")]
            private IWebElement txtDesc { get; set; }
           
            #endregion
            #region Method and Calls
            public IWebElement InputPrincipalAnesthesiaProcDesc(string text = null)
            {
                Generic.SendKeys(PrincipalAnesthesiaProcedureCode, text);
                Generic.SendKeys(PrincipalAnesthesiaProcedureCode, Keys.Enter);
                Thread.Sleep(2000);
                return PrincipalAnesthesiaProcedureCode;
            }
            public string PrincipalAnesthesiaProcDescText => Generic.GetText(PrincipalAnesthesiaProcDesc);
            public IWebElement InputOtherAnesthesiaProcDesc(string text = null)
            {
                Generic.SendKeys(AdditionalAnesthesiaProcedureCode, text);
                Generic.SendKeys(AdditionalAnesthesiaProcedureCode, Keys.Enter);
                Thread.Sleep(2000);
                return AdditionalAnesthesiaProcedureCode;


            }
            public string OtherAnesthesiaProcDescText => Generic.GetText(txtOtherAnesthesiaDesc);
            public IWebElement ClickAdd() => Generic.Click(lnkProfAdd);
            public IWebElement InputDiagnosisCode(string text = null) => Generic.SendKeys(txtDiagnosisCode, text);
            public IWebElement InputDiagnosisCodeType(string text = null) => Generic.SendKeys(CodeType_Input, text);
            public string GetCodeDescAfterSearch => Generic.GetText(txtDesc);
            #endregion

        }
        public class ClaimPaymentinformation
        {
            IWebDriver context;
            public ClaimPaymentinformation(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtBilledAmount')]")]
            private IWebElement txtBilledAmount { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtNetBilled')]")]
            private IWebElement txtNetBilled { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMedicaidPayableAmount')]")]
            private IWebElement txtMedicaidPayableAmount { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'txtMedicaidPayableAmount_wrapper')]")]
            private IWebElement txtMedicaidPayableAmount_wrapper { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtTotalMemResp')]")]
            private IWebElement txtTotalMemResp { get; set; }

            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEncounterAmount')]")]
            private IWebElement txtEncounterAmount { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtNetDifference')]")]
            private IWebElement txtNetDifference { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtRepricedAmount')]")]
            private IWebElement txtRepricedAmount { get; set; }


            #region Methods and Calls
            public string BilledAmount => Generic.GetText(txtBilledAmount);
            public string MedicaidPayableAmount => Generic.GetText(txtMedicaidPayableAmount);
            public string TotalMemResp => Generic.GetText(txtTotalMemResp);
            public string EncounterAmount => Generic.GetText(txtEncounterAmount);
            public string NetDifference => Generic.GetText(txtNetDifference);
            public string RepricedAmount => Generic.GetText(txtRepricedAmount);
            public IWebElement InputMeidcaidPayableAmount(string text = null) => Generic.SendKeys(txtMedicaidPayableAmount, txtMedicaidPayableAmount_wrapper, text);

            public string NetBilled => Generic.GetText(txtNetBilled);
            #endregion


        }
        public class ClaimAmbulanceDetails
        {
            IWebDriver context;

            public ClaimAmbulanceDetails(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, context);
            }
            private Generic Generic
            {
                get
                {
                    Generic generic = new Generic(context);
                    return generic;
                }
            }
            #region Ambulance Elements
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ReasonForTrans_Input')]")]
            private IWebElement ReasonForTrans_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ConResponseCode_Input')]")]
            private IWebElement ConResponseCode_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'UnitType_Input')]")]
            private IWebElement UnitType_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtweight')]")]
            private IWebElement txtweight { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtMileage')]")]
            private IWebElement txtMileage { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtRoundtripDesc')]")]
            private IWebElement txtRoundtripDesc { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtStretcherDesc')]")]
            private IWebElement txtStretcherDesc { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddressLine1')]")]
            private IWebElement AddressLine1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddressLine2')]")]
            private IWebElement AddressLine2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCity')]")]
            private IWebElement txtCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'State_Input')]")]
            private IWebElement State_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtZipCode_wrapper')]")]
            private IWebElement txtZipCodeOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtZipCode')]")]
            private IWebElement txtZipCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Address1')]")]
            private IWebElement Address1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Address2')]")]
            private IWebElement Address2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCity1')]")]
            private IWebElement txtCity1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'State1_Input')]")]
            private IWebElement State1_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtZipCode1_wrapper')]")]
            private IWebElement txtZipCodeOverlay1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtZipCode1')]")]
            private IWebElement txtZipCode1 { get; set; }

            #endregion
            #region Ambulance MethodsAndCalls

            /// <summary>
            /// Patient Transferred to Rehabilitation facility,
            /// Patient was transported for the benefit of a preferred physician,
            /// Patient was transported to nearest facility for care of symptoms, complaints, or both
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputReasonForTransport(string text = null) => Generic.SendKeys(ReasonForTrans_Input, text);

            /// <summary>
            /// Ambulance service was medically necessary;
            /// Patient had to be physically restrained;
            /// Patient had visible hemorrhaging;Patient is confined to a bed or chair;
            /// Patient was admitted to a hospital;Patient was moved by stretcher;
            /// Patient was transported in an emergency situation
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputConditionRepsonseCode(string text = null) => Generic.SendKeys(ConResponseCode_Input, text);
            /// <summary>
            /// Pounds
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputUnitType(string text = null) => Generic.SendKeys(UnitType_Input, text);
            public IWebElement InputWeight(string text = null) => Generic.SendKeys(txtweight, text);
            public IWebElement InputMileage(string text = null) => Generic.SendKeys(txtMileage, text);
            public IWebElement InputRoundtripPurposeDescription(string text = null) => Generic.SendKeys(txtRoundtripDesc, text);
            public IWebElement InputStretcherDescription(string text = null) => Generic.SendKeys(txtStretcherDesc, text);

            public IWebElement InputPickUpAddressLineOne(string text = null) => Generic.SendKeys(AddressLine1, text);
            public IWebElement InputPickUpAddressLineTwo(string text = null) => Generic.SendKeys(AddressLine2, text);
            public IWebElement InputPickUpCity(string text = null) => Generic.SendKeys(txtCity, text);
            public IWebElement InputPickUpState(string text = null) => Generic.SendKeys(State_Input, text);
            public IWebElement InputPickUpZipCode(string text = null) => Generic.SendKeys(txtZipCode, txtZipCodeOverlay, text);

            public IWebElement InputDropOffAddressLineOne(string text = null) => Generic.SendKeys(Address1, text);
            public IWebElement InputDropOffAddressLineTwo(string text = null) => Generic.SendKeys(Address2, text);
            public IWebElement InputDropOffCity(string text = null) => Generic.SendKeys(txtCity1, text);
            public IWebElement InputDropOffState(string text = null) => Generic.SendKeys(State1_Input, text);
            public IWebElement InputDropOffZipCode(string text = null) => Generic.SendKeys(txtZipCode1, txtZipCodeOverlay1, text);

            #endregion

        }
        public class ClaimProfServiceLines
        {
            IWebDriver context;
            public ClaimProfServiceLines(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'SaveBtm')]")]
            private IWebElement SaveBtm { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'SaveAndAddAnotherBtn')]")]
            private IWebElement SaveAndAddAnotherBtn { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkProfAdd')]")]
            private IWebElement lnkProfAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DosFrom_dateInput')]")]
            private IWebElement DOSFrom_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DosFrom_dateInput_wrapper')]")]
            private IWebElement DOSFrom_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DosTo_dateInput')]")]
            private IWebElement DOSTo_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DosTo_dateInput_wrapper')]")]
            private IWebElement DOSTo_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'POS_Input')]")]
            private IWebElement POS_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtProcedureCode')]")]
            private IWebElement txtProcedureCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ProcedureCodeType')]")]
            private IWebElement ProcedureCodeType { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMod1')]")]
            private IWebElement txtMod1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMod2')]")]
            private IWebElement txtMod2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMod3')]")]
            private IWebElement txtMod3 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMod4')]")]
            private IWebElement txtMod4 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtUnits')]")]
            private IWebElement txtUnits { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtCOBAmount')]")]
            private IWebElement txtCOBAmount { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtNDC_wrapper')]")]
            private IWebElement txtNDC_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtNDC')]")]
            private IWebElement txtNDC { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtUnit_wrapper')]")]
            private IWebElement txtUnit_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtUnit')]")]
            private IWebElement txtUnit { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Measurements')]")]
            private IWebElement Measurements { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtRenderingProviderId')]")]
            private IWebElement txtRenderingProviderId { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtRenderingProviderTaxonomy')]")]
            private IWebElement txtRenderingProviderTaxonomy { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOrderingProviderNPI')]")]
            private IWebElement txtOrderingProviderNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtOrderingProviderName')]")]
            private IWebElement txtOrderingProviderName { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtLineItemControlNumber')]")]
            private IWebElement txtLineItemControlNumber { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'Diagnosis_Input')]")]
            private IWebElement Diagnosis_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'chkEPSDT')]")]
            private IWebElement chkEPSDT { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ChkEMG')]")]
            private IWebElement ChkEMG { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'chkFamilyPlanning')]")]
            private IWebElement chkFamilyPlanning { get; set; }

            
        
            #endregion
            #region Methods and Calls
            public IWebElement InputDOSFrom(string text = null) => Generic.SendKeys(DOSFrom_dateInput, DOSFrom_dateInput_wrapper, text);
            public IWebElement InputDOSTo(string text = null) => Generic.SendKeys(DOSTo_dateInput, DOSTo_dateInput_wrapper, text);
            public IWebElement InputPOS(string text = null) => Generic.SendKeys(POS_Input, POS_Input, text);
            public IWebElement InputProcedureCode(string text = null) => Generic.SendKeys(txtProcedureCode, text);
            public IWebElement InputreProcdureCodeType(string text = null) => Generic.SendKeys(ProcedureCodeType, text);
            public IWebElement InputFirstModifier(string text = null) => Generic.SendKeys(txtMod1, text);
            public IWebElement InputSecondModifier(string text = null) => Generic.SendKeys(txtMod2, text);
            public IWebElement InputThirdModifier(string text = null) => Generic.SendKeys(txtMod3, text);
            public IWebElement InputFourthModifier(string text = null) => Generic.SendKeys(txtMod4, text);
            public IWebElement InputTotalBillUnits(string text = null) => Generic.SendKeys(txtUnits, text);
            public IWebElement InputNDC(string text = null) => Generic.SendKeys(txtNDC, txtNDC_wrapper, text);
            public IWebElement InputNDCUnits(string text = null) => Generic.SendKeys(txtUnit, txtUnit_wrapper, text);
            public IWebElement InputNDCMeasurements(string text = null) => Generic.SendKeys(Measurements, text);
            public IWebElement InputRenderingProviderID(string text = null) => Generic.SendKeys(txtRenderingProviderId, text);
            public string GetCOBAmount => Generic.GetText(txtCOBAmount);
            public IWebElement InputerRenderingProviderTaxonomy(string text = null) => Generic.SendKeys(txtRenderingProviderTaxonomy, text);
            public IWebElement InputOrderingProviderNPIAPI(string text = null) => Generic.SendKeys(txtOrderingProviderNPI, text);
            public string GetOrderingProviderName => Generic.GetText(txtOrderingProviderName);
            public string GetLineItemControlNumber => Generic.GetText(txtLineItemControlNumber);
            public IWebElement ClickAdd() => Generic.Click(lnkProfAdd);
            public IWebElement ClickSave() => Generic.Click(SaveBtm);
            public IWebElement ClickSaveAndAddAnother() => Generic.Click(SaveAndAddAnotherBtn);
            public IWebElement InputDiagnosis(string text = null) => Generic.SendKeys(Diagnosis_Input, text);
            public IWebElement ClickEPSDTRadioButton() => Generic.Click(chkEPSDT);
            public IWebElement ClickEMGRadioButton() => Generic.Click(ChkEMG);
            public IWebElement ClickFamilyPlanningRadioButton() => Generic.Click(chkFamilyPlanning);
            #endregion
        }
        public class ClaimBillingProviderInformation
        {
            IWebDriver context;
            public ClaimBillingProviderInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, context);
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtBillingProvNPI')]")]
            private IWebElement txtBillingProvNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtBillProviderName')]")]
            private IWebElement txtBillProviderName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'BillProvCorrect_0')]")]
            private IWebElement BillProvCorrect_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'BillProvCorrect_1')]")]
            private IWebElement BillProvCorrect_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'TaxIdQualifier_Input')]")]
            private IWebElement TaxIdQualifier_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtTaxID')]")]
            private IWebElement txtTaxID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtTaxonomyCode')]")]
            private IWebElement txtTaxonomyCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'therIDQuali_Input')]")]
            private IWebElement therIDQuali_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOtherID')]")]
            private IWebElement txtOtherID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AcceptsAssignment_Input')]")]
            private IWebElement AcceptsAssignment_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnSelectExistingAdd_0')]")]
            private IWebElement radBtnSelectExistingAdd_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnSelectExistingAdd_1')]")]
            private IWebElement radBtnSelectExistingAdd_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnSelectExistingAdd_2')]")]
            private IWebElement radBtnSelectExistingAdd_2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddressLine1')]")]
            private IWebElement AddressLine1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddressLine2')]")]
            private IWebElement AddressLine2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCity')]")]
            private IWebElement txtCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'State_Input')]")]
            private IWebElement State_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtZipCode_wrapper')]")]
            private IWebElement txtZipCodeOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtZipCode')]")]
            private IWebElement txtZipCode { get; set; }
            #endregion
            #region Method and Calls

            public IWebElement InputBillingProviderNPIAPI(string text = null) => Generic.SendKeys(txtBillingProvNPI, text);
            public string GetBillingProviderName => Generic.GetText(txtBillProviderName);
            /// <summary>
            /// Yes or No
            /// </summary>
            /// <param name="yesno"></param>
            public IWebElement DecideIsBillingProviderCorrect(string yesno) => Generic.DecisionClick(BillProvCorrect_0, BillProvCorrect_1, yesno);
            public IWebElement InputTaxIDQualifer(string text = null) => Generic.SendKeys(TaxIdQualifier_Input, text);
            public IWebElement InputTaxID(string text = null) => Generic.SendKeys(txtTaxID, text);
            public IWebElement InputTaxonomyCode(string text = null) => Generic.SendKeys(txtTaxonomyCode, text);
            public IWebElement InputOtherIDQualifier(string text = null) => Generic.SendKeys(therIDQuali_Input, text);
            public IWebElement InputOtherID(string text = null) => Generic.SendKeys(txtOtherID, text);
            /// <summary>
            /// Assigned;
            /// Assignment Accepted on Clinical Lab Services Only;
            /// Not Assigned
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputProviderAcceptsAssignment(string text = null) => Generic.SendKeys(AcceptsAssignment_Input, text);
            public IWebElement ClickSelectExistingAddress() => Generic.Click(radBtnSelectExistingAdd_0);
            public IWebElement ClickEnterNewAddress() => Generic.Click(radBtnSelectExistingAdd_1);
            public IWebElement ClickAddressNotProvided() => Generic.Click(radBtnSelectExistingAdd_2);
            public IWebElement InputAddressLineOne(string text = null) => Generic.SendKeys(AddressLine1, text);
            public IWebElement InputAddressLineTwo(string text = null) => Generic.SendKeys(AddressLine2, text);
            public IWebElement InputCity(string text = null) => Generic.SendKeys(txtCity, text);
            public IWebElement InputState(string text = null) => Generic.SendKeys(State_Input, text);
            public IWebElement InputZipCode(string text = null) => Generic.SendKeys(txtZipCode, txtZipCodeOverlay, text);
            #endregion
        }
        public class ClaimsReferringProviderInformation
        {
            IWebDriver context;
            public ClaimsReferringProviderInformation(IWebDriver context)
            {
                this.context = context;
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ReferFacNPI')]")]
            private IWebElement ReferFacNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtRefProviderName')]")]
            private IWebElement txtRefProviderName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OtherIDQuali')]")]
            private IWebElement OtherIDQuali { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOthrID')]")]
            private IWebElement txtOthrID { get; set; }




            #endregion
            #region Methods and Class

            public IWebElement InputOtherID(string text = null) => Generic.SendKeys(txtOthrID, text);
            /// <summary>
            /// State License;
            /// UPIN
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputOtherIDQualifier(string text = null) => Generic.SendKeys(OtherIDQuali, text);
            public string GetReferringProviderName => Generic.GetText(txtRefProviderName);
            public IWebElement InputReferringNPI(string text = null) => Generic.SendKeys(ReferFacNPI, text);
            #endregion
        }
        public class ClaimsOperatingProviderInformation
        {
            IWebDriver context;
            public ClaimsOperatingProviderInformation(IWebDriver context)
            {
                this.context = context;
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OperProvNPI')]")]
            private IWebElement OperProvNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'OperatingProviderName')]")]
            private IWebElement OperatingProviderName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OtherIDQuali_Input')]")]
            private IWebElement OtherIDQuali_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OthrID')]")]
            private IWebElement OthrID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtRenderTaxonomyCode')]")]
            private IWebElement txtRenderTaxonomyCode { get; set; }






            #endregion
            #region Methods and Class
            public IWebElement InputRenderingProviderTaxonomyCode(string text = null) => Generic.SendKeys(txtRenderTaxonomyCode, text);
            public IWebElement InputOtherID(string text = null) => Generic.SendKeys(OthrID, text);
            /// <summary>
            /// State License;
            /// UPIN
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputOtherIDQualifier(string text = null) => Generic.SendKeys(OtherIDQuali_Input, text);
            public string GetOperatingProviderName => Generic.GetText(OperatingProviderName);
            public IWebElement InputOperProvNPI(string text = null) => Generic.SendKeys(OperProvNPI, text);
            #endregion
        }
        public class ClaimsOtherOperatingProviderInformation
        {
            IWebDriver context;
            public ClaimsOtherOperatingProviderInformation(IWebDriver context)
            {
                this.context = context;
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OtherOprtngFacNPI')]")]
            private IWebElement OtherOprtngFacNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'OtherOprtngProviderName')]")]
            private IWebElement OtherOprtngProviderName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OtherIDOther_Input')]")]
            private IWebElement OtherIDOther_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OthrIDOther')]")]
            private IWebElement OthrIDOther { get; set; }







            #endregion
            #region Methods and Class
            public IWebElement InputOtherID(string text = null) => Generic.SendKeys(OthrIDOther, text);
            /// <summary>
            /// State License;
            /// UPIN
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputOtherIDQualifier(string text = null) => Generic.SendKeys(OtherIDOther_Input, text);
            public string GetOtherOprtngProviderName => Generic.GetText(OtherOprtngProviderName);
            public IWebElement InputOtherOprtngFacNPI(string text = null) => Generic.SendKeys(OtherOprtngFacNPI, text);
            #endregion
        }
        public class ClaimsRenderingProviderInformation
        {
            IWebDriver context;
            public ClaimsRenderingProviderInformation(IWebDriver context)
            {
                this.context = context;
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'RenderFacNPI')]")]
            private IWebElement RenderFacNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtRenProviderName')]")]
            private IWebElement txtRenProviderName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OtherIDRender_Input')]")]
            private IWebElement OtherIDRender_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOthrID')]")]
            private IWebElement txtOthrID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtRenderTaxonomyCode')]")]
            private IWebElement txtRenderTaxonomyCode { get; set; }






            #endregion
            #region Methods and Class
            public IWebElement InputRenderingProviderTaxonomyCode(string text = null) => Generic.SendKeys(txtRenderTaxonomyCode, text);
            public IWebElement InputOtherID(string text = null) => Generic.SendKeys(txtOthrID, text);
            /// <summary>
            /// State License;
            /// UPIN
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputOtherIDQualifier(string text = null) => Generic.SendKeys(OtherIDRender_Input, text);
            public string GetRenderingProviderName => Generic.GetText(txtRenProviderName);
            public IWebElement InputRenderFacNPI(string text = null) => Generic.SendKeys(RenderFacNPI, text);
            #endregion
        }
        public class ClaimsServiceFacilityInformation
        {
            IWebDriver context;
            public ClaimsServiceFacilityInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, context);
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtServFacNPI')]")]
            private IWebElement txtServFacNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtServiName')]")]
            private IWebElement txtServiName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OthIdQu')]")]
            private IWebElement TaxIdQualifier_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOthID')]")]
            private IWebElement txtTaxID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtTaxonomyCode')]")]
            private IWebElement txtTaxonomyCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'therIDQuali_Input')]")]
            private IWebElement therIDQuali_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOtherID')]")]
            private IWebElement txtOtherID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AcceptsAssignment_Input')]")]
            private IWebElement AcceptsAssignment_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnExiAd_0')]")]
            private IWebElement radBtnSelectExistingAdd_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnExiAd_1')]")]
            private IWebElement radBtnSelectExistingAdd_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnExiAd_2')]")]
            private IWebElement radBtnSelectExistingAdd_2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddressLne1')]")]
            private IWebElement AddressLine1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddressLne2')]")]
            private IWebElement AddressLine2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCty')]")]
            private IWebElement txtCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'stat_Input')]")]
            private IWebElement State_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'zipcde_wrapper')]")]
            private IWebElement txtZipCodeOverlay { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'zipcde')]")]
            private IWebElement txtZipCode { get; set; }
            #endregion
            #region Method and Calls

            public IWebElement InputServiceFacilityNPIAPI(string text = null) => Generic.SendKeys(txtServFacNPI, text);
            public string GetServiceFacilityName => Generic.GetText(txtServiName);
            public IWebElement InputTaxIDQualifer(string text = null) => Generic.SendKeys(TaxIdQualifier_Input, text);
            public IWebElement InputTaxID(string text = null) => Generic.SendKeys(txtTaxID, text);
            public IWebElement InputTaxonomyCode(string text = null) => Generic.SendKeys(txtTaxonomyCode, text);
            public IWebElement InputOtherIDQualifier(string text = null) => Generic.SendKeys(therIDQuali_Input, text);
            public IWebElement InputOtherID(string text = null) => Generic.SendKeys(txtOtherID, text);
            public IWebElement ClickSelectExistingAddress() => Generic.Click(radBtnSelectExistingAdd_0);
            public IWebElement ClickEnterNewAddress() => Generic.Click(radBtnSelectExistingAdd_1);
            public IWebElement ClickAddressNotProvided() => Generic.Click(radBtnSelectExistingAdd_2);
            public IWebElement InputAddressLineOne(string text = null) => Generic.SendKeys(AddressLine1, text);
            public IWebElement InputAddressLineTwo(string text = null) => Generic.SendKeys(AddressLine2, text);
            public IWebElement InputCity(string text = null) => Generic.SendKeys(txtCity, text);
            public IWebElement InputState(string text = null) => Generic.SendKeys(State_Input, text);
            public IWebElement InputZipCode(string text = null) => Generic.SendKeys(txtZipCode, txtZipCodeOverlay, text);
            #endregion
        }
        public class ClaimsSupervisingProviderInformation
        {
            IWebDriver context;
            public ClaimsSupervisingProviderInformation(IWebDriver context)
            {
                this.context = context;
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtSupervisingProviderNPI')]")]
            private IWebElement SupervisingProviderNPI { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'SupervisingProviderName')]")]
            private IWebElement SupervisingProviderName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OtherIDSupervising_Input')]")]
            private IWebElement OtherIDSupervising_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOthrIDSupervising')]")]
            private IWebElement txtOthrID { get; set; }
            #endregion
            #region Methods and Class
            public IWebElement InputOtherID(string text = null) => Generic.SendKeys(txtOthrID, text);
            /// <summary>
            /// State License;
            /// UPIN
            /// </summary>
            /// <param name="text"></param>
            public IWebElement InputOtherIDQualifier(string text = null) => Generic.SendKeys(OtherIDSupervising_Input, text);
            public string GetSupervisingProviderName => Generic.GetText(SupervisingProviderName);
            public IWebElement InputSupervisingProviderNPI(string text = null) => Generic.SendKeys(SupervisingProviderNPI, text);
            #endregion
        }
        public class ClaimsReferralAuthsEpisodes
        {
            IWebDriver context;

            [System.Obsolete]
            public ClaimsReferralAuthsEpisodes(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkAuthRefAdd')]")]
            private IWebElement lnkAuthRefAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleCancel')]")]
            private IWebElement btnRoleCancel { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Type_Input')]")]
            private IWebElement Type_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleSave')]")]
            private IWebElement btnRoleSave { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkAuthRefEdit')]")]
            private IWebElement lnkAuthRefEdit { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkAuthRefRemove')]")]
            private IWebElement lnkAuthRefRemove { get; set; }

            #endregion

            #region Methods and Calls
            public IWebElement ClickAddButton() => Generic.Click(lnkAuthRefAdd);
            public IWebElement ClickCancelButton() => Generic.Click(btnRoleCancel);
            public IWebElement ClickSaveButton() => Generic.Click(btnRoleSave);
            public IWebElement ClickEditButton() => Generic.Click(lnkAuthRefEdit);
            public IWebElement ClickRemoveButton() => Generic.Click(lnkAuthRefRemove);
            public IWebElement InputType(string text = null) => Generic.SendKeys(Type_Input, text);
            #endregion

        }
        public class ClaimsMemberBasicInformation
        {
            IWebDriver context;
            public ClaimsMemberBasicInformation(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemId')]")]
            private IWebElement txtMemId { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtMemName')]")]
            private IWebElement txtMemName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnListIsMember_0')]")]
            private IWebElement radBtnListIsMember_0 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'radBtnListIsMember_1')]")]
            private IWebElement radBtnListIsMember_1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtMemDOB')]")]
            private IWebElement txtMemDOB { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtMemGender')]")]
            private IWebElement txtMemGender { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtPatAccNo')]")]
            private IWebElement txtPatAccNo { get; set; }
            #endregion

            #region Methods and Calls
            public IWebElement InputMemberID(string text = null) => Generic.SendKeys(txtMemId, text);

            public string GetMemberName => Generic.GetText(txtMemName);
            public IWebElement InputIsMemberCorrect(string yesno) => Generic.DecisionClick(radBtnListIsMember_0, radBtnListIsMember_1, yesno);
            public string GetDateOfBirth => Generic.GetText(txtMemDOB);
            public string GetGender => Generic.GetText(txtMemGender);
            public IWebElement InputPatientAccountNumber(string text = null) => Generic.SendKeys(txtPatAccNo, text);
            #endregion

        }
        public class ClaimsTreatmentResultingFrom
        {
            IWebDriver context;
            public ClaimsTreatmentResultingFrom(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboTreatResFrom_Input')]")]
            private IWebElement cboTreatResFrom { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DateOfAcc_dateInput_wrapper')]")]
            private IWebElement DateOfAcc_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'tdtDateOfAcc_dateInput')]")]
            private IWebElement tdtDateOfAcc_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboStateofAcc_Input')]")]
            private IWebElement cboStateofAcc_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'SubrogationId_Input')]")]
            private IWebElement SubrogationId_Input { get; set; }
            #endregion
            #region Methods and Calls
            public IWebElement InputTreatmentResultingFrom(string text = null) => Generic.SendKeys(cboTreatResFrom, text);
            public IWebElement InputDateOfAccident(string text = null) => Generic.SendKeys(tdtDateOfAcc_dateInput, DateOfAcc_dateInput_wrapper, text);
            public IWebElement InputStateOfAccoutn(string text = null) => Generic.SendKeys(cboStateofAcc_Input, text);
            public IWebElement InputSubrogationList(string text = null) => Generic.SendKeys(SubrogationId_Input, text);
            #endregion
        }
        public class ClaimsMiscellaneousBasicInformation
        {
            IWebDriver context;
            public ClaimsMiscellaneousBasicInformation(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtOutLabCharge')]")]
            private IWebElement txtOutLabCharge { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'OutLabCharge_wrapper')]")]
            private IWebElement OutLabCharge_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtSubmitterID')]")]
            private IWebElement txtSubmitterID { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtBatchID')]")]
            private IWebElement txtBatchID { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtEncounterClaimNo')]")]
            private IWebElement txtEncounterClaimNo { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkAddRelClaim')]")]
            private IWebElement lnkAddRelClaim { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkRemRelClaim')]")]
            private IWebElement lnkRemRelClaim { get; set; }

            #endregion

            #region Methods and Calls
            public IWebElement InputOutsideLabChanges(string text = null) => Generic.SendKeys(txtOutLabCharge, OutLabCharge_wrapper, text);
            public string GetSubmitterID => Generic.GetText(txtSubmitterID);
            public string GetBatchID => Generic.GetText(txtBatchID);
            public string GetEncounterClaimNo => Generic.GetText(txtEncounterClaimNo);
            public IWebElement ClickAddButton() => Generic.Click(lnkAddRelClaim);
            public IWebElement ClicRemoveButton() => Generic.Click(lnkRemRelClaim);

            #endregion

        }
        public class ClaimsCOBCarrierDetails
        {
            IWebDriver context;
            public ClaimsCOBCarrierDetails(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCarrierCode')]")]
            private IWebElement txtCarrierCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtCarrierName')]")]
            private IWebElement txtCarrierName { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtCarrierType')]")]
            private IWebElement txtCarrierType { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PayerSequence')]")]
            private IWebElement PayerSequence { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ClaimFilingIndicatorUD_Input')]")]
            private IWebElement ClaimFilingIndicatorUD_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'InsurancePolicyOrGroupNumber')]")]
            private IWebElement InsurancePolicyOrGroupNumber { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubmittedCarrierID')]")]
            private IWebElement SubmittedCarrierID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubmittedCarrierName')]")]
            private IWebElement SubmittedCarrierName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubmittedCarrierAddressLine1')]")]
            private IWebElement SubmittedCarrierAddressLine1 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubmittedCarrierAddressLine2')]")]
            private IWebElement SubmittedCarrierAddressLine2 { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubmittedCarrierCity')]")]
            private IWebElement SubmittedCarrierCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubmittedCarrierState')]")]
            private IWebElement SubmittedCarrierState { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubmittedCarrierPostalCode')]")]
            private IWebElement SubmittedCarrierPostalCode { get; set; }
            #endregion

            #region Methods and Calls
            public IWebElement InputCarrierCode(string text = null) => Generic.SendKeys(txtCarrierCode, text);
            public string GetCarrierName => Generic.GetText(txtCarrierName);
            public string GetCarrierType => Generic.GetText(txtCarrierType);
            /// <summary>
            /// Payer Responsibility Eleven;
            /// Payer Responsibility Eight;
            /// Payer Responsibility Four;
            /// Payer Responsibility Five;
            /// Payer Responsibility Nine;
            /// Primary;
            /// Secondary;
            /// Tertiary
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public IWebElement InputPayerSequence(string text = null) => Generic.SendKeys(PayerSequence, text);
            /// <summary>
            /// 11 - Other Non-Federal Programs;
            /// 12 - Preferred Provider Organization (PPO);
            /// 13 - Point of Service (POS);
            /// 14 - Exclusive Provider Organization (EPO);
            /// 15 - Indemnity Insurance;
            /// 16 - Health Maintenance Organization (HMO) Medicare Risk;
            /// 17 - Dental Maintenance Organization;
            /// BL - Blue Cross/Blue Shield;
            /// CH - Champus;
            /// CI - Commercial Insurance Co.;
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public IWebElement InputClaimFilingIndicator(string text = null) => Generic.SendKeys(ClaimFilingIndicatorUD_Input, text);
            public IWebElement InputSubmittedCarrierID(string text = null) => Generic.SendKeys(SubmittedCarrierID, text); 
            public IWebElement InputInsurancePolicyOnGroupNumber(string text = null) => Generic.SendKeys(InsurancePolicyOrGroupNumber, text);
            public IWebElement InputSubmittedCarrierName(string text = null) => Generic.SendKeys(SubmittedCarrierName, text); 
            public IWebElement InputSubmittedCarrierAddressLine1(string text = null) => Generic.SendKeys(SubmittedCarrierAddressLine1, text); 
            public IWebElement InputSubmittedCarrierAddressLine2(string text = null) => Generic.SendKeys(SubmittedCarrierAddressLine2, text);
            public IWebElement InputSubmittedCarrierCity(string text = null) => Generic.SendKeys(SubmittedCarrierCity, text);
            public IWebElement InputSubmittedCarrierState(string text = null) => Generic.SendKeys(SubmittedCarrierState, text);
            public IWebElement InputSubmittedCarrierPostalCode(string text = null) => Generic.SendKeys(SubmittedCarrierPostalCode, text);
            #endregion

        }
        public class ClaimsCOBClaimDetails
        {
            IWebDriver context;
            public ClaimsCOBClaimDetails(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PayerClaimNumber')]")]
            private IWebElement PayerClaimNumber { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PaymentDate_dateInput')]")]
            private IWebElement PaymentDate_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'PaymentDate_dateInput_wrapper')]")]
            private IWebElement PaymentDate_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PayerPaidAmount')]")]
            private IWebElement PayerPaidAmount { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'NonCoveredAmount')]")]
            private IWebElement NonCoveredAmount { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'RemainingPatientLiability')]")]
            private IWebElement RemainingPatientLiability { get; set; }
            #endregion

            #region Methods and Calls
            public IWebElement InputPayerClaimNumber(string text = null) => Generic.SendKeys(PayerClaimNumber, text);
            public IWebElement InputPayerPaidAmount(string text = null) => Generic.SendKeys(PayerPaidAmount, text);
            public IWebElement InputNonCoveredAmount(string text = null) => Generic.SendKeys(NonCoveredAmount, text);
            public IWebElement InputRemainingPatientLiability(string text = null) => Generic.SendKeys(RemainingPatientLiability, text);
            public IWebElement InputPaymentDate(string text = null) => Generic.SendKeys(PaymentDate_dateInput, PaymentDate_dateInput_wrapper, text);
            #endregion

        }
        public class ClaimsCOBAdjustmentDetails
        {
            IWebDriver context;
            public ClaimsCOBAdjustmentDetails(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'AdjustmentAdd')]")]
            private IWebElement AdjustmentAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'AdjustmentEdit')]")]
            private IWebElement AdjustmentEdit { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'RemoveAdjustButton')]")]
            private IWebElement RemoveAdjustButton { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Amount')]")]
            private IWebElement Amount { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'Amount_wrapper')]")]
            private IWebElement Amount_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'Units_wrapper')]")]
            private IWebElement Units_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'Units')]")]
            private IWebElement Units { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'btnCancel')]")]
            private IWebElement btnCancel { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'btnSave')]")]
            private IWebElement btnSave { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'AdjustmentReasonCode_Input')]")]
            private IWebElement AdjustmentReasonCode_Input { get; set; }

            #endregion
            #region Methods and Calls
            public IWebElement ClickAdjustmentAddButton => Generic.Click(AdjustmentAdd);
            public IWebElement ClickAdjustmentEditButton => Generic.Click(AdjustmentEdit);
            public IWebElement ClickAdjustmentRemoveButton => Generic.Click(RemoveAdjustButton);
            public IWebElement ClickCancel => Generic.Click(btnCancel);
            public IWebElement ClickSave => Generic.Click(btnSave);
            public IWebElement InputAmount(string text = null) => Generic.SendKeys(Amount, Amount_wrapper, text);
            /// <summary>
            /// Additional payment for Dental/Vision service utilization.;
            /// Adjustment code for mandated federal, state or local law/regulation that is not already covered by another code and is mandated before a new code can be created.;
            /// Adjustment for administrative cost. Usage: To be used for pharmaceuticals only.;
            /// Adjustment for compound preparation cost. Usage: To be used for pharmaceuticals only.;
            /// Adjustment for delivery cost. Usage: To be used for pharmaceuticals only.;
            /// Adjustment for postage cost. Usage: To be used for pharmaceuticals only.;
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public IWebElement InputClaimAdjustmentReasonCode(string text = null) => Generic.SendKeys(AdjustmentReasonCode_Input, text);
            public IWebElement InputUnits(string text = null) => Generic.SendKeys(Units, Units_wrapper, text);
            #endregion
        }
        public class ClaimsCOBSubscriberDetails
        {
            IWebDriver context;
            public ClaimsCOBSubscriberDetails(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'RelationshipToInsuredUD_Input')]")]
            private IWebElement RelationshipToInsuredUD_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubscriberID')]")]
            private IWebElement SubscriberID { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubscriberFirstName')]")]
            private IWebElement SubscriberFirstName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubscriberMiddleName')]")]
            private IWebElement SubscriberMiddleName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubscriberLastName')]")]
            private IWebElement SubscriberLastName { get; set; }


            #endregion
            #region Methods and Calls
            public IWebElement InputRelationshipTInsuredUD(string text = null) => Generic.SendKeys(RelationshipToInsuredUD_Input, text);
            public IWebElement InputSubscriberID(string text = null) => Generic.SendKeys(SubscriberID, text);
            public IWebElement InputSubscriberFirstName(string text = null) => Generic.SendKeys(SubscriberFirstName, text);
            public IWebElement InputSubscriberMiddleName(string text = null) => Generic.SendKeys(SubscriberMiddleName, text);
            public IWebElement InputSubscriberLastName(string text = null) => Generic.SendKeys(SubscriberLastName, text);


            #endregion
        }
        public class ClaimsVissionAndHearing
        {
            IWebDriver context; 
            ClaimsVissionAndHearing(IWebDriver context)
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

            #region Elements
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'PartDate_dateInput_wrapper')]")]
            private IWebElement PartDate_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PartDate_dateInput')]")]
            private IWebElement PartDate_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SpectacleLensVisionServiceCodes_Input')]")]
            private IWebElement SpectacleLensVisionServiceCodes_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'SpectacleLensVisionServiceCodes_Arrow')]")]
            private IWebElement SpectacleLensVisionServiceCodes_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'checkBoxSpectacleLensVisionService')]")]
            private IWebElement checkBoxSpectacleLensVisionService { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ContactLensVisionService')]")]
            private IWebElement ContactLensVisionService { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ContactLensVisionServiceCodes_Input')]")]
            private IWebElement ContactLensVisionServiceCodes_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'ContactLensVisionServiceCodes_Arrow')]")]
            private IWebElement ContactLensVisionServiceCodes_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'checkBoxContactLensVisionService')]")]
            private IWebElement checkBoxContactLensVisionService { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'checkBoxSpectacleFramesVisionService')]")]
            private IWebElement CheckBoxSpectacleFramesVisionService { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SpectacleFramesVisionServiceCodes_Input')]")]
            private IWebElement SpectacleFramesVisionServiceCodes_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'SpectacleFramesVisionServiceCodes_Arrow')]")]
            private IWebElement SpectacleFramesVisionServiceCodes_Arrow { get; set; }
            #endregion

            #region Methods and Calls
            public IWebElement InputPresciptionDate(string text = null) => Generic.SendKeys(PartDate_dateInput, PartDate_dateInput_wrapper, text);
            /// <summary>
            /// General Standard of 20 Degree or .5 Diopter Sphere or Cylinder Change Met;
            /// Replacement Due to Patient Preference;
            /// Replacement Due to Loss or Theft;
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public IWebElement InputSpectacleLensesConditionCode(string text = null) => Generic.SendKeys(SpectacleFramesVisionServiceCodes_Input, text);
            public IWebElement InputContactLensesConditionCode(string text = null) => Generic.SendKeys(ContactLensVisionService, text);
            public IWebElement InputSpectacleFrame(string text = null) => Generic.SendKeys(SpectacleFramesVisionServiceCodes_Input, text);
            public IWebElement InputSpectacleLensVisionServiceCodes(string text = null) => Generic.SendKeys(SpectacleLensVisionServiceCodes_Input, text);
            public IWebElement InputContactLensVisionSerice(string text = null) => Generic.SendKeys(ContactLensVisionServiceCodes_Input, text);
            public IWebElement ClickSpectacleFramesCheckBox => Generic.Click(CheckBoxSpectacleFramesVisionService);
            public IWebElement ClickContactLensesCheckBox => Generic.Click(checkBoxContactLensVisionService);
            public IWebElement ClickSpectacleLensesCheckBox => Generic.Click(checkBoxSpectacleLensVisionService);
            public IWebElement ClickSpectacleLensVisionServiceCodesArrow => Generic.Click(SpectacleLensVisionServiceCodes_Arrow);
            public IWebElement ClickContactLensVisionServiceCodesArrow => Generic.Click(ContactLensVisionServiceCodes_Arrow);
            public IWebElement ClickSpectacleFramesVisionServiceCodes => Generic.Click(SpectacleFramesVisionServiceCodes_Arrow);
            #endregion
        }
        public class ClaimsOccurenceSpanAndConditions
        {
            IWebDriver context;
            ClaimsOccurenceSpanAndConditions(IWebDriver context)
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
            #region Elements
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkOccuranceAdd')]")]
            private IWebElement lnkOccuranceAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleCancel')]")]
            private IWebElement btnRoleCancel { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OccCode_Input')]")]
            private IWebElement OccCode_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'cboOccCode_Arrow')]")]
            private IWebElement cboOccCode_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'OccFrom_dateInput_wrapper')]")]
            private IWebElement OccFrom_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OccFrom_dateInput')]")]
            private IWebElement OccFrom_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OccTo_dateInput')]")]
            private IWebElement OccTo_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'OccTo_dateInput_wrapper')]")]
            private IWebElement OccTo_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboConditionCode_Input')]")]
            private IWebElement cboConditionCode_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboSubrogationId_Input')]")]
            private IWebElement cboSubrogationId_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleSave')]")]
            private IWebElement btnRoleSave { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkOccuranceEdit')]")]
            private IWebElement lnkOccuranceEdit { get; set; }
            
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkOccuranceRem')]")]
            private IWebElement lnkOccuranceRem { get; set; }

            #endregion
            #region Methods and Calls
            public IWebElement ClickAddButton() => Generic.Click(lnkOccuranceAdd);
            public IWebElement ClickCancelButton() => Generic.Click(btnRoleCancel);
            public IWebElement ClickSaveButton() => Generic.Click(btnRoleSave);
            public IWebElement ClickEditButton() => Generic.Click(lnkOccuranceEdit);
            public IWebElement ClickRemoveButton() => Generic.Click(lnkOccuranceRem);
            public IWebElement ClickOccurenceCodeArrow() => Generic.Click(cboOccCode_Arrow);
            public IWebElement InputOccurenceCode(string text = null) => Generic.SendKeys(OccCode_Input, text);
            public IWebElement InputOccurenceDateFrom(string text = null) => Generic.SendKeys(OccFrom_dateInput, OccFrom_dateInput_wrapper, text);
            public IWebElement InputOccurenceDateTo(string text = null) => Generic.SendKeys(OccTo_dateInput, OccTo_dateInput_wrapper, text);
            /// <summary>
            /// Any number from 00-99;
            /// or A1 - W5;
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public IWebElement InputConditionCode(string text = null) => Generic.SendKeys(cboConditionCode_Input, text);
            public IWebElement InputSubrogationList(string text = null) => Generic.SendKeys(cboSubrogationId_Input, text);
            #endregion

        }
        public class ClaimsOccurenceCodes
        {
            IWebDriver context;
            ClaimsOccurenceCodes(IWebDriver context)
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
            #region Elements
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkOccuranCodeAdd')]")]
            private IWebElement lnkOccuranCodeAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleCancel')]")]
            private IWebElement btnRoleCancel { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'OccCode_Input')]")]
            private IWebElement OccCode_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'cboOccCode_Arrow')]")]
            private IWebElement cboOccCode_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'OccDate_dateInput_wrapper')]")]
            private IWebElement OccDate_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'tdtOccDate_dateInput')]")]
            private IWebElement tdtOccDate_dateInput { get; set; }

            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleSave')]")]
            private IWebElement btnRoleSave { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'OccuranceCodeEdit')]")]
            private IWebElement OccuranceCodeEdit { get; set; }

            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'OccuranCodeceRem')]")]
            private IWebElement OccuranCodeceRem { get; set; }

            #endregion
            #region Methods and Calls
            public IWebElement ClickAddButton() => Generic.Click(lnkOccuranCodeAdd);
            public IWebElement ClickCancelButton() => Generic.Click(btnRoleCancel);
            public IWebElement ClickSaveButton() => Generic.Click(btnRoleSave);
            public IWebElement ClickEditButton() => Generic.Click(OccuranceCodeEdit);
            public IWebElement ClickRemoveButton() => Generic.Click(OccuranCodeceRem);
            public IWebElement InputOccurenceCode(string text = null) => Generic.SendKeys(OccCode_Input, text);
            public IWebElement InputOccurenceDateFrom(string text = null) => Generic.SendKeys(tdtOccDate_dateInput, OccDate_dateInput_wrapper, text);

            #endregion

        }
        public class ClaimsValueCodes
        {
            IWebDriver context;
            ClaimsValueCodes(IWebDriver context)
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
            #region Elements
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lnkOccuranCodeAdd')]")]
            private IWebElement lnkOccuranCodeAdd { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleCancel')]")]
            private IWebElement btnRoleCancel { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboValueCode_Input')]")]
            private IWebElement cboValueCode_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'cboValueCode_Arrow')]")]
            private IWebElement cboValueCode_Arrow { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAmount')]")]
            private IWebElement txtAmount { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnRoleSave')]")]
            private IWebElement btnRoleSave { get; set; }

            #endregion
            #region Methods and Calls
            public IWebElement ClickAddButton() => Generic.Click(lnkOccuranCodeAdd);
            public IWebElement ClickCancelButton() => Generic.Click(btnRoleCancel);
            public IWebElement ClickSaveButton() => Generic.Click(btnRoleSave);
            public IWebElement InputValueCode(string text = null) => Generic.SendKeys(cboValueCode_Input, text);
            public IWebElement ClickValueCodesArrow() => Generic.Click(cboValueCode_Arrow);
            public IWebElement InputValueCodesAmount(string text = null) => Generic.SendKeys(txtAmount, text);

            #endregion

        }
    }
}