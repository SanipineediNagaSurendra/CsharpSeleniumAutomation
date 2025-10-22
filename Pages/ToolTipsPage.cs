using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class ToolTipsPage
    {
        private readonly ControlHelpers _controlHelpers;
        private readonly WaitingHelpers waitingHelpers;
        

        public ToolTipsPage()
        {
            _controlHelpers = new ControlHelpers();
             waitingHelpers = new WaitingHelpers();
        }

        protected By BtnHoverText(string element) => By.XPath($"//button[text() = '{element}']");

        protected By ToolTipInnerMessage(string element) => By.XPath($"//div[text() = '{element}']");

        protected By HoverMeToSeeTextField(string element) => By.XPath("//input[@id = 'toolTipTextField']");

        protected By ContraryLink(string element) => By.XPath($"//a[text() = '{element}']");

        public void MouseHoverOnElement(string element)
        {
            Actions actions = new Actions(DriverFactory._driver);
             

            actions.MoveToElement(_controlHelpers.FindElement(BtnHoverText(element)));
            actions.Perform();
        }

        public void verifyToastMessage(string element)
        {
            var ele = _controlHelpers.FindElement(ToolTipInnerMessage(element));
            Assert.IsTrue(ele.Displayed, "Instruction message is not dispalyed..");
            
        }


        public void SafeClickHverMeToSeeTextBox(string element)
        {
            Actions actions = new Actions(DriverFactory._driver);

            actions.MoveToElement(_controlHelpers.FindElement(HoverMeToSeeTextField(element)));
            actions.Perform();
        }

        public void SafeClickContraryLink(string element)
        {
            Actions actions = new Actions(DriverFactory._driver);

            actions.MoveToElement(_controlHelpers.FindElement(ContraryLink(element)));
            actions.Perform();
        }
    }
}
