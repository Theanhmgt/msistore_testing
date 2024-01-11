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
    public class ChangePassword
    {
        private IWebDriver driver;
        private string baseUrl;
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            baseUrl = "http://localhost:3000";

            driver.Navigate().GoToUrl(baseUrl + "/login");
            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            IWebElement signInBTN = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/form/div[3]/button"));

            usernameInput.SendKeys("theanh5");
            passwordInput.SendKeys("Theanh28");
            signInBTN.Click();

            Thread.Sleep(4000);
            driver.Navigate().GoToUrl(baseUrl + "/dashboard");
        }
        [TestMethod]
        public void TC3_2_3_1()
        {
            IWebElement changePassworBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[2]/div[1]/div[3]/span[2]"));
            changePassworBtn.Click();
            Thread.Sleep(1000);

            IWebElement currentUserInput = driver.FindElement(By.CssSelector("input[name='old_password']"));
            IWebElement newUserInput = driver.FindElement(By.CssSelector("input[name='new_password']"));
            IWebElement saveBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div[2]/div[1]/div[3]/span[2]"));
            currentUserInput.SendKeys("Theanh28");
            newUserInput.SendKeys("Theanh30");
            saveBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            IWebElement alert = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[4]/div/div/div[1]/div[2]")));


            Assert.AreEqual("Changed password successlly", alert.Text);
        }
        
        [TestCleanup]
        public void TestDown()
        {
            driver.Quit();
        }
    }
}
