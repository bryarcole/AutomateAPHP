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
        public string HippWorkFlow(string activityReason,IWebDriver context, string screenshotLocation, DocX doc)
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
            doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Results of pass: ");
            utility.RecordStepStatusMAIN("App in " + appQueue + "and in status of " + activityReason, screenshotLocation, "CheckAppStaus", doc);
            workitem.ClickCompletedButton();
            utility.RecordStepStatusMAIN("Appliciation Completed", screenshotLocation, "Application Completed", doc);
            context.Url = startUp.AWSINTWoker;

            landingPage.HippApplicationSearch();
            hIPPSearchpage.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearchpage.SearchButtonClick();
            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            string workItem2 = workitem.gatherWorkItemType();
            string appQueue2 = workitem.gatherWorkItemStatus();
            doc.InsertAtBookmark("\n " + "Pass 2: " + workItem2 + "\n " + appQueue2, "Pass 2");

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
        public void HippPendCase(string appNumber, IWebDriver context, string screenshotLocation, DocX doc)
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
            utility.RecordStepStatusMAIN("Search results", screenshotLocation, "SearchResults", doc);
            generic.genericLinkTextClick(appNumber);
            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            string workItem2 = workitem.gatherWorkItemType();
            string appQueue2 = workitem.gatherWorkItemStatus();
            doc.InsertAtBookmark("\n " + "Pass 2: " + workItem2 + "\n " + appQueue2, "Pass 2");

            workitem.ActivitystatusResn_Input.SendKeys("Pend");

            workitem.ClickPendButton();
            Thread.Sleep(3000);
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            generic.HoverByElement(workitem.ActivitystatusResn);
            utility.RecordStepStatusMAIN("Status is Pended", screenshotLocation, "PendedStatus", doc);

            workitem.ClickCompletedButton();
            utility.RecordStepStatusMAIN("Case Completed", screenshotLocation, "Case Completed", doc);
        }

    }
}
