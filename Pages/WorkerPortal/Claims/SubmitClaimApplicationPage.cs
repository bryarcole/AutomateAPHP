using NUnit.Tests1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;



namespace NUnit.Tests1.Pages.WorkerPortal.Claims
{
    public class SubmitClaimApplicationPage
    {
        static IWebDriver context;
        public class ClaimSummaryInformation
        {
            IWebDriver context;
            public ClaimSummaryInformation(IWebDriver context)
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
            public string ClaimNumber => Generic.ProtectedElementGetText(txtClaimNo);
            public string GetCleanStatus => Generic.ProtectedElementGetText(txtClean);
            public string GetClaimEncounterStatus => Generic.ProtectedElementGetText(txtClaimStatus);
            public string GetBenefitPlan => Generic.ProtectedElementGetText(txtBenefitPlan);
            public string GetDuplicateStatus => Generic.ProtectedElementGetText(txtDuplicate);
            public string GetAdjustedStatus => Generic.ProtectedElementGetText(txtAdjust);
            public string GetCrossoverStatus => Generic.ProtectedElementGetText(txtCrossOver);
            public string GetMediaSource => Generic.ProtectedElementGetText(txtMediaType);
            public string GetVoidStatus => Generic.ProtectedElementGetText(txtVoid);
            public string RemittanceAdviceNumber => Generic.ProtectedElementGetText(txtRemittanceAdviceNumber);
            public string RemittanceAdviceDate => Generic.ProtectedElementGetText(txtRemittanceAdviceDate);
            public void InputAdjustmentReason(string text) => Generic.ProtectedElementSendKeys(AdjustmentReason_Input, text);

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
            public void InputDateOfReciept(string text)
            {
                Generic.ProtectedElementClick(DateOfRec_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(DateOfRec_dateInput, text);
            }
            public void InputDateOfCurrent(string text)
            {
                Generic.ProtectedElementClick(DateofCur_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(DateofCur_dateInput, text);
            }
            public void InputUnableToWorkFrom(string text)
            {
                Generic.ProtectedElementClick(UnabletoFrom_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(UnabletoFrom_dateInput, text);
            }
            public void InputUnableToWorkTo(string text)
            {
                Generic.ProtectedElementClick(UnabletoWorkTo_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(UnabletoWorkTo_dateInput, text);
            }
            public void InputHospitalizationDateFrom(string text)
            {
                Generic.ProtectedElementClick(Hospitafrom_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(Hospitafrom_dateInput, text);
            }
            public void InputHospitalizationDateTo(string text)
            {
                Generic.ProtectedElementClick(Hospitato_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(Hospitato_dateInput, text);
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
            public void InputPrincipalAnesthesiaProcDesc(string text)
            {
                Generic.ProtectedElementSendKeys(PrincipalAnesthesiaProcedureCode, text);
                Generic.ProtectedElementSendKeys(PrincipalAnesthesiaProcedureCode, Keys.Enter);
                Thread.Sleep(2000);
            }
            public string PrincipalAnesthesiaProcDescText => Generic.ProtectedElementGetText(PrincipalAnesthesiaProcDesc);
            public void InputOtherAnesthesiaProcDesc(string text)
            {
                Generic.ProtectedElementSendKeys(AdditionalAnesthesiaProcedureCode, text);
                Generic.ProtectedElementSendKeys(AdditionalAnesthesiaProcedureCode, Keys.Enter);
                Thread.Sleep(2000);
               
            }
            public string OtherAnesthesiaProcDescText => Generic.ProtectedElementGetText(txtOtherAnesthesiaDesc);
            public void ClickAdd() => Generic.ProtectedElementClick(lnkProfAdd);
            public void InputDiagnosisCode(string text) => Generic.ProtectedElementSendKeys(txtDiagnosisCode, text);
            public void InputDiagnosisCodeType(string text) => Generic.ProtectedElementSendKeys(CodeType_Input, text);
            public string GetCodeDescAfterSearch => Generic.ProtectedElementGetText(txtDesc);
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
            public string BilledAmount => Generic.ProtectedElementGetText(txtBilledAmount);
            public string MedicaidPayableAmount => Generic.ProtectedElementGetText(txtMedicaidPayableAmount);
            public string TotalMemResp => Generic.ProtectedElementGetText(txtTotalMemResp);
            public string EncounterAmount => Generic.ProtectedElementGetText(txtEncounterAmount);
            public string NetDifference => Generic.ProtectedElementGetText(txtNetDifference);
            public string RepricedAmount => Generic.ProtectedElementGetText(txtRepricedAmount);
            public void InputMeidcaidPayableAmount(string text) => Generic.ProtectedAccessElement(txtMedicaidPayableAmount, txtMedicaidPayableAmount_wrapper, text);

            public string NetBilled => Generic.ProtectedElementGetText(txtNetBilled);
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
            public void InputReasonForTransport(string text) => Generic.ProtectedElementSendKeys(ReasonForTrans_Input, text);

            /// <summary>
            /// Ambulance service was medically necessary;
            /// Patient had to be physically restrained;
            /// Patient had visible hemorrhaging;Patient is confined to a bed or chair;
            /// Patient was admitted to a hospital;Patient was moved by stretcher;
            /// Patient was transported in an emergency situation
            /// </summary>
            /// <param name="text"></param>
            public void InputConditionRepsonseCode(string text) => Generic.ProtectedElementSendKeys(ConResponseCode_Input, text);
            /// <summary>
            /// Pounds
            /// </summary>
            /// <param name="text"></param>
            public void InputUnitType(string text) => Generic.ProtectedElementSendKeys(UnitType_Input, text);
            public void InputWeight(string text) => Generic.ProtectedElementSendKeys(txtweight, text);
            public void InputMileage(string text) => Generic.ProtectedElementSendKeys(txtMileage, text);
            public void InputRoundtripPurposeDescription(string text) => Generic.ProtectedElementSendKeys(txtRoundtripDesc, text);
            public void InputStretcherDescription(string text) => Generic.ProtectedElementSendKeys(txtStretcherDesc, text);

            public void InputPickUpAddressLineOne(string text) => Generic.ProtectedElementSendKeys(AddressLine1, text);
            public void InputPickUpAddressLineTwo(string text) => Generic.ProtectedElementSendKeys(AddressLine2, text);
            public void InputPickUpCity(string text) => Generic.ProtectedElementSendKeys(txtCity, text);
            public void InputPickUpState(string text) => Generic.ProtectedElementSendKeys(State_Input, text);
            public void InputPickUpZipCode(string text) => Generic.ProtectedAccessElement(txtZipCode, txtZipCodeOverlay, text);

            public void InputDropOffAddressLineOne(string text) => Generic.ProtectedElementSendKeys(Address1, text);
            public void InputDropOffAddressLineTwo(string text) => Generic.ProtectedElementSendKeys(Address2, text);
            public void InputDropOffCity(string text) => Generic.ProtectedElementSendKeys(txtCity1, text);
            public void InputDropOffState(string text) => Generic.ProtectedElementSendKeys(State1_Input, text);
            public void InputDropOffZipCode(string text) => Generic.ProtectedAccessElement(txtZipCode1, txtZipCodeOverlay1, text);

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
            public void InputDOSFrom(string text) => Generic.ProtectedAccessElement(DOSFrom_dateInput, DOSFrom_dateInput_wrapper, text);
            public void InputDOSTo(string text) => Generic.ProtectedAccessElement(DOSTo_dateInput, DOSTo_dateInput_wrapper, text);
            public void InputPOS(string text) => Generic.ProtectedAccessElement(POS_Input, POS_Input, text);
            public void InputProcedureCode(string text) => Generic.ProtectedElementSendKeys(txtProcedureCode, text);
            public void InputreProcdureCodeType(string text) => Generic.ProtectedElementSendKeys(ProcedureCodeType, text);
            public void InputFirstModifier(string text) => Generic.ProtectedElementSendKeys(txtMod1, text);
            public void InputSecondModifier(string text) => Generic.ProtectedElementSendKeys(txtMod2, text);
            public void InputThirdModifier(string text) => Generic.ProtectedElementSendKeys(txtMod3, text);
            public void InputFourthModifier(string text) => Generic.ProtectedElementSendKeys(txtMod4, text);
            public void InputTotalBillUnits(string text) => Generic.ProtectedElementSendKeys(txtUnits, text);
            public void InputNDC(string text) => Generic.ProtectedAccessElement(txtNDC, txtNDC_wrapper, text);
            public void InputNDCUnits(string text) => Generic.ProtectedAccessElement(txtUnit, txtUnit_wrapper, text);
            public void InputNDCMeasurements(string text) => Generic.ProtectedElementSendKeys(Measurements, text);
            public void InputRenderingProviderID(string text) => Generic.ProtectedElementSendKeys(txtRenderingProviderId, text);
            public string GetCOBAmount => Generic.ProtectedElementGetText(txtCOBAmount);
            public void InputerRenderingProviderTaxonomy(string text) => Generic.ProtectedElementSendKeys(txtRenderingProviderTaxonomy, text);
            public void InputOrderingProviderNPIAPI(string text) => Generic.ProtectedElementSendKeys(txtOrderingProviderNPI, text);
            public string GetOrderingProviderName => Generic.ProtectedElementGetText(txtOrderingProviderName);
            public string GetLineItemControlNumber => Generic.ProtectedElementGetText(txtLineItemControlNumber);
            public void ClickAdd() => Generic.ProtectedElementClick(lnkProfAdd);
            public void ClickSave() => Generic.ProtectedElementClick(SaveBtm);
            public void ClickSaveAndAddAnother() => Generic.ProtectedElementClick(SaveAndAddAnotherBtn);
            public void InputDiagnosis(string text) => Generic.ProtectedElementSendKeys(Diagnosis_Input, text);
            public void ClickEPSDTRadioButton() => Generic.ProtectedElementClick(chkEPSDT);
            public void ClickEMGRadioButton() => Generic.ProtectedElementClick(ChkEMG);
            public void ClickFamilyPlanningRadioButton() => Generic.ProtectedElementClick(chkFamilyPlanning);
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

            public void InputBillingProviderNPIAPI(string text) => Generic.ProtectedElementSendKeys(txtBillingProvNPI, text);
            public string GetBillingProviderName => Generic.ProtectedElementGetText(txtBillProviderName);
            /// <summary>
            /// Yes or No
            /// </summary>
            /// <param name="yesno"></param>
            public void DecideIsBillingProviderCorrect(string yesno) => Generic.ProtectedDecisionClick(BillProvCorrect_0, BillProvCorrect_1, yesno);
            public void InputTaxIDQualifer(string text) => Generic.ProtectedElementSendKeys(TaxIdQualifier_Input, text);
            public void InputTaxID(string text) => Generic.ProtectedElementSendKeys(txtTaxID, text);
            public void InputTaxonomyCode(string text) => Generic.ProtectedElementSendKeys(txtTaxonomyCode, text);
            public void InputOtherIDQualifier(string text) => Generic.ProtectedElementSendKeys(therIDQuali_Input, text);
            public void InputOtherID(string text) => Generic.ProtectedElementSendKeys(txtOtherID, text);
            /// <summary>
            /// Assigned;
            /// Assignment Accepted on Clinical Lab Services Only;
            /// Not Assigned
            /// </summary>
            /// <param name="text"></param>
            public void InputProviderAcceptsAssignment(string text) => Generic.ProtectedElementSendKeys(AcceptsAssignment_Input, text);
            public void ClickSelectExistingAddress() => Generic.ProtectedElementClick(radBtnSelectExistingAdd_0);
            public void ClickEnterNewAddress() => Generic.ProtectedElementClick(radBtnSelectExistingAdd_1);
            public void ClickAddressNotProvided() => Generic.ProtectedElementClick(radBtnSelectExistingAdd_2);
            public void InputPickUpAddressLineOne(string text) => Generic.ProtectedElementSendKeys(AddressLine1, text);
            public void InputPickUpAddressLineTwo(string text) => Generic.ProtectedElementSendKeys(AddressLine2, text);
            public void InputPickUpCity(string text) => Generic.ProtectedElementSendKeys(txtCity, text);
            public void InputPickUpState(string text) => Generic.ProtectedElementSendKeys(State_Input, text);
            public void InputPickUpZipCode(string text) => Generic.ProtectedAccessElement(txtZipCode, txtZipCodeOverlay, text);
            #endregion


        }

    }
}