// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps.StartUp;
using NUnit.Tests1.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Tests1.Utilities;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace NUnit.Tests1
{
    [TestFixture]
    [Author("Bryar Cole", "Bryar.h.cole@gmail.com")]
    public class TestClassTemplate
    {
        ExtentReports extent = null;
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Testing");
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        public IWebDriver context;
        string bryar = "bryar.h.cole";
        string screenshotLocation = @"C:\\Users\\bryar.h.cole\Desktop\AutomationProvjects\NUnit.Tests1\Testing\images";

        int sucessCount = 1;
        int errorCount = 1;
        
        [Test]
        [Category("Access Data Elements")]
        public void AccessDataElements()
        {
            context = new ChromeDriver();
        }




      
    }

}
