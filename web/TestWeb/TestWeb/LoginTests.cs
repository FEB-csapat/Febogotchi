using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using System.Runtime.ConstrainedExecution;
using AngleSharp.Dom;

namespace TestWeb
{
    public class LoginTests
    {
        IWebDriver driver;

        const string baseUrl = "http://localhost:5174/";

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            driver.Url = baseUrl;

            var usernameTextbox = driver.FindElement(By.Id("username_textbox"));
            usernameTextbox.SendKeys("Feco");

            var passwordTextbox = driver.FindElement(By.Id("password_textbox"));
            passwordTextbox.SendKeys("jelszo");

            var submitButton = driver.FindElement(By.Id("submit_button"));
            submitButton.Click();

            // wait for response
            while (true)
            {
                try
                {
                    if (driver.Url == $"{baseUrl}create" || driver.Url == $"{baseUrl}index")
                    {
                        // successful login
                        break;
                    }
                }
                catch
                {
                    IAlert simpleAlert = driver.SwitchTo().Alert();
                    if (simpleAlert.Text == "AxiosError: Request failed with status code 422")
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [Test]
        public void NotExistingUserLoginTest()
        {
            driver.Url = baseUrl;

            var usernameTextbox = driver.FindElement(By.Id("username_textbox"));
            usernameTextbox.SendKeys("NotARealUsername");

            var passwordTextbox = driver.FindElement(By.Id("password_textbox"));
            passwordTextbox.SendKeys("WrongPassword");

            var submitButton = driver.FindElement(By.Id("submit_button"));
            submitButton.Click();

            // wait for response
            while (true)
            {
                try
                {
                    if (driver.Url == $"{baseUrl}create" || driver.Url == $"{baseUrl}index")
                    {
                        // successful login
                        Assert.Fail();
                    }
                }
                catch
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    if (alert.Text.Contains("User does not exist"))
                    {
                        alert.Dismiss();
                        break;
                    }
                }
            }
        }

        [Test]
        public void TooShortUsernameLoginTest()
        {
            driver.Url = baseUrl;

            var usernameTextbox = driver.FindElement(By.Id("username_textbox"));
            usernameTextbox.SendKeys("a");

            var passwordTextbox = driver.FindElement(By.Id("password_textbox"));
            passwordTextbox.SendKeys("WrongPassword");

            var submitButton = driver.FindElement(By.Id("submit_button"));
            submitButton.Click();


            // wait for response
            while (true)
            {
                try
                {
                    if (driver.Url == $"{baseUrl}create" || driver.Url == $"{baseUrl}index")
                    {
                        // successful login
                        Assert.Fail();
                    }
                }
                catch
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    if (alert.Text.Contains("The name must be at least 4 characters"))
                    {
                        alert.Dismiss();
                        break;
                    }

                }
            }
        }


        [Test]
        public void WrongPasswordLoginTest()
        {
            driver.Url = baseUrl;

            var usernameTextbox = driver.FindElement(By.Id("username_textbox"));
            usernameTextbox.SendKeys("Feco");

            var passwordTextbox = driver.FindElement(By.Id("password_textbox"));
            passwordTextbox.SendKeys("WrongPassword");

            var submitButton = driver.FindElement(By.Id("submit_button"));
            submitButton.Click();


            // wait for response
            var startTimestamp = DateTime.Now.Millisecond;
            var endTimestamp = startTimestamp + 50000;

            while (true)
            {
                try
                {
                    if (driver.Url == $"{baseUrl}create" || driver.Url == $"{baseUrl}index")
                    {
                        // successful login
                        Assert.Fail();
                    }
                }
                catch
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    if (alert.Text.Contains("Password mismatch"))
                    {
                        alert.Dismiss();
                        break;
                    }
                }
            }
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}