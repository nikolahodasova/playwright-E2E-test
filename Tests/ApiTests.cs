using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using Serilog;
using PlaywrightE2ETest.Fixtures;

namespace PlaywrightE2ETest.Tests
{
    public class ApiTests : BaseTest
    {
        [Test]
        [Category("API"), Category("Smoke")]
        public async Task GetUsersTest()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("x-api-key", "reqres_02507a8ea9534af49842ec4a6cd84926");
            var request = await Playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                ExtraHTTPHeaders = headers
            });

            var response = await request.GetAsync("https://reqres.in/api/users?page=2");
            
            Log.Information("API Response Status: {Status}", response.Status);
            var body = await response.TextAsync();
            Log.Information("API Response Body: {Body}", body);

            Assert.IsTrue(response.Ok);

            Assert.IsTrue(body.Contains("data"));
        }
    }
}