//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System.Threading;

//namespace Guru99
//{
//    [TestClass]
//    public class Guru99
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
//        [TestCategory("Verify the title of the page.")]
//        public void TitleOfThePage()
//        {
//            var title = _driver.FindElement(By.ClassName("page-title"))
//                .Text;
//            Console.WriteLine("The title is: " + title);
//            Assert.AreEqual("THIS IS DEMO SITE FOR   ", title);
//            Thread.Sleep(5000);
//            //_wait.Until(ExpectedConditions.TitleContains(Convert.ToString(title)));
//        }

//        [TestMethod]
//        [TestCategory("Click on 'Mobile' option of the menu.")]
//        public void MobileSection()
//        {
//            //Click on "Mobile" option of menu.
//            IWebElement mobileOption = _driver.FindElement(By.LinkText("MOBILE"));
//            Thread.Sleep(5000);
//            // _wait.Until(ExpectedConditions.UrlToBe("http://live.guru99.com/index.php/mobile.html"));

//            mobileOption.Click();
//            Thread.Sleep(5000);

//            //Verify the title.
//            try
//            {
//                var title = _driver.FindElement(By.XPath("//div[@class='page-title category-title']"))
//                    .Text;
//                Console.WriteLine("The title is: " + title);
//                Assert.AreEqual("MOBILE", title);
//            }

//            catch (NoSuchElementException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//            Thread.Sleep(5000);

//            //Sort by.
//            var selectSort = _driver.FindElement(By.XPath("//select[@title='Sort By']"));
//            SelectElement select = new SelectElement(selectSort);
//            select.SelectByIndex(1);
//            Thread.Sleep(5000);
//        }

//        [TestCleanup]
//        public void TearDown()
//        {
//            _driver.Close();
//            _driver.Quit();
//        }
//    }
//}
