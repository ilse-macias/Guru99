using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Guru99
{
    public class MyAccountLogin : TestBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public MyAccountLogin(string email, string password)
        {
            Email = email;
            Password = password;
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
    }
}
