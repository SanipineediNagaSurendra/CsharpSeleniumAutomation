using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation
{
    public class WaitingHelpers
    {
      private readonly IWebDriver _driver;

        
        public IWebElement WaitElementIsVisible(By Locator, int timeinseconds)
        {
            WebDriverWait _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeinseconds));
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Locator));
        }

        public IWebElement WaitElementToBeClickable(By Locator, int timeinseconds)
        {
            WebDriverWait _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeinseconds));
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Locator));
        }

        public IWebElement WaitElementExists(By Locator, int timeinseconds)
        {
            WebDriverWait _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeinseconds));
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(Locator));
        }
    }
}
