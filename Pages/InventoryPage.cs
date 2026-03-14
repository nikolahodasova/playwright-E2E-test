using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightE2ETest.Pages
{
    public class InventoryPage
    {
        private readonly IPage _page;

        public InventoryPage(IPage page)
        {
            _page = page;
        }

        private ILocator ProductsTitle => _page.Locator(".title");
        private ILocator AddToCartButton => _page.Locator("#add-to-cart-sauce-labs-backpack");
        private ILocator CartIcon => _page.Locator(".shopping_cart_link");

        public async Task<bool> IsInventoryVisible()
        {
            return await ProductsTitle.IsVisibleAsync();
        }

        public async Task AddProductToCart()
        {
            await AddToCartButton.ClickAsync();
        }

        public async Task OpenCart()
        {
            await CartIcon.ClickAsync();
        }
    }
}