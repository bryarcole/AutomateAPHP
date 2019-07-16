using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps;
using NUnit.Tests1.Utilities;
using NUnit.Tests1;
using TestProject.Common.Enums;
using TestProject.SDK;
using System;

namespace AutomateAPHP
{
    class Program
    {
        private static string DevToken = "22i1mFpH8PJR7MOUhf0wB856af07uNR7wHSFBrAqLcI1";
        private static AutomatedBrowserType BrowserType = AutomatedBrowserType.Chrome; // Choose different browser as needed
        static void Main(string[] args)
        {

            Console.WriteLine("Select the test you wish to run");

            Console.WriteLine("Test 1: Naviagate to search");
            Console.WriteLine("Test 2: Submit testcase");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    using (Runner runner = RunnerFactory.Instance.CreateWeb(DevToken, BrowserType))
                        runner.Run(new MyFirstTestProjectTest());
                    break;
                case "2":
                    using (Runner runner1 = RunnerFactory.Instance.CreateWeb(DevToken, BrowserType))
                        runner1.Run(new SubmitHIPPApplication());
                    break;
            }


        }
        

    }
}
