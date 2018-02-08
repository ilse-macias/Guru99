using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
    public class Television
    {
        private IWebDriver _driver;
        private ChromeOptions _options;
        private WebDriverWait _wait;
        private Actions _actions;

        public const string TvLink = "TV";
        string url = "http://live.guru99.com/index.php/";

        [TestInitialize]
        public void Setup()
        {
            _options = new ChromeOptions();
            _driver = new ChromeDriver(_options);
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        ///*** Account.cs ***///
        [TestMethod]
        [TestCategory("Click on 'My Account' link.")]
        public void MyAccountOption()
        {
            //Account
            IWebElement account = _driver.FindElement(By.XPath("//*[@class='skip-link skip-account']"));
            _wait.Until(ExpectedConditions.ElementToBeClickable(account));
            account.Click();
            Thread.Sleep(5000);

            //Select 'My Account' sub-option using actions.
            IWebElement myAccountLink = _driver.FindElement(By.CssSelector("#header-account>div>ul>li.first>a"));
            try
            {
                _actions.Click(myAccountLink)
                    .Build()
                    .Perform();

                //_wait.Until(ExpectedConditions.ElementToBeSelected(myAccountLink));
                Thread.Sleep(5000);

                //string myAccountLink = "My Account";
                //_driver.FindElement(By.LinkText(myAccountLink)).Click();
                //Thread.Sleep(5000);

                Console.WriteLine("Link clicked: " + myAccountLink);
            }

            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Click 'Create Account' link and fill 'New User' information except 'Email ID'.")]
        public void CreateAccountAndFillInfo(string firstName, string lastName, string email, string password, string confirmPassword)
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
            IWebElement firstNameField = _driver.FindElement(By.Id("firstname"));
            firstNameField.SendKeys(firstName);
            //_wait.Until(ExpectedConditions.ElementExists(By.Id("firstname")));
            Thread.Sleep(5000);
            Console.WriteLine("First Name: " + firstNameField.GetAttribute("value"));

            IWebElement lastNameField = _driver.FindElement(By.Id("lastname"));
            lastNameField.SendKeys(lastName);
            //_wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lastname")));
            Thread.Sleep(5000);
            Console.WriteLine("Last Name: " + lastNameField.GetAttribute("value"));

            IWebElement emailField = _driver.FindElement(By.Id("email_address"));
            emailField.SendKeys(email);
            Console.WriteLine("Email: " + emailField.GetAttribute("value"));

            IWebElement passwordField = _driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);
            //_wait.Until(ExpectedConditions.ElementExists(By.Id("password")));
            Thread.Sleep(5000);
            Console.WriteLine("Password: " + passwordField.GetAttribute("value"));

            IWebElement confirmPasswordField = _driver.FindElement(By.Id("confirmation"));
            confirmPasswordField.SendKeys(confirmPassword);
            Thread.Sleep(5000);
            Console.WriteLine("Confirm password: " + confirmPasswordField.GetAttribute("value"));
        }

        [TestMethod]
        public void RegisterButton()
        {
            _driver.FindElement(By.XPath("//button[@title='Register']"))
                   .Click();
            Console.WriteLine("The button has been clicked.");
            Thread.Sleep(5000);
        }

        [TestMethod]
        public void VerifyRegistionIsDone()
        {

            IWebElement failMessage = _driver.FindElement(By.ClassName("error-msg"));
            // IWebElement successMessage = _driver.FindElement(By.ClassName("success-msg"));

            if (failMessage.Displayed)
            {
                Console.WriteLine("Message: " + failMessage.Text);
                Thread.Sleep(5000);
            }

            //if(successMessage.Displayed)
            //{
            //    Console.WriteLine("Message: " + successMessage.Text);
            //    Thread.Sleep(5000);
            //}
        }

        [TestMethod]
        public void LogIn(string email, string password)
        {
            _driver.FindElement(By.Id("email"))
                   .SendKeys(email);
            Console.WriteLine("Email: " + email);
            Thread.Sleep(5000);
          
            _driver.FindElement(By.Id("pass"))
                .SendKeys(password);
            Thread.Sleep(5000);

            _driver.FindElement(By.Id("send2"))
                .Click();
            Console.WriteLine("The botton was clicked.");
            Thread.Sleep(5000);
        }

        ///**Television***///
        [TestMethod]
        public void ClickOnTelevisionOption(string TelevisionLink)
        {
            IWebElement clickOnTelevision = _driver.FindElement(By.LinkText(TvLink));
            _wait.Until(ExpectedConditions.ElementToBeClickable(clickOnTelevision));
            clickOnTelevision.Click();
            Console.WriteLine("The link selected is: " + TvLink);
        }

        [TestMethod]
        public void AddToWishListTV()
        {
            int elementPosition = 1;
            IList<IWebElement> productPosition = _driver.FindElements(By.XPath("//li[@class='item last']"));

            for (int count = 0; count <= productPosition.Count; count++)
            {
                if (count == elementPosition)
                {
                    IList<IWebElement> clickOnWishList = _driver.FindElements(By.ClassName("link-wishlist"));

                    for (int i = 0; i <= clickOnWishList.Count; i++)
                    {
                        if (i == elementPosition)
                        {
                            _wait.Until(ExpectedConditions.ElementToBeClickable(clickOnWishList[elementPosition]));
                            clickOnWishList[elementPosition].Click();
                            Console.WriteLine("Botton clicked");
                            Thread.Sleep(5000);
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void ShareWishList()
        {
            _driver.FindElement(By.Name("save_and_share"))
                .Click();
            Thread.Sleep(5000);

            //Sharing information
            _driver.FindElement(By.Name("emails"))
                .SendKeys("test@mailinator.com");
            Thread.Sleep(5000);
            
            _driver.FindElement(By.Id("message"))
                .SendKeys("Hello World");
            Thread.Sleep(5000);

            _driver.FindElement(By.XPath("//button[@title='Share Wishlist']"))
                .Click();
        }

        [TestMethod]
        public void VerifyIfWishListIsShare()
        {
            string message = "Your Wishlist has been shared.";
            IWebElement shareMessage = _driver.FindElement(By.ClassName("success-msg"));

            Assert.AreEqual(message, shareMessage.Text);
            Console.WriteLine("The message are matcheables.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}