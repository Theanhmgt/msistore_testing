using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.Net.WebRequestMethods;

namespace msistore_testing
{
    [TestClass]
    public class Register
    {
        private IWebDriver driver;
        private string baseUrl;
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();
            baseUrl = "http://localhost:3000";
            //baseUrl = "https://msistore.vercel.app";
        }
        [TestMethod]
        public void TC3_2_2_1()
        {
            driver.Navigate().GoToUrl(baseUrl + "/register");
            IWebElement firstNameInput = driver.FindElement(By.CssSelector("input[name='first_name']"));
            IWebElement lastNameInput = driver.FindElement(By.CssSelector("input[name='last_name']"));
            IWebElement emailInput = driver.FindElement(By.CssSelector("input[name='email']"));
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            IWebElement conFirmPasswordInput = driver.FindElement(By.CssSelector("input[name='confirmPassword']"));
            IWebElement avatarInput = driver.FindElement(By.CssSelector("input[name='avatar']"));
            IWebElement signInBTN = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[8]/button"));

            firstNameInput.SendKeys("Anh");
            lastNameInput.SendKeys("Nguyễn");
            emailInput.SendKeys("abc@gmail.com");
            usernameInput.SendKeys("theanh28");
            passwordInput.SendKeys("Theanh28");
            conFirmPasswordInput.SendKeys("Theanh28");
            avatarInput.SendKeys("C:\\Users\\Admin\\Pictures\\Personal\\selenium.png");
            signInBTN.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            IWebElement alert = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[4]/div/div/div[1]/div[2]")));

            Assert.AreEqual("Register successfully, redirecting to homepage", alert.Text);
        }
        [TestMethod]
        public void TC3_2_2_2()
        {
            driver.Navigate().GoToUrl(baseUrl + "/register");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));

            usernameInput.SendKeys("a");
            passwordInput.SendKeys("Theanh28");


            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[3]/span"));

            Assert.AreEqual("Username should be 3-16 characters and shouldn't include any special character!", alert.Text);
        }
        [TestMethod]
        public void TC3_2_2_3()
        {
            driver.Navigate().GoToUrl(baseUrl + "/register");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));

            passwordInput.SendKeys("a");
            usernameInput.SendKeys("Theanh28");
            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[5]/span"));

            Assert.AreEqual("Password should be 8-20 characters and include at least 1 number", alert.Text);
        }


        [TestMethod]
        public void TC3_2_2_4()
        {
            driver.Navigate().GoToUrl(baseUrl + "/register");
            IWebElement firstNameInput = driver.FindElement(By.CssSelector("input[name='first_name']"));
            IWebElement lastNameInput = driver.FindElement(By.CssSelector("input[name='last_name']"));
            IWebElement emailInput = driver.FindElement(By.CssSelector("input[name='email']"));
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            IWebElement conFirmPasswordInput = driver.FindElement(By.CssSelector("input[name='confirmPassword']"));
            IWebElement avatarInput = driver.FindElement(By.CssSelector("input[name='avatar']"));
            IWebElement signInBTN = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[8]/button"));

            firstNameInput.SendKeys("Anh");
            lastNameInput.SendKeys("Nguyễn");
            emailInput.SendKeys("abc@gmail.com");
            usernameInput.SendKeys("theanh28");
            passwordInput.SendKeys("Theanh28");
            conFirmPasswordInput.SendKeys("Theanh28");
            avatarInput.SendKeys("C:\\Users\\Admin\\Pictures\\Personal\\dkmh.pdf");

            signInBTN.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            IWebElement alert = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[4]/div/div/div[1]/div[2]")));

            Assert.AreEqual("Invalid file type", alert.Text);
        }
        [TestMethod]
        public void TC3_2_2_5()
        {
            driver.Navigate().GoToUrl(baseUrl + "/register");
            IWebElement firstNameInput = driver.FindElement(By.CssSelector("input[name='first_name']"));
            IWebElement lastNameInput = driver.FindElement(By.CssSelector("input[name='last_name']"));
            IWebElement emailInput = driver.FindElement(By.CssSelector("input[name='email']"));
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            IWebElement conFirmPasswordInput = driver.FindElement(By.CssSelector("input[name='confirmPassword']"));
            IWebElement avatarInput = driver.FindElement(By.CssSelector("input[name='avatar']"));
            IWebElement signInBTN = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[8]/button"));

            firstNameInput.SendKeys("Anh");
            lastNameInput.SendKeys("Nguyễn");
            emailInput.SendKeys("abc@gmail.com");
            usernameInput.SendKeys("theanh5");
            passwordInput.SendKeys("Theanh28");
            conFirmPasswordInput.SendKeys("Theanh28");
            avatarInput.SendKeys("C:\\Users\\Admin\\Pictures\\Personal\\selenium.png");

            signInBTN.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            IWebElement alert = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[4]/div/div/div[1]/div[2]")));

            Assert.AreEqual("Account already exists", alert.Text);
        }
        [TestCleanup]
        public void TestDown()
        {
            driver.Quit();
        }
    }
}
