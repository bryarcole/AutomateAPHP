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

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'WorkItem_txtQueueStatus')]")]
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
        public string  gatherAppNumber()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            string text = "";

            wait.Until(context =>
            {
                try
                {
                    text = applicationNumber.Text;

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
            return text;
        }
        public string gatherWorkItemType()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            string text = "";

            wait.Until(context =>
            {
                try
                {
                    text = txtWorkItemType.Text;

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
            return text;
        }
        public string gatherWorkItemStatus()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            string text = "";

            wait.Until(context =>
            {
                try
                {
                    text = txtQueueStatus.Text;

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
            return text;
        }




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

        public void ClickApproveButton()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    btnActivityApprove.Click();

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
        public void ClickPendButton()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    btnActivityPend.Click();

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
        public void ClickDenyButton()
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    btnActivityDeny.Click();

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

    }
}
