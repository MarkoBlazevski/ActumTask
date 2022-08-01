using ActumTask.Drivers;
using ActumTask.Common;
using ActumTask.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ActumTask.StepDefinitions
{
    [Binding]
    public class SignInStepDefinitions : TestBase
    {
        private readonly SignInPage _signInPageObject;

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

        [Given(@"I type my personal information")]
        public void GivenITypeMyPersonalInformation()
        {
            _signInPageObject.PersonalInfo();
        }

        [When(@"I press Register button")]
        public void WhenIPressRegisterButton()
        {
            _signInPageObject.ClickRegisterButton();
        }

        [Then(@"My Account page is presented")]
        public void ThenMyAccountPageIsPresented()
        {
            Assert.IsTrue(_signInPageObject.MyAccountPageValidation());
            _signInPageObject.ClickLogout();
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
            Assert.IsTrue(_signInPageObject.ForgotPassPageValidation());
        }

        [When(@"I click on Sign In button")]
        public void WhenIClickOnSignInButton()
        {
            _signInPageObject.ClickSignInButton();
        }

        [Then(@"Email address is required error message is presented")]
        public void ThenEmailAddressIsRequiredErrorMessageIsPresented()
        {
            Assert.AreEqual(_signInPageObject.EmailAddressErrorValidation(), ErrorMessages.EmailRequiredError);
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
            Assert.AreEqual(_signInPageObject.EmailFormatErrorValidation(), ErrorMessages.InvalidEmail);
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
            Assert.AreEqual(_signInPageObject.AuthenticationErrorValidation(), ErrorMessages.AuthenticationError);
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
            Assert.AreEqual(_signInPageObject.RequiredPasswordErrorValidation(), ErrorMessages.PasswordRequired);
        }
    }
}
