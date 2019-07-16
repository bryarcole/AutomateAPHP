using NUnit.Tests1.Pages;
using OpenQA.Selenium;
using NUnit.Tests1.Utilities;
using TestProject.SDK.PageObjects;
namespace AutomateAPHP
{
    public class HIPPSearch
    {

        public void HIPPMemberSearch(string appNumber, IWebDriver context)
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
        public void HIPPAppSearch(string appNumber, IWebDriver context)
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

        }

        public void HIPPClickSearchResult(string appNumber)
        {

        }
    }
}
