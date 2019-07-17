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
            public Generic GrabGeneric(IWebDriver context)
            {
                return new Generic(context);
            }
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

            public void clickSaveButton()
            {
                GrabGeneric(context).ProtectedElementClick(btnSave);
            }
            public void ClickCancelButton()
            {
                GrabGeneric(context).ProtectedElementClick(btnCancel);
            }
            public void RICInput(string input)
            {
                GrabGeneric(context).ProtectedElementClick(RicValue_Input);
                GrabGeneric(context).ProtectedElementSendKeys(RicValue_Input, input);
                GrabGeneric(context).ProtectedElementSendKeys(RicValue_Input, Keys.Tab);

            }
            public void MedicarePartInput(string input)
            {
                GrabGeneric(context).ProtectedElementClick(MedicarePart_Input);
                GrabGeneric(context).ProtectedElementSendKeys(MedicarePart_Input, input);
                GrabGeneric(context).ProtectedElementSendKeys(MedicarePart_Input, Keys.Tab);

            }
            public void TransactionCodeInput(string input)
            {
                GrabGeneric(context).ProtectedElementSendKeys(TransactionCode, input);
            }
            public void SubCodeInput(string input)
            {
                GrabGeneric(context).ProtectedElementClick(SubCode);
                GrabGeneric(context).ProtectedElementSendKeys(SubCode, input);
                GrabGeneric(context).ProtectedElementSendKeys(SubCode, Keys.Tab);

            }
            public void BuyInEligibilityCodeInput(string input)
            {
                GrabGeneric(context).ProtectedElementClick(EligibilityCode_Input);
                GrabGeneric(context).ProtectedElementSendKeys(EligibilityCode_Input, input);
                GrabGeneric(context).ProtectedElementSendKeys(EligibilityCode_Input, Keys.Tab);
            }
            public void TransactionEffectiveDateFromInput(string input)
            {
                GrabGeneric(context).ProtectedElementClick(BuyInEffFromDate_dateInput_wrapper);
                GrabGeneric(context).ProtectedElementSendKeys(BuyInEffFromDate_dateInput, input);
                GrabGeneric(context).ProtectedElementSendKeys(BuyInEffFromDate_dateInput ,Keys.Tab);

            }
            public void TransactionEffectiveToFromInput(string input)
            {
                GrabGeneric(context).ProtectedElementClick(dpBuyInEffToDate_dateInput_wrapper);
                GrabGeneric(context).ProtectedElementSendKeys(BuyInEffToDatedateInput, input);
                GrabGeneric(context).ProtectedElementSendKeys(BuyInEffToDatedateInput, Keys.Tab);

            }
            public void SentRecievedDateInput(string input)
            {
                GrabGeneric(context).ProtectedElementClick(SentRecievedDate_dateInput_wrapper);
                GrabGeneric(context).ProtectedElementSendKeys(SentRecievedDate_dateInput, input);
                GrabGeneric(context).ProtectedElementSendKeys(SentRecievedDate_dateInput, Keys.Tab);

            }
            public void PremiumInput(string input)
            {
                GrabGeneric(context).ProtectedElementSendKeys(txtPremium, input);
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