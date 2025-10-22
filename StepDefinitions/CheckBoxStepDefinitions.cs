using DemoQA_Automation.Drivers;
using DemoQA_Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Page;
using Reqnroll;
using System;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class CheckBoxStepDefinitions
    {
        CheckBoxPage checkbox = new CheckBoxPage(DriverFactory._driver);
           
        
       
        [When("User expands the {string} node")]
        public void WhenUserExpandsTheNode(string toggle)
        {
            checkbox.SafeToggleButtonclick(toggle);
            Thread.Sleep(3000);
           
        }
        [When("User expandes the {string} node")]
        public void WhenUserExpandesTheNode(string desktop)
        {
           checkbox.ClickToggleElement(desktop);
            Thread.Sleep(3000);
        }


        [When("User selects the {string} checkbox")]
        public void WhenUserSelectsTheCheckbox(string home)
        {
            checkbox.SafeCheckBoxClick(home);
            Thread.Sleep(4000);
        }

        [When("User selects all checkboxes under {string}")]
        public void WhenUserSelectsAllCheckboxesUnder(string documents)
        {
            checkbox.SafeCheckBoxClick(documents);
            Thread.Sleep(3000);
        }

        [When("User unchecks the {string} checkbox")]
        public void WhenUserUnchecksTheCheckbox(string office)
        {
           checkbox.UnCheckTheCheckBox(office);
            Thread.Sleep(3000);
        }
        
        [Then("All child checkboxes should be selected")]
        public void ThenAllChildCheckboxesShouldBeSelected()
        {
           bool ele = checkbox.VerifyAllCheckBoxesAreSelected();

            Assert.IsTrue(ele, "checkboxes are not selected");
        }

        [Then("The {string} checkbox should be in a partially selected state")]
        public void ThenTheCheckboxShouldBeInAPartiallySelectedState(string desktop)
        {
            checkbox.VerifyCheckBoxSelectedOrNot(desktop);
        }
        

    }
}
