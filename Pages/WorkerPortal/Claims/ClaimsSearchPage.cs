using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1.Steps;
using NUnit.Tests1.Utilities;
using SeleniumExtras;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using System.Collections.Generic;

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
        public Generic GrabGeneric(IWebDriver context)
        {
            return new Generic(context);
        }
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
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Mode_Input')]")]
        private IWebElement ApplicationMode { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnSearch')]")]
        private IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnReset')]")]
        private IWebElement ResetButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCommunicationSearch')]")]
        private IWebElement txtCommunicationSearch { get; set; }
        [FindsBy(How = How.ClassName, Using = "rgNorecords")]
        private IWebElement ReturnNoRecords { get; set; }
        [FindsBy(How = How.XPath, Using = "//table[contains(@id, 'HippSearchResults')]")]
        private IWebElement SearchResults { get; set; }
        [FindsBy(How = How.XPath, Using = "//table[contains(@id, 'MemberSearchResults_ctl00']")]
        private IWebElement FirstCell { get; set; }

        public void BeginNewClaimClick()
        {
            GrabGeneric(context).ProtectedElementClick(BeginNewClaim);
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
            GrabGeneric(context).ProtectedElementClear(Where);
            GrabGeneric(context).ProtectedElementSendKeys(Where, searchCriteria);

        }
        /// <summary>
        /// Contains, 
        /// Equals, 
        /// Starts With
        /// </summary>
        /// <param name="searchCriteria"></param>
        private void HowSearchInput(string searchCriteria)
        {
            GrabGeneric(context).ProtectedElementClear(HowSearch);
            GrabGeneric(context).ProtectedElementSendKeys(HowSearch, searchCriteria);

        }

        /// <summary>
        /// Click Search Button
        /// </summary>
        /// <returns></returns>
        public void SearchButtonClick()
        {
            GrabGeneric(context).ProtectedElementClick(SearchButton);
        }
        public void SearchInputBox(string searchInput)
        {

            GrabGeneric(context).ProtectedElementClear(txtCommunicationSearch);
            GrabGeneric(context).ProtectedElementSendKeys(txtCommunicationSearch, searchInput);

        }
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


    }
}