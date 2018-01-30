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
    public class Main
    {
        //public IWebDriver _driver;
        //public ChromeOptions _chromeOptions;
        //public WebDriverWait _wait;

        public const string MobileLink = "MOBILE";

        Mobile mobile = new Mobile();
        
        //MobileProducts mobileProducts = new MobileProducts();

        //[TestInitialize]
        //public void Setup()
        //{
        //    _chromeOptions = new ChromeOptions();

        //    _driver = new ChromeDriver(_chromeOptions);
        //    _driver.Manage().Cookies.DeleteAllCookies();
        //    _driver.Navigate().GoToUrl("http://live.guru99.com/index.php/");
        //    _driver.Manage().Window.Maximize();
        //    _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        //}

        [TestMethod]
        [TestCategory("Verify item in Mobile List page can be sorted by 'Name'.")]
        public void VerifyAndSortByName()
        {
            mobile.Setup();
            mobile.ClickOnMobileOption(MobileLink);
            mobile.VerifyTitle();
            mobile.SortByName();
            mobile.TearDown();
        }

        [TestMethod]
        [TestCategory("Verify that cost of product in list page and details page are equal.")]
        public void VerifyCostOfProductInListAndDetails()
        {
            mobile.Setup();
            mobile.ClickOnMobileOption(MobileLink);
            mobile.CostOfSonyXperiaMobile();
            mobile.ClickOnSonyXperia();
            mobile.PriceDescriptionOfXperiaMobile();
            mobile.ReadMobileDetails();
            mobile.CompareValuesPrices();
            mobile.TearDown();
        }

        //public void TearDown()
        //{
        //    _driver.Close();
        //    _driver.Quit();
        //}
    }
}
