using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;


namespace HandsOn.Pages.Locators
{
    public class ProductLocators
    {
        IWebDriver driver;

        //This locator is a Product.FindElements type, so we need to use FindsBy
        By cardTitle = By.CssSelector(".card-title a");

        //This locator is a Product.FindElements type, so we need to use FindsBy
        By addToCart = By.CssSelector(".card-footer button");

        public ProductLocators(IWebDriver driver)
        {
            this.driver = driver;

            //page objects initialization in constructor
            PageFactory.InitElements(driver, this);
        }

        //This locator is a driver.FindElements type, so we need to use FindsBy

        //Page object factory for all phone -> app-cards
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        //Page Object Factory for Checkout link
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkout;

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getCardTitle()
        {
            return cardTitle;
        }

        public By getAddToCart()
        {
            return addToCart;
        }

        public CheckOutLocator getCheckout()
        {
            checkout.Click();
            return new CheckOutLocator(driver);
        }
    }
}
