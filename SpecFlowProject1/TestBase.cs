using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace ActumTask
{
    public class TestBase
    {
        public static IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

        public static string HomePageUrl => Config.GetSection("Url")["HomePageUrl"];
        public static string SignInPageUrl => Config.GetSection("Url")["SignInPageUrl"];
        public static string ContactUsPageUrl => Config.GetSection("Url")["ContactUsPageUrl"];


        public static void OpenUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
    }
}
