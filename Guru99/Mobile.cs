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
        private IWebDriver _driver;
        private ChromeOptions _chromeOptions;
        private WebDriverWait _wait;

        public const string MobileLink = "MOBILE";
        string url = "http://live.guru99.com/index.php/";
        //MobileProducts mobileProducts = new MobileProducts();

        Cart cart = new Cart();

        [TestInitialize]
        public void Setup()
        {
          //  Cart cart = new Cart();
            _chromeOptions = new ChromeOptions();
            _driver = new ChromeDriver(_chromeOptions);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
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
