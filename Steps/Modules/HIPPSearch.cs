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

namespace NUnit.Tests1.Steps
{
    public class HIPPSearch
    {

        public void HIPPMemberSearch(string appNumber, IWebDriver context, int sucessCount, string screenshotLocation, ExtentTest test, DocX doc)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);


            //Gather Data from app
            landingPage.HippApplicationSearch();
            hIPPSearch.SearchHiPPCase("Contains", "MemberID", appNumber);
            hIPPSearch.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            utility.RecordPassStatus("Search Results", Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);
            generic.genericLinkTextClick(appNumber);

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
        public void HIPPAppSearch(string appNumber, IWebDriver context, int sucessCount, string screenshotLocation, ExtentTest test, DocX doc)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);


            //Gather Data from app
            landingPage.HippApplicationSearch();
            hIPPSearch.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearch.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            utility.RecordPassStatus("Search Results", Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);

        }
    }
}
