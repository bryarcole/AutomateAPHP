using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1.Utilities;

namespace NUnit.Tests1.Pages.WorkerPortal
{
    public class ClaimsSearchPage
    {
        IWebDriver context;
        public ClaimsSearchPage(IWebDriver context)
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
        #region elements
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'StartsWith_Input')]")]
        private IWebElement StartsWith { get; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'lbtnReferral')]")]
        private IWebElement BeginNewClaim { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Where_Input')]")]
        private IWebElement Where { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'How_Input')]")]
        private IWebElement HowSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'For_Input')]")]
        private IWebElement LookingFor { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnSearch')]")]
        private IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnReset')]")]
        private IWebElement ResetButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCommunicationSearch')]")]
        private IWebElement txtCommunicationSearch { get; set; }
        [FindsBy(How = How.ClassName, Using = "rgNorecords")]
        private IWebElement ReturnNoRecords { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DOSFrom_dateInput')]")]
        private IWebElement DOSFrom_dateInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DOSFrom_dateInput_wrapper')]")]
        private IWebElement DOSFrom_dateInput_wrapper { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DOSTo_dateInput')]")]
        private IWebElement DOSTo_dateInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DOSTo_dateInput_wrapper')]")]
        private IWebElement DOSTo_dateInput_wrapper { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ClaimType_Input')]")]
        private IWebElement ClaimType_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'CboClaimType_Arrow')]")]
        private IWebElement CboClaimType_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CboClaimStatus_Input')]")]
        private IWebElement CboClaimStatus_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'CboClaimStatus_Arrow')]")]
        private IWebElement CboClaimStatus_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtMemberId')]")]
        private IWebElement txtMemberId { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboBenefitPaln_Input')]")]
        private IWebElement cboBenefitPaln_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'cboBenefitPaln_Arrow')]")]
        private IWebElement cboBenefitPaln_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'xtFinacialAccNo')]")]
        private IWebElement xtFinacialAccNo { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAuthRefID')]")]
        private IWebElement txtAuthRefID { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtBillProvNPI')]")]
        private IWebElement txtBillProvNPI { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtRend')]")]
        private IWebElement txtRend { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtReferProvNPI')]")]
        private IWebElement txtReferProvNPI { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboProvNtwk_Input')]")]
        private IWebElement cboProvNtwk_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'cboProvNtwk_Arrow')]")]
        private IWebElement cboProvNtwk_Arrow { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtResultCode')]")]
        private IWebElement txtResultCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtDiagnosisCode')]")]
        private IWebElement txtDiagnosisCode { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtProcCode')]")]
        private IWebElement txtProcCode { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboMediaType_Input')]")]
        private IWebElement cboMediaType_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboMediaType_Arrow')]")]
        private IWebElement cboMediaType_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtEpiId')]")]
        private IWebElement txtEpiId { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CboEpisodeType_Input')]")]
        private IWebElement CboEpisodeType_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'CboEpisodeType_Arrow')]")]
        private IWebElement CboEpisodeType_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboProgType_Input')]")]
        private IWebElement cboProgType_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'cboProgType_Arrow')]")]
        private IWebElement cboProgType_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtRemittanceAdviceNumber')]")]
        private IWebElement txtRemittanceAdviceNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCheckOrEFTNumber')]")]
        private IWebElement txtCheckOrEFTNumber { get; set; }
        #endregion
        #region Methods and Calls
        public void InputCheckOrEFTNumber(string CheckOrEFTNumber) => Generic.SendKeys(txtCheckOrEFTNumber, CheckOrEFTNumber);
        public void InputRemittanceAdviceNumber(string AdviceNumber) => Generic.SendKeys(txtRemittanceAdviceNumber, AdviceNumber);
        /// <summary>
        /// Three digits from 001-109
        /// </summary>
        /// <param name="ProgType"></param>
        public void InputProgType(string ProgType)
        {
            Generic.SendKeys(cboProgType_Input, ProgType);
            Generic.Click(cboProgType_Arrow);
        }
        /// <summary>
        /// Acute Myocardial Infarction (AMI)/Heart Attack,
        /// Broken Limb,
        /// Congestive Heart Failure (CHF),
        /// Heart Attack,
        /// Hip Replacement,
        /// Hypertension,
        /// Joint Degeneration,
        /// Knee Replacement,
        /// Pnuemonia,
        /// Pregnancy/Delivery/NICU
        /// </summary>
        /// <param name="EpisodeType"></param>
        public void InputEpisodeType(string EpisodeType)
        {
            Generic.SendKeys(CboEpisodeType_Input, EpisodeType);
            Generic.Click(CboEpisodeType_Arrow);
        }
        public void InputEpisodeId(string epID) => Generic.SendKeys(txtEpiId, epID);
        public void InputMediaType(string MediaType)
        {
            Generic.SendKeys(cboMediaType_Input, MediaType);
            Generic.Click(cboMediaType_Arrow);
        }
        public void InputProcCode(string ProcCode) => Generic.SendKeys(txtProcCode, ProcCode);
        public void InputDiagnosisCode(string DiagnosisCode) => Generic.SendKeys(txtDiagnosisCode, DiagnosisCode);
        public void InputResultCode(string ResultCode) => Generic.SendKeys(txtResultCode, ResultCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvNtwk"></param>
        public void InputProvNtwk(string ProvNtwk)
        {
            Generic.SendKeys(cboProvNtwk_Input, ProvNtwk);
            Generic.Click(cboProvNtwk_Arrow);
        }
        public void InputReferProvNPI(string ReferProvNPI)
        {
            Generic.SendKeys(txtReferProvNPI, ReferProvNPI);
        }
        public void InputRendProvNPI(string Rend)
        {
            Generic.SendKeys(txtRend, Rend);
        }
        public void InputBillProvNPI(string BillProvNPI)
        {

            Generic.SendKeys(txtBillProvNPI, BillProvNPI);
        }
        public void InputAuthReferralID(string AuthRefID)
        {
            
            Generic.SendKeys(txtAuthRefID, AuthRefID);
        }
        public void InputFinancialAccountNumber(string accountNumber)
        {
            Generic.SendKeys(xtFinacialAccNo, accountNumber);
        }
        /// <summary>
        /// Building Independence Waiver,
        /// Buy-In,
        /// CCCPlus,
        /// Default Benefit Plan,
        /// Dialysis,
        /// Medicaid Works,
        /// Medicare Coinsurance and Deductibles,
        /// Plan First
        /// </summary>
        /// <param name="type"></param>
        public void InputBenefitPlan(string type)
        {
            Generic.SendKeys(cboBenefitPaln_Input, type);
            Generic.Click(cboBenefitPaln_Arrow);
        }
        public void InputMemberID(string ID)
        {
            Generic.SendKeys(txtMemberId, ID);
        }
        public void InputClaimStatus(string type)
        {
            Generic.SendKeys(CboClaimStatus_Input, type);
            Generic.Click(CboClaimStatus_Arrow);
        }
        /// <summary>
        /// Dental,
        /// Institutional
        /// Professional
        /// </summary>
        /// <param name="type"></param>
        public void InputClaimType(string type)
        {
            Generic.SendKeys(ClaimType_Input, type);
            Generic.Click(CboClaimType_Arrow);

        }
        public void InputDateFrom(string date)
        {
            Generic.Click(DOSFrom_dateInput_wrapper);
            Generic.SendKeys(DOSFrom_dateInput, date);
        }
        public void InputDateTO(string date)
        {
            Generic.Click(DOSTo_dateInput_wrapper);
            Generic.SendKeys(DOSTo_dateInput, date);
        }
        public void BeginNewClaimClick()
        {
            Generic.Click(BeginNewClaim);
        }
        /// <summary>
        /// Claim/EncounterNumber, 
        /// Billing Provider NPI/API,
        /// Billing Name, 
        /// Rendering Provider NPI/API,
        /// Rendering Name,
        /// Service Facility NPI/API,
        /// Service Favility Name, 
        /// Member ID,
        /// Member Name,
        /// /// </summary>
        /// <param name="searchCriteria"></param>
        public void WhereSearchInput(string searchCriteria)
        {
            Generic.Clear(Where);
            Generic.SendKeys(Where, searchCriteria);

        }
        /// <summary>
        /// Contains, 
        /// Equals, 
        /// Starts With
        /// </summary>
        /// <param name="searchCriteria"></param>
        public void HowSearchInput(string searchCriteria) => Generic.AccessElement(HowSearch, HowSearch, searchCriteria);

        /// <summary>
        /// Click Search Button
        /// </summary>
        /// <returns></returns>
        public void SearchButtonClick() => Generic.Click(SearchButton);
        public void SearchInputBox(string searchInput) => Generic.AccessElement(txtCommunicationSearch, txtCommunicationSearch, searchInput);
        public bool ChkReturnNoRecords()
        {
            return ReturnNoRecords.Displayed;
        }

        public void SearchMember(string Where, string How, string InputValue)
        {

            WhereSearchInput(Where);
            HowSearchInput(How);
            SearchInputBox(InputValue);
            SearchButtonClick();
        }

        #endregion
    }
}