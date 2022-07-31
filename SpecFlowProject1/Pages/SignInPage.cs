using ActumTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        //Personal info
        public void ClickAccountButton() => CreateAnAccountButton.Click();
        public void ClickLogiut() => Logout.Click();
        public void ClickRadioButton() 
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TitleRadioButton.Click();
        }
        public void FirstNameCredentials() => FirstName.SendKeys("Marko");
        public void LastNameCredentials() => LastName.SendKeys("tal"); // random
        public void PasswordCredentials() => Password.SendKeys("1234567"); // also random
        public void ChooseDate() => Date.Click(); // method for random choosing from dropdown for all dropdowns
        public void ChooseDay() => Month.Click();
        public void ChooseYear() => Year.Click();

        //Address info

        public void AddressCredentials() => Address.SendKeys("Any line"); // random
        public void CityCredentials() => City.SendKeys("New York"); // random
        public void CountryCredentials() => CountryDropdown.Click(); // first choose country
        public void ChooseState() => StateDropdown.Click();
        public void ZipNummber() => Zip.SendKeys("00000");
        public void MobileNummber() => MobilePhone.SendKeys("555555555"); // random 9 nummbers
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

        public void AuthenticationErrorValidation() => Assert.AreEqual("Authentication failed.", SignInError.Text);
        public void EmailAddressErrorValidation() => Assert.AreEqual("An email address required.", SignInError.Text);
        public void EmailFormatErrorValidation() => Assert.AreEqual("Invalid email address.", SignInError.Text);
        public void RequiredPasswordErrorValidation() => Assert.AreEqual("Password is required.", SignInError.Text);

        public void ForgotPassPageValidation() => Assert.IsTrue(ForgotPasswordPage.Displayed);
        public void ExistingEmailErrorValidation()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            IWebElement error = wait.Until(
                _webDriver => _webDriver.FindElement(
                    By.XPath("//*[@id='create_account_error']/ol/li")));
            Assert.IsNotNull(error);
            Assert.IsTrue(ExistingEmail.Displayed);
        }
        public void MyAccountPageValidation() => Assert.IsTrue(MyAccountHeader.Displayed);
    }
}
