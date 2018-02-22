using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guru99
{
    [TestClass]
    public class Main
    {
        Mobile mobile;
        MobileProducts mobileProducts;
        Cart cart;
        Television television;
        PurchaseProducts purchaseProducts;
        MyAccountLogin myAccountLogin;
        //Utils utils;

        //Mobile.cs
        [TestMethod]
        [TestCategory("Verify item in Mobile List page can be sorted by 'Name'.")]
        public void VerifyAndSortByName()
        {
            mobile = new Mobile();
           // utils = new Utils();

            mobile.Setup();
            mobile.ClickAnOption(Constants.MOBILE_LINK);
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
            //utils = new Utils();

            mobileProducts.Setup();
            mobileProducts.ClickAnOption(Constants.MOBILE_LINK);
            mobileProducts.CostOfSonyXperiaMobile();
            mobileProducts.ClickOnSonyXperia();
            mobileProducts.PriceDescriptionOfXperiaMobile();
            mobileProducts.ReadMobileDetails();
            mobileProducts.CompareValuesPrices();
            mobileProducts.TearDown();
            //utils.LogMsg("PASS");
        }

        //Cart.cs
        [TestMethod]
        [TestCategory("Verify that you cannot add more product in cart than the product available in store")]
        public void NoAddMoreProductsInCart()
        {
            cart = new Cart();
          //  utils = new Utils();

            cart.Setup();
            cart.ClickAnOption(Constants.MOBILE_LINK);
            cart.AddToCartButton();
            cart.ChangeQuantity();
            cart.ErrorMessage();
            cart.EmptyCartLink();
            cart.VerifyCartIsEmpty();
            cart.TearDown();
            //utils.LogMsg("PASS");
        }

        //Mobile.cs 2 windows.
        [TestMethod]
        [TestCategory("Verify that you are able to compare two product")]
        public void HandlingPopupWindows()
        {
            mobile.Setup();
            mobile.ClickAnOption(Constants.MOBILE_LINK);
            mobile.AddToCompareLink();
            mobile.CompareButton();
            mobile.PopUpWindows();
            mobile.TearDown();
            //utils.LogMsg("PASS");
        }

        //Television.cs
        //The idea is separate some methods of Television.cs to Account.cs
        [TestMethod]
        [TestCategory("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void Ecommerce()
        {
            television = new Television();
           // myAccountLogin = new MyAccountLogin("test@mailinator.com", "123456");

            television.Setup();
            television.ClickAnOption(Constants.ACCOUNT);
            television.MyAccountOption();
            //television.CreateAccountAndFillInfo("Yudi", "Ramos", "test@mailinator.com", "123456", "123456");
            //television.RegisterButton();
            // account.VerifyRegistionIsDone();
            television.LogIn("test@mailinator.com", "123456");
            television.ClickAnOption(Constants.TV_LINK);
            television.AddToWishListTV();
            television.ShareWishList();
            television.VerifyIfWishListIsShare();
            television.TearDown();
        }

        [TestMethod]
        [TestCategory("Verify user is able to purchase product using registered email ID.")]
        public void PurchaseProductUsingEmail()
        {
            purchaseProducts = new PurchaseProducts();

            purchaseProducts.Setup();
            purchaseProducts.ClickAnOption(Constants.ACCOUNT);
            purchaseProducts.MyAccountOption();
            purchaseProducts.LogIn("test@mailinator.com", "123456");
            //   purchaseProducts.BlockAccount();
          //  purchaseProducts.ClickAnOption(Constants.CART);
            //purchaseProducts.ClickAnOption(Constants.ACCOUNT);
            //purchaseProducts.AddToWishListTV();
            purchaseProducts.TearDown();
        }
    }
}
