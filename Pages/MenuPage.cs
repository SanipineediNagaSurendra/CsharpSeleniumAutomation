using DemoQA_Automation.Drivers;
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
    internal class MenuPage
    {
        private readonly ControlHelpers _controlHelpers;

        public MenuPage()
        {
            _controlHelpers = new ControlHelpers();
        }

        protected By ClickMenuTabs(string element) => By.XPath($"//a[text() = '{element}']");


        public void MouseHoverOnElement(string element)
        {
           Actions actions =  new Actions(DriverFactory._driver);

            actions.MoveToElement(_controlHelpers.FindElement(ClickMenuTabs(element)));
            actions.Perform();
        }

        public void VerifyTextIsFound(string element)
        {
          var ele =   _controlHelpers.FindElement(ClickMenuTabs(element));
            Assert.IsTrue(ele.Displayed, "Text is not displayed..");
        }
    }
}
