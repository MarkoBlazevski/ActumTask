using ActumTask.Drivers;
using ActumTask.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ActumTask.StepDefinitions
{
    [Binding]
    public class SignInStepDefinitions
    {
        private readonly SignInPage _signInPageObject;

        private const string SignInPageUrl = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

        public SignInStepDefinitions(BrowserDriver driver)
        {
            _signInPageObject = new SignInPage(driver.Current);
        }

        [Given(@"I am on Sign In page")]
        public void GivenIAmOnSignInPage()
        {
            _signInPageObject.OpenSignInUrl(SignInPageUrl);
        }

        [Given(@"I create an account with following details")]
        public void GivenICreateAnAccountWithFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _signInPageObject.EmailCredentials((string)data.Email);
        }

        [Given(@"I create new account with following details")]
        public void GivenICreateNewAccountWithFollowingDetails()
        {
            _signInPageObject.NewEmail();
        }

        [Given(@"I click Create an Account button")]
        public void GivenIClickCreateAnAccountButton()
        {
            _signInPageObject.ClickAccountButton();
        }

        [Given(@"I Fill my personal information")]
        public void GivenIFillMyPersonalInformation()
        {
            _signInPageObject.ClickRadioButton();
            _signInPageObject.FirstNameCredentials();
            _signInPageObject.LastNameCredentials();
            _signInPageObject.PasswordCredentials();
            _signInPageObject.ChooseDate();
            _signInPageObject.ChooseDay();
            _signInPageObject.ChooseYear();
        }

        [Given(@"I Fill my address information")]
        public void GivenIFillMyAddressInformation()
        {
            _signInPageObject.AddressCredentials();
            _signInPageObject.CityCredentials();
            _signInPageObject.CountryCredentials();
            _signInPageObject.ChooseState();
            _signInPageObject.ZipNummber();
            _signInPageObject.MobileNummber();
        }

        [When(@"I press Register button")]
        public void WhenIPressRegisterButton()
        {
            _signInPageObject.ClickRegisterButton();
        }

        [Then(@"My Account page is presented")]
        public void ThenMyAccountPageIsPresented()
        {
            _signInPageObject.MyAccountPageValidation();
            _signInPageObject.ClickLogiut();
        }

        [When(@"I click Create an Account button")]
        public void WhenIClickCreateAnAccountButton()
        {
            _signInPageObject.ClickCreateAccountButton();
        }

        [Then(@"Valid error message is presented")]
        public void ThenValidErrorMessageIsPresented()
        {
            _signInPageObject.ExistingEmailErrorValidation();
        }

        [When(@"I click on Forgot your password link")]
        public void WhenIClickOnForgotYourPasswordLink()
        {
            _signInPageObject.ClickForgotPasswordLink();
        }

        [Then(@"Forgot your password page is presented")]
        public void ThenForgotYourPasswordPageIsPresented()
        {
            _signInPageObject.ForgotPassPageValidation();
        }

        [When(@"I click on Sign In button")]
        public void WhenIClickOnSignInButton()
        {
            _signInPageObject.ClickSignInButton();
        }

        [Then(@"Email address is required error message is presented")]
        public void ThenEmailAddressIsRequiredErrorMessageIsPresented()
        {
            _signInPageObject.EmailAddressErrorValidation();
        }

        [When(@"I type invalid email")]
        public void WhenITypeInvalidEmail(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _signInPageObject.SignInEmailCredentials((string)data.Email);
        }

        [Then(@"Invalid email address error message is presented")]
        public void ThenInvalidEmailAddressErrorMessageIsPresented()
        {
            _signInPageObject.EmailFormatErrorValidation();
        }

        [Given(@"I type valid email")]
        public void GivenITypeValidEmail(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _signInPageObject.SignInEmailCredentials((string)data.Email);
        }

        [Given(@"I type in invalid password")]
        public void GivenITypeInInvalidPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _signInPageObject.SignInPasswordCredentials((string)data.Password);
        }

        [Then(@"Authentcation error message is presented")]
        public void ThenAuthentcationErrorMessageIsPresented()
        {
            _signInPageObject.AuthenticationErrorValidation();
        }

        [Given(@"I type invalid email format")]
        public void GivenIYypeInvalidEmailFormat(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _signInPageObject.SignInEmailCredentials((string)data.Email);
        }

        [Then(@"Invalid password error message is presented")]
        public void ThenInvalidPasswordMessageIsPresented()
        {
            _signInPageObject.RequiredPasswordErrorValidation();
        }
    }
}
