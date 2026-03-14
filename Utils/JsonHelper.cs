using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PlaywrightE2ETest.Utils
{
    public class JsonHelper
    {
        public static List<LoginDataModel> LoadLoginData()
        {
            var json = File.ReadAllText("TestData/LoginData.json");

            var data = JsonSerializer.Deserialize<List<LoginDataModel>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return data ?? [];
        }
    }
}
