using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using HandsOn.Utilities;
using HandsOn.Pages.Locators;
using HandsOn.Pages;

namespace HandsOn.TestCases
{
    public class UnitTest1 : Base
    {
        [Test]
        public void EndToEndFlow()
        {
            String[] expectedProd = { "iphone X", "Blackberry" };
            String[] actualProd = new string[2];

            LoginLocator loginPage = new LoginLocator(getDriver());
            //Defining reusable methods and smartly creating objects of next page
            ProductLocators prod = loginPage.validLogin("rahulshettyacademy", "learning");

            //ProductLocators productPage = new ProductLocators(getDriver());
            prod.waitForPageDisplay();

            IList<IWebElement> products = prod.getCards();

            foreach (IWebElement product in products)
            {
                //1 element will  match
                if (expectedProd.Contains(product.FindElement(prod.getCardTitle()).Text))
                {
                    //click on cart
                    product.FindElement(prod.getAddToCart()).Click();
                }
               // TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            CheckOutLocator Checkout = prod.getCheckout();

            IList<IWebElement> checkoutCards = Checkout.getCheckoutCards();

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProd[i] = checkoutCards[i].Text;
            }

            //Assert.AreEqual(expectedProd, actualProd);
            ConfirmationLocator confirmPage = Checkout.getPlaceOrderBtn();

            //driver.FindElement(By.Id("country")).SendKeys("ind");
            confirmPage.getCountryInput("Ind");

            confirmPage.waitForCountryInput();

            //driver.FindElement(By.LinkText("India")).Click();
            //driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            //driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            confirmPage.getCountrySelect();
           
            //String confirmText = driver.FindElement(By.CssSelector(".alert-success")).Text;

            //StringAssert.Contains("Success", confirmText);
        }

    }
}