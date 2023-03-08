using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestWeb
{
    public class Tests
    {

        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "http://www.google.co.in";
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}