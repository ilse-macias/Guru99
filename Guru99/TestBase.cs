using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Guru99
{
    public class TestBase
    {
        protected IWebDriver _driver;
        //protected FireFoxOption _options;
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

           // string noos = TestContext.TestName.ToString();
        }

        [TestMethod]
        [TestCategory("Click on 'My Account' link.")]
        public void MyAccountOption()
        {
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

        //****//
        [TestCategory("Screenshot")]
        public void ScreenShot()
        {
            // Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();

            ITakesScreenshot screen = _driver as ITakesScreenshot;
            Screenshot ss = screen.GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\img01.png", ScreenshotImageFormat.Png);
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
