// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Tests1.Pages;
using NUnit.Tests1.Steps;
using TestProject.SDK;
using TestProject.SDK.Tests.Helpers;
using TestProject.SDK.Tests;
using TestProject.SDK.PageObjects;



namespace AutomateAPHP
{

    public class MyFirstTestProjectTest : IWebTest
    {

        public ExecutionResult Execute(WebTestHelper helper)
        {

            var driver = helper.Driver;
            
            var app = new CreateHIPPApplication();

            APHPHomePage loginPage = new APHPHomePage(driver);
            driver.Url = "https://10.3.29.100:44305";
            driver.Manage().Window.Maximize();
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(driver);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(driver);


            loginPage.LoginPage("bryar.h.wrkr", "Password123");
            landingPage.HippApplicationSearch();

            return hIPPSearch.BeginNewHIPPApplication.Displayed ? ExecutionResult.Passed : ExecutionResult.Failed;

        }
    }

}
