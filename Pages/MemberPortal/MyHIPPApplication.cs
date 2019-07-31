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

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, cboSelectType_Input)]")]
        private IWebElement SelectTypeInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, btnBeginApp)]")]
        private IWebElement BeginAppButton { get; set; }
        private Generic Generic
        {
            get
            {
                Generic generic = new Generic(context);
                return generic;
            }
        }
        public void InputSelectType(string text)
        {
            Generic.Click(SelectTypeInput);
            Generic.SendKeys(SelectTypeInput, text);
        }
        public void BeginApplicationClick() => Generic.Click(BeginAppButton);
    }
}
