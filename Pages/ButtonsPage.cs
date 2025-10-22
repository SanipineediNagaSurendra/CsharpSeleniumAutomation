using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class ButtonsPage
    {
        private readonly ControlHelpers _controlHelpers;
        private readonly IWebDriver _driver;

        public ButtonsPage(IWebDriver driver)
        {
            _driver = driver;
            _controlHelpers = new ControlHelpers();
        }

        protected By doubleButtonlink(string element) => By.XPath($"//button[text() = '{element}']");

        protected By verifyGetText(string element) => By.XPath($"//p[text() = '{element}']");

        public void DoubleClickOnElement(string element)
        {
           var ele =  _controlHelpers.FindElement(doubleButtonlink(element));

            Actions action = new Actions(_driver);

            action.DoubleClick(ele).Perform();
            
            
        }

        public void VerifyElementIsDisplayed(string element)
        {
           var ele =  _controlHelpers.FindElement(verifyGetText(element));

            Assert.IsTrue(ele.Displayed, "element is not found..");
        }
    }
}
