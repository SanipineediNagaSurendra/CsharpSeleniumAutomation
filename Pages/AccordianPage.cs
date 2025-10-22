using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class AccordianPage
    {
        private readonly ControlHelpers _controlHelpers;
        private readonly WaitingHelpers waitingHelpers;
        public AccordianPage()
        {
            _controlHelpers = new ControlHelpers();
            waitingHelpers = new WaitingHelpers();
        }

        protected By SectionText(string element) => By.XPath($"//p[starts-with(text(), '{element}')]");

        protected By Section(string element) => By.XPath($"//div[text() = '{element}']");

        protected By VerifyText => By.XPath("//h1[@class = 'text-center']");

        public void VerifyAccordianText(string element)
        {
           string actual =  _controlHelpers.FindElement(VerifyText).Text;
            Assert.AreEqual(element, actual, "Text is not displayed...");    
        }

        public void SafeClickSection1(string element)
        {
            _controlHelpers.ScrollToBottom(DriverFactory._driver);
            _controlHelpers.SafeClick(Section(element));
            

        }

        public void VerifySection1Text(string text)
        {
           var status =  _controlHelpers.FindElement(SectionText(text));
            Assert.IsTrue(status.Displayed, "element is not displayed..");
        }
    }
}
