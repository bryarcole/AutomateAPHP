using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps.StartUp;
using OpenQA.Selenium;
using NUnit.Tests1.Utilities;
using System;
using System.Threading;
using System.Reflection;

namespace AutomateAPHP
{
    public class HIPPWorkFlow
    {

        /// <summary>
        /// This is the beginning workflow module. You will use this after one of the case creation modules
        /// </summary>
        /// <param name="activityReason"></param>
        /// <param name="context"></param>
        /// <param name="sucessCount"></param>
        /// <param name="screenshotLocation"></param>
        /// <param name="test"></param>
        /// <param name="doc"></param>
        public string HippWorkFlow(string activityReason,IWebDriver context, string screenshotLocation)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearchpage = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            InitiateTest startUp = new InitiateTest(context);

            //Gather Data from app
            generic.GenericCheveronClick("2");
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");

            ///Pend Application
            workitem.ActivitystatusResn_Input.Click();
            workitem.ActivitystatusResn_Input.SendKeys(activityReason);

            switch(activityReason){
                case "Approved":
                    workitem.ClickApproveButton();
                    break;
                case "Denied":
                    workitem.ClickDenyButton();
                    break;
                case "Pended":
                    workitem.ClickApproveButton();
                    break;

            }
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            generic.HoverByElement(workitem.CompletedBottom);

            string appNumber = workitem.gatherAppNumber();
            string workItem = workitem.gatherWorkItemType();
            string appQueue = workitem.gatherWorkItemStatus();
            workitem.ClickCompletedButton();
            context.Url = startUp.AWSINTWoker;

            workitem.ClickExitButton();

            try
            {
                workitem.ClickExitButton();
            }
            catch (Exception ex)
            {
                Type exType = ex.GetType();
                if (exType == typeof(TargetInvocationException) ||
                    exType == typeof(NoSuchElementException) ||
                    exType == typeof(ElementClickInterceptedException) ||
                    exType == typeof(ElementNotVisibleException) ||
                    exType == typeof(InvalidOperationException))
                {
                    //Do nothing and continue
                }
            }
            landingPage.HippApplicationSearch();
            hIPPSearchpage.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearchpage.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            generic.genericLinkTextClick(appNumber);
            if(activityReason == "Denied")
            {
                return appNumber;
            }
            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            string workItem2 = workitem.gatherWorkItemType();
            string appQueue2 = workitem.gatherWorkItemStatus();
            if (activityReason == "Pended")
            {
                HippPendCase(appNumber, context, screenshotLocation);
            }
            return appNumber;

    

        }

        /// <summary>
        /// This is a requirement to pend any case, if your case needs to be pended.
        /// Case must be available to be pended. 
        /// </summary>
        /// <param name="appNumber"></param>
        /// <param name="context"></param>
        /// <param name="sucessCount"></param>
        /// <param name="screenshotLocation"></param>
        /// <param name="test"></param>
        /// <param name="doc"></param>
        public void HippPendCase(string appNumber, IWebDriver context, string screenshotLocation)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearchpage = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            HIPPSearch hIPPSearch = new HIPPSearch();
            InitiateTest startUp = new InitiateTest(context);
            context.Url = startUp.AWSINTWoker;
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            workitem.btnActivityDone.Click();
            workitem.ClickCompletedButton();
            context.Url = startUp.AWSINTWoker;
            workitem.ClickExitButton();
            landingPage.HippApplicationSearch();
            hIPPSearchpage.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearchpage.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            generic.genericLinkTextClick(appNumber);

            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);

            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            workitem.ClickPendButton();
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            generic.HoverByElement(workitem.ActivitystatusResn);

            Thread.Sleep(2000);

            workitem.ClickCompletedButton();



        }

    }
}
