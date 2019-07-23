using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;

namespace NUnit.Tests1.Pages.WorkerPortal
{
    public class WorkerPortalLandingPage
    {
        public IWebDriver context;
        public WorkerPortalLandingPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Member")]
        public IWebElement Memberhover { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "My Dashboard")]
        public IWebElement myDashboard { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "HIPP Application Search")]
        public IWebElement HiPPApplicationSearch { get; set; }


        
        public void HippApplicationSearch()
        {
            MemberHover();
            HiPPApplicationSearch.Click();
        }



        public void MemberHover()
        {
            Actions action = new Actions(context);
            action.MoveToElement(Memberhover).Perform();
        }
        public static IWebElement HIPPApp(IWebDriver context)
        {
            IWebElement HIPPApplicationSearch = context.FindElement(By.Id("pageContentMaster_WorkerHeader_MainNavigation_rptWorkerTopMenu_rptWorkerTopSubMenu_2_lnkWorkerTopSubMenu_1"));
            return HIPPApplicationSearch;
        }
    }
}
