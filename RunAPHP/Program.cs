using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps;
using NUnit.Tests1.Utilities;
using NUnit.Tests1;
using TestProject.Common.Enums;
using TestProject.SDK;

namespace AutomateAPHP
{
    class Program
    {
        private static string DevToken = "22i1mFpH8PJR7MOUhf0wB856af07uNR7wHSFBrAqLcI1";
        private static AutomatedBrowserType BrowserType = AutomatedBrowserType.Chrome; // Choose different browser as needed
        static void Main(string[] args)
        {
            HIPPWorkFlowTestProject proj = new HIPPWorkFlowTestProject();
            using (Runner runner = RunnerFactory.Instance.CreateWeb(DevToken, BrowserType))
                runner.Run(new MyFirstTestProjectTest());
            using (Runner runner1 = RunnerFactory.Instance.CreateWeb(DevToken, BrowserType))
                runner1.Run(new MyFirstTestProjectTest());
        }
        

    }
}
