using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DemoQA_Automation.Pages
{
    internal class PraticeFormPage : WebTablePage
    {
        private readonly ControlHelpers _controlHelpers;
        RadioButtonPage ButtonPage = new RadioButtonPage();
       
        private readonly WaitingHelpers _waitingHelpers;
       
        public PraticeFormPage()
        {
            _controlHelpers = new ControlHelpers();
            _waitingHelpers = new WaitingHelpers();
        }

        protected By mobileTextBox => By.Id("userNumber");

      
        

        protected By dobTextBox => By.Id("dateOfBirthInput");

        protected By subjectFeildBox => By.Id("subjectsInput");

        protected By CurrentAddress => By.Id("currentAddress");

        protected By State => By.Id("react-select-3-input");

        protected By City => By.Id("react-select-4-input");

        protected By SubmitButton(string element) => By.XPath($"//button[contains(text() , '{element}')]");

        protected By PopUpText(string element) => By.XPath($"//div[text() = '{element}']");


        public void FillTheFormWithValidCredentials(Table table)
        {
            var row = table.Rows[0];
           
            


           string date =  row["DOB"];

           string[] parts =  date.Split(' ');

            string day = parts[0];
            string month = parts[1];
            string year =   parts[2];
            
            var  selectMonthFeildBox = By.XPath($"//select[@class = 'react-datepicker__month-select']/option[contains(text(),'{month}')]");
            var yearTextBox = By.XPath($"//select[@class = 'react-datepicker__year-select']");
            
            var dayTextBox = By.XPath($"//div[contains(@aria-label , '{month}') and text() = '{day}']");
            var HobbiesCheckBox = By.XPath($"//label[text() = '{row["Hobbies"]}']");
            


            var gender = By.XPath($"//label[normalize-space(text())='{row["Gender"]}']");
            _controlHelpers.EnterText(firstName, row["FirstName"]);
            _controlHelpers.EnterText(lastName, row["LastName"]);
            _controlHelpers.EnterText(email, row["Email"]);
            _controlHelpers.EnterText(mobileTextBox, row["Mobile"]);
            _controlHelpers.SafeClick(gender);
          
            _controlHelpers.SafeClick(dobTextBox);
            
            _controlHelpers.SafeClick(selectMonthFeildBox);
            SelectYear(year);
            _controlHelpers.SafeClick(dayTextBox);

            _controlHelpers.EnterText(CurrentAddress, row["Address"]);
            _controlHelpers.ScrollToBottom(DriverFactory._driver);

            
            var subjectBox = DriverFactory._driver.FindElement(subjectFeildBox);
            subjectBox.SendKeys(row["Subject"]);
            subjectBox.SendKeys(Keys.ArrowDown);
            subjectBox.SendKeys(Keys.Tab);

            _controlHelpers.SafeClick(HobbiesCheckBox);
            
            _controlHelpers.EnterText(State, row["State"] + Keys.ArrowDown + Keys.Tab);
            _controlHelpers.EnterText(City, row["City"] + Keys.ArrowDown + Keys.Tab);





            









        }
        public void SafeClickSubmitButton(string element)
        {
            _controlHelpers.ScrollToBottom(DriverFactory._driver);
            _controlHelpers.SafeClick(SubmitButton(element));
        }

        public void VerifyTheModalPopUpWindow(string element)
        {

            var ele = _controlHelpers.FindElement(PopUpText(element));
            string actualText = ele.Text;

            Assert.AreEqual(element, actualText,  "Text is not displayed...");

        }
        public void SelectYear(string targetYear)
        {
           
            int yearToSelect = int.Parse(targetYear);
            int currentYear = DateTime.Now.Year;

           var yearDropdown = DriverFactory._driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));

            
            SelectElement select = new SelectElement(yearDropdown);
            select.SelectByText(targetYear);

            bool found = false;
            int attempts = 0;
            int maxAttempts = 30;

            while (!found && attempts < maxAttempts)
            {
                try
                {
                    
                    var yearElement = yearDropdown.FindElement(By.XPath($".//option[text()='{yearToSelect}']"));
                    ((IJavaScriptExecutor)DriverFactory._driver).ExecuteScript("arguments[0].scrollIntoView(true);", yearElement);
                    yearElement.Click();
                    found = true;
                }
                catch (NoSuchElementException)
                {
                    // Decide scroll direction
                    if (yearToSelect < currentYear)
                    {
                        // Scroll down (past years)
                        ((IJavaScriptExecutor)DriverFactory._driver).ExecuteScript(
                            "arguments[0].scrollTop = arguments[0].scrollTop + 50;", yearDropdown);
                    }
                    else
                    {
                        // Scroll up (future years)
                        ((IJavaScriptExecutor)DriverFactory._driver).ExecuteScript(
                            "arguments[0].scrollTop = arguments[0].scrollTop - 50;", yearDropdown);
                    }
                }

                attempts++;
                Thread.Sleep(200);
            }

            
        }




    }
}
