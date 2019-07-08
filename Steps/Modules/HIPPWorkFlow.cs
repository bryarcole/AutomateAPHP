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

namespace NUnit.Tests1.Steps.Modules
{
    class HIPPWorkFlow
    {


        public void ApproveHIPPApp(IWebDriver context, string screenshotLocation, DocX doc)
        {

            APHPHomePage loginPage = new APHPHomePage(context);
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(context);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(context);
            HIPPSubmitApplicationPage submitApp = new HIPPSubmitApplicationPage(context);
            WorkItemComponent workitem = new WorkItemComponent(context);
            Generic generic = new Generic(context);
            Utility utility = new Utility(context);

            generic.GenericCheveronClick("2");
            generic.GenericCheveronClick("3");
            generic.GenericCheveronClick("4");
            string appNumber = workitem.applicationNumber.Text;
            string workItem = workitem.txtWorkItemType.Text;
            string appQueue = workitem.txtQueueStatus.Text;
            Paragraph par = doc.InsertParagraph(appNumber + "\n " + workItem + "\n " + appQueue);
            doc.InsertAtBookmark(appNumber + "\n " + workItem + "\n " + appQueue, "Page");
            workitem.ActivitystatusResn_Input.Click();
            workitem.ActivitystatusResn_Input.SendKeys("Approved");
            workitem.btnActivityApprove.Click();
            Thread.Sleep(2000);

            generic.GenericCheveronClick("3");
            Thread.Sleep(2000);
            workitem.ClickCompletedButton();
            context.Navigate().Refresh();
            Thread.Sleep(2000);
            landingPage.HippApplicationSearch();
            hIPPSearch.SearchHiPPCase("Contains", "Application ID", appNumber);
            hIPPSearch.SearchButtonClick();
            Thread.Sleep(1500);
            generic.genericLinkTextClick(appNumber);
            MessageBox.Show(appNumber + "\n " + workItem + "\n " + appQueue);
        }
    }
}
