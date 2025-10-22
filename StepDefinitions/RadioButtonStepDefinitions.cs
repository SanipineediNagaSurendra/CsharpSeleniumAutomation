using System;
using DemoQA_Automation.Pages;
using NUnit.Framework;
using Reqnroll;
using Reqnroll.Bindings.Discovery;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class RadioButtonStepDefinitions
    {
        RadioButtonPage radioPage = new RadioButtonPage();

        [When("User select the {string} RadioButton")]
        public void WhenUserSelectTheRadioButton(string yes)
        {
           radioPage.SafeClickRadioButton(yes);
            
        }

        [Then("The message {string}and {string} should be displayed")]
        public void ThenTheMessageAndShouldBeDisplayed(string element, string yes)
        {
            var ele = radioPage.VerifyTextShouldBeDisplayed(element, yes);
            Assert.IsTrue(ele, "Text is not displayed...");
        }

        [Then("The {string} radio button should be disabled and not selectable")]
        public void ThenTheRadioButtonShouldBeDisabledAndNotSelectable(string no)
        {
          var ele =  radioPage.VerifyRadioButtonIsEnabled(no);
            Assert.IsTrue(ele, "Radiobutton is enabled");
        }

    }
}
