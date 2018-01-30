using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class Mobile
    {
        private IWebDriver _driver;
        private ChromeOptions _chromeOptions;
        private WebDriverWait _wait;

    //    MobileProducts mobileProducts = new MobileProducts();

        [TestInitialize]
        public void Setup()
        {
            _chromeOptions = new ChromeOptions();
            
            _driver = new ChromeDriver(_chromeOptions);
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl("http://live.guru99.com/index.php/");
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        [TestCategory("Click on 'Mobile' option of the menu.")]
        public void ClickOnMobileOption(string linkMobile)
        {
            IWebElement mobileOption = _driver.FindElement(By.LinkText(linkMobile));
            //Thread.Sleep(5000);
            //_wait.Until(ExpectedConditions.UrlToBe("http://live.guru99.com/index.php/mobile.html"));

            mobileOption.Click();
            Console.WriteLine("The option selected is: " + linkMobile);
            Thread.Sleep(5000);
        }

        [TestMethod]
        [TestCategory("Verify the title.")]
        public void VerifyTitle()
        {
            try
            {
                string title = _driver.FindElement(By.XPath("//div[@class='page-title category-title']"))
                    .Text;
                Console.WriteLine("The title is: " + title);
                Assert.AreEqual("MOBILE", title);
                Console.WriteLine("The titles are matching.");
            }

            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Thread.Sleep(5000);
        }

        [TestMethod]
        [TestCategory("Sort by 'Name'. (DDL)")]
        public void SortByName()
        {
            try
            {
                IWebElement selectSort = _driver.FindElement(By.XPath("//select[@title='Sort By']"));
                SelectElement select = new SelectElement(selectSort);
                select.SelectByIndex(1);
                Thread.Sleep(5000);
                //Console.WriteLine("The option selected is: ");
            }

            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Products
        [TestMethod]
        [TestCategory("Read the cost of Sony Xperia mobile")]
        public void CostOfSonyXperiaMobile()
        {
            string priceSonyXperia = _driver.FindElement(By.Id("product-price-1"))
                .Text;
            Assert.AreEqual("$100.00", priceSonyXperia);
            Console.WriteLine("Product Value in list and details pagre should be equal " + priceSonyXperia + " dlls.");
        }

        [TestMethod]
        [TestCategory("Click on Sony Xperia mobile.")]
        public void ClickOnSonyXperia()
        {
            try
            {
                IWebElement imageSonyXperia = _driver.FindElement(By.Id("product-collection-image-1"));
                _wait.Until(ExpectedConditions.ElementToBeClickable(imageSonyXperia));
                imageSonyXperia.Click();

                //wait time 
                //try
                //{
                //    _wait.Until(ExpectedConditions.ElementToBeClickable(imageSonyXperia));
                //}

                //catch (WebDriverTimeoutException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

                Console.WriteLine("Sony Xperia mobile has been clicked.");
            }

            catch(NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Read the Sony Xperia mobile from detail page.")]
        public void ReadMobileDetails()
        {
            IWebElement readDetailsTab = _driver.FindElement(By.XPath("//div[@class='tab-content']/h2"));
            
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

    }
}
