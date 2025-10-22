using System;
using DemoQA_Automation.Pages;
using OpenQA.Selenium.DevTools.V136.Browser;
using Reqnroll;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class AlertsStepDefinitions
    {
        BrowserWindowPage windowPage = new BrowserWindowPage();
        AlertsPage alertsPage = new AlertsPage();
        NestedFrames nestedFrames = new NestedFrames();
        ModalWindowsPage modalWindowsPage = new ModalWindowsPage();

        [When("User selects the {string} button")]
        public void WhenUserSelectsTheButton(string p0)
        {
            windowPage.SafeClickNewTabButton(p0);
        }

        [Then("a new tab should open with message {string}")]
        public void ThenANewTabShouldOpenWithMessage(string p0)
        {
           windowPage.VerifyNewTabText(p0);
        }

      

        [When("I click on the {string} button")]
        public void WhenIClickOnTheButton(string p1)
        {
            windowPage.SafeClickNewTabButton(p1);
        }

        [Then("a new window should open with message {string}")]
        public void ThenANewWindowShouldOpenWithMessage(string p0)
        {
            windowPage.VerifyNewTabText(p0);
        }

        [Then("a message window should open with some text")]
        public void ThenAMessageWindowShouldOpenWithSomeText()
        {
            windowPage.VerifyNewWindowText();
        }

        [When("User select the Click me button based on text {string}")]
        public void WhenUserSelectTheClickMeButtonBasedOnText(string p0)
        {
            alertsPage.SafeClickAlertText(p0);
            Thread.Sleep(5000); 
        }

        [Then("User should see the text {string} in popup window")]
        public void ThenUserShouldSeeTheTextInPopupWindow(string p0)
        {
            alertsPage.verifyAlertTextBoxIsOpenedOrNot(p0);
        }

        [Then("I verify text in frame is {string}")]
        public void ThenIVerifyTextInFrameIs(string p0)
        {
            alertsPage.VerifyIframesText(p0);
        }

        [Then("I verify text in the frame is {string}")]
        public void ThenIVerifyTextInTheFrameIs(string p0)
        {
            alertsPage.VerifyIframe2Text(p0);
        }

        [When("I switch to the parent frame")]
        public void WhenISwitchToTheParentFrame()
        {
            nestedFrames.SwitchToParentFrame();
        }

        [Then("I should see {string} text")]
        public void ThenIShouldSeeText(string p0)
        {
           nestedFrames.VerifyParentFrameIsDisplayed(p0);
           
        }

        [When("I switch to the child frame")]
        public void WhenISwitchToTheChildFrame()
        {
          nestedFrames.SwitchToChildFrame();
        }

        [Then("I switch back to the main page")]
        public void ThenISwitchBackToTheMainPage()
        {
            nestedFrames.SwitchBackToMainPage();
        }

        [When("I click on {string} button")]
        public void WhenIClickOnButton(string p0)
        {
            modalWindowsPage.SafeClickSmallWindow(p0);
            Thread.Sleep(6000);
        }

        [Then("The modal title should be {string}")]
        public void ThenTheModalTitleShouldBe(string p0)
        {
            modalWindowsPage.VerifySmallWindowTitle(p0);
        }

        [Then("The modal body should contain {string}")]
        public void ThenTheModalBodyShouldContain(string p0)
        {
           modalWindowsPage.VerifySmallWindowText(p0);
        }
       
        [Then("The modal body should contains {string}")]
        public void ThenTheModalBodyShouldContains(string p0)
        {
           modalWindowsPage.VerifyWindowModalText(p0);
        }


        [When("I click on {string} button in the modal")]
        public void WhenIClickOnButtonInTheModal(string close)
        {
           modalWindowsPage.SafeClickCloseButton(close);
            Thread.Sleep(6000);
        }

        [Then("The modal window should be closed")]
        public void ThenTheModalWindowShouldBeClosed()
        {
            modalWindowsPage.VerifySmallWindowButtonDisplayedOrNot();
        }




    }
}
