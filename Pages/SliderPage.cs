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
    internal class SliderPage
    {
        private readonly ControlHelpers _controlHelpers;

        public SliderPage()
        {
            _controlHelpers = new ControlHelpers();
        }

        protected By VerifySliderDefaultValue(string element) => By.XPath("//input[@class = 'range-slider range-slider--primary']");

        protected By SlideBasedOnValue(string element) => By.XPath($"//input[@type='range']");

        public void VerifySliderValue(string element)
        {
           var ele =  _controlHelpers.FindElement(VerifySliderDefaultValue(element)).GetAttribute("value");
            Assert.IsTrue(ele.Equals(element), "element value is different...");
        }

        public void SlideTheSliderBasedOnMinValue(string element)
        {
            

            
            var slider = DriverFactory._driver.FindElement(By.XPath("//input[@type='range']"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverFactory._driver;
            
            js.ExecuteScript("arguments[0].value='" + element + "';", slider);
            js.ExecuteScript("arguments[0].dispatchEvent(new Event('change'));", slider);

            //Actions actions = new Actions(DriverFactory._driver);
            //var slide = actions.MoveByOffset(150, 200);
            
            

        }
        
    }
}
