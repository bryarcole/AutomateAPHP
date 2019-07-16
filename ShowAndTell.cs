using System.Collections;
using NUnit.Framework;
using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps.StartUp;
using NUnit.Tests1.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Tests1.Utilities;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TFSCommon.Common;
using TFSCommon.Data;
using Xceed.Words.NET;
using RequirementsTraceability;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
namespace NUnit.Tests1
{
    [TestFixture]
    public class ShowAndTell
    {
        public IWebDriver context = new ChromeDriver();

        [Test]
        public void GoToGoogle()
        {
            context.Url = "http://Google.com";

            IWebElement searchBar = context.FindElement(By.Name("q"));
            IWebElement searchButton = context.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[3]/center/input[1]"));

            searchBar.SendKeys("Dallas Cowboys");
            searchButton.Click();
        }

        [Test]
        public void AphpLogin()
        {
            APHPHomePage homepage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage searchPage = new HIPPSearchPage(context);
            Generic generic = new Generic(context);

            IWebElement table = context.FindElement(By.Id("ctl00_ctl00_pageContentMaster_criteria1_grdHippSearchResults_ctl00__0"));
            string appnumber = "10000151";
            homepage.LoginPage("bryar.h.wrkr", "Password123");

            landingPage.HippApplicationSearch();

            searchPage.SearchHiPPCase("contains", "Application ID", appnumber);
            searchPage.SearchButtonClick();

            Assert.IsTrue(table.Displayed);

            generic.genericLinkTextClick(appnumber);





        }
        


        

    }
}
