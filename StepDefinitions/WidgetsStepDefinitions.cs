using System;
using DemoQA_Automation.Pages;
using Reqnroll;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        AccordianPage accordianPage =  new AccordianPage();
        Auto_completePage autocompletePage = new Auto_completePage();
        DatePickerPage datePickerPage = new DatePickerPage();
        SliderPage sliderPage = new SliderPage();
        ProgressBarPage progressBarPage = new ProgressBarPage();
        TabsPage tabsPage = new TabsPage();
        MenuPage menuPage = new MenuPage();
        ToolTipsPage toolTipsPage = new ToolTipsPage();

        [Then("User should see the text of {string}")]
        public void ThenUserShouldSeeTheTextOf(string accordian)
        {
            accordianPage.VerifyAccordianText(accordian);
            Thread.Sleep(3000);
        }
        
        [When("I click on {string} header")]
        public void WhenIClickOnHeader(string p0)
        {
            accordianPage.SafeClickSection1(p0);
            Thread.Sleep(3000);
        }

        [Then("body should contain {string}")]
        public void ThenBodyShouldContain(string p0)
        {
            accordianPage.VerifySection1Text(p0);
        }
        [When("User shouls selects the multiple colours")]
        public void WhenUserShoulsSelectsTheMultipleColours(DataTable dataTable)
        {
            autocompletePage.EnterMultipleColours(dataTable);
            Thread.Sleep(5000);
        }
        [When("User selects the {string} Colour")]
        public void WhenUserSelectsTheColour(string green)
        {
            autocompletePage.EnterSingleColour(green);
        }


        [Then("{string} should be displayed in the input box")]
        public void ThenShouldBeDisplayedInTheInputBox(string green)
        {
           autocompletePage.VerifyColourIsDisplayed(green);
        }
        [When("User selects the select date input field")]
        public void WhenUserSelectsTheSelectDateInputField()
        {
            datePickerPage.SafeClickDateInputFeild();
           
        }

        [When("User should enter the date {string}")]
        public void WhenUserShouldEnterTheDate(string p0)
        {
            datePickerPage.SafeClickDateButtonFeild(p0);
            
        }

        [Then("User should verify given date {string} is displayed or not")]
        public void ThenUserShouldVerifyGivenDateIsDisplayedOrNot(string p0)
        {
            datePickerPage.VerifyGivenDateIsDisplayed(p0);
        }

        [When("User selects the Date and Time input field")]
        public void WhenUserSelectsTheDateAndTimeInputField()
        {
            datePickerPage.SafeClickDateAndTimeInputFeild();
            Thread.Sleep(4000);
        }

        [When("User should enter the date of {string} and time {string}")]
        public void WhenUserShouldEnterTheDateOfAndTime(string p0, string p1)
        {
           datePickerPage.SafeClickMonth(p0, p1);
            
        }
        
        [Then("User should verify the given date can be displayed")]
        public void ThenUserShouldVerifyTheGivenDateCanBeDisplayed()
        {
           
        }
        
        [Then("the slider value should be {string}")]
        public void ThenTheSliderValueShouldBe(string p0)
        {
            sliderPage.VerifySliderValue(p0);
            Thread.Sleep(3000);
        }
        [When("I move the slider to {string}")]
        public void WhenIMoveTheSliderTo(string p0)
        {
            sliderPage.SlideTheSliderBasedOnMinValue(p0);
           
        }
        [When("I click the {string} button")]
        public void WhenIClickTheButton(string start)
        {
           progressBarPage.SafeClickStartOrStopButton(start);
         
        }

        [Then("the progress bar should reach {string}")]
        public void ThenTheProgressBarShouldReach(string p0)
        {
            progressBarPage.VerifyProgressBarReached(p0);
            Thread.Sleep(10000);
        }
        [Then("the {string} tab content should be visible")]
        public void ThenTheTabContentShouldBeVisible(string what)
        {
            tabsPage.VerifyTabContentShouldbeVisible(what);
        }
        [When("user selects the {string} tab")]
        public void WhenUserSelectsTheTab(string origin)
        {
           tabsPage.SafeClickTabItem(origin);
           Thread.Sleep(3000);
        }

        [When("User should mouse hover the {string}")]
        public void WhenUserShouldMouseHoverThe(string p0)
        {
            menuPage.MouseHoverOnElement(p0);
            Thread.Sleep(6000);
        }

        [Then("should display {string} under given menutab")]
        public void ThenShouldDisplayUnderGivenMenutab(string p0)
        {
          menuPage.VerifyTextIsFound(p0);
        }
        [When("I hover over the {string}")]
        public void WhenIHoverOverThe(string p0)
        {
           toolTipsPage.MouseHoverOnElement(p0);
            Thread.Sleep(3000);
            
        }

        [Then("I should see a tooltip with text {string}")]
        public void ThenIShouldSeeATooltipWithText(string p0)
        {
            toolTipsPage.verifyToastMessage(p0);
            Thread.Sleep(3000);
        }

        [When("I hover over the {string} in the input feild")]
        public void WhenIHoverOverTheInTheInputFeild(string p0)
        {
          toolTipsPage.SafeClickHverMeToSeeTextBox(p0);
            Thread.Sleep(3000);
        }

        [When("I hover over the {string} link")]
        public void WhenIHoverOverTheLink(string contrary)
        {
            toolTipsPage.SafeClickContraryLink(contrary);
            Thread.Sleep(3000);
        }













    }
}
