using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RequirementsTraceability;
using TFSCommon.Common;
using TFSCommon.Data;
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
        public TestCase GetTestCase(int testCaseId, int suiteID)
        {
            #region Pull Test Case from TFS
            PropertiesReader config = new PropertiesReader("config.txt");

            Properties props = new Properties();
            props.PersonalAccessToken = config.get("personalaccesstoken");
            props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));
            props.Project = config.get("project");
            props.Uri = config.get("server");
            props.SaveLocation = config.get("saveLocation");
            props.FileName = StringTools.addExtension(config.get("fileName"), "xlsx"); ;
            props.ExecutionSheetName = config.get("executionsheetname");
            props.ScriptSheetName = config.get("scriptsheetname");
            props.TestPlanId = Convert.ToInt32(config.get("testplanid"));
            props.TestSuiteId = Convert.ToInt32(config.get("testsuiteid"));

            Logger logger = new Logger(props.SaveLocation);

            props.Logger = logger;

            TestCase thisTestCase = new TestCase();
            RequirementsTraceabilityJobs requirementsTraceabilityJob = new RequirementsTraceabilityJobs(props);
            thisTestCase = requirementsTraceabilityJob.GetSingleTestCase(testCaseId, suiteID);
            return thisTestCase;
        }
        #endregion
        #region Record status from Step for word doc
        /// <summary>
        /// Record Status for Word doc
        /// </summary>
        /// <param name="LogNote"></param>
        /// <param name="ScreenshotLocation"></param>
        /// <param name="TestCase"></param>
        /// <param name="doc"></param>
        public void RecordStepStatus(
            string LogNote,
            string ScreenshotLocation,
            string TestCase,
            DocX doc)
        {

            ScreenCaputres.TakeSreenShot(context, ScreenshotLocation + TestCase + ".png");
            //Document
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + ".png");
            Picture p = img.CreatePicture();
            //Create a new paragraph  
            Paragraph par = doc.InsertParagraph(LogNote);
            p.HeightInches = 3.8;
            p.WidthInches = 6.8;
            par.AppendPicture(p);
            par.Alignment = Alignment.center;
            par.FontSize(16);
            par.AppendLine("\n");
            par.AppendLine("\n");
        }
        public void RecordStepStatus(
            string LogNote,
            string Description,
            string ScreenshotLocation,
            string TestCase,
            DocX doc)
        {

            ScreenCaputres.TakeSreenShot(context, ScreenshotLocation + TestCase + ".png");
            //Document
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + ".png");
            Picture p = img.CreatePicture();
            //Create a new paragraph  
            Paragraph par = doc.InsertParagraph(LogNote);
            par.Append(Description);
            p.HeightInches = 3.8;
            p.WidthInches = 6.8;
            par.AppendPicture(p);
            par.Alignment = Alignment.center;
            par.FontSize(16);
            par.AppendLine("\n");
            par.AppendLine("\n");
        }
        #endregion
        #region RecordPass Statuses with Extent Report and Word doc
        public ExtentTest RecordPassStatusExtent(
            string LogNote,
            Status TestStatus,
            string ScreenshotLocation,
            string TestCase,
            ExtentTest test)
        {
            ScreenCaputres.TakeSreenShot(context, ScreenshotLocation + TestCase + ".png");
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).AddScreenCaptureFromPath("images\\" + TestCase + ".png");
            return test;
        }
        public ExtentTest RecordStepStatusExtent(
            string LogNote,
            Status TestStatus,
            string ScreenshotLocation,
            string TestCase,
            ExtentTest test,
            DocX doc)
        {

            ScreenCaputres.TakeSreenShot(context, ScreenshotLocation + TestCase + ".png");
            //Extent Report
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).AddScreenCaptureFromPath("images\\" + TestCase + ".png");

            //Document
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + ".png");
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
        public ExtentTest RecordStepStatusMAIN(
            string LogNote,
            Status TestStatus,
            string ScreenshotLocation,
            string TestCase,
            string description,
            DocX doc,
            ExtentTest test)
        {
            Thread.Sleep(2000);

            ScreenCaputres.TakeSreenShot(context, ScreenshotLocation + TestCase + ".png");
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).Log(TestStatus, description).AddScreenCaptureFromPath("images\\" + TestCase + ".png");
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + ".png");
            Picture p = img.CreatePicture();
            //Create a new paragraph  
            Paragraph par = doc.InsertParagraph(LogNote);
            p.HeightInches = 3.8;
            p.WidthInches = 6.8;
            par.AppendPicture(p);
            Paragraph desc = doc.InsertParagraph(description);
            par.Alignment = Alignment.center;
            par.FontSize(16);
            par.AppendLine("\n");
            par.AppendLine("\n");
            return test;
        }

        public void RecordStepStatusMAIN(
            string LogNote,
            string ScreenshotLocation,
            string TestCase,
            DocX doc
            )
        {
            Thread.Sleep(2000);
            ScreenCaputres.TakeSreenShot(context, ScreenshotLocation + TestCase + ".png");
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + ".png");
            Picture p = img.CreatePicture();
            //Create a new paragraph  
            Paragraph par = doc.InsertParagraph(LogNote);
            p.HeightInches = 3.8;
            p.WidthInches = 6.8;
            par.AppendPicture(p);
            par.Alignment = Alignment.center;
            par.FontSize(16);
            par.AppendLine("\n");
            par.AppendLine("\n");
        }
        public ExtentTest RecordPassStatus(
            string LogNote,
            string ScreenshotLocation,
            string TestCase,
            string description,
            Status TestStatus,
            ExtentTest test,
            DocX doc)
        {
            ScreenCaputres.TakeSreenShot(context, ScreenshotLocation + TestCase + ".png");
            test.Log(TestStatus, LogNote);
            test.CreateNode(LogNote).Log(TestStatus, description).AddScreenCaptureFromPath("images\\" + TestCase + ".png");
            Xceed.Words.NET.Image img = doc.AddImage(ScreenshotLocation + TestCase + ".png");
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


        #endregion




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
        public static ExtentTest RecordSimpleStatus(
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
        public string RandomAlphaNumericSpecialCharacterString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomNumericString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomOneTwoThree(int length)
        {
            const string chars = "123";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomNumericAndSpciaChracterString(int length)
        {
            const string chars = "0123456789!@#$%^&*()/<>.,[]}{;";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomAlphaString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomNumberAlphaString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ12345678912345678900";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomSpecialCharacterString(int length)
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
        #region Random Strings Number Static
        public static string RandomAlphaNumericSpecialCharacterStringStatic(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumericStringStatic(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomOneTwoThreeStatic(int length)
        {
            const string chars = "123";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumericAndSpciaChracterStringStatic(int length)
        {
            const string chars = "0123456789!@#$%^&*()/<>.,[]}{;";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomAlphaStringStatic(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomSpecialCharacterStringStatic(int length)
        {
            const string chars = "!@#$%^&*()/<>.,[]}{;'";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
        public static string CleanTestDescription(string value)
        {
            value = Regex.Replace(value, "([\\<br\\>] [\\&nbsp\\;])", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

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
        public string GetRandomFirstName()
        {
            string[] names = { "Micheal", "Lee", "Aaron", "Shannon", "David", "Lisa", "Mary", "Austin", "Sam", "John", "Thomas", "Luka", "Marie", "Carlos", "Rose", "Lily", "Chance", "Shaun", "Ryan", "Ceasar" };
            Random random = new Random();
            int i = random.Next(names.Count());
            return names[i];
        }
        public string GetRandomSurName()
        {
            string[] names = { "Micheal", "Lee", "Hammons", "Shannon", "David", "Lisa", "Mary", "Austin", "Sam", "Johnson", "Thomas", "Luka", "Marie", "Ryans", "Rose", "Lily", "Francis", "Shaun", "Gale", "Ceasar", "Malcom","Cole", "Wilson", "Brown", "Rowan", "DesMaris", "Barton", "Foster", "Vann", "Stephens", "Schiender", "Louis"};
            Random random = new Random();
            int i = random.Next(names.Count());
            return names[i];
        }
        public string GetRandomCompanyName()
        {
            string[] names = { "Microsoft", "Accenture", "Global Inc.", "WalMart", "CNN", "Target", "All World Systems", "HP", "YETI Coolers", "State Government", "Local Government", "Barton Construction Inc.", "Swytch", "GLOBAL VISSE Inc", "Arrive Logistics", "Genius Business Solutions, Inc.", "Aptive Resources", "Indio", "LUV Inc.", "All Web Leads", "Technozant", "PROLIM Corp.", "ITL Corp", "Brown", "Rowans and Company", "Thai How Are You", "Dominoes Pizza", "Thundercloud Subs", "Ironworks BBQ", "Reagan Hospital", "Shereens Garden", "Turbo Tax" };
            Random random = new Random();
            int i = random.Next(names.Count());
            return names[i];
        }
        public string GetRandomYesNo()
        {
            string[] names = { "Yes", "No" };
            Random random = new Random();
            int i = random.Next(names.Count());
            return names[i];
        }
        public string GetRandomInsuranceType()
        {
            string[] names = { "Employer Plan", "COBRA" , "Individual Policy" };
            Random random = new Random();
            int i = random.Next(names.Count());
            return names[i];
        }
        public string GetRandomCity()
        {
            string[] names = { "Richmond", "Roanoke", "Hopewell", "Virginia Beach", "Alexandria", "Norfolk", "Poquoson", "Portsmouth" };
            Random random = new Random();
            int i = random.Next(names.Count());
            return names[i];
        }
    }
}
