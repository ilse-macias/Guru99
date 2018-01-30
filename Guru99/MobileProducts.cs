//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Guru99
//{
//    [TestClass]
//    public class MobileProducts
//    {
//        private IWebDriver _driver;
//        private ChromeOptions _chromeOptions;
//        private WebDriverWait _wait;

//        [TestInitialize]
//        public void Setup()
//        {
//            _chromeOptions = new ChromeOptions();

//            _driver = new ChromeDriver(_chromeOptions);
//            _driver.Manage().Cookies.DeleteAllCookies();
//            _driver.Navigate().GoToUrl("http://live.guru99.com/index.php/");
//            _driver.Manage().Window.Maximize();
//            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
//        }

//        [TestMethod]
//        [TestCategory("Read the cost of Sony Xperia mobile")]
//        public void CostOfSonyXperiaMobile()
//        {
//            string priceSonyXperia = _driver.FindElement(By.Id("product-price-1"))
//                .Text;
//            Assert.AreEqual("$100.00", priceSonyXperia);
//            Console.WriteLine("Product Value in list and details pagre should be equal " + priceSonyXperia + " dlls.");
//        }

//        [TestCleanup]
//        public void TearDown()
//        {
//            _driver.Close();
//            _driver.Quit();
//        }
//    }
//}
