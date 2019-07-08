using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1.Steps;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace NUnit.Tests1.Pages
{
    public class WorkItemComponent
    {

        public IWebDriver context;
        public WorkItemComponent(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        /// <summary>
        /// Information 
        /// </summary>

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtQueueStatus')]")]
        public IWebElement txtQueueStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtDtCreated')]")]
        public IWebElement txtDtCreated { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'WorkItem_btncreatedby')]")]
        public IWebElement WorkItem_btncreatedby { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtWorkItemType')]")]
        public IWebElement txtWorkItemType { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'WorkItem_btnmod')]")]
        public IWebElement applicationNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnClose')]")]
        public IWebElement btnClose { get; set; }

       
        

        /// <summary>
        /// Buttons
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'txtActivityStatus')]")]
        public IWebElement txtActivityStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ActivitystatusResn_Input')]")]
        public IWebElement ActivitystatusResn_Input { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ActivitystatusResn')]")]
        public IWebElement ActivitystatusResn { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnActivityPend')]")]
        public IWebElement btnActivityPend { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnActivityDeny')]")]
        public IWebElement btnActivityDeny { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnActivityApprove')]")]
        public IWebElement btnActivityApprove { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'ReqtInfoBottom')]")]
        public IWebElement ReqtInfoBottom { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'CompletedBottom')]")]
        public IWebElement CompletedBottom { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnExitBottom')]")]
        public IWebElement btnExitBottom { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'WorkItem_btnView')]")]
        public IWebElement WorkItem_btnView { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnActivityReopen')]")]
        public IWebElement btnActivityReopen { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnActivityDone')]")]
        public IWebElement btnActivityDone { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnWorkItemTop')]")]
        public IWebElement btnWorkItemTop { get; set; }

        public void ClickCompletedButton()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    CompletedBottom.Click();

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
        public void ClickExitButton()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    btnExitBottom.Click();

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
        public void ClickWorkItemButton()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    btnWorkItemTop.Click();

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
        public string GetQueueStatus()
        {
            string queueStatus = txtQueueStatus.Text;
            return queueStatus;
        }
        public string GetCreateDate()
        {
            string createDate = txtDtCreated.Text;
            return createDate;
        }
        public string GetWorkerPortal()
        {
            string createdBy = WorkItem_btncreatedby.Text;
            return createdBy;
        }
    }
}
