using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99
{
    [TestClass]
    public class Mobile
    {
        public IWebDriver _driver;
        public ChromeOptions _chromeOptions;
        public WebDriverWait _wait;

        public const string MobileLink = "MOBILE";

        // MobileProducts mobileProducts = new MobileProducts();
        Cart cart = new Cart();

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
            _wait.Until(ExpectedConditions.ElementToBeClickable(mobileOption)).Click();
            Console.WriteLine("The option selected is: " + linkMobile);
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
                // _wait.Until(ExpectedConditions.ElementToBeSelected(selectSort));
                SelectElement select = new SelectElement(selectSort);

                var selectingElement = select;
                selectingElement.SelectByIndex(1);
                select = selectingElement;

                Console.WriteLine("The option selected is: " + select);

                //Take a screenshot for evidence.
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\img01.png", ScreenshotImageFormat.Png);
                Console.WriteLine("User has screenshoted.");
            }

            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //**Products**//
        [TestMethod]
        [TestCategory("Read the cost of Sony Xperia mobile")]
        public string CostOfSonyXperiaMobile()
        {
            string priceSonyXperia = _driver.FindElement(By.Id("product-price-1"))
                .Text;
            //  _wait.Until(ExpectedConditions.ElementToBeSelected(priceSonyXperia));
            Thread.Sleep(5000);
            Assert.AreEqual("$100.00", priceSonyXperia);
            Console.WriteLine("Product Value in list and details pagre should be equal " + priceSonyXperia + " dlls.");

            return priceSonyXperia;
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
                Console.WriteLine("Sony Xperia mobile has been clicked.");
            }

            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Price of description of Xperia Mobile.")]
        public string PriceDescriptionOfXperiaMobile()
        {
            string priceDescription = _driver.FindElement(By.Id("product-price-1"))
                .Text;
            Console.WriteLine("The price of description is: " + priceDescription);
            return priceDescription;
        }

        [TestMethod]
        [TestCategory("Read the Sony Xperia mobile from detail page.")]
        public void ReadMobileDetails()
        {
            IWebElement readDetailsTab = _driver.FindElement(By.CssSelector("#collateral-tabs>dd.tab-container.current>div>div"));
            //XPATH is not working for text: _driver.FindElement(By.XPath("//div[@class='tab-content']/h2")).Text;
            Console.WriteLine("The description is: " + readDetailsTab.Text);
        }

        [TestMethod]
        [TestCategory("Compare values in Step 3 and Step 5")]
        public void CompareValuesPrices()
        {
            string one = CostOfSonyXperiaMobile();
            string two = PriceDescriptionOfXperiaMobile();

            try
            {
                Assert.AreEqual(two, one);
                Console.WriteLine("The values are matching.");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //**Cart**//
        [TestMethod]
        public void AddToCartButton()
        {
            int positionItem = 1;
            IList<IWebElement> itemOption = _driver.FindElements(By.XPath("//li[@class='item last']"));
            Console.WriteLine("Total of elements: " + itemOption.Count);

            for (int countOption = 0; countOption <= itemOption.Count; countOption++)
            {
                //int numberPositionTitle = 1;
                // IList<IWebElement> titleOption = _driver.FindElements(By.ClassName("product-name"));
                if(positionItem == countOption)
                {
                    IList<IWebElement> button = _driver.FindElements(By.XPath("//button[@type='button']"));

                    for (int countButton = 0; countButton <= button.Count; countButton++)
                    {
                        //Change the number position of button (Range: 0 - 3)
                        int numberPositionButton = positionItem;

                        //Do a compare No. counted (for) and the number position of button.
                        if (countButton == numberPositionButton)
                        {
                            _wait.Until(ExpectedConditions.ElementToBeClickable(button[numberPositionButton]));
                            button[numberPositionButton].Click();
                            Console.WriteLine("User has clicked.");
                            Thread.Sleep(5000);
                        }
                    }
                }             
            }
            //Assert.AreEqual("IPHONE", titleOption[numberPositionTitle].Text);
            //Console.WriteLine("The option selected is: " + titleOption[numberPositionTitle].Text);
        }

        [TestMethod]
        [TestCategory("Change 'QTY' value to 1000 and click 'UPDATE' button.")]
        public void ChangeQuantity()
        {
            IWebElement quantity = _driver.FindElement(By.XPath("//input[@class='input-text qty']"));
            _wait.Until(ExpectedConditions.ElementToBeClickable(quantity));
            quantity.Click();
            quantity.Clear();
            quantity.SendKeys("1000");
            Console.WriteLine("Quantity changed.");

            IWebElement updateButton = _driver.FindElement(By.XPath("//*[@title='Update']"));
            _wait.Until(ExpectedConditions.ElementToBeClickable(updateButton));
            updateButton.Click();
            Console.WriteLine("Update button was clicked.");

            //Take a screenshot for evidence.
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\ErrorCart.png", ScreenshotImageFormat.Png);
            Thread.Sleep(5000);
        }

        [TestMethod]
        [TestCategory("Verify error message.")]
        public void ErrorMessage()
        {
            string message = "* The maximum quantity allowed for purchase is 500.";
            IWebElement errorMessage = _driver.FindElement(By.CssSelector("#shopping-cart-table>tbody>tr>td.product-cart-info>p"));
            Assert.AreEqual(message, errorMessage.Text);
            Console.WriteLine(message);
        }

        [TestMethod]
        [TestCategory("Click on 'EMPTY CART' link in the footer of list of all mobiles.")]
        public void EmptyCartLink()
        {
            try
            {
                IWebElement emptyCart = _driver.FindElement(By.Id("empty_cart_button"));
                _wait.Until(ExpectedConditions.ElementToBeClickable(emptyCart));
                emptyCart.Click();
                Console.WriteLine("Link clicked.");
                Thread.Sleep(5000);
            }

            catch (StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Take a screenshot for evidence.
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Leonime\Desktop\screenshot\Empty.png", ScreenshotImageFormat.Png);
            Thread.Sleep(5000);
        }

        [TestMethod]
        [TestCategory("Verify shopping cart is empty.")]
        public void VerifyCartIsEmpty()
        {
            string message = "SHOPPING CART IS EMPTY";
            IWebElement titleEmptyCart = _driver.FindElement(By.ClassName("page-title"));
            Assert.AreEqual(message, titleEmptyCart.Text);
            Console.WriteLine(message);
        }

        //**HandlingPopupWindows**//
        [TestMethod]
        [TestCategory("In mobile products list, click on 'Add To Compare' for two mobiles.")]
        public void AddToCompareLink()
        {
            int positionOne = 0;
            int positionTwo = 2;
            IList<IWebElement> positionItem = _driver.FindElements(By.XPath("//li[@class='item last']"));

            //Elements
            for(int i=0; i<=positionItem.Count; i++)
            {
                if(i == positionOne)
                {
                    //Change # position
                    int positionAddToCompare = positionOne;
                    IList<IWebElement> elementAddToCompare = _driver.FindElements(By.ClassName("link-compare"));

                    //Add to compare button.
                    for (int count = 0; count <= elementAddToCompare.Count; count++)
                    {
                        if (count == positionAddToCompare)
                        {
                            elementAddToCompare[positionAddToCompare].Click();
                            Console.WriteLine("The button was clicked. " + elementAddToCompare[positionAddToCompare]);
                            Thread.Sleep(5000);
                        }
                    }
                }

                if (i == positionTwo)
                {
                    //Change # position
                    int positionAddToCompare = positionTwo;
                    IList<IWebElement> elementAddToCompare = _driver.FindElements(By.ClassName("link-compare"));

                    //Add to compare button.
                    for (int count = 0; count <= elementAddToCompare.Count; count++)
                    {
                        if (count == positionAddToCompare)
                        {
                            elementAddToCompare[positionAddToCompare].Click();
                            Console.WriteLine("The button was clicked. " + elementAddToCompare[positionAddToCompare]);
                            Thread.Sleep(5000);
                        }
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Click on 'COMPARE' button.")]
        public void CompareButton()
        {
            IWebElement compareButton = _driver.FindElement(By.XPath("//button[@title='Compare']"));
            compareButton.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(compareButton));
        }

        [TestMethod]
        [TestCategory("Verify the pop-up window and check that the products are reflectd in it.")]
        public void PopUpWindows()
        {
            //Switch the windows.
            var windows = _driver.WindowHandles;
            foreach(string handle in windows)
            {
                Console.WriteLine("Switching to windows: " + handle);
                _driver.SwitchTo().Window(handle);
                Thread.Sleep(5000);
            }

            IWebElement compareTitle = _driver.FindElement(By.CssSelector("body>div>div.page-title.title-buttons>h1"));
            Assert.AreEqual("COMPARE PRODUCTS", compareTitle.Text);
            Console.WriteLine("Title are equals " + compareTitle.Text);

            //Compare labels.


        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
