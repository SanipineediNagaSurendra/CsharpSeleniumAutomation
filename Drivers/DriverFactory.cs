using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver _driver;


        public static void LaunchTheBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            
        }

        public static void QuitBrowser()
        {
            _driver?.Quit();
        }
    }
}
