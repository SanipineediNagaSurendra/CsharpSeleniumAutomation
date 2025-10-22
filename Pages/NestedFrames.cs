using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class NestedFrames
    {
        private readonly ControlHelpers _controlHelpers;

        public NestedFrames()
        {
            _controlHelpers = new ControlHelpers();
        }

        protected By VerifyFrameIsDisplayed(string element) => By.TagName("body");

        protected By SwitchToChildframe => By.TagName("iframe");

        public void SwitchToParentFrame()
        {
            
            DriverFactory._driver.SwitchTo().Frame("frame1");

        }

        public void VerifyParentFrameIsDisplayed(string element)
        {
           string actual =  _controlHelpers.FindElement(VerifyFrameIsDisplayed(element)).Text;

            Assert.AreEqual(element, actual, "Parnt frames is not dispalyed");
        }

        public void SwitchToChildFrame()
        {
            IWebElement childFrame = DriverFactory._driver.FindElement(SwitchToChildframe);
            DriverFactory._driver.SwitchTo().Frame(childFrame);
            
        }

        

        public void SwitchBackToMainPage()
        {
            DriverFactory._driver.SwitchTo().DefaultContent();
        }


    }
}
