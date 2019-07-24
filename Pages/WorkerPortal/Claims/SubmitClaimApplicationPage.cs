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


namespace NUnit.Tests1.Pages.WorkerPortal.Claims
{
    public class SubmitClaimApplicationPage
    {
        static IWebDriver context;



        public class SummaryInformation
        {
            IWebDriver context;
            public SummaryInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }
            private Generic MakeGeneric
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
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'cboAdjustmentReason_Input')]")]
            private IWebElement cboAdjustmentReason_Input { get; set; }

            #endregion
            #region Method and Calls
            public string GetClaimNumber()
            {

                return MakeGeneric.ProtectedElementGetText(txtClaimNo);
            }
            public string GetCleanStatus()
            {

                return MakeGeneric.ProtectedElementGetText(txtClean);
            }
            public string GetClaimEncounterStatus()
            {

                return MakeGeneric.ProtectedElementGetText(txtClaimStatus);
            }
            public string GetBenefitPlan()
            {

                return MakeGeneric.ProtectedElementGetText(txtBenefitPlan);

            }
            public string GetDuplicateStatus()
            {

                return MakeGeneric.ProtectedElementGetText(txtDuplicate);
            }
            public string GetAdjustedStatus()
            {
                return MakeGeneric.ProtectedElementGetText(txtAdjust);
            }
            public string GetCrossoverStatus()
            {
                return MakeGeneric.ProtectedElementGetText(txtCrossOver);
            }
            public string GetMediaSource()
            {
               return MakeGeneric.ProtectedElementGetText(txtMediaType);
            }
            public string GetVoidStatus()
            {
                return MakeGeneric.ProtectedElementGetText(txtVoid);
            }
            public string GetRemittanceAdviceNumber()
            {
                return MakeGeneric.ProtectedElementGetText(txtRemittanceAdviceNumber);
            }
            public string GetRemittanceAdviceDate()
            {
                return MakeGeneric.ProtectedElementGetText(txtRemittanceAdviceDate);
            }
            public void InputAdjustmentReason(string text)
            {
                MakeGeneric.ProtectedElementSendKeys(cboAdjustmentReason_Input, text);
            }

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


    }
}