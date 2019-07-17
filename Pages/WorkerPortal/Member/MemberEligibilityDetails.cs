using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1.Steps;
using NUnit.Tests1.Utilities;
using SeleniumExtras;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace NUnit.Tests1.Pages
{
    public class MemberEligibilityDetails
    {

        IWebDriver context;

        public MemberEligibilityDetails(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);

        }


        public class MedicareBuyIn : MemberEligibilityDetails
        {
            
            public MedicareBuyIn(IWebDriver context) : base(context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);

            }

            #region Element Declare
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnSave')]")]
            private IWebElement btnSave { get; set; }
            [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnCancel')]")]
            private IWebElement btnCancel { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'RicValue_Input')]")]
            private IWebElement RicValue_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'MedicarePart_Input')]")]
            private IWebElement MedicarePart_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'TransactionCode')]")]
            private IWebElement TransactionCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SubCode')]")]
            private IWebElement SubCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EligibilityCode_Input')]")]
            private IWebElement EligibilityCode_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'BuyInEffFromDate_dateInput')]")]
            private IWebElement BuyInEffFromDate_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'BuyInEffFromDate_dateInput_wrapper')]")]
            private IWebElement BuyInEffFromDate_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'SentRecievedDate_dateInput')]")]
            private IWebElement SentRecievedDate_dateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'SentRecievedDate_dateInput_wrapper')]")]
            private IWebElement SentRecievedDate_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'BuyInEffToDate$dateInput')]")]
            private IWebElement BuyInEffToDatedateInput { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'BuyInEffToDate_dateInput_wrapper')]")]
            private IWebElement dpBuyInEffToDate_dateInput_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtPremium')]")]
            private IWebElement txtPremium { get; set; }
            #endregion

            #region Class Methods
            public void RICInput(string input)
            {
                Generic.ProtectedElementClick(RicValue_Input);
                Generic.ProtectedElementSendKeys(RicValue_Input, input);
            }
            public void MedicarePartInput(string input)
            {
                Generic.ProtectedElementClick(MedicarePart_Input);
                Generic.ProtectedElementSendKeys(MedicarePart_Input, input);
            }
            public void TransactionCodeInput(string input)
            {
                Generic.ProtectedElementSendKeys(TransactionCode, input);
            }
            public void SubCodeInput(string input)
            {
                Generic.ProtectedElementClick(SubCode);
                Generic.ProtectedElementSendKeys(SubCode, input);
            }
            public void BuyInEligibilityCodeInput(string input)
            {
                Generic.ProtectedElementClick(EligibilityCode_Input);
                Generic.ProtectedElementSendKeys(EligibilityCode_Input, input);
            }
            public void TransactionEffectiveDateFromInput(string input)
            {
                Generic.ProtectedElementClick(BuyInEffFromDate_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(BuyInEffFromDate_dateInput, input);
            }
            public void TransactionEffectiveToFromInput(string input)
            {
                Generic.ProtectedElementClick(dpBuyInEffToDate_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(BuyInEffToDatedateInput, input);
            }
            public void SentRecievedDateInput(string input)
            {
                Generic.ProtectedElementClick(SentRecievedDate_dateInput_wrapper);
                Generic.ProtectedElementSendKeys(SentRecievedDate_dateInput, input);
            }
            public void PremiumInput(string input)
            {
                Generic.ProtectedElementSendKeys(txtPremium, input);
            }
            #endregion


            public void MedicareBuyInput(string RIC, 
                string medicarePart, 
                string transactionCode, 
                string subCode, 
                string eligibilityCode, 
                string transactionFrom,
                string transactionTo,
                string DateSentRecieved,
                string Premium)
            {
                RICInput(RIC);
                MedicarePartInput(medicarePart);
                TransactionCodeInput(transactionCode);
                SubCodeInput(subCode);
                BuyInEligibilityCodeInput(eligibilityCode);
                TransactionEffectiveDateFromInput(transactionFrom);
                TransactionEffectiveToFromInput(transactionTo);
                SentRecievedDateInput(DateSentRecieved);
                PremiumInput(Premium);
            }
        }
    }
}