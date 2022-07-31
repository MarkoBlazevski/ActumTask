using BoDi;
using ActumTask.Drivers;
using TechTalk.SpecFlow;

namespace ActumTask.Features.Hooks
{
    /// <summary>
    /// Share the same browser window for all scenarios
    /// This makes sequential test execution faster
    /// Note: The downside is that 
    /// - we can not run tests in paralel
    /// - we have to 'rest' the state of the browser before each scenario
    /// </summary>
    [Binding]
    public class SharedBrowserHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            // Initialize a shared BrowserDriver in the global container
            testThreadContainer.BaseContainer.Resolve<BrowserDriver>();
        }
    }
}
