using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99
{
    [TestClass]
    public class Television
    {
        private IWebDriver _driver;
        private ChromeOptions _options;
        private WebDriverWait _wait;

        public const string TvLink = "TV";
        string url = "http://live.guru99.com/index.php/";

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _options = new ChromeOptions();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Minimize();
        }

        [TestMethod]
        public void ClickOnTelevisionOption(string TelevisionLink)
        {
            IWebElement clickOnTelevision = _driver.FindElement(By.LinkText(TvLink));
            _wait.Until(ExpectedConditions.ElementToBeClickable(clickOnTelevision));
            Console.WriteLine("The link selected is: " + TvLink);
        }
        
        //**Ecommerce**//
        //[TestMethod]
        //public void AccountClass()
        //{

        //}
        
        [TestMethod]
        public void AddToWishListTV()
        {
            int elementPosition = 1;
            IList<IWebElement> productPosition = _driver.FindElements(By.XPath("//li[@class='item last']"));

            for(int count=0; count<=productPosition.Count; count++)
            {
                if(count == elementPosition)
                {
                    IList<IWebElement> clickOnWishList = _driver.FindElements(By.ClassName("link-wishlist"));

                    for(int i=0; i<=clickOnWishList.Count; i++)
                    {
                        if(i == elementPosition)
                        {
                            _wait.Until(ExpectedConditions.ElementToBeClickable(clickOnWishList[elementPosition]));
                            clickOnWishList[elementPosition].Click();
                            Console.WriteLine("Botton clicked");
                            Thread.Sleep(5000);
                        }
                    }
                }
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
