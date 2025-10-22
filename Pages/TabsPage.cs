using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Storage;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class TabsPage
    {
        private readonly ControlHelpers _controlHelpers;

        public TabsPage()
        {
            _controlHelpers = new ControlHelpers(); 
        }

        protected By ClickTabElementBtn(string element) => By.XPath($"//a[text() = '{element}']");
        
        public void VerifyTabContentShouldbeVisible(string element)
        {
            

            
            var wait = new WebDriverWait(DriverFactory._driver, TimeSpan.FromSeconds(10));

            
            var tabContent = wait.Until(d =>
                d.FindElement(By.CssSelector(".tab-content .tab-pane.active"))
            );

            string actualContent = tabContent.Text.Trim();
            Console.WriteLine($"DEBUG: Found tab content: '{actualContent}'");

            Assert.IsTrue(
                actualContent.Contains(element, StringComparison.OrdinalIgnoreCase),
                $"Expected '{element}' tab content but got '{actualContent}'"
            );

            Console.WriteLine($"'{element}' tab content is visible");
        }

        public void SafeClickTabItem(string element)
        {
            _controlHelpers.SafeClick(ClickTabElementBtn(element));
        }
    }
}
