using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightE2ETest.Pages;
using PlaywrightEORTest.Pages;
using System.Threading.Tasks;
using PlaywrightE2ETest.Utils;

namespace PlaywrightE2ETest.Fixtures
{
    public class BaseTest : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            loginPage = new LoginPage(Page);
            inventoryPage = new InventoryPage(Page);
            await OnBeforeTest();
        }
        protected virtual async Task OnBeforeTest()
        {
            await Task.CompletedTask;
        }
        protected async Task PerformLogin(LoginDataModel data)
        {
            await loginPage.Navigate(Config.BaseUrl);
            await loginPage.Login(data.Username!, data.Password!);
        }
        protected LoginPage loginPage;
        protected InventoryPage inventoryPage;      


        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = $"screenshot_{TestContext.CurrentContext.Test.Name}.png";

                await Page.ScreenshotAsync(new()
                {
                    Path = screenshotPath,
                    FullPage = true
                });

                TestContext.AddTestAttachment(screenshotPath);
            }
        }
    }
}
