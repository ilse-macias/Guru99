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
        //MyAccountLogin myAccountLogin;
        //   Menu menu;

        // MyAccountRegister account = new MyAccountRegister();

        //Mobile.cs
        [TestMethod]
        [TestCategory("Verify item in Mobile List page can be sorted by 'Name'.")]
        public void VerifyAndSortByName()
        {
            mobile = new Mobile();
            //menu = new Menu();

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

            mobileProducts.Setup();
            mobileProducts.ClickAnOption(Constants.MOBILE_LINK);
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
            cart.ClickAnOption(Constants.MOBILE_LINK);
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
            mobile.ClickAnOption(Constants.MOBILE_LINK);
            mobile.AddToCompareLink();
            mobile.CompareButton();
            mobile.PopUpWindows();
            mobile.TearDown();
        }

        //Television.cs
        //The idea is separate some methods of Television.cs to Account.cs
        [TestMethod]
        [TestCategory("Verify you can create account in E-commerce site and can share wishlist to other people using email.")]
        public void Ecommerce()
        {
            television = new Television();
           // myAccountLogin = new MyAccountLogin();

            television.Setup();
            television.ClickAnOption(Constants.ACCOUNT);
            television.MyAccountOption();
            //television.CreateAccountAndFillInfo("Yudi", "Ramos", "test@mailinator.com", "123456", "123456");
            //television.RegisterButton();
            //account.VerifyRegistionIsDone();
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
           // television.AddToWishListTV();
        }
    }
}
