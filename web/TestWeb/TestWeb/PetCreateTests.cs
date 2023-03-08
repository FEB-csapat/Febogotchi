using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace TestWeb
{
    public class PetCreateTests
    {
        IWebDriver driver;

        const string baseUrl = "http://localhost:5174/";

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        private void goToCreatePage()
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
                    if (driver.Url == $"{baseUrl}create")
                    {
                        // successful login
                        break;
                    }
                    else if (driver.Url == $"{baseUrl}index")
                    {
                        driver.Navigate().GoToUrl(@$"{baseUrl}create");
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
        public void SuccessfulCreatePetTest()
        {
            goToCreatePage();

            var petnameTextbox = driver.FindElement(By.Id("petname_textbox"));
            petnameTextbox.SendKeys("Maggot");

            var optionSelector = driver.FindElement(By.Id("option_selector"));
            SelectElement select = new SelectElement(optionSelector);

            select.SelectByValue("1");


            var createButton = driver.FindElement(By.Id("create_button"));
            createButton.Click();

            // wait for response
            while (true)
            {
                try
                {
                    IAlert simpleAlert = driver.SwitchTo().Alert();
                    if (simpleAlert.Text.Contains("Sikeres létrehozás!"))
                    {
                        // success
                        simpleAlert.Dismiss();
                        break;
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
                catch
                {
                   
                }
            }
        }

        

        [Test]
        public void NoTypeSelectedCreatePetTest()
        {
            goToCreatePage();

            var petnameTextbox = driver.FindElement(By.Id("petname_textbox"));
            petnameTextbox.SendKeys("Maggot");

            // no pet type selected

            var createButton = driver.FindElement(By.Id("create_button"));
            createButton.Click();

            // check if pet creation was successful

            while (true)
            {
                try
                {
                    IAlert simpleAlert = driver.SwitchTo().Alert();
                    if (simpleAlert.Text.Contains("The pet type id field is required"))
                    {
                        // success
                        simpleAlert.Dismiss();
                        Assert.Fail();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {

                }
            }
        }

        [Test]
        public void NoNameCreatePetTest()
        {
            goToCreatePage();

            // no name given

            var optionSelector = driver.FindElement(By.Id("option_selector"));
            SelectElement select = new SelectElement(optionSelector);

            select.SelectByValue("1");


            var createButton = driver.FindElement(By.Id("create_button"));
            createButton.Click();

            // wait for response
            while (true)
            {
                try
                {
                    IAlert simpleAlert = driver.SwitchTo().Alert();
                    if (simpleAlert.Text.Contains("The name field is required"))
                    {
                        simpleAlert.Dismiss();
                        Assert.Fail();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    
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