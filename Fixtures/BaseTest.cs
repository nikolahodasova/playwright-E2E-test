using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightE2ETest.Pages;
using PlaywrightEORTest.Pages;
using System.Threading.Tasks;
using PlaywrightE2ETest.Utils;
using System.IO;
using Serilog;

namespace PlaywrightE2ETest.Fixtures
{
    [TestFixture]
    [RetryOnFailure(3)]
    public class BaseTest : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Logger.Init();
            Log.Information("Starting test: " + TestContext.CurrentContext.Test.Name);
            
            loginPage = new LoginPage(Page);
            inventoryPage = new InventoryPage(Page);
            await OnBeforeTest();
        }
        protected virtual async Task OnBeforeTest()
        {
            var context = await Browser.NewContextAsync(new Microsoft.Playwright.BrowserNewContextOptions
            {
                RecordVideoDir = "videos/"
            }
            );
        }
        protected async Task PerformLogin(LoginDataModel data)
        {
            await loginPage.Navigate(ConfigReader.GetBaseUrl());
            await loginPage.Login(data.Username!, data.Password!);
        }
        protected LoginPage loginPage;
        protected InventoryPage inventoryPage;      


        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Directory.CreateDirectory("screenshots");
                var screenshotPath = Path.Combine("screenshots", $"screenshot_{TestContext.CurrentContext.Test.Name}.png");

                await Page.ScreenshotAsync(new()
                {
                    Path = screenshotPath,
                    FullPage = true
                });

                TestContext.AddTestAttachment(screenshotPath);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Log.CloseAndFlush();
        }
    }
}
