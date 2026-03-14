using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightEORTest.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator Username => _page.Locator("#user-name");
        private ILocator Password => _page.Locator("#password");
        private ILocator LoginButton => _page.Locator("#login-button");
        public async Task Navigate(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task Login(string user, string pass)
        {
            await Username.FillAsync(user);
            await Password.FillAsync(pass);
            await LoginButton.ClickAsync();
        }
    }
}