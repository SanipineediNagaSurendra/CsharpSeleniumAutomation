using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class BrowserWindowPage
    {
        private readonly ControlHelpers _controlHelpers;

        public BrowserWindowPage()
        {
            _controlHelpers = new ControlHelpers();
        }

        protected By NewTabButton(string element) => By.XPath($"//button[text() = '{element}']");

        protected By NewWindowPage => By.TagName("body");

        protected By VerifyText => By.Id("sampleHeading");

        public void SafeClickNewTabButton(string element)
        {
           _controlHelpers.SafeClick(NewTabButton(element));
        }

        public void VerifyNewTabText(string element)
        {
            var allWindows = DriverFactory._driver.WindowHandles;
            string currentTab = DriverFactory._driver.CurrentWindowHandle;
            DriverFactory._driver.SwitchTo().Window(allWindows.Last());
           string actualText =  _controlHelpers.FindElement(VerifyText).Text;

            Assert.AreEqual(actualText, element, "Text is not matched...");
        }

        public void VerifyNewWindowText()
        {
            var allwindows = DriverFactory._driver.WindowHandles;
            string parentWindow = DriverFactory._driver.CurrentWindowHandle;
            //DriverFactory._driver.SwitchTo().Window(allwindows.Last());
            //string ele = _controlHelpers.FindElement(NewWindowPage).Text;
            //Assert.IsFalse(string.IsNullOrWhiteSpace(ele) , "element is not opened in new window page...");

            DriverFactory._driver.FindElement(By.Id("messageWindowButton")).Click();

            // Wait until new window appears
            new WebDriverWait(DriverFactory._driver, TimeSpan.FromSeconds(5))
                .Until(d => d.WindowHandles.Count > 1);

            // Switch to new window
            string newWindow = DriverFactory._driver.WindowHandles.First(h => h != parentWindow);
            DriverFactory._driver.SwitchTo().Window(newWindow);

            // ✅ Get the raw page source text (works because it’s plain text, not HTML)
            string message = DriverFactory._driver.PageSource;

            Console.WriteLine(message);
        }
    }
}
