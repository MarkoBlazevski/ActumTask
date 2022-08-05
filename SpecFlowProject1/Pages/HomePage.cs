using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ActumTask.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _webDriver;


        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        private IWebElement SearchBox => _webDriver.FindElement(By.XPath("//*[@id='search_query_top']"));
        private IWebElement SearchButton => _webDriver.FindElement(By.XPath("//*[@id='searchbox']/button"));
        private IWebElement SearchResult => _webDriver.FindElement(By.XPath("//*[@id='center_column']/h1/span[2]"));
        private IWebElement EnterASearchWarningMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement NoResultsFoundWarningMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/p"));

        //Actions

        public void OpenHomeUrl(string url) => _webDriver.Navigate().GoToUrl(url);

        public void ClickSearchButton() => SearchButton.Click();

        public void Query(string query)
        {
            SearchBox.SendKeys(query);
        }

        // Validations

        public bool NoResultsQueryValidation()
        {
            return NoResultsFoundWarningMessage.Displayed;
        }

        public bool EnterASearchWarningMessageValidation()
        {
            return EnterASearchWarningMessage.Displayed;
        }

        public string QueryValidation()
        {
            return SearchResult.Text;
        }

        public IWebElement HintDropdownMenuValidation()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            IWebElement dropdown = wait.Until(_webDriver => 
                _webDriver.FindElement(By.ClassName("ac_results")));
            return dropdown;
            //Assert.IsNotNull(dropdown);
        }
    }
}
