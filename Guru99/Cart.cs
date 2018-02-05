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
    public class Cart
    {
        public IWebDriver _driver;
        public ChromeOptions _chromeOptions;
        public WebDriverWait _wait;

        public const string MobileLink = "MOBILE";
        public string url = "http://live.guru99.com/index.php/";
        //Mobile mobile = new Mobile();

        [TestInitialize]
        public void Setup()
        {
            _chromeOptions = new ChromeOptions();

            _driver = new ChromeDriver(_chromeOptions);
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
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
        public void AddToCartButton()
        {
            int positionItem = 1;
            IList<IWebElement> itemOption = _driver.FindElements(By.XPath("//li[@class='item last']"));
            Console.WriteLine("Total of elements: " + itemOption.Count);

            for (int countOption = 0; countOption <= itemOption.Count; countOption++)
            {
                //int numberPositionTitle = 1;
                // IList<IWebElement> titleOption = _driver.FindElements(By.ClassName("product-name"));
                if (positionItem == countOption)
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

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}

