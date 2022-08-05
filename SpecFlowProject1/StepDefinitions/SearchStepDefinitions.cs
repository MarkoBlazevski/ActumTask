using ActumTask.Common;
using ActumTask.Drivers;
using ActumTask.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ActumTask.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        private readonly HomePage _homePage;

        public SearchStepDefinitions(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
        }


        [Given(@"I am on Home Page")]
        public void GivenIAmOnHomePage()
        {
            _homePage.OpenHomeUrl(TestBase.HomePageUrl);
        }

        [Given(@"I type query into search box")]
        public void GivenITypeQueryIntoSearchBox(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _homePage.Query((string)data.Query);
        }

        [When(@"I type query into search box")]
        public void WhenITypeQueryIntoSearchBox(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _homePage.Query((string)data.Query);
        }

        [When(@"I press submit search button")]
        public void WhenIPressSubmitSearchButton()
        {
            _homePage.ClickSearchButton();
        }

        [Then(@"Results for query are presented")]
        public void ThenResultsForQueryArePresented()
        {
            _homePage.QueryValidation();
        }

        [Then(@"Please enter a search keyword warning is presented")]
        public void ThenPleaseEnterASearchKeywordWarningIsPresented()
        {
            Assert.IsTrue(_homePage.EnterASearchWarningMessageValidation());
        }

        [Then(@"Drop down search hints are presented")]
        public void ThenDropDownSearchHintsArePresented()
        {
            Assert.IsNotNull(_homePage.HintDropdownMenuValidation());
        }

        [Then(@"No results found warning is presented")]
        public void ThenNoResultsFoundWarningIsPresented()
        {
            Assert.IsTrue(_homePage.NoResultsQueryValidation());
        }
    }
}
