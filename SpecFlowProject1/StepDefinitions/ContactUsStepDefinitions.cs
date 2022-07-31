using System;
using ActumTask.Drivers;
using ActumTask.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ActumTask.StepDefinitions
{
    [Binding]
    public class ContactUsStepDefinitions
    {
        private readonly ContactUsPage _contactUsPageObject;
        private const string ContactUsUrl = "http://automationpractice.com/index.php?controller=contact";


        public ContactUsStepDefinitions(BrowserDriver driver)
        {
            _contactUsPageObject = new ContactUsPage(driver.Current);
        }

        [Given(@"I am on Contact Us page")]
        public void GivenIAmOnContactUsPage()
        {
            _contactUsPageObject.OpenContactUsUrl(ContactUsUrl);
        }

        [Given(@"I choose Customer Service from Subject Heading")]
        public void GivenIChooseCustomerServiceFromSubjectHeading()
        {
            _contactUsPageObject.SelectDropDownCustomerService();
        }

        [Given(@"I enter following details")]
        public void GivenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _contactUsPageObject.Credentials((string)data.Email, (int)data.OrderReference, (string)data.Message);
        }

        [When(@"I click on Send button")]
        public void WhenIClickOnSendButton()
        {
            _contactUsPageObject.ClickSendButton();
        }

        [Then(@"Success message is presented")]
        public void ThenSuccessMessageIsPresented()
        {
            _contactUsPageObject.SuccessMessageValidation();
        }

        [Given(@"I choose Webmaster from Subject Heading")]
        public void GivenIChooseWebmasterFromSubjectHeading()
        {
            _contactUsPageObject.SelectDropdownWebmaster();
        }

        [Then(@"Invalid email address Error message is presented")]
        public void ThenErrorMessageIsPresented()
        {
            _contactUsPageObject.InvalidEmailAddressValidation();
        }

        [Given(@"I do NOT choose any option from Subject Heading")]
        public void GivenIDoNOTChooseAnyOptionFromSubjectHeading()
        {
            _contactUsPageObject.ClickSendButton();
        }

        [When(@"I click on Home button")]
        public void WhenIClickOnHomeButton()
        {
            _contactUsPageObject.ClickHomePageButton();
        }

        [Then(@"Home page is presented")]
        public void ThenHomePageIsPresented()
        {
            _contactUsPageObject.HomePageValidation();
        }

        [Then(@"The message can not be blank Error message is presented")]
        public void ThenBlankErrorMessageIsPresented()
        {
            _contactUsPageObject.InvalidMessageValidation();
        }

        [Then(@"Please select a subject from the list provided Error message is presented")]
        public void ThenSelectSubjectErrorMessageIsPresented()
        {
            _contactUsPageObject.InvalidSubjectValidation();
        }
    }
}
