﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1.Steps;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using NUnit.Tests1.Utilities;

namespace NUnit.Tests1.Pages.WorkerPortal
{
    public class WorkItemComponent
    {

        public IWebDriver context;
        public WorkItemComponent(IWebDriver context)
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
        public string GatherAppNumber() => Generic.GetText(applicationNumber);
        public string GatherWorkItemType() => Generic.GetText(txtWorkItemType);
        public string GetGatherWorkItemStatus() => Generic.GetText(txtQueueStatus);
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
        
        public IWebElement ClickApproveButton() => Generic.Click(btnActivityApprove);
        public IWebElement ClickPendButton() => Generic.Click(btnActivityPend);
        public IWebElement ClickDenyButton() => Generic.Click(btnActivityDeny);
        public IWebElement ClickCompletedButton() => Generic.Click(CompletedBottom);
        public IWebElement ClickExitButton() => Generic.Click(btnExitBottom);
        public IWebElement ClickWorkItemButton() => Generic.Click(btnWorkItemTop);

    }
}
