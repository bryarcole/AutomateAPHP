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
    public class HIPPMemberApplicationSubmitPage
    {
        IWebDriver context;

        public HIPPMemberApplicationSubmitPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        class HIPPMemberPolicyolderEmployeeInformation
        {
            IWebDriver context;
            public HIPPMemberPolicyolderEmployeeInformation(IWebDriver context)
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
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Prefix_Input'")]
            private IWebElement Prefix_Input { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'FirstName'")]
            private IWebElement FirstName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'MiddleName'")]
            private IWebElement MiddleName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'LastName'")]
            private IWebElement LastName { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddOne'")]
            private IWebElement AddOne { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'AddTwo'")]
            private IWebElement AddTwo { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtCity'")]
            private IWebElement txtCity { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'State_Input'")]
            private IWebElement State_Input { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ZipCode_wrapper'")]
            private IWebElement ZipCode_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ZipCode'")]
            private IWebElement ZipCode { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'HomePhone_wrapper'")]
            private IWebElement HomePhone_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'HomePhone'")]
            private IWebElement HomePhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'CellPhone_wrapper'")]
            private IWebElement CellPhone_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CellPhone'")]
            private IWebElement CellPhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'WorkPhone_wrapper'")]
            private IWebElement WorkPhone_wrapper { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'WorkPhone'")]
            private IWebElement WorkPhone { get; set; }
            [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Email'")]
            private IWebElement Email { get; set; }



        }
        class HIPPMemberHouseholdInformation
        {
            
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
