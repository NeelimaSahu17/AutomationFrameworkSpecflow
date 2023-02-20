using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationFrameworkAmbition.Configuration
{
    [Binding]
    public class SeleniumSpecFlowHooks
    {
        private readonly IObjectContainer container;
        private ChromeDriver driver;

        public SeleniumSpecFlowHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void InitializeBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            driver.Close();
            driver.Dispose();
        }

    }

}