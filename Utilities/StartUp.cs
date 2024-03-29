﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using NUnit.Tests1.Pages;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1.Utilities;
using OpenQA.Selenium.Chrome;
using TFSCommon.Common;
using TFSCommon.Data;
using Xceed.Words.NET;
using System.Drawing;
using RequirementsTraceability;

namespace NUnit.Tests1.Steps.StartUp
{
    public class InitiateTest 
    {
        IWebDriver context;
        public InitiateTest(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }
        private string AssetINT = "";
        public string AssetPTWorker = "https://10.3.36.214:44305";
        public string AssetPTMember = "https://10.3.36.214:44304";
        public string AssetPTProvider = "https://10.3.36.214:44303";
        public string AWSINTWoker = "https://10.3.29.100:44305";
        public string AWSINTMember = "https://10.3.29.100:44304";
        public string AWSINTProvider = "https://10.3.29.100:44303";
        public string DEV03 = "https://10.3.38.19:44305/WorkerDashboard.aspx";


        //private static void FireFoxStartUp(string username, string password, string url)
        //{
        //    FireFoxBrowser.Goto(url);
        //    FireFoxBrowser.Driver().Manage().Window.Maximize();
        //    APHPHomePage.User().SendKeys(username);
        //    APHPHomePage.PasswordOverlayInput().Click();
        //    APHPHomePage.PasswordEnter().SendKeys(password);
        //    APHPHomePage.LogIn().Click();
        //}
        //private static void IEStartUp(string username, string password, string url)
        //{
        //    IEBrowser.Goto(url);
        //    IEBrowser.Driver().Manage().Window.Maximize();
        //    APHPHomePage.User().SendKeys(username);
        //    APHPHomePage.PasswordOverlayInput().Click();
        //    APHPHomePage.PasswordEnter().SendKeys(password);
        //    APHPHomePage.LogIn().Click();
        //}
        //[SetUp]

        //[TearDown]
        //public static void Close()
        //{
        //    Browser.Close();
        //}

    }
}
