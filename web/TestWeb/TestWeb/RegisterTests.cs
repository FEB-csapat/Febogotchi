using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using System.Runtime.ConstrainedExecution;

namespace TestWeb
{
    public class RegisterTests
    {
        IWebDriver driver;

        static string baseUrl = "http://localhost:5174/";

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        [Test]
        public void SuccessfulRegistrationTest()
        {
            driver.Url = baseUrl + "register";

            var usernameTextbox = driver.FindElement(By.Id("username_textbox"));
            usernameTextbox.SendKeys("NewUser12222");

            var passwordTextbox = driver.FindElement(By.Id("password_textbox"));
            passwordTextbox.SendKeys("jelszo");

            var passwordAgainTextbox = driver.FindElement(By.Id("password_again_textbox"));
            passwordAgainTextbox.SendKeys("jelszo");

            var submitButton = driver.FindElement(By.Id("submit_button"));
            submitButton.Click();

            // wait for response
            while (true)
            {
                try
                {
                    IAlert simpleAlert = driver.SwitchTo().Alert();
                    if (simpleAlert.Text.Contains("Sikeres regisztráció, kérlek jelentkezz be"))
                    {
                        simpleAlert.Accept();
                        break;
                    }
                    else
                    {
                        simpleAlert.Dismiss();
                        Assert.Fail();
                        break;
                    }
                }
                catch
                {
                    
                }
            }
        }

        [Test]
        public void PasswordMismatchRegistrationTest()
        {
            driver.Url = baseUrl + "register";

            var usernameTextbox = driver.FindElement(By.Id("username_textbox"));
            usernameTextbox.SendKeys("NewUser2");

            var passwordTextbox = driver.FindElement(By.Id("password_textbox"));
            passwordTextbox.SendKeys("Password");

            var passwordAgainTextbox = driver.FindElement(By.Id("password_again_textbox"));
            passwordAgainTextbox.SendKeys("Pasword_typo");

            var submitButton = driver.FindElement(By.Id("submit_button"));
            submitButton.Click();

            IAlert alert1 = driver.SwitchTo().Alert();
            
            if (alert1.Text.Contains("A két jelszó nem egyezik meg!"))
            {
                alert1.Dismiss();
                return;
            }
            else
            {
                Assert.Fail();
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}