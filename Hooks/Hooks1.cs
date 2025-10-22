using Allure.Net.Commons;
using DemoQA_Automation.Drivers;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support.Extensions;
using Reqnroll;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace DemoQA_Automation.Hooks
{

    [Binding]
    public sealed class Hooks1
    {
        private readonly ScenarioContext _scenarioContext;
        private static AllureLifecycle _allure = AllureLifecycle.Instance;

        private static readonly ILog log = LogManager.GetLogger(typeof(Hooks1));

        public Hooks1(ScenarioContext scenarioContext)
        {
              _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }
            log.Info("===== TEST RUN STARTED =====");
           
            string allureDir = Path.Combine(AppContext.BaseDirectory, "Allure-Results");

            if(Directory.Exists(allureDir))
            {
                Directory.CreateDirectory(allureDir);
            }

            
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            log.Info("==== Test Run Finished ====");
        }

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            log.Info($"---- Starting Scenario: {_scenarioContext.ScenarioInfo.Title} ----");
            DriverFactory.LaunchTheBrowser();
            
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
           DriverFactory.QuitBrowser();

            if (_scenarioContext.TestError != null)
            {
                log.Error($"Scenario FAILED: {_scenarioContext.ScenarioInfo.Title}");
                log.Error($"Error: {_scenarioContext.TestError.Message}");
            }
            else
            {
                log.Info($"Scenario PASSED: {_scenarioContext.ScenarioInfo.Title}");
            }
        }

        [AfterStep]

        public void AfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                var screenshot = ((ITakesScreenshot)DriverFactory._driver).GetScreenshot();

               
                Byte[] screenshotBytes = screenshot.AsByteArray;

               
                AllureApi.AddAttachment("Screenshot on Failure", "image/png", screenshotBytes);

                log.Error($"step failed: {_scenarioContext.ScenarioInfo.Title}");
            }
            else
            {
                log.Info($"Step passed: {_scenarioContext.StepContext.StepInfo.Text}");
            }

        }
    }
    
}