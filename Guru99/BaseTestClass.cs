using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Guru99
{
    [TestClass]
    public class BaseTestClass
    {
        protected IWebDriver _driver;
        protected ChromeOptions _options;
        protected WebDriverWait _wait;
        protected Actions _actions;

        [TestInitialize]
        public void Setup()
        {
            _options = new ChromeOptions();
            _driver = new ChromeDriver(_options);
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(Constants.URL_PROJECT);
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

        #region TestMethod
        [TestMethod]
        [TestCategory("Click on 'element' option of the menu.")]
        public void ClickOnElementOption(string nameOfElement)
        {
            IWebElement mobileOption = _driver.FindElement(By.LinkText(nameOfElement));
            _wait.Until(ExpectedConditions.ElementToBeClickable(mobileOption)).Click();
            Console.WriteLine("The option selected is: " + nameOfElement);
        }
        #endregion

    }
}
