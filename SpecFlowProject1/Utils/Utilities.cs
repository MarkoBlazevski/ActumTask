using ActumTask.Models;
using System.Text.Json;

namespace ActumTask.Utils
{
    public static class Utilities
    {
        public static string GenerateRandomEmail()
        {
            return $"actum_{DateTime.Now.ToString("ddMMyyyyhhmmss")}@test.com";
        }

        public static string RandomName()
        {
            return $"Name_{DateTime.Now.ToString("ddMMyyyyhhmmss")}";
        }

        public static UserData GetUserData()
        {
            string userDataJson = "UserData.json";
            string jsonString = File.ReadAllText(userDataJson);
            return JsonSerializer.Deserialize<UserData>(jsonString)!;
        }
    }
}
