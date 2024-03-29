﻿// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Collections;

namespace NUnit.Tests1
{
    [TestFixture]
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class hIPPSearchTest
    {
        ExtentReports extent = null;
        string reportLocation = @"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HiPPSearch\Index.html";
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(reportLocation);
            extent.AttachReporter(htmlReporter);
            
        

        }


        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        static public IWebDriver context;
        string screenshotLocation = @"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Reports\HippSearch\images\";

        int sucessCount = 0;
        int errorCount = 0;
        //Data Set up
        static IList Where()
        {
            ArrayList list = new ArrayList();

            list.Add("Application ID");
            list.Add("Member ID");
            list.Add("Policyholder/Employee Name");
            list.Add("SSN");

            return list;
        }
        static IList How()
        {
            ArrayList list = new ArrayList();
            list.Add("Equals");
            list.Add("Contains");
            list.Add("Starts With");
            return list;
        }

        //Pages


        [Test, Category("HIPP Search"), Category("Contains Search")]
        public void TC_IT03_HIPP_Workflow_Pend_Renewal_Paper_Application()
        {

        }


    }
}
   
