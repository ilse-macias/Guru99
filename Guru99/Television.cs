using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Guru99
{
    [TestClass]
    public class Television : BaseTestClass
    {
        [TestMethod]
        public void ClickOnTelevisionOption(string TelevisionLink)
        {
            IWebElement clickOnTelevision = _driver.FindElement(By.LinkText(TelevisionLink));
            _wait.Until(ExpectedConditions.ElementToBeClickable(clickOnTelevision));
            Console.WriteLine("The link selected is: " + TelevisionLink);
        }
        
        [TestMethod]
        public void AddToWishListTV()
        {
            int elementPosition = 1;
            IList<IWebElement> productPosition = _driver.FindElements(By.XPath("//li[@class='item last']"));

            for(int count=0; count<=productPosition.Count; count++)
            {
                if(count == elementPosition)
                {
                    IList<IWebElement> clickOnWishList = _driver.FindElements(By.ClassName("link-wishlist"));

                    for(int i=0; i<=clickOnWishList.Count; i++)
                    {
                        if(i == elementPosition)
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
    }
}
