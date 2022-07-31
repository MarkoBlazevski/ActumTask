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
            return $"Marko_{DateTime.Now.ToString("ddMMyyyyhhmmss")}";
        }
    }
}
