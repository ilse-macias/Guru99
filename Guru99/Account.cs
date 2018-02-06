using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
    public class Account
    {
        private IWebDriver _driver;
        private ChromeOptions _options;
        private WebDriverWait _wait;
        private Actions _action;

        string url = "http://live.guru99.com/index.php/";

        [TestInitialize]
        public void Setup()
        {
            _options = new ChromeOptions();
            _driver = new ChromeDriver(_options);
            _action = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]
        [TestCategory("Click on 'My Account' link.")]
        public void MyAccountOption()
        {
            //Account
            IWebElement account = _driver.FindElement(By.XPath("//*[@class='skip-link skip-account']"));
            //_action.MoveToElement(account).Perform();
            _wait.Until(ExpectedConditions.ElementToBeClickable(account));
            account.Click();
            Thread.Sleep(5000);

            //My Account
            IWebElement myAccount = _driver.FindElement(By.CssSelector("#header-account>div>ul>li.first>a"));
            try
            {
                // _wait.Until(ExpectedConditions.ElementToBeSelected(myAccount));
                Thread.Sleep(15000);
                myAccount.Click();
            }

            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Click 'Create Account' link and fill 'New User' information except 'Email ID'.")]
        public void CreateAccountAndFillInfo()
        {
            try
            {
                IWebElement createAnAccountButton = _driver.FindElement(By.CssSelector("#login-form>div>div.col-1.new-users>div.buttons-set>a"));
               // _wait.Until(ExpectedConditions.ElementToBeClickable(createAnAccountButton));
                createAnAccountButton.Click();
            }

            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Fill all fields.
            IWebElement firstName = _driver.FindElement(By.Id("firstname"));
            firstName.SendKeys("Brain");
            //_wait.Until(ExpectedConditions.ElementExists(By.Id("firstname")));
            Thread.Sleep(5000);
            Console.WriteLine("First Name: " + firstName.GetAttribute("value"));

            IWebElement lastName = _driver.FindElement(By.Id("lastname"));
            lastName.SendKeys("Regan");
            //_wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lastname")));
            Thread.Sleep(5000);
            Console.WriteLine("Last Name: " + lastName.GetAttribute("value"));

            IWebElement email = _driver.FindElement(By.Id("email_address"));
            email.SendKeys("test@mailinator.com");
            Console.WriteLine("Email: " + email.GetAttribute("value"));

            IWebElement password = _driver.FindElement(By.Id("password"));
            password.SendKeys("123456");
            //_wait.Until(ExpectedConditions.ElementExists(By.Id("password")));
            Thread.Sleep(5000);
            Console.WriteLine("Password: " + password.GetAttribute("value"));

            IWebElement confirmPassword = _driver.FindElement(By.Id("confirmation"));
            confirmPassword.SendKeys("123456");
            Thread.Sleep(5000);
            Console.WriteLine("Confirm password: " + confirmPassword.GetAttribute("value"));
        }

        [TestMethod]
        public void RegisterButton()
        {
            _driver.FindElement(By.XPath("//button[@title='Register']"))
                   .Click();
            Console.WriteLine("The button has been clicked.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
