using System;
using DemoQA_Automation.Drivers;
using DemoQA_Automation.Pages;
using Reqnroll;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class ButtonsStepDefinitions
    {
        ButtonsPage btnpage = new ButtonsPage(DriverFactory._driver);

        [When("user double click on the {string} button")]
        public void WhenUserDoubleClickOnTheButton(string doubleclkbtn)
        {
            btnpage.DoubleClickOnElement(doubleclkbtn);
        }

        [Then("verify the message {string} should be displayed")]
        public void ThenVerifyTheMessageShouldBeDisplayed(string message)
        {
            btnpage.VerifyElementIsDisplayed(message);
        }
    }
}
