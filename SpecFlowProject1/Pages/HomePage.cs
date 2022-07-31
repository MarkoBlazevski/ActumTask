using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ActumTask.Pages
{
    public class HomePage
    {
        private const string HomePageUrl = "http://automationpractice.com/index.php";

        private readonly IWebDriver _webDriver;


        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void OpenHomeUrl()
        {
            _webDriver.Navigate().GoToUrl(HomePageUrl);
            _webDriver.Manage().Window.Maximize();
        }

        private IWebElement SearchBox => _webDriver.FindElement(By.XPath("//*[@id='search_query_top']"));
        private IWebElement SearchButton => _webDriver.FindElement(By.XPath("//*[@id='searchbox']/button"));
        private IWebElement SearchResult => _webDriver.FindElement(By.XPath("//*[@id='center_column']/h1/span[2]"));
        private IWebElement EnterASearchWarningMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement NoResultsFoundWarningMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/p"));

        //Actions

        public void ClickSearchButton() => SearchButton.Click();

        public void Query(string query)
        {
            SearchBox.SendKeys(query);
        }

        // Validations

        public void NoResultsQueryValidation() => Assert.IsTrue(NoResultsFoundWarningMessage.Displayed);

        public void EnterASearchWarningMessageValidation() => Assert.AreEqual(
            "Please enter a search keyword", EnterASearchWarningMessage.Text);

        public void QueryValidation()
        {
            string URL = _webDriver.Url;
            StringAssert.Contains("search_query=" + SearchBox.GetAttribute("value"), URL);
            StringAssert.Contains("results have been found", SearchResult.Text);
        }

        public void HintDropdownMenuValidation()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            IWebElement dropdown = wait.Until(_webDriver => _webDriver.FindElement(By.ClassName("ac_results")));
            Assert.IsNotNull(dropdown);
        }
    }
}
