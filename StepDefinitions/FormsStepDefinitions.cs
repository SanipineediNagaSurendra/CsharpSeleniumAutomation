using DemoQA_Automation.Drivers;
using DemoQA_Automation.Pages;
using Reqnroll;
using System;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class FormsStepDefinitions
    {
        PraticeFormPage formPage = new PraticeFormPage();
        TextBoxPage textBox = new TextBoxPage(DriverFactory._driver);


        [When("User selects the {string} feature from the homepage")]
        public void WhenUserSelectsTheFeatureFromTheHomepage(string elements)
        {
           textBox.SafeClickTextBox(elements);
        }

        [When("the user enters the form details")]
        public void WhenTheUserEntersTheFormDetails(DataTable dataTable)
        {
            formPage.FillTheFormWithValidCredentials(dataTable);
            Thread.Sleep(5000);
        }

        [When("the user {string} the form")]
        public void WhenTheUserTheForm(string submit)
        {
            formPage.SafeClickSubmitButton(submit);
            Thread.Sleep(3000);
        }


        [Then("the submitted details {string} should be displayed in the popup window")]
        public void ThenTheSubmittedDetailsShouldBeDisplayedInThePopupWindow(string p0)
        {
            formPage.VerifyTheModalPopUpWindow(p0);
            Thread.Sleep(3000);
        }



        [Then("The user {string} the form")]
        public void ThenTheUserTheForm(string close)
        {
           formPage.SafeClickSubmitButton(close);
        }

    }
}
