﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public const string TelevisionLink = "TV";

        Cart cart = new Cart();
        Mobile mobile = new Mobile();
        Television television = new Television();
        Account account = new Account();

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

        [TestMethod]
        [TestCategory("Verify that you cannot add more product in cart than the product available in store")]
        public void NoAddMoreProductsInCart()
        {
            cart.Setup();
            cart.ClickOnMobileOption(MobileLink);
            //mobile.CartClass();
            cart.AddToCartButton();
            cart.ChangeQuantity();
            cart.ErrorMessage();
            cart.EmptyCartLink();
            cart.VerifyCartIsEmpty();
            cart.TearDown();
        }

        [TestMethod]
        [TestCategory("Verify that you are able to compare two product")]
        public void HandlingPopupWindows()
        {
            mobile.Setup();
            mobile.ClickOnMobileOption(MobileLink);
            mobile.AddToCompareLink();
            mobile.CompareButton();
            mobile.PopUpWindows();
            mobile.TearDown();
        }

        [TestMethod]
        [TestCategory("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void Ecommerce()
        {
            account.Setup();
            account.MyAccountOption();
            account.CreateAccountAndFillInfo();
            account.RegisterButton();
            account.VerifyRegistionIsDone();

            //try
            //{
             
            //}

            //catch (NoSuchElementException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            account.TearDown();
        }
    }
}
