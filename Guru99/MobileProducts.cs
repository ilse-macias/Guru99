using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Guru99
{
    [TestClass]
    public class MobileProducts : TestBase
    {
        [Description("Read the cost of Sony Xperia mobile")]
        [TestProperty("Author", "Ilse Macías")]
        [TestMethod]
        public string CostOfSonyXperiaMobile()
        {
            string priceSonyXperia = _driver.FindElement(By.Id("product-price-1"))
                .Text;
            //  _wait.Until(ExpectedConditions.ElementToBeSelected(priceSonyXperia));
            Thread.Sleep(5000);
            Assert.AreEqual("$100.00", priceSonyXperia);
            logger.Info($"Product Value in list and details pagre should be equal {priceSonyXperia} dlls.");
            return priceSonyXperia;
        }

        [Description("Click on Sony Xperia mobile.")]
        [TestProperty("Author", "Ilse Macías")]
        [TestMethod]
        public void ClickOnSonyXperia()
        {
            try
            {
                IWebElement imageSonyXperia = _driver.FindElement(By.Id("product-collection-image-1"));
                _wait.Until(ExpectedConditions.ElementToBeClickable(imageSonyXperia));
                imageSonyXperia.Click();
                logger.Info("Sony Xperia mobile has been clicked.");
            }

            catch (NoSuchElementException ex)
            {
                logger.Info(ex.Message);
            }
        }

        [Description("Price of description of Xperia Mobile.")]
        [TestProperty("Author", "Ilse Macías")]
        [TestMethod]
        public string PriceDescriptionOfXperiaMobile()
        {
            string priceDescription = _driver.FindElement(By.Id("product-price-1"))
                .Text;
            logger.Info($"The price of description is: {priceDescription}");
            return priceDescription;
        }

        [Description("Read the Sony Xperia mobile from detail page.")]
        [TestProperty("Author", "Ilse Macías")]
        [TestMethod]
        public void ReadMobileDetails()
        {
            IWebElement readDetailsTab = _driver.FindElement(By.CssSelector("#collateral-tabs>dd.tab-container.current>div>div"));
            //XPATH is not working for text: _driver.FindElement(By.XPath("//div[@class='tab-content']/h2")).Text;
            logger.Info($"The description is: {readDetailsTab.Text}");
        }

        [Description("Compare values in Step 3 and Step 5")]
        [TestProperty("Author", "Ilse Macías")]
        [TestMethod]
        public void CompareValuesPrices()
        {
            string one = CostOfSonyXperiaMobile();
            string two = PriceDescriptionOfXperiaMobile();

            try
            {
                Assert.AreEqual(two, one);
                logger.Info("The values are matching.");
            }

            catch (Exception e)
            {
                logger.Info(e.Message);
            }
        }
    }
}
