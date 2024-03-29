﻿using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Tests1.Pages;
using OpenQA.Selenium;
using System.Reflection;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace NUnit.Tests1.Utilities
{

    public class Generic
    {
        public IWebDriver context;
        public Generic(IWebDriver context)
        {
            this.context = context;
            #pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(context, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(@id, 'signoutBtn')]")]
        public static IWebElement signoutBtn { get; set; }
        public IWebElement ClickSignoutButton() => Click(signoutBtn);

        public IWebElement AccessElement(IWebElement element, IWebElement wrapper, string text)
        {
            Click(wrapper);
            Clear(element);
            SendKeys(element, text);
            return element;
        }
        public IWebElement DecisionClick(IWebElement yes, IWebElement no, string text)
        {
            switch (text)
            {
                case "Yes":
                    Click(yes);
                    return yes;
                case "No":
                    Click(no);
                    return no;
            }
            return null;

        }
        public bool IsVisible(IWebElement ele)
        {
            bool displayed = false;
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    displayed = ele.Displayed;
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(WebDriverTimeoutException) ||
                        exType == typeof(InvalidOperationException))
                    {

                        Console.Write("New exception: \n" + ex.InnerException.Message + "\n \n");

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return displayed;
        }
        public IWebElement Click(IWebElement ele)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    ele.Click();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {

                        Console.Write("New exception: \n" + ex.InnerException.Message + "\n \n");

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return ele;
        }
        public IWebElement SendKeys(IWebElement ele, IWebElement wrapper, string text)

        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    string val = ele.GetAttribute("value");
                    if (val.Equals(""))
                    {
                        Click(wrapper);
                        ele.SendKeys(text);
                    }
                    else
                    {
                        string elementText = GetText(ele);
                        VetElement(ele, wrapper, val, text);

                    }
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return ele;
        }
        public IWebElement SendKeys(IWebElement ele, string text)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    string val = ele.GetAttribute("value");

                    if (val.Equals("")) 
                    {
                        ele.SendKeys(text);
                    }
                    else
                    {
                        VetElement(ele, val, text);

                    }
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return ele;
        }
        public string GetText(IWebElement ele)
        {
            string text = "";
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    text = ele.Text;
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||

                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        //throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return text;
        }
        public IWebElement Clear(IWebElement ele)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(10));
            wait.Until(context =>
            {
                try
                {
                    ele.Clear();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return ele;
        }
        public IWebElement Click(IWebElement ele, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(context =>
            {
                try
                {
                    ele.Click();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return ele;
        }
        public IWebElement SendKeys(IWebElement ele, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(context =>
            {
                try
                {
                    ele.Clear();
                    ele.SendKeys(text);
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;

            });
            return ele;
        }
        public string GetText(IWebElement ele, int timeInSeconds)
        {
            string text = "";
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(context =>
            {
                try
                {
                    text = ele.Text;
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);

                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return text;
        }
        public IWebElement Clear(IWebElement ele, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(context =>
            {
                try
                {
                    ele.Clear();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return ele;
        }
        public IWebElement CheckBox(IWebElement ele, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(context =>
            {
                try
                {
                    ele.Click();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return ele;
        }
        #region Search Result and assigned items buttons
        /// <summary>
        /// Search Result buttons
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'btnNext')]")]
        private static IWebElement assignedItemsNext { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'btnPrev')]")]
        private static IWebElement assignedItemsPrev { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'btnLast')]")]
        private static IWebElement assignedItemsLast { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'btnFirst')]")]
        private static IWebElement assignedItemsFirst { get; set; }

        public static void searchResultNext()
        {
            assignedItemsNext.Click();
        }
        public static void searchResultPrev()
        {
            assignedItemsPrev.Click();
        }
        public void searchResultLast()
        {
            assignedItemsLast.Click();
        }
        public void searchResultFirst()
        {
            assignedItemsFirst.Click();
        }

        #endregion
        //Shout out to BV for this Idea
        #region Generic Item Hover    
        /// <summary>
        /// Generic Item Hover
        /// </summary>
        /// <param name="elementLinkText"></param>
        public Actions HoverByElement(IWebElement element)
        {
            Actions action = new Actions(context);
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(3));
            wait.Until(context =>
            {
                try
                {
                    action.MoveToElement(element).Perform();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(WebDriverTimeoutException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write("New exception: \n" + ex.Message);
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
            return action;
        }
        public Actions HoverByLinkText(string elementLinkText)
        {
            Actions action = new Actions(context);
            action.MoveToElement(context.FindElement(By.PartialLinkText(elementLinkText))).Perform();
            return action;
        }
        public Actions HoverById(string id)
        {
            Actions action = new Actions(context);
            action.MoveToElement(context.FindElement(By.Id(id))).Perform();
            return action;
        }
        public Actions HoverByClassName(string ClassName)
        {
            Actions action = new Actions(context);
            action.MoveToElement(context.FindElement(By.ClassName(ClassName))).Perform();
            return action;
        }
        #endregion
        //Yes IDs matter bruh
        public void CheveronClick(string id)
        {
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(20));
            wait.Until(context =>
            {
                try
                {
                    IWebElement element = context.FindElement(By.Id(id));
                    element.Click();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        Console.Write(ex.Message);
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }

                return true;
            });

        }
        public void LinkTextClick(string linkText)
        {


            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(5));
            wait.Until(context =>
            {
                try
                {
                    IWebElement element = context.FindElement(By.PartialLinkText(linkText));
                    element.Click();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }

                return true;
            });
        }
        public void SelectTableCell(string tableID, string row, string column)

        {

            IWebElement cell = context.FindElement(By.XPath("'//*[@id=" + tableID + "]//tr["+ row + "]//td[" + column + "]'"));
            WebDriverWait wait = new WebDriverWait(context, TimeSpan.FromSeconds(20));
            wait.Until(context =>
            {
                try
                {
                    cell.Click();
                }
                catch (Exception ex)
                {
                    Type exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(ElementClickInterceptedException) ||
                        exType == typeof(ElementNotVisibleException) ||
                        exType == typeof(InvalidOperationException))
                    {
                        return false; //By returning false, wait will still rerun the func.
                    }
                    else
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }

                return true;
            });
        }
        /// <summary>
        /// For displaying images in the report
        /// </summary>
        /// <param name="testCase"></param>
        /// <param name="testCount"></param>
        /// <returns></returns>
        static public string GenerateImageLocation(string testCase, int testCount)
        {
            string location = "images\\" + testCase + testCount + ".png";
            return location;
        }

        private void VetElement(IWebElement element,IWebElement wrapper , string elementText, string text)
        {
            switch (elementText)
            {
                case "###-###-####":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "#####-####":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "mm/dd/yyyy":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "__-_______":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "_____-____":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "User Name":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "Password":
                    Console.Write("Reached Passwrod Case");
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "__ / __ / ____":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "Select":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                case "###-##-####":
                    Click(wrapper);
                    element.SendKeys(text);
                    break;
                default:
                    Console.Write(" \nElement Text not matching cases: ");
                    Console.Write("\n" + elementText);
                    return;

            }
        }
        private void VetElement(IWebElement element, string elementText, string text)
        {
            switch (elementText)
            {
                case "###-###-####":
                    element.SendKeys(text);
                    break;
                case "#####-####":
                    element.SendKeys(text);
                    break;
                case "mm/dd/yyyy":
                    element.SendKeys(text);
                    break;
                case "__-_______":
                    element.SendKeys(text);
                    break;
                case "_____-____":
                    element.SendKeys(text);
                    break;
                case "User Name":
                    element.SendKeys(text);
                    break;
                case "Password":
                    element.SendKeys(text);
                    break;
                case "__ / __ / ____":
                    element.SendKeys(text);
                    break;
                case "Select":
                    element.SendKeys(text);
                    break;
                case "###-##-####":
                    element.SendKeys(text);
                    break;
                default:
                    Console.Write("\nElement Text not matching cases but being valued as empty: ");
                    Console.Write("\n" + elementText);
                    return;

            }
        }

    }
}
