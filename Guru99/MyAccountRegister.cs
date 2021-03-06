﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Guru99
{
    [TestClass]
    public class MyAccountRegister : TestBase
    {
        //[TestMethod]
        //[TestCategory("Click on 'My Account' link.")]
        //public void MyAccountOption()
        //{
        //    //Account
        //    IWebElement account = _driver.FindElement(By.XPath("//*[@class='skip-link skip-account']"));
        //    _wait.Until(ExpectedConditions.ElementToBeClickable(account));
        //    account.Click();
        //    Thread.Sleep(5000);

        //    //Select 'My Account' sub-option using actions.
        //    IWebElement myAccountLink = _driver.FindElement(By.CssSelector("#header-account>div>ul>li.first>a"));
        //    try
        //    {
        //        _actions.Click(myAccountLink)
        //            .Build()
        //            .Perform();

        //        //_wait.Until(ExpectedConditions.ElementToBeSelected(myAccountLink));
        //      Thread.Sleep(5000);

        //        //string myAccountLink = "My Account";
        //        //_driver.FindElement(By.LinkText(myAccountLink)).Click();
        //        //Thread.Sleep(5000);

        //        Console.WriteLine("Link clicked: " + myAccountLink);
        //    }

        //    catch (WebDriverTimeoutException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

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


            _driver.FindElement(By.XPath("//button[@title='Register']"))
                .Click();
            Thread.Sleep(5000);
            Console.WriteLine("The button has been clicked.");
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
    }
}
