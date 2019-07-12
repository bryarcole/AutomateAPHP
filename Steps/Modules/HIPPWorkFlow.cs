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
        public string HippWorkFlow(string activityReason,IWebDriver context, int sucessCount, string screenshotLocation, ExtentTest test, DocX doc)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearchpage = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);


            //Gather Data from app
            generic.GenericCheveronClick("2");
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");

            ///Pend Application
            workitem.ActivitystatusResn_Input.Click();
            workitem.ActivitystatusResn_Input.SendKeys("Denied");

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
            utility.RecordPassStatus("App in " + appQueue + "and in status of " + activityReason, Status.Pass, screenshotLocation, sucessCount, "CheckAppStaus", test, doc);
            workitem.ClickCompletedButton();
            utility.RecordPassStatus("Applciation Completed", Status.Pass, screenshotLocation, sucessCount, "Application Completed", test, doc);

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
        public void HippPendCase(string appNumber, IWebDriver context, int sucessCount, string screenshotLocation, ExtentTest test, DocX doc)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearchpage = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
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
            utility.RecordPassStatus("Search Results 2", Status.Pass, screenshotLocation, sucessCount, "SearchResults2", test, doc);
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
            utility.RecordPassStatus("Status is Pended", Status.Pass, screenshotLocation, sucessCount, "PendedStatus", test, doc);

            workitem.ClickCompletedButton();
            utility.RecordPassStatus("Case Completed", Status.Pass, screenshotLocation, sucessCount, "appcompleted", test, doc);
        }

    }
}
