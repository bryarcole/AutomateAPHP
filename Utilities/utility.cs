using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Xceed.Words.NET;

namespace NUnit.Tests1.Utilities
{
    public class Utility
    {
        IWebDriver context;
        public Utility(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);

        }

        private static Random random = new Random();
        public static bool RemoveHTMLTags(string value)
        {
            return Regex.IsMatch(value, @"</?(p|div)>");
        }
        public ExtentTest RecordPassStatus(
            string LogNote, 
            Status TestStatus, 
            string ScreenshotLocation, 
            int TestCount, 
            string TestCase, 
            ExtentTest test)
        {
            Screenshots.TakeSreenShot(context, ScreenshotLocation + TestCase + TestCount + ".png");
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).AddScreenCaptureFromPath("images\\" + TestCase + TestCount + ".png");
            return test;
        }
        public ExtentTest RecordPassStatus(
            string LogNote,
            Status TestStatus,
            string ScreenshotLocation,
            int TestCount,
            string TestCase,
            ExtentTest test,
            DocX doc)
        { 

            Screenshots.TakeSreenShot(context, ScreenshotLocation + TestCase + TestCount + ".png");
            //Extent Report
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).AddScreenCaptureFromPath("images\\" + TestCase + TestCount + ".png");

            //Document
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + TestCount + ".png");
            Picture p = img.CreatePicture();
            //Create a new paragraph  
            Paragraph par = doc.InsertParagraph(LogNote);
            p.HeightInches = 3.8;
            p.WidthInches = 6.5;
            par.AppendPicture(p);
            par.Alignment = Alignment.center;
            par.FontSize(16);
            par.AppendLine("\n");
            par.AppendLine("\n");

            return test;
        }
        public ExtentTest RecordPassStatus(
            string LogNote,
            Status TestStatus,
            string ScreenshotLocation,
            int TestCount,
            string TestCase,
            string description,
            ExtentTest test,
            DocX doc)
        {
            Screenshots.TakeSreenShot(context, ScreenshotLocation + TestCase + TestCount + ".png");
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).Log(TestStatus, description).AddScreenCaptureFromPath("images\\" + TestCase + TestCount + ".png");
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + TestCount + ".png");
            Picture p = img.CreatePicture();
            //Create a new paragraph  
            Paragraph par = doc.InsertParagraph(LogNote);
            p.HeightInches = 3.8;
            p.WidthInches = 6.5;
            par.AppendPicture(p);
            Paragraph desc = doc.InsertParagraph(description);
            par.Alignment = Alignment.center;
            par.FontSize(16);
            par.AppendLine("\n");
            par.AppendLine("\n");
            return test;
        }
        public ExtentTest RecordPassStatus(
            string LogNote,
            Status TestStatus,
            string ScreenshotLocation,
            int TestCount,
            string TestCase,
            string description,
            ExtentTest test)
        {
            Screenshots.TakeSreenShot(context, ScreenshotLocation + TestCase + TestCount + ".png");
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).Log(TestStatus, description).AddScreenCaptureFromPath(ScreenshotLocation + TestCase + TestCount + ".png");
            return test;
        }







        /// <summary>
        /// Record Status with no screenshot
        /// </summary>
        /// <param name="LogNote"></param>
        /// <param name="TestStatus"></param>
        /// <param name="TestCount"></param>
        /// <param name="TestCase"></param>
        /// <param name="description"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public ExtentTest RecordSimpleStatus(
            string LogNote,
            Status TestStatus,
            string description,
            ExtentTest test)
        {
            test.CreateNode(LogNote).Log(TestStatus, description);
            return test;
        }
        public ExtentTest RecordSimpleStatus(
            string LogNote,
            Status TestStatus,
            ExtentTest test)
        {
            test.Log(TestStatus, LogNote);
            return test;
        }

#region Random Strings Number
        public static string RandomAlphaNumericSpecialCharacterString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumericString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomOneTwoThree(int length)
        {
            const string chars = "123";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumericAndSpciaChracterString(int length)
        {
            const string chars = "0123456789!@#$%^&*()/<>.,[]}{;";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomAlphaString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomSpecialCharacterString(int length)
        {
            const string chars = "!@#$%^&*()/<>.,[]}{;'";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool IsHtmlFragment(string value)
        {
            return Regex.IsMatch(value, @"</?(p|div)>");
        }
#endregion

        /// <summary>
        /// Remove tags from a html string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveTags(string value)
        {
            if (value != null)
            {
                value = CleanHtmlComments(value);
                value = CleanHtmlBehaviour(value);
                value = Regex.Replace(value, @"</[^>]+?>", " ");
                value = Regex.Replace(value, @"<[^>]+?>", "");
                value = value.Trim();
            }
            return value;
        }

        /// <summary>
        /// Clean script and styles html tags and content
        /// </summary>
        /// <returns></returns>
        public static string CleanHtmlBehaviour(string value)
        {
            value = Regex.Replace(value, "(<style.+?</style>)|(<script.+?</script>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return value;
        }

        /// <summary>
        /// Replace the html commens (also html ifs of msword).
        /// </summary>
        public static string CleanHtmlComments(string value)
        {
            //Remove disallowed html tags.
            value = Regex.Replace(value, "<!--.+?-->", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return value;
        }

        /// <summary>
        /// Adds rel=nofollow to html anchors
        /// </summary>
        public static string HtmlLinkAddNoFollow(string value)
        {
            return Regex.Replace(value, "<a[^>]+href=\"?'?(?!#[\\w-]+)([^'\">]+)\"?'?[^>]*>(.*?)</a>", "<a href=\"$1\" rel=\"nofollow\" target=\"_blank\">$2</a>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
    }
}
