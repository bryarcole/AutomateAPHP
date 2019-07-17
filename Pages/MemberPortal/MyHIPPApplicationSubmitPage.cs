using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Tests1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;


namespace NUnit.Tests1.Pages.MemberPortal
{
    public class MyHIPPApplicationSubmitPage
    {
        IWebDriver context;

        public MyHIPPApplicationSubmitPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        class PolicyolderEmployeeInformation
        {
            IWebDriver context;
            public PolicyolderEmployeeInformation(IWebDriver context)
            {
                this.context = context;
                PageFactory.InitElements(context, this);
            }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AccountYN_0')]")]
            private IWebElement PolicyHolderYes { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AccountYN_1')]")]
            private IWebElement PolicyHolderNo { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, MemAccount_Input")]
            private IWebElement MemAccount_Input { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, btnBeginApp")]
            private IWebElement BeginAppButton { get; set; }

            
        }








        //public void InputSelectType(string text)
        //{
        //    Generic.ProtectedElementClick(SelectTypeInput);
        //    Generic.ProtectedElementSendKeys(SelectTypeInput, text);
        //}
        //public void BeginApplicationClick()
        //{
        //    Generic.ProtectedElementClick(BeginAppButton);
        //}
    }
}
