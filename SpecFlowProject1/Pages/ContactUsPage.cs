using NUnit.Framework;
using OpenQA.Selenium;

namespace ActumTask.Pages
{
    public class ContactUsPage
    {
        private const string HomePageUrl = "http://automationpractice.com/index.php";

        private readonly IWebDriver _webDriver;

        public ContactUsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void OpenContactUsUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Window.Maximize();
        }

        //Finding elements

        private IWebElement DropDownCustomerService => _webDriver.FindElement(By.XPath("//*[@id='id_contact']/option[2]"));
        private IWebElement DropDownWebmaster => _webDriver.FindElement(By.XPath("//*[@id='id_contact']/option[3]"));
        private IWebElement EmailAddress => _webDriver.FindElement(By.Id("email"));
        private IWebElement OrderReference => _webDriver.FindElement(By.Id("id_order"));
        private IWebElement Message => _webDriver.FindElement(By.Id("message"));
        private IWebElement SendButton => _webDriver.FindElement(By.XPath("//*[@id='submitMessage']/span"));
        private IWebElement SuccessMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement EmailErrorMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement SubjectErrorMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement MessageErrorMessage => _webDriver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement HomePageButton => _webDriver.FindElement(By.XPath("//*[@id='columns']/div[1]/a"));


        //Actions

        public void SelectDropDownCustomerService() => DropDownCustomerService.Click();

        public void SelectDropdownWebmaster() => DropDownWebmaster.Click();

        public void ClickSendButton() => SendButton.Click();
        public void ClickHomePageButton() => HomePageButton.Click();

        public void Credentials(string email, int orderReference, string? message = null)
        {
            EmailAddress.SendKeys(email);
            OrderReference.SendKeys(orderReference.ToString());
            Message.SendKeys(message);
        }
        
        //Validations

        public void SuccessMessageValidation() => Assert.AreEqual(
            "Your message has been successfully sent to our team.", SuccessMessage.Text);
        public void InvalidEmailAddressValidation() => Assert.AreEqual(
            "Invalid email address.", EmailErrorMessage.Text);
        public void InvalidMessageValidation() => Assert.AreEqual(
            "The message cannot be blank.", MessageErrorMessage.Text);
        public void InvalidSubjectValidation() => Assert.AreEqual(
            "Please select a subject from the list provided.", SubjectErrorMessage.Text);

        public void HomePageValidation() 
        {
            string URL = _webDriver.Url;
            Assert.AreEqual(HomePageUrl, URL);
        }
    }
}
