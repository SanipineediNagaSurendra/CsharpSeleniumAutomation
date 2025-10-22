using DemoQA_Automation.Drivers;
using DemoQA_Automation.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace DemoQA_Automation.StepDefinitions
{
    [Binding]
    public class WebTablesStepDefinitions
    {
        WebTablePage webpage = new WebTablePage();
        TextBoxPage textBox = new TextBoxPage(DriverFactory._driver);

        [When("User navigates to the {string} section")]
        public void WhenUserNavigatesToTheSection(string webtables)
        {
            textBox.SafeClickTextBox(webtables);
        }
        [When("User click on the {string} button")]
        public void WhenUserClickOnTheButton(string add)
        {
            webpage.SafeClickAddButton(add);
            
        }


        [When("User enters {string} in the First Name field")]
        public void WhenUserEntersInTheFirstNameField(string surendra)
        {
          webpage.SafeEnterFirstName(surendra);
            
        }

        [When("User enters {string} in the Last Name field")]
        public void WhenUserEntersInTheLastNameField(string sanipineedi)
        {
           webpage.SafeEnterLastName(sanipineedi);
        }

        [When("User enters {string} in the Age field")]
        public void WhenUserEntersInTheAgeField(string no)
        {
            webpage.SafeEnterAge(no);
          
        }

        [When("User enters {string} in the Email field")]
        public void WhenUserEntersInTheEmailField(string email)
        {
            webpage.EnterEmail(email);
           
        }

        [When("User should add salary {string} in the Salary field")]
        public void WhenUserShouldAddSalaryInTheSalaryField(string p0)
        {
            webpage.EnterSalary(p0);
            Thread.Sleep(3000);
        }
        [When("User enters the {string} in the department field")]
        public void WhenUserEntersTheInTheDepartmentField(string finance)
        {
            webpage.EnterDepartment(finance);
        }

        [Then("The new record with name {string} should appear in the table")]
        public void ThenTheNewRecordWithNameShouldAppearInTheTable(string expectedName)
        {

            var rows = DriverFactory._driver.FindElements(By.XPath("//div[@class='rt-tbody']/div[@class='rt-tr-group']"));

            bool nameFound = false;

            foreach (var row in rows)
            {
                
                var firstNameCell = row.FindElement(By.XPath(".//div[@class='rt-td'][2]"));
                string actualName = firstNameCell.Text.Trim();

                if (actualName.Equals(expectedName, StringComparison.OrdinalIgnoreCase))
                {
                    nameFound = true;
                    break;
                }
            }

            Assert.IsTrue(nameFound, $"Record with name '{expectedName}' was not found in the table.");
        }

        [When("User is on the {string} page")]
        public void WhenUserIsOnThePage(string p0)
        {
           webpage.IsOnWebPage(p0);
        }

        [When("User clicks on the {string} button for the record with email {string}")]
        public void WhenUserClicksOnTheButtonForTheRecordWithEmail(string delete, string p1)
        {
            var rows = DriverFactory._driver.FindElements(By.XPath("//div[@class='rt-tbody']/div"));
            var targetRow = rows.FirstOrDefault(row => row.Text.Contains(p1));

            Assert.IsNotNull(targetRow, $"Record with email '{p1}' not found before deletion.");

            if (delete == "Delete")
            {
                var deleteButton = targetRow.FindElement(By.XPath(".//span[@title='Delete']"));
                deleteButton.Click();
            }
            else
            {
                throw new NotImplementedException($"Button '{delete}' click is not implemented.");
            }
        }

        [Then("The record with email {string} should be removed from the table")]
        public void ThenTheRecordWithEmailShouldBeRemovedFromTheTable(string p0)
        {
            WebDriverWait _wait = new WebDriverWait(DriverFactory._driver, TimeSpan.FromSeconds(3));
            bool isDeleted = _wait.Until(driver =>
        {
            var updatedRows = driver.FindElements(By.XPath("//div[@class='rt-tbody']/div"));
            return updatedRows.All(row => !row.Text.Contains(p0));
        });

        Assert.IsTrue(isDeleted, $"Record with email '{p0}' still exists after deletion.");
        }

    }
}
