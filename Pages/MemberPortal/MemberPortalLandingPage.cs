using NUnit.Tests1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
namespace NUnit.Tests1.Pages.MemberPortal
{
    public class MemberPortalDashBoard
    {
        public IWebDriver context;
        public MemberPortalDashBoard(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }
        private Generic Generic
        {
            get
            {
                Generic generic = new Generic(context);
                return generic;
            }
        }
        [FindsBy(How = How.PartialLinkText, Using = "My Claims")]
        public IWebElement myClaims { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "Find a Provider")]
        public IWebElement FindAProvider { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "My Dashboard")]
        public IWebElement myDashboard { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "HIPP Application")]
        public IWebElement HiPPApplicationLinkText { get; set; }
        [FindsBy(How  = How.PartialLinkText, Using = "My HIPP Application")]
        private IWebElement MyHIPPApplication { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "HIPP Employee Insurance Verification")]
        private IWebElement HIPPEIV { get; set; }


        public void HIPPMyApplication()
        {
            HiPPApplicationHover();
            Generic.Click(MyHIPPApplication);
        }
        public void HIPPEIVData()
        {
            HiPPApplicationHover();
            Generic.Click(HIPPEIV);
        }
        public void HiPPApplicationHover()
        {
            Actions action = new Actions(context);
            action.MoveToElement(HiPPApplicationLinkText).Perform();
        }
    }
}
