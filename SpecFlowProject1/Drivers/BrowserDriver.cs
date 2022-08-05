using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ActumTask.Drivers
{
    // Manages a browser instance using Selenium

    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _disposed;

        public BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        // The Selenium IwebDriver instance
        public IWebDriver Current => _currentWebDriverLazy.Value;


        // Creates Selenium web driver (opens the browser)
        private IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            chromeDriver.Manage().Window.Maximize();

            return chromeDriver;
        }


        // Dispose the Selenium web driver (closing the browser) after Scenario is completed
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _disposed = true;
        }
    }
}
