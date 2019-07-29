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
    public class MemberSearchPage
    {

        IWebDriver context;

        public MemberSearchPage(IWebDriver context)
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
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnCreateNewMemberPanel')]")]
        private IWebElement CreateNewMemberPanel { get; set; }
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
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtAdditionalCriterias')]")]
        private IWebElement AdditionalCriterias { get; set; }
        [FindsBy(How = How.ClassName, Using = "rgNorecords")]
        private IWebElement ReturnNoRecords { get; set; }
        [FindsBy(How = How.XPath, Using = "//table[contains(@id, 'HippSearchResults')]")]
        private IWebElement SearchResults { get; set; }
        [FindsBy(How = How.XPath, Using = "//table[contains(@id, 'MemberSearchResults_ctl00']")]
        private IWebElement FirstCell { get; set; }

        public void CreateNewMemberPanelClick()
        {
            Generic.Click(CreateNewMemberPanel);
        }
        /// <summary>
        /// Case ID, 
        /// Member ID,
        /// Last Name, 
        /// SSN,
        /// Address Line1 
        /// </summary>
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
        private void HowSearchInput(string searchCriteria)
        {
            Generic.Clear(HowSearch);
            Generic.SendKeys(HowSearch, searchCriteria);

        }

        /// <summary>
        /// Click Search Button
        /// </summary>
        /// <returns></returns>
        public void SearchButtonClick()
        {
            Generic.Click(SearchButton);
        }
        public void SearchInputBox(string searchInput)
        {

            Generic.Clear(AdditionalCriterias);
            Generic.SendKeys(AdditionalCriterias, searchInput);

        }
        public bool ChkReturnNoRecords()
        {
            return ReturnNoRecords.Displayed;
        }

        public void SearchMember(string Where, string How,  string InputValue)
        {

            WhereSearchInput(Where);
            HowSearchInput(How);
            SearchInputBox(InputValue);
            SearchButtonClick();
        }


    }
}