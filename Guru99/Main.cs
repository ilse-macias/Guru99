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
        public const string MobileLink = "MOBILE";
        public const string TelevisionLink = "TV";
        
        Mobile mobile;
        MobileProducts mobileProducts;
        Cart cart;

        Television television = new Television();
        Account account = new Account();
        
        //Mobile.cs
        [TestMethod]
        [TestCategory("Verify item in Mobile List page can be sorted by 'Name'.")]
        public void VerifyAndSortByName()
        {
            mobile = new Mobile();

            mobile.Setup();
            //mobile.ClickOnMobileOption(MobileLink);
            mobile.ClickOnElementOption(Constants.MobileLink);
            mobile.VerifyTitle();
            mobile.SortByName();
            mobile.TearDown();
        }

        //MobileProducts.cs
        [TestMethod]
        [TestCategory("Verify that cost of product in list page and details page are equal.")]
        public void VerifyCostOfProductInListAndDetails()
        {
            mobileProducts = new MobileProducts();

            mobileProducts.Setup();
            //mobileProducts.ClickOnMobileOption(MobileLink);
            mobile.ClickOnElementOption(Constants.MobileLink);
            mobileProducts.CostOfSonyXperiaMobile();
            mobileProducts.ClickOnSonyXperia();
            mobileProducts.PriceDescriptionOfXperiaMobile();
            mobileProducts.ReadMobileDetails();
            mobileProducts.CompareValuesPrices();
            mobileProducts.TearDown();
        }

        //Cart.cs
        [TestMethod]
        [TestCategory("Verify that you cannot add more product in cart than the product available in store")]
        public void NoAddMoreProductsInCart()
        {
            cart = new Cart();

            cart.Setup();
            //cart.ClickOnMobileOption(MobileLink);
            cart.ClickOnElementOption(Constants.MobileLink);
            //mobile.CartClass();
            cart.AddToCartButton();
            cart.ChangeQuantity();
            cart.ErrorMessage();
            cart.EmptyCartLink();
            cart.VerifyCartIsEmpty();
            cart.TearDown();
        }

        //Mobile.cs 2 windows.
        [TestMethod]
        [TestCategory("Verify that you are able to compare two product")]
        public void HandlingPopupWindows()
        {
            mobile.Setup();
            //mobile.ClickOnMobileOption(MobileLink);
            mobile.ClickOnElementOption(Constants.MobileLink);
            mobile.AddToCompareLink();
            mobile.CompareButton();
            mobile.PopUpWindows();
            mobile.TearDown();
        }

        //Account.cs
        [TestMethod]
        [TestCategory("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void Ecommerce()
        {
            account.Setup();
            account.MyAccountOption();
            account.CreateAccountAndFillInfo("Yudi", "Ramos", "test@mailinator.com", "123456", "123456");
            account.RegisterButton();
            account.VerifyRegistionIsDone();
            account.TearDown();
        }
    }
}
