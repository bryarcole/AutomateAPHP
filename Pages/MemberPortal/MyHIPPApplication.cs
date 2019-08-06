using NUnit.Tests1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace NUnit.Tests1.Pages.MemberPortal
{
    public class MyHIPPApplicationPage
    {
        IWebDriver context;

        public MyHIPPApplicationPage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }


        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'errorMessageLightBox')]")]
        private IWebElement errorMessageLightBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"ctl00_ctl00_pageContentMaster_pageContent_grdRecentApps_ctl00__0\"]/td[4]")]
        private IWebElement AppStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"ctl00_ctl00_pageContentMaster_pageContent_grdRecentApps_ctl00_ctl04_lnkColumn\"]")]
        private IWebElement AppNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'cboSelectType_Input')]")]
        private IWebElement SelectTypeInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'btnBeginApp')]")]
        private IWebElement BeginAppButton { get; set; }
        private Generic Generic
        {
            get
            {
                Generic generic = new Generic(context);
                return generic;
            }
        }

        public bool IsErrorVisible() => Generic.IsVisible(errorMessageLightBox);
        public string GetAppStatus() => Generic.GetText(AppStatus);
        public string GetAppNumber() => Generic.GetText(AppNumber);
        public IWebElement ClickAppNumber() => Generic.Click(AppNumber);

        public void InputSelectType(string text)
        {
            Generic.SendKeys(SelectTypeInput, SelectTypeInput, text);
        }
        public void BeginApplicationClick() => Generic.Click(BeginAppButton);
    }
}
