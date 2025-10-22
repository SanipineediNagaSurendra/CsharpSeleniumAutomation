using DemoQA_Automation.Drivers;
using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    public class TextBoxPage
    {
        public readonly ControlHelpers _controlHelpers;
        private readonly IWebDriver _driver;
       
        public TextBoxPage(IWebDriver driver)
        {
           _driver = driver;
            _controlHelpers = new ControlHelpers();
        }
       
        protected By ElementsCard(string element) => By.XPath($"//h5[text() = '{element}']");
        protected By TextBox(string element) => By.XPath($"//span[text() = '{element}']");

        protected By UserName => By.Id("userName");

        protected By UserEmail => By.Id("userEmail");

        protected By CurrentAddress => By.Id("currentAddress");

        protected By PermanentAddress => By.Id("permanentAddress");

        protected By submit(string element) => By.Id(element);

        public void NavigateUrl(string url)
        {
            _controlHelpers.NavigateUrl(url);
            
        }

        public void SafeClickElemetCard(string element)
        {
            _controlHelpers.SafeClick(ElementsCard(element));
            
        }

        public void SafeClickTextBox(string element)
        {
            _controlHelpers.ScrollUntilElementFound(TextBox(element));
            Thread.Sleep(3000);
            
        }

        public void EnterText(string element)
        {
            _controlHelpers.EnterText(UserName, element);
        }

        public void EnterEmail(string element)
        {
            _controlHelpers.EnterText(UserEmail, element);
        }

        public void currentAddress()
        {
            _controlHelpers.EnterText(CurrentAddress, ConfigReader.currentAddress);
        }

        public void permanentAddress()
        {
            _controlHelpers.EnterText(PermanentAddress, ConfigReader.permanentAddress);
        }
       
        public void SubmitButton(string element)
        {
            _controlHelpers.ScrollToBottom(_driver);
            Thread.Sleep(5000);
            _controlHelpers.SafeClick(submit(element));
        }

       public void VerifyElementIsSame()
       {
            var nameText = _controlHelpers.FindElement(By.Id("name")).Text;
            var emailText = _controlHelpers.FindElement(By.Id("email")).Text;
           
            Assert.AreEqual("Name:SurendraSanipineedi", nameText.Replace(" ", ""));
            Assert.AreEqual("Email:surendra@gmail.com", emailText.Replace(" ", ""));
            
       }

        public void ThenTheEmailFieldShouldShowARedBorder()
        {
            var emailField = _controlHelpers.FindElement(By.Id("userEmail"));
            
            string borderColor = emailField.GetCssValue("border-color");
            Console.WriteLine("Border color is: " + borderColor);

            
            bool isRed = borderColor.Contains("rgb(255, 0, 0)") || borderColor.Contains("rgba(255, 0, 0, 1)");

            Assert.IsTrue(isRed, $"Expected red border color, but got: {borderColor}");
        }
    }
}
