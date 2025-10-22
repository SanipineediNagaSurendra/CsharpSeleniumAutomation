using System;
using DemoQA_Automation.Pages;
using Reqnroll;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class LinksStepDefinitions
    {
        LinksPage linkpage = new LinksPage();

        [When("User clicks on the {string} link")]
        public void WhenUserClicksOnTheLink(string home)
        {
            linkpage.SafeClickHomeLink(home);
        }

        [Then("A new browser tab should open with the DemoQA home page")]
        public void ThenANewBrowserTabShouldOpenWithTheDemoQAHomePage()
        {
            linkpage.VerifyNewTabIsOpendOrNot();
        }
    }
}
