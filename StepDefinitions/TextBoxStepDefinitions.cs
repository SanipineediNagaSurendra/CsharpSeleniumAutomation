using System;
using DemoQA_Automation.Drivers;
using DemoQA_Automation.Pages;
using Reqnroll;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class TextBoxStepDefinitions
    {
        TextBoxPage textBox = new TextBoxPage(DriverFactory._driver); 

        [Given("User launches the website {string}")]
        public void GivenUserLaunchesTheWebsite(string url)
        {
           textBox.NavigateUrl(url);
        }

        [Given("User selects the {string} feature from the homepage")]
        public void GivenUserSelectsTheFeatureFromTheHomepage(string elements)
        {
            textBox.SafeClickElemetCard(elements);
            Thread.Sleep(2000);
           
        }

        [When("User selects the {string} link")]
        public void WhenUserSelectsTheLink(string link)
        {
            textBox.SafeClickTextBox(link);
            Thread.Sleep(6000);
          
        }

        [When("User enters the name {string} in the Full Name field")]
        public void WhenUserEntersTheNameInTheFullNameField(string name)
        {
            textBox.EnterText(name);
         
        }

        [When("User enters the email {string} in the Email field")]
        public void WhenUserEntersTheEmailInTheEmailField(string email)
        {
            textBox.EnterEmail(email);
            
        }

        [When("User enters a address in the Current Address field")]
        public void WhenUserEntersAAddressInTheCurrentAddressField()
        {
            textBox.currentAddress();
           
        }

        [When("User enters a address in the Permanent Address field")]
        public void WhenUserEntersAAddressInThePermanentAddressField()
        {
            textBox.permanentAddress();
            Thread.Sleep(3000);
            
        }

        [When("User clicks on the {string} button")]
        public void WhenUserClicksOnTheButton(string submit)
        {
            textBox.SubmitButton(submit);
            Thread.Sleep(3000);
           
        }

        [Then("The displayed content should match the entered values")]
        public void ThenTheDisplayedContentShouldMatchTheEnteredValues()
        {
            textBox.VerifyElementIsSame();
            Thread.Sleep(3000);
        }

        [Then("The Email field should be highlighted with a red border")]
        public void ThenTheEmailFieldShouldBeHighlightedWithARedBorder()
        {
            textBox.ThenTheEmailFieldShouldShowARedBorder();
            Thread.Sleep(3000);
        }

    }
}
