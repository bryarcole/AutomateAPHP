using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using NUnit.Tests1;
using System.Threading;
using SeleniumExtras.PageObjects;

using NUnit.Tests1.Steps.StartUp;
using TestProject.SDK.PageObjects;
using System.Reflection;

namespace AutomateAPHP
{
    public class APHPHomePage
    {

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'Username')]")]
        public IWebElement Username;

        [FindsBy(How = How.Id, Using = "UsernameTextBox")]
        public IWebElement userName;
        [FindsBy(How = How.XPath, Using = "//input[contains(@type, 'password')]")]
        public IWebElement PasswordInputField;
        [FindsBy(How = How.XPath, Using = "//a[contains(@id, 'SubmitButton')]")]
        public IWebElement LoginButton;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PasswordText')]")]
        public IWebElement PasswordOverlay;


        public void LoginPage(string username, string password)
        {

            UserInput(username);
            PasswordInput(password);
            LoginButtonClick();
        }

        public void UserInput(string username)
        {
            //WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));

            //wait.Until(context =>
            //{
            //    try
            //    {
            Username.SendKeys(username);
            //    }
            //    catch (Exception ex)
            //    {
            //        Type exType = ex.GetType();
            //        if (exType == typeof(TargetInvocationException) ||
            //            exType == typeof(NoSuchElementException) ||
            //            exType == typeof(ElementClickInterceptedException) ||
            //            exType == typeof(ElementNotVisibleException) ||
            //            exType == typeof(InvalidOperationException))
            //        {
            //            return false; //By returning false, wait will still rerun the func.
            //        }
            //        else
            //        {
            //            throw; //Rethrow exception if it's not ignore type.
            //        }
            //    }

            //    return true;
            //});
        }

        public void PasswordInput(string password)
        {
            PasswordOverlay.Click();
            PasswordInputField.SendKeys(password);
        }
        public void LoginButtonClick()
        {
            LoginButton.Click();
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

