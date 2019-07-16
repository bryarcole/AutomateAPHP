using OpenQA.Selenium;
using TestProject.SDK.PageObjects;

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
