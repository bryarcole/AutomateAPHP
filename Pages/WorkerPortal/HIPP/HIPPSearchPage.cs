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
    public class HIPPSearchPage
    {

        IWebDriver context;

        public HIPPSearchPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);

        }
        public Generic GrabGeneric(IWebDriver context)
        {
            return new Generic(context);
        }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnCreateNewHippApplication')]")]
        private IWebElement BeginNewHIPPApplication { get; set; }
        [FindsBy(How= How.XPath, Using ="//input[contains(@id, 'Where_Input')]")]
        private IWebElement Where { get; set; }
        [FindsBy(How= How.XPath, Using ="//input[contains(@id, 'How_Input')]")]
        private IWebElement HowSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Type_Input')]")]
        private IWebElement ApplicationType { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Mode_Input')]")]
        private IWebElement ApplicationMode { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnSearch')]")]
        private IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using ="//input[contains(@id, 'SearchValue')]")]
        private IWebElement SearchValue { get; set; }
        [FindsBy (How = How.ClassName, Using = "rgNorecords")]
        private IWebElement ReturnNoRecords { get; set; }
        [FindsBy(How = How.XPath, Using = "//table[contains(@id, 'HippSearchResults')]")]
        private IWebElement SearchResults { get; set; }
        [FindsBy(How = How.Id, Using = "//ctl00_ctl00_pageContentMaster_criteria1_grdHippSearchResults_ctl00_ctl04_lnkColumn")]
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
        public void ClickBeginNewApp()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));

            wait.Until(context =>
            {
                try
                {
                    BeginNewHIPPApplication.Click();
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
        /// Application Id, 
        /// Member ID,
        /// Policyholder/Employee Name, 
        /// SSN 
        /// </summary>
        /// <param name="searchCriteria"></param>
        public void WhereSearchInput(string searchCriteria)
        {
            GrabGeneric(context).Clear(Where);
            GrabGeneric(context).SendKeys(Where, searchCriteria);

        }
        /// <summary>
        /// Contains, 
        /// Equals, 
        /// Starts With
        /// </summary>
        /// <param name="searchCriteria"></param>
        private IWebElement HowSearchInput(string searchCriteria)
        {

            HowSearch.Clear();
            HowSearch.SendKeys(searchCriteria);
            return HowSearch;

        }
        /// <summary>
        /// New, 
        /// Renewal 
        /// </summary>
        /// <param name="searchCriteria"></param>
        private IWebElement ApplicationTypeInput(string searchCriteria)
        {
            ApplicationType.Clear();
            ApplicationType.SendKeys(searchCriteria);
            return ApplicationType;
        }
        /// <summary>
        /// Paper, 
        /// Electronic 
        /// </summary>
        /// <param name="searchCriteria"></param>
        private IWebElement ApplicationModeInput(string searchCriteria)
        {
            ApplicationMode.Clear();
            ApplicationMode.SendKeys(searchCriteria);
            return ApplicationMode;
        }
        /// <summary>
        /// Click Search Button
        /// </summary>
        /// <returns></returns>
        public void SearchButtonClick()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));

            wait.Until(context =>
            {
                try
                {
                    SearchButton.Click();

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
        public void SearchInputBox(string searchInput)
        {

            SearchValue.Clear();
            SearchValue.SendKeys(searchInput);

        }
        public bool ChkReturnNoRecords()
        {
            return ReturnNoRecords.Displayed;
        }

        public void SearchHiPPCase(string How, string Where, string InputValue)
        {
            HowSearchInput(How);
            WhereSearchInput(Where);
            SearchInputBox(InputValue);
        }
        public void SearchHiPPCase(string How, string Where, string InputValue, string Mode, string Type)
        {
            Generic generic = new Generic(context);
            GrabGeneric(context).GenericCheveronClick("0");
            HowSearchInput(How);
            WhereSearchInput(Where);
            SearchInputBox(InputValue);
            ApplicationModeInput(Mode);
            ApplicationTypeInput(Type);
        }

        private IWebElement SelectTableCell(string row, string column)
        {
            SearchResults.FindElement(By.XPath("//*[contains(@id,'Results_ctl00__0'])"));
            IWebElement cell = context.FindElement(By.XPath("'//table[contains(@id=" + "SearchResults" + ")]//tr[" + row + "]//td[" + column + "]'"));
            return cell;
        }
    }
}