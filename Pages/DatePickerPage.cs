using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.CSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemoQA_Automation.Pages
{
    internal class DatePickerPage
    {
        private readonly ControlHelpers _controlHelpers;
        private readonly PraticeFormPage _formPage;
       

        public DatePickerPage()
        {
            _controlHelpers = new ControlHelpers();
            _formPage = new PraticeFormPage();
        }

        protected By Date => By.Id("datePickerMonthYearInput");

        protected By SelectMonth(string element) => By.XPath($"//select[@class = 'react-datepicker__month-select']/option[contains(text(), '{element}')]");

        protected By VerifyDate(string element) => By.XPath($"//input[@value = '{element}']");

        protected By DateAndTime => By.Id("dateAndTimePickerInput");

        protected By SelectMonthInDropDown(string element) => By.XPath($"//span[@class = 'react-datepicker__month-read-view--selected-month' and contains(text() , '{element}')]");

        public void SafeClickDateInputFeild()
        {
            _controlHelpers.SafeClick(Date);
        }

        public void SafeClickDateButtonFeild(string date)
        {
            string[] parts = date.Split(' ');

            string day = parts[0];
            string month = parts[1];
            string year = parts[2];

            _controlHelpers.SafeClick(SelectMonth(month));

            _formPage.SelectYear(year);
            var SelectDay = By.XPath($"//div[contains(@aria-label, '{month}') and text() = '{day}']");
            _controlHelpers.SafeClick(SelectDay);

            
        }

        public void VerifyGivenDateIsDisplayed(string element)
        {
            

            var eleInput = _controlHelpers.FindElement(VerifyDate(element));

            Assert.IsTrue(eleInput.Displayed, "Date is not matching in date feild..");
        }

        public void SafeClickDateAndTimeInputFeild()
        {
            _controlHelpers.SafeClick(DateAndTime);
        }

        public void SafeClickMonth(string date, string time)
        {

            string targetDateTime = $"{date}, {time}";
        }

            
    }
}
