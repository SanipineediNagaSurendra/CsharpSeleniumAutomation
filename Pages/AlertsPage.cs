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
    internal class AlertsPage
    {
        private readonly ControlHelpers _controlHelpers;

        public AlertsPage()
        {
            _controlHelpers = new ControlHelpers();
        }


        protected By AlertText(string element) => By.Id(element);

        protected By SampleHeading => By.Id("sampleHeading");

        public void SafeClickAlertText(string element)
        {


            _controlHelpers.SafeClick(AlertText(element));
           
            
        }

        public void verifyAlertTextBoxIsOpenedOrNot(string element)
        {
            IAlert alert = DriverFactory._driver.SwitchTo().Alert();

            string text = alert.Text;

            Assert.IsFalse(string.IsNullOrEmpty(text), "alert textt box is empty...");

            Assert.AreEqual(element, text, "alert text box is not  equal..");

            alert.Accept();
        }

        public void VerifyIframesText(string element)
        {
            DriverFactory._driver.SwitchTo().Frame("frame1");
            
            string text = DriverFactory._driver.FindElement(SampleHeading).Text;
            Console.WriteLine(text);
            DriverFactory._driver.SwitchTo().DefaultContent();
        }

        public void VerifyIframe2Text(string element)
        {
            DriverFactory._driver.SwitchTo().Frame("frame2");
            string text = DriverFactory._driver.FindElement(SampleHeading).Text;
            Console.WriteLine(text);
            DriverFactory._driver.SwitchTo().DefaultContent();
        }
    }
}
