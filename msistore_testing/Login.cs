using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

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
            baseUrl = "http://localhost:3000";
        }
        [TestMethod]
        public void TC1_1()
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

        [TestCleanup] 
        public void TestDown()
        {
            driver.Quit();
        }
    }
}
