using OpenQA.Selenium;

namespace ActumTask.Pages
{
    public class ContactUsPage
    {
        private readonly IWebDriver _webDriver;

        public ContactUsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
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

        public void OpenContactUsUrl(string url) => _webDriver.Navigate().GoToUrl(url);

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

        public string SuccessMessageValidation()
        {
            return SuccessMessage.Text;
        }
        
        public string InvalidEmailAddressValidation()
        {
            return EmailErrorMessage.Text;
        }
       
        public string BlankMessageValidation()
        {
            return MessageErrorMessage.Text;
        }
 
        public string InvalidSubjectValidation()
        {
            return SubjectErrorMessage.Text;
        }

        public string HomePageValidation() 
        {
            return _webDriver.Url;
        }
    }
}
