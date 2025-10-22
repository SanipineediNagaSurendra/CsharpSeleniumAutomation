using DemoQA_Automation.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Utilities
{
    public class ControlHelpers
    {
       
        
        public IWebElement FindElement(By Locator)
        {
            return DriverFactory._driver.FindElement(Locator);
        }
        public IReadOnlyCollection<IWebElement> FindElements(By Locator)
        {
            return DriverFactory._driver.FindElements(Locator);
        }
        public void SafeClick(By Locator)
        {
            IWebElement element = null;
            try
            {
                element = FindElement(Locator);

                IJavaScriptExecutor js = (IJavaScriptExecutor)DriverFactory._driver;
                js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);


                try
                {
                    element.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    Console.WriteLine("⚠️ Element click intercepted, retrying via JS...");
                    js.ExecuteScript("arguments[0].click();", element);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ Failed to click {Locator}: {ex.Message}");
            }


        }

        public void NavigateUrl(string url)
        {
           DriverFactory._driver.Navigate().GoToUrl(url);
        }

        public void EnterText(By Locator, string element)
        {
            var ele = FindElement(Locator);
            ele.SendKeys(element);

        }

        public void ScrollToBottom(IWebDriver driver)
        {
          
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 600);");
           
        }

        
        public void ScrollUntilElementFound(By Locator)
        {

            bool elementFound = false;

            while (!elementFound)
            {
                try
                {
                    var element = DriverFactory._driver.FindElement(Locator);
                    if (element.Displayed)
                    {
                        elementFound = true;
                        ((IJavaScriptExecutor)DriverFactory._driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                        element.Click();
                    }
                }
                catch (NoSuchElementException)
                {

                    ((IJavaScriptExecutor)DriverFactory._driver).ExecuteScript("window.scrollBy(0, 300);");
                }
            }



        }

        
       
    }
}
