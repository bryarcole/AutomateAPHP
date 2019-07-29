using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1;
using System.Threading;
using NUnit.Tests1.Steps.StartUp;
using NUnit.Tests1.Utilities;

namespace NUnit.Tests1.Pages
{
    public class BeginNewClaimPage
    {
        IWebDriver context;
        public BeginNewClaimPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }
        public Generic GrabGeneric(IWebDriver context)
        {
            return new Generic(context);
        }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'CboSelectType')]")]
        private IWebElement CboSelectType { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'CboSelectType_Arrow')]")]
        private IWebElement CboSelectType_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ComboBoxTypeOfBill')]")]
        private IWebElement ComboBoxTypeOfBill { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'TypeOfBill_Arrow')]")]
        private IWebElement TypeOfBill_Arrow { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'btnBeginNewClaim')]")]
        private IWebElement btnBeginNewClaim { get; set; }
        

        /// <summary>
        /// Institutional, 
        /// Professional 
        /// </summary>
        /// <param name="text"></param>
        public void SelectClaimType(string text)
        {
            Generic generic = new Generic(context);
            generic.SendKeys(CboSelectType, text);
            generic.Click(CboSelectType_Arrow);
        }

        /// <summary>
        /// 110 - Hospital; inpatient; Non-payment/zero claim,
        /// 111 - Hospital; inpatient; Admit thru discharge claim,
        /// 112 - Hospital; inpatient; Interim - First claim,
        /// 113 - Hospital; inpatient; Interim - Continuing claim,
        /// 114 - Hospital; inpatient; Interim - Last claim,
        /// 11A - Hospital; inpatient; Admission/election notice,
        /// 11B - Hospital; inpatient; Termination/Revocation Notice,
        /// 11D - Hospital; inpatient; Cancellation of Election Notice
        /// </summary>
        /// <param name="text"></param>
        public void SelectTypeOfBill(string text)
        {
            Generic generic = new Generic(context);
            generic.SendKeys(ComboBoxTypeOfBill, text);
            generic.Click(TypeOfBill_Arrow);
        }

        public void ClickBeginNewClaim()
        {
            Generic generic = new Generic(context);
            generic.Click(btnBeginNewClaim);
        }
    }
}

