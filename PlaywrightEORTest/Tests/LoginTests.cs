using Allure.NUnit;
using NUnit.Framework;
using PlaywrightE2ETest.Fixtures;
using PlaywrightE2ETest.Pages;
using PlaywrightE2ETest.Utils;
using PlaywrightEORTest.Pages;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using Allure.Net.Commons;

namespace PlaywrightE2ETest.Tests
{
    [AllureNUnit]
    public class LoginTests : BaseTest
    {
        private static List<LoginDataModel> GetLoginTestData()
        {
            return JsonHelper.LoadLoginData();
        }
        [Test]
        [TestCaseSource (nameof(GetLoginTestData))]
        public async Task LoginTest(LoginDataModel data)
        {
            await AllureApi.Step($"Login attempt with username: {data.Username}", async () =>
             {
                 await PerformLogin(data);
                 bool isInventoryVisible = await inventoryPage.IsInventoryVisible();

                 if (data.ShouldLogin)
                 {
                     Assert.IsTrue(isInventoryVisible, "User should be logged in");
                 }
                 else
                 {
                     Assert.IsFalse(isInventoryVisible, "Login should fail");
                 }
             }
             );
        }
    }
 }