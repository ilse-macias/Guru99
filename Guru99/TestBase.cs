using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Guru99
{
    public class TestBase
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
            _driver.Navigate().GoToUrl(Constants.URL);
            _driver.Manage().Window.Maximize();
        }

        //*** Menu.cs ****/
        [TestMethod]
        [TestCategory("Click an option of the menu.")]
        public void ClickAnOption(string elementLink)
        {
            IWebElement elementOption = _driver.FindElement(By.LinkText(elementLink));
            _wait.Until(ExpectedConditions.ElementToBeClickable(elementOption)).Click();
            Console.WriteLine("The option selected is: " + elementLink);
        }

        [TestMethod]
        [TestCategory("Click on 'My Account' link.")]
        public void MyAccountOption()
        {
            ////IWebElement account = _driver.FindElement(By.XPath("//*[@class='skip-link skip-account']"));
            //IWebElement account = _driver.FindElement(By.LinkText(accountLink));
            //_wait.Until(ExpectedConditions.ElementToBeClickable(account));
            //account.Click();
            //Thread.Sleep(5000);

            //Select 'My Account' sub-option using actions.
            IWebElement myAccountLink = _driver.FindElement(By.CssSelector("#header-account>div>ul>li.first>a"));
            try
            {
                _actions.Click(myAccountLink)
                    .Build()
                    .Perform();

                //_wait.Until(ExpectedConditions.ElementToBeSelected(myAccountLink));
                Thread.Sleep(5000);

                //string myAccountLink = "My Account";
                //_driver.FindElement(By.LinkText(myAccountLink)).Click();
                //Thread.Sleep(5000);

                Console.WriteLine("Link clicked: " + myAccountLink);
            }

            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
