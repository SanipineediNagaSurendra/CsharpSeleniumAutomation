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
    internal class RadioButtonPage
    {
        private readonly ControlHelpers _controlHelpers;
        private readonly WaitingHelpers _waitingHelpers;

        public RadioButtonPage()
        {
            _controlHelpers = new ControlHelpers();
            _waitingHelpers = new WaitingHelpers();
        }

        protected By radioButton(string element) => By.XPath($"//label[text() = '{element}']");

        protected By getTextDisplayed(string element, string btn) => By.XPath($"//p[text() = '{element}']/span[text() = '{btn}']");

        protected By getRadioButton(string element) => By.XPath($"//label[text() = '{element}']/parent::div//input[@id = 'noRadio']");


        public void SafeClickRadioButton(string element)
        {
            _controlHelpers.SafeClick(radioButton(element));
        }

        public bool VerifyTextShouldBeDisplayed(string element, string button)
        {
            var ele = _controlHelpers.FindElement(getTextDisplayed(element, button));

            if(ele.Displayed)
            {
                return true;
            }
            return false;   
        }

        public bool VerifyRadioButtonIsEnabled(string element)
        {
            var ele = _controlHelpers.FindElement(getRadioButton(element));

            if(!ele.Enabled)
            {
                return true;
            }
            return false;
        }
    }
}
//label[normalize-space(text())='{element}']//parent::div//input