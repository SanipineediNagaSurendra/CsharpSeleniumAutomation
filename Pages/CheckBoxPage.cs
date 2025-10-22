using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoQA_Automation.Pages
{
    public class CheckBoxPage
    {
        private readonly ControlHelpers _controlHelpers;
        private readonly IWebDriver _driver;

        public CheckBoxPage(IWebDriver driver)
        {
            _driver = driver;
            _controlHelpers = new ControlHelpers();
        }

        protected By togglebtn(string element) => By.XPath($"//button[@title = '{element}']");
        protected By checkboxElement(string element) => By.XPath($"//span[text() ='{element}']/ancestor::label//span[contains(@class, 'checkbox')]");

        protected By toggleElement(string element) => By.XPath($"//span[text() = '{element}']/ancestor::span//button[@title = 'Toggle']");

        protected By VerifyCheckBox => By.XPath("//input[@type = 'checkbox']");

        protected By VerifyCheckBoxIsSelectedOrNot(string element) => By.XPath($"//span[text() = '{element}']/preceding-sibling::input[@type = 'checkbox']");

        protected By Label(string element) => By.XPath($"//span[@class='rct-title' and text()='{element}']");

        protected By CheckBoxIcon => By.XPath("./preceding-sibling::span[@class='rct-checkbox']");

        public void SafeToggleButtonclick(string element)
        {
            _controlHelpers.SafeClick(togglebtn(element));
        }

        public void SafeCheckBoxClick(string element)
        {
            _controlHelpers.SafeClick(checkboxElement(element));
        }
        
        public bool VerifyAllCheckBoxesAreSelected()
        {
            var elements = _controlHelpers.FindElements(VerifyCheckBox);

            foreach (var element in elements)
            {
                if(element.Selected)
                {
                    return true;
                }
               
            }
            return false;

           
        }

        public void ClickToggleElement(string element)
        {
            _controlHelpers.SafeClick(toggleElement(element));
        }

        public void VerifyCheckBoxSelectedOrNot(string element)
        {
            var partialCheckBox = _controlHelpers.FindElement(VerifyCheckBoxIsSelectedOrNot(element));

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            bool isPartiallySelected = (bool)js.ExecuteScript("return arguments[0].indeterminate;", partialCheckBox);

            // Assertion
            Assert.IsTrue(isPartiallySelected, "The Desktop checkbox is not in a partially selected state.");
        }

        public void UnCheckTheCheckBox(string element)
        {
           
            var label = DriverFactory._driver.FindElement(Label(element));

            
            var checkboxIcon = label.FindElement(CheckBoxIcon);

           
            bool isChecked = checkboxIcon.GetAttribute("class").Contains("check");

            if (isChecked)
            {
                label.Click(); 
                Console.WriteLine($"'{element}' checkbox was checked — now unchecked.");
            }
            else
            {
                Console.WriteLine($"'{element}' checkbox is already unchecked.");
            }
        }
    }
}
