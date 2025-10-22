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
    internal class ModalWindowsPage
    {
        private readonly ControlHelpers _controlHelpers;

        public ModalWindowsPage()
        {
            _controlHelpers = new ControlHelpers();
        }


        protected By SmallWindow(string element) => By.XPath($"//button[text() = '{element}']");

        protected By CloseButton(string element) => By.XPath($"//button[text() = '{element}']");

        protected By VerifySmallWindow(string element) => By.XPath("//div[@id = 'example-modal-sizes-title-sm' or @id = 'example-modal-sizes-title-lg']");

        protected By VerifySmallWinText => By.CssSelector(".modal-body");

        protected By SmallWindowButton => By.XPath($"//button[text() = 'Small modal']");

        protected By VerifyModalText => By.XPath("//div[@class = 'modal-body']/p");


        public void SafeClickSmallWindow(string element)
        {
            _controlHelpers.SafeClick(SmallWindow(element));
        }

        public void VerifySmallWindowTitle(string element)
        {
           
          string actual =   DriverFactory._driver.FindElement(VerifySmallWindow(element)).Text;

            Assert.AreEqual(element, actual, "Text is not matched to actual text..");
        }

        public void VerifySmallWindowText(string elememt)
        {
           string actual =  DriverFactory._driver.FindElement(VerifySmallWinText).Text;
            Assert.AreEqual(elememt, actual, "TextBody should not expected..");
        }

        public void SafeClickCloseButton(string element)
        {
            _controlHelpers.SafeClick(CloseButton(element));
        }

        public void VerifySmallWindowButtonDisplayedOrNot()
        {
           var status =  _controlHelpers.FindElement(SmallWindowButton);
            Assert.IsTrue(status.Displayed, "Button is not displayed..");
        }
        public void VerifyWindowModalText(string elememt)
        {
            bool status = DriverFactory._driver.FindElement(VerifyModalText).Displayed;
            Assert.IsTrue(status, "TextBody should not expected..");
        }


    }
}
