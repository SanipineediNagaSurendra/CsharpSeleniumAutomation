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
    internal class ProgressBarPage
    {
        private readonly ControlHelpers _controlHelpers;

        public ProgressBarPage()
        {
            _controlHelpers = new ControlHelpers();
        }

        protected By StartButton(string element) => By.XPath($"//button[text() = '{element}']");

        protected By ProgressBarSuccess(string element) => By.XPath($"//div[@class = 'progress-bar bg-success' and @aria-valuenow = '{element}'");


        public void SafeClickStartOrStopButton(string element)
        {
            _controlHelpers.SafeClick(StartButton(element));
        }

        public void VerifyProgressBarReached(string element)
        {
            string expectedValue = element.Replace("%", "").Trim(); 

            WebDriverWait wait = new WebDriverWait(DriverFactory._driver, TimeSpan.FromSeconds(20));

            bool reached = wait.Until(driver =>
            {
                var progressBar = _controlHelpers.FindElement(By.CssSelector("div[role='progressbar']"));

                string ariaValue = progressBar.GetAttribute("aria-valuenow");  
                string style = progressBar.GetAttribute("style");              
                string text = progressBar.Text;                               

                return ariaValue == expectedValue || style.Contains(expectedValue + "%") || text == element;
            });

            Assert.IsTrue(reached, $"❌ Progress bar did not reach {element}");
        }
    }
}
