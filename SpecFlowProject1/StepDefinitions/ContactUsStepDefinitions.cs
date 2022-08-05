using ActumTask.Common;
using ActumTask.Drivers;
using ActumTask.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ActumTask.StepDefinitions
{
    [Binding]
    public class ContactUsStepDefinitions : TestBase
    {
        private readonly ContactUsPage _contactUsPage;

        public ContactUsStepDefinitions(BrowserDriver driver)
        {
            _contactUsPage = new ContactUsPage(driver.Current);
        }

        [Given(@"I am on Contact Us page")]
        public void GivenIAmOnContactUsPage()
        {
            _contactUsPage.OpenContactUsUrl(ContactUsPageUrl);
        }

        [Given(@"I choose Customer Service from Subject Heading")]
        public void GivenIChooseCustomerServiceFromSubjectHeading()
        {
            _contactUsPage.SelectDropDownCustomerService();
        }

        [Given(@"I enter following details")]
        public void GivenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _contactUsPage.Credentials((string)data.Email, (int)data.OrderReference, (string)data.Message);
        }

        [When(@"I click on Send button")]
        public void WhenIClickOnSendButton()
        {
            _contactUsPage.ClickSendButton();
        }

        [Then(@"Success message is presented")]
        public void ThenSuccessMessageIsPresented()
        {
            Assert.AreEqual(ErrorMessages.MessageSuccessfulySentMessage, _contactUsPage.SuccessMessageValidation());
        }

        [Given(@"I choose Webmaster from Subject Heading")]
        public void GivenIChooseWebmasterFromSubjectHeading()
        {
            _contactUsPage.SelectDropdownWebmaster();
        }

        [Then(@"Invalid email address Error message is presented")]
        public void ThenErrorMessageIsPresented()
        {
            Assert.AreEqual(ErrorMessages.InvalidEmail, _contactUsPage.InvalidEmailAddressValidation());
        }

        [Given(@"I do NOT choose any option from Subject Heading")]
        public void GivenIDoNOTChooseAnyOptionFromSubjectHeading()
        {
            _contactUsPage.ClickSendButton();
        }

        [When(@"I click on Home button")]
        public void WhenIClickOnHomeButton()
        {
            _contactUsPage.ClickHomePageButton();
        }

        [Then(@"Home page is presented")]
        public void ThenHomePageIsPresented()
        {
            Assert.AreEqual(HomePageUrl, _contactUsPage.HomePageValidation());
        }

        [Then(@"The message can not be blank Error message is presented")]
        public void ThenBlankErrorMessageIsPresented()
        {
            Assert.AreEqual(ErrorMessages.BlankMessageError, _contactUsPage.BlankMessageValidation());
        }

        [Then(@"Please select a subject from the list provided Error message is presented")]
        public void ThenSelectSubjectErrorMessageIsPresented()
        {
            Assert.AreEqual(ErrorMessages.SelectSubjectError, _contactUsPage.InvalidSubjectValidation());
        }
    }
}
