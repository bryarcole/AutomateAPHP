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
        public Generic GrabGeneric(IWebDriver context)
        {
            return new Generic(context);
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
        //[FindsBy(How = How.XPath, Using = "//*[contains(@id, 'ctl00_ctl00_pageContentMaster_pageContent_grdNewAssignedWI_ctl00__0')]")]
        //private List<IWebElement> returnedTable { get; set; }
        ////*[@id="ctl00_ctl00_pageContentMaster_pageContent_grdNewAssignedWI_ctl00__0"]/td[1]



        //public void GetTableCell()
        //{
        //    int i = 0;

        //    for(i = 0; 1 < returnedTable.Count; i++ ){

        //        IWebElement row = context.FindElement(By.XPath("//*[@id=\"ctl00_ctl00_pageContentMaster_pageContent_grdNewAssignedWI_ctl00__" + i + "\"]"));

        //        //*[@id="ctl00_ctl00_pageContentMaster_pageContent_grdNewAssignedWI_ctl00_ctl04_WorkItemId"]
        //        //*[@id="ctl00_ctl00_pageContentMaster_pageContent_grdNewAssignedWI_ctl00__0"]/td[1]
        //    }
        //}
        public void CreateNewMemberPanelClick()
        {
            GrabGeneric(context).ProtectedElementClick(CreateNewMemberPanel);
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

            GrabGeneric(context).ProtectedElementClear(AdditionalCriterias);
            GrabGeneric(context).ProtectedElementSendKeys(AdditionalCriterias, searchInput);

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