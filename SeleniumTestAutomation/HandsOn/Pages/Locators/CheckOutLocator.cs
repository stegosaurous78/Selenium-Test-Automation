using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.Pages.Locators
{
    public class CheckOutLocator
    {
        IWebDriver driver;

        public CheckOutLocator(IWebDriver driver)
        {
            this.driver = driver;

            //page objects initialization in constructor
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]   
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-success")]
        private IWebElement placeOrderBtn;

        public IList<IWebElement> getCheckoutCards()
        {
            return checkoutCards;
        }

        public ConfirmationLocator getPlaceOrderBtn()
        {
             placeOrderBtn.Click();
             return new ConfirmationLocator(driver);   
        }

    }
}
