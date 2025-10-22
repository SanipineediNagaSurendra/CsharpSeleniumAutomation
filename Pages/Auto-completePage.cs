using DemoQA_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Pages
{
    internal class Auto_completePage
    {
        private readonly ControlHelpers _controlHelpers;

        public Auto_completePage()
        {
            _controlHelpers = new ControlHelpers();
        }

        protected By MultipleColourInput => By.Id("autoCompleteMultipleInput");

        protected By SibgleColourInput => By.Id("autoCompleteSingleInput");

        protected By VerifyColour(string element) => By.XPath($"//*[text()='{element}']");

        public void EnterMultipleColours(Table table)
        {
            var ele = _controlHelpers.FindElement(MultipleColourInput);

            foreach (var row in table.Rows)
            {
                string colour = row["Colours"];
               
                ele.SendKeys(colour);

              
                ele.SendKeys(Keys.ArrowDown);
                ele.SendKeys(Keys.Tab);
                Thread.Sleep(2000);
            }
        }

        public void VerifyColourIsDisplayed(string colour)
        {
           var ele =  _controlHelpers.FindElement(VerifyColour(colour));

            Assert.IsTrue(ele.Displayed, "Colours are not displayed..");

        }

        public void EnterSingleColour(string colour)
        {
            var ele = _controlHelpers.FindElement(SibgleColourInput);
            ele.SendKeys(colour);
            //ele.SendKeys(Keys.ArrowDown);
            ele.SendKeys(Keys.Enter);
            //Thread.Sleep(2000);
        }
    }
}
