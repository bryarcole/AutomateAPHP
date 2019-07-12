using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Tests1;
using System.Threading;
using NUnit.Tests1.Steps.StartUp;


namespace NUnit.Tests1.Pages
{
    public class APHPHomePage
    {
        IWebDriver context;
        public APHPHomePage(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Username')]")]
        public IWebElement UserNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@type, 'password')]")]
        public IWebElement PasswordInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'SubmitButton')]")]
        public IWebElement LoginButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PasswordText')]")]
        public IWebElement PasswordOverlay { get; set; }


        public void LoginPage(string username, string password)
        {

            InitiateTest startUp = new InitiateTest(context);
            //Thread.Sleep(3000);
            context.Url = startUp.AWSINTWoker;
            context.Manage().Window.Maximize();
            UserNameInput.SendKeys(username);
            PasswordOverlay.Click();
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }
        
        public static IWebElement User(IWebDriver driver)
        {
            IWebElement UserNameInput = driver.FindElement(By.Id("UsernameTextBox"));
            return UserNameInput;
        }

        public static IWebElement PasswordOverlayInput(IWebDriver driver)
        {
            IWebElement PasswordOverlay = driver.FindElement(By.XPath("//*[@id=\"ContentPlaceHolder1_PasswordText\"]"));
            return PasswordOverlay;
        }

        public static IWebElement LogIn(IWebDriver driver)
        {
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"ContentPlaceHolder1_SubmitButton\"]"));
            return LoginButton;
        }

        public static IWebElement PasswordEnter(IWebDriver driver)
        {
            IWebElement PasswordInput = driver.FindElement(By.Id("PasswordTextBox"));
            return PasswordInput;
        }
    }
}
