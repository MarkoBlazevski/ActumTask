using ActumTask.Drivers;
using ActumTask.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ActumTask.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        private readonly HomePage _homePageObject;

        public SearchStepDefinitions(BrowserDriver driver)
        {
            _homePageObject = new HomePage(driver.Current);
        }


        [Given(@"I am on Home Page")]
        public void GivenIAmOnHomePage()
        {
            _homePageObject.OpenHomeUrl();
        }

        [Given(@"I type query into search box")]
        public void GivenITypeQueryIntoSearchBox(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _homePageObject.Query((string)data.Query);
        }

        [When(@"I type query into search box")]
        public void WhenITypeQueryIntoSearchBox(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _homePageObject.Query((string)data.Query);
        }

        [When(@"I press submit search button")]
        public void WhenIPressSubmitSearchButton()
        {
            _homePageObject.ClickSearchButton();
        }

        [Then(@"Results for query are presented")]
        public void ThenResultsForQueryArePresented()
        {
            _homePageObject.QueryValidation();
        }

        [Then(@"Please enter a search keyword warning is presented")]
        public void ThenPleaseEnterASearchKeywordWarningIsPresented()
        {
            _homePageObject.EnterASearchWarningMessageValidation();
        }

        [Then(@"Drop down search hints are presented")]
        public void ThenDropDownSearchHintsArePresented()
        {
            _homePageObject.HintDropdownMenuValidation();
        }

        [Then(@"No results found warning is presented")]
        public void ThenNoResultsFoundWarningIsPresented()
        {
            _homePageObject.NoResultsQueryValidation();
        }
    }
}
