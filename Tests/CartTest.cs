using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightE2ETest.Fixtures;
using PlaywrightE2ETest.Pages;
using PlaywrightE2ETest.Utils;
using PlaywrightEORTest.Pages;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PlaywrightE2ETest.Tests
{
    [AllureNUnit]
    public class CartTest : BaseTest
    {
        protected override async Task OnBeforeTest()
        {
            await PerformLogin(new LoginDataModel
            {
                Username = "standard_user",
                Password = "secret_sauce",
            });
        }
            [Test]
        [AllureStep("Add product to cart")]
        public async Task AddProductToCartTest()
        {
            Assert.IsTrue(await inventoryPage.IsInventoryVisible());

            await inventoryPage.AddProductToCart();
            await inventoryPage.OpenCart();
        }
    }
}