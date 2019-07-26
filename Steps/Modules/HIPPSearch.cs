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
using System.Threading;
using System.Linq;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using NUnit.Tests1.Pages.WorkerPortal;

namespace NUnit.Tests1.Steps
{
    public class HIPPSearch
    {

        public void HIPPMemberSearch(string appNumber, IWebDriver context)
        {

            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            Generic generic = new Generic(context);


            //Gather Data from app
            landingPage.HippApplicationSearch();
            hIPPSearch.SearchHiPPCase("Contains", "MemberID", appNumber);
            hIPPSearch.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            generic.GenericLinkTextClick(appNumber);

        }

        /// <summary>
        /// Searchs for application number, App number must be clicked to continue in the flow
        /// </summary>
        /// <param name="appNumber"></param>
        /// <param name="context"></param>
        /// <param name="sucessCount"></param>
        /// <param name="screenshotLocation"></param>
        /// <param name="test"></param>
        /// <param name="doc"></param>
        public void HIPPAppSearch(string appNumber, IWebDriver context)
        {

            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            Generic generic = new Generic(context);


            //Gather Data from app
            landingPage.HippApplicationSearch();
            hIPPSearch.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearch.SearchButtonClick();
            generic.HoverByLinkText(appNumber);

        }

        public void HIPPClickSearchResult(string appNumber)
        {

        }
    }
}
