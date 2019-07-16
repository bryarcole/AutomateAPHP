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

    public class SubmitHIPPApplication : IWebTest
    {

        public ExecutionResult Execute(WebTestHelper helper)
        {

            var driver = helper.Driver;
            

            APHPHomePage loginPage = new APHPHomePage(driver);
            driver.Url = "https://10.3.29.100:44305";
            driver.Manage().Window.Maximize();
            WorkerPortalLandingPage landingPage = new WorkerPortalLandingPage(driver);
            HIPPSearchPage hIPPSearch = new HIPPSearchPage(driver);
            CreateHIPPApplication app = new CreateHIPPApplication();

            loginPage.LoginPage("bryar.h.wrkr", "Password123");
            landingPage.HippApplicationSearch();
            hIPPSearch.ClickBeginNewApp();
            app.SubmitHIPPCaseSubmissionUltimate(driver, false);

            return ExecutionResult.Passed;

        }
    }

}
