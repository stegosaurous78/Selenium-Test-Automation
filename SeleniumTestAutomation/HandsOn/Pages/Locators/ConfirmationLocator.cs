using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.Pages.Locators
{
    public class ConfirmationLocator
    {
        IWebDriver driver;
        public ConfirmationLocator(IWebDriver driver)
        {
            this.driver = driver;

            //page objects initialization in constructor
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id, Using ="country")]
        private IWebElement countryInput;

        [FindsBy(How=How.LinkText, Using ="India")]
        private IWebElement selectCountry;

        [FindsBy(How=How.CssSelector, Using ="label[for*='checkbox2']")]
        private IWebElement agreeCheckBox;

        [FindsBy(How=How.CssSelector, Using ="[value='Purchase']")]
        private IWebElement purchaseBtn;

        public IWebElement getCountryInput(string country)
        {
            countryInput.SendKeys(country);
            return countryInput;
        }

        public void waitForCountryInput()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

        public void getCountrySelect()
        {
            selectCountry.Click();
            agreeCheckBox.Click();
            purchaseBtn.Click();
        }
    }
}
