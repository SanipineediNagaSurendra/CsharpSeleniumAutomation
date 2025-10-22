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
    internal class LinksPage
    {
        private readonly ControlHelpers _controlHelpers;

        public LinksPage()
        {
            _controlHelpers = new ControlHelpers();
        }

        protected By homeLink(string element) => By.XPath($"//a[@id = 'simpleLink' and text() = '{element}']");


        public void SafeClickHomeLink(string element)
        {
            _controlHelpers.SafeClick(homeLink(element));
        }

        public void VerifyNewTabIsOpendOrNot()
        {
            

            
            DriverFactory._driver.SwitchTo().Window(DriverFactory._driver.WindowHandles[1]);

            
            string actualUrl = DriverFactory._driver.Url;


            Assert.IsFalse(string.IsNullOrEmpty(DriverFactory._driver.Url), "New tab did not open or has no URL.");
        }
    }
}
