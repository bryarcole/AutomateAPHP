using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps.StartUp;
using OpenQA.Selenium;
using NUnit.Tests1.Utilities;
using System;
using System.Threading;
using Xceed.Words.NET;
using System.Reflection;
using NUnit.Tests1.Pages.WorkerPortal;

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
            HIPPSubmitApplicationPageWorker submitApp = new HIPPSubmitApplicationPageWorker(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            InitiateTest startUp = new InitiateTest(context);

            //Gather Data from app
            generic.CheveronClick("2");
            generic.CheveronClick("3");
            generic.CheveronClick("4");

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
            generic.CheveronClick("3");
            generic.CheveronClick("4");
            generic.HoverByElement(workitem.CompletedBottom);


            workitem.ClickCompletedButton();
            utility.RecordStepStatusMAIN("Appliciation Completed", screenshotLocation, "Application Completed", doc);

            string appNumber = workitem.GatherAppNumber();
            string workItem = workitem.GatherWorkItemType();
            string appQueue = workitem.GetGatherWorkItemStatus();
            doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Pass 1");
            utility.RecordStepStatusMAIN("App in " + appQueue + "and in status of " + activityReason, screenshotLocation, "CheckAppStaus", doc);

            // Refresh Page
            context.Url = startUp.AWSINTWoker;

            workitem.ClickExitButton();
            landingPage.HippApplicationSearch();
            hIPPSearchpage.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearchpage.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            utility.RecordStepStatusMAIN("Search results", screenshotLocation, "SearchResults", doc);
            generic.LinkTextClick(appNumber);
            if(activityReason == "Denied")
            {
                return appNumber;
            }
            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);
            generic.CheveronClick("3");
            generic.CheveronClick("4");
            string workItem2 = workitem.GatherWorkItemType();
            string appQueue2 = workitem.GetGatherWorkItemStatus();
            doc.InsertAtBookmark("\n " + "Pass 2: " + workItem2 + "\n " + appQueue2, "Pass 2");
            if (activityReason == "Pended")
            {
                HippPendCase(appNumber, context, screenshotLocation, doc);
            }
            return appNumber;
        }
        public string HippWorkFlowRenewal(string activityReason, IWebDriver context, string screenshotLocation, DocX doc)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearchpage = new HIPPSearchPage(context);
            HIPPSubmitApplicationPageWorker submitApp = new HIPPSubmitApplicationPageWorker(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            InitiateTest startUp = new InitiateTest(context);

            //Gather Data from app
            generic.CheveronClick("2");
            generic.CheveronClick("3");
            generic.CheveronClick("4");

            ///Pend Application
            workitem.ActivitystatusResn_Input.Click();
            workitem.ActivitystatusResn_Input.SendKeys(activityReason);

            switch (activityReason)
            {
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
            generic.CheveronClick("3");
            generic.CheveronClick("4");
            generic.HoverByElement(workitem.CompletedBottom);

            string appNumber = workitem.GatherAppNumber();
            string workItem = workitem.GatherWorkItemType();
            string appQueue = workitem.GetGatherWorkItemStatus();
            doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Pass 1");
            utility.RecordStepStatusMAIN("App in " + appQueue + "and in status of " + activityReason, screenshotLocation, "CheckAppStaus", doc);
            workitem.ClickCompletedButton();
            utility.RecordStepStatusMAIN("Appliciation Completed", screenshotLocation, "Application Completed", doc);

            ///Refresh Page
            context.Url = startUp.AWSINTWoker;

            workitem.ClickExitButton();

       
            landingPage.HippApplicationSearch();
            hIPPSearchpage.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearchpage.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            utility.RecordStepStatusMAIN("Search results", screenshotLocation, "SearchResults", doc);
            generic.LinkTextClick(appNumber);
            if (activityReason == "Denied")
            {
                return appNumber;
            }
            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);
            generic.CheveronClick("3");
            generic.CheveronClick("4");
            string workItem2 = workitem.GatherWorkItemType();
            string appQueue2 = workitem.GetGatherWorkItemStatus();
            doc.InsertAtBookmark("\n " + "Pass 2: " + workItem2 + "\n " + appQueue2, "Pass 2");
            if (activityReason == "Pended")
            {
                HippPendCase(appNumber, context, screenshotLocation, doc);
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
        public void HippPendCase(string appNumber, IWebDriver context, string screenshotLocation, DocX doc)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearchpage = new HIPPSearchPage(context);
            HIPPSubmitApplicationPageWorker submitApp = new HIPPSubmitApplicationPageWorker(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);
            HIPPSearch hIPPSearch = new HIPPSearch();
            InitiateTest startUp = new InitiateTest(context);
            context.Url = startUp.AWSINTWoker;
            generic.CheveronClick("3");
            generic.CheveronClick("4");
            workitem.btnActivityDone.Click();
            workitem.ClickCompletedButton();
            context.Url = startUp.AWSINTWoker;
            workitem.ClickExitButton();
            landingPage.HippApplicationSearch();
            hIPPSearchpage.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearchpage.SearchButtonClick();
            generic.HoverByLinkText(appNumber);
            utility.RecordStepStatusMAIN("Search results", screenshotLocation, "SearchResults", doc);
            generic.LinkTextClick(appNumber);

            workitem.ClickWorkItemButton();
            Thread.Sleep(3000);

            generic.CheveronClick("3");
            generic.CheveronClick("4");
            workitem.ClickPendButton();
            generic.CheveronClick("3");
            generic.CheveronClick("4");
            generic.HoverByElement(workitem.ActivitystatusResn);

            Thread.Sleep(2000);
            utility.RecordStepStatusMAIN("Status is Pended", screenshotLocation, "PendedStatus", doc);

            workitem.ClickCompletedButton();
            utility.RecordStepStatusMAIN("Case Completed", screenshotLocation, "Case Completed", doc);



        }

    }
}
