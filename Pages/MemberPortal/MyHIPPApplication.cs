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
    public class MyHIPPApplicationPage
    {
        IWebDriver context;

        public MyHIPPApplicationPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, cboSelectType_Input")]
        private IWebElement SelectTypeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, btnBeginApp")]
        private IWebElement BeginAppButton { get; set; }

        public Generic GrabGeneric(IWebDriver context)
        {
            return new Generic(context);
        }


        public void InputSelectType(string text)
        {
            GrabGeneric(context).ProtectedElementClick(SelectTypeInput);
            GrabGeneric(context).ProtectedElementSendKeys(SelectTypeInput, text);
        }
        public void BeginApplicationClick()
        {
            GrabGeneric(context).ProtectedElementClick(BeginAppButton);
        }
    }
}
