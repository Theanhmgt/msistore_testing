using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace msistore_testing
{
    [TestClass]
    public class Login
    {
        private IWebDriver driver;
        private string baseUrl;
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            baseUrl = "http://localhost:3000";
        }
        [TestMethod]
        public void TC3_2_1_1()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            IWebElement signInBTN = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/form/div[3]/button"));

            usernameInput.SendKeys("theanh5");
            passwordInput.SendKeys("Theanh28");
            signInBTN.Click();

            Thread.Sleep(4000);

            string current_url = driver.Url;
            string home_url = baseUrl + "/";
            Assert.AreEqual(home_url,current_url);
        }

        [TestMethod]
        public void TC3_2_1_2()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            IWebElement signInBTN = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/form/div[3]/button"));

            usernameInput.SendKeys("aaaaaaaaa");
            passwordInput.SendKeys("Theanh28");
            signInBTN.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            IWebElement alert = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[4]/div/div/div[1]/div[2]")));


            Assert.AreEqual("Account not found", alert.Text);
        }
        [TestMethod]
        public void TC3_2_1_3()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));

            usernameInput.SendKeys("a");
            passwordInput.SendKeys("Theanh28");

            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/form/div[1]/span"));

            Assert.AreEqual("Username should be 3-16 characters and shouldn't include any special character!", alert.Text);
        }
        [TestMethod]
        public void TC3_2_1_4()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));

            passwordInput.SendKeys("a");
            usernameInput.SendKeys("Theanh28");

            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/form/div[2]/span"));

            Assert.AreEqual("Password should be 8-20 characters and include at least 1 number", alert.Text);
        }
        [TestMethod]
        public void TC3_2_1_5()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));

            usernameInput.SendKeys("");
            passwordInput.SendKeys("Passw0rd");

            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/form/div[1]/span"));

            Assert.AreEqual("Username should be 3-16 characters and shouldn't include any special character!", alert.Text);
        }
        [TestMethod]
        public void TC3_2_1_6()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));

            passwordInput.SendKeys("");
            usernameInput.SendKeys("Theanh28");

            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/form/div[2]/span"));

            Assert.AreEqual("Password should be 8-20 characters and include at least 1 number", alert.Text);
        }
        [TestCleanup] 
        public void TestDown()
        {
            driver.Quit();
        }
    }
}
