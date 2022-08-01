using ActumTask.Models;
using ActumTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;

namespace ActumTask.Pages
{
    public class SignInPage
    {
        private readonly IWebDriver _webDriver;

        public SignInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void OpenSignInUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Window.Maximize();
        }

        //Finding elements

        private IWebElement Email => _webDriver.FindElement(By.Id("email_create"));
        private IWebElement Logout => _webDriver.FindElement(By.ClassName("logout"));
        private IWebElement CreateAnAccountButton => _webDriver.FindElement(By.XPath("//*[@id='SubmitCreate']"));
        private IWebElement TitleRadioButton => _webDriver.FindElement(By.XPath("//*[@id='id_gender1']"));
        private IWebElement FirstName => _webDriver.FindElement(By.XPath("//*[@id='customer_firstname']"));
        private IWebElement LastName => _webDriver.FindElement(By.XPath("//*[@id='customer_lastname']"));
        private IWebElement Password => _webDriver.FindElement(By.XPath("//*[@id='passwd']"));
        private IWebElement Date => _webDriver.FindElement(By.XPath("//*[@id='days']/option[14]"));
        private IWebElement Month => _webDriver.FindElement(By.XPath("//*[@id='months']/option[9]"));
        private IWebElement Year => _webDriver.FindElement(By.XPath("//*[@id='years']/option[38]"));
        private IWebElement Address => _webDriver.FindElement(By.XPath("//*[@id='address1']"));
        private IWebElement City => _webDriver.FindElement(By.XPath("//*[@id='city']"));
        private IWebElement StateDropdown => _webDriver.FindElement(By.XPath("//*[@id='id_state']/option[2]"));
        private IWebElement CountryDropdown => _webDriver.FindElement(By.XPath("//*[@id='id_country']/option[2]"));
        private IWebElement Zip => _webDriver.FindElement(By.XPath("//*[@id='postcode']"));
        private IWebElement MobilePhone => _webDriver.FindElement(By.XPath("//*[@id='phone_mobile']"));
        private IWebElement RegisterButton => _webDriver.FindElement(By.XPath("//*[@id='submitAccount']"));
        private IWebElement MyAccountHeader => _webDriver.FindElement(By.XPath("//*[@id='columns']/div[1]/span[2]"));
        private IWebElement ForgotPassword => _webDriver.FindElement(By.XPath("//*[@id='login_form']/div/p[1]/a"));
        private IWebElement ForgotPasswordPage => _webDriver.FindElement(By.XPath("//*[@id='form_forgotpassword']/fieldset/p/button"));
        private IWebElement SignInButton => _webDriver.FindElement(By.XPath("//*[@id='SubmitLogin']"));
        private IWebElement SignInEmail => _webDriver.FindElement(By.XPath("//*[@id='email']"));
        private IWebElement SignInPass => _webDriver.FindElement(By.XPath("//*[@id='passwd']"));
        private IWebElement SignInError => _webDriver.FindElement(By.XPath("//*[@id='center_column']/div[1]/ol/li"));
        private IWebElement ExistingEmail => _webDriver.FindElement(By.XPath("//*[@id='create_account_error']"));

        // Actions

        public void ClickAccountButton() => CreateAnAccountButton.Click();

        public void ClickLogout() => Logout.Click();

        public void PersonalInfo()
        {
            string userDataJson = "UserData.json";
            string jsonString = File.ReadAllText(userDataJson);
            UserData? userdata = JsonSerializer.Deserialize<UserData>(jsonString)!;

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TitleRadioButton.Click();
            FirstName.SendKeys(userdata.FirstName);
            LastName.SendKeys(userdata.LastName);
            Password.SendKeys(userdata.Password);
            Date.Click();
            Month.Click();
            Year.Click();
            Address.SendKeys(userdata.Address);
            City.SendKeys(userdata.City);
            CountryDropdown.Click();
            StateDropdown.Click();
            Zip.SendKeys(userdata.Zip);
            MobilePhone.SendKeys(userdata.MobilePhone);
        }

        public void ClickRegisterButton() => RegisterButton.Click();

        public void ClickCreateAccountButton() => CreateAnAccountButton.Click();

        public void NewEmail()
        {
            Email.SendKeys(Utilities.GenerateRandomEmail());
        }

        public void EmailCredentials(string email)
        {
            Email.SendKeys(email);

        }

        public void SignInEmailCredentials(string? email = null)
        {
            SignInEmail.SendKeys(email);
        }

        public void SignInPasswordCredentials(string? password = null)
        {
            SignInPass.SendKeys(password);
        }

        public void ClickSignInButton() => SignInButton.Click();

        public void ClickForgotPasswordLink() => ForgotPassword.Click();

        // Validation

        public string AuthenticationErrorValidation()
        {
            return SignInError.Text;
        }

        public string EmailAddressErrorValidation()
        {
            return SignInError.Text;
        }

        public string EmailFormatErrorValidation()
        {
            return SignInError.Text;
        }

        public string RequiredPasswordErrorValidation()
        {
            return SignInError.Text;
        }

        public bool ForgotPassPageValidation()
        {
            return ForgotPasswordPage.Displayed;
        }
        public void ExistingEmailErrorValidation()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            IWebElement error = wait.Until(
                _webDriver => _webDriver.FindElement(
                    By.XPath("//*[@id='create_account_error']/ol/li")));
            if (error != null)
            Assert.IsNotNull(error);
            Assert.IsTrue(ExistingEmail.Displayed);
        }

        public bool MyAccountPageValidation()
        {
            return MyAccountHeader.Displayed;
        }
    }
}
