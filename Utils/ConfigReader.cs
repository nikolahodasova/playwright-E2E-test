using System.IO;
using System.Text.Json;

namespace PlaywrightE2ETest.Utils
{
    public class ConfigReader
    {
        public static string GetBaseUrl()
        {
            var json = File.ReadAllText("config/appsettings.json");

            var doc = JsonDocument.Parse(json);

            return doc.RootElement.GetProperty("baseUrl").GetString() ?? string.Empty;
        }
    }
}
