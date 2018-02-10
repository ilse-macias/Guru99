using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guru99
{
    public class PurchaseProducts : TestBase
    {
        //**MyAccountLogin.cs**//
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

        //[TestMethod]
        //public void BlockAccount()
        //{
        //   //_driver.FindElement(By.ClassName("block-content"));

        //    IWebElement ekee = _driver.FindElement(By.LinkText(Constants.MY_WISHLIST));
        //    ekee.Click();
        //    Thread.Sleep(5000);
        //}
    }
}
