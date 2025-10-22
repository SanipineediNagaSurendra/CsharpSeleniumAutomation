using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class WebTablePage
    {
        private readonly ControlHelpers _controlHelpers;
        private readonly WaitingHelpers _wait;
        public WebTablePage()
        {
            _controlHelpers = new ControlHelpers();
            _wait = new WaitingHelpers();
        }
        
        protected By firstName  => By.Id("firstName");

        protected By lastName => By.Id("lastName");

        protected By age => By.Id("age");

        protected By email => By.Id("userEmail");

        protected By addButton(string element) => By.XPath($"//button[text() = '{element}']");

        protected By salary => By.Id("salary");

        protected By department => By.Id("department");

        public void SafeClickAddButton(string element)
        {
            _controlHelpers.SafeClick(addButton(element));
        }

        public void SafeEnterFirstName(string element)
        {
            _controlHelpers.EnterText(firstName, element);
        }

        public void SafeEnterLastName(string element)
        {
            _controlHelpers.EnterText(lastName, element);
        }

        public void SafeEnterAge(string element)
        {
            _controlHelpers.EnterText(age, element);
        }

        public void EnterEmail(string element)
        {
            _controlHelpers.EnterText(email, element);
        }

        public void EnterSalary(string element)
        {
            _controlHelpers.EnterText(salary, element);
        }

        public void EnterDepartment(string element)
        {
            _controlHelpers.EnterText(department, element);
        }

        public void IsOnWebPage(string element)
        {
            if (element == "Web Tables")
            {
                DriverFactory._driver.Navigate().GoToUrl("https://demoqa.com/webtables");
                _controlHelpers.FindElement(By.XPath("//div[@class = 'rt-tbody']"));
                
            }
           
        }
       
    }
}
