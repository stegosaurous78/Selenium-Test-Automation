using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOn.Pages.Locators
{
    public class LoginLocator
    {
        private IWebDriver driver;
        public LoginLocator(IWebDriver driver) 
        {
            this.driver = driver;

            //page objects initialization in constructor
            PageFactory.InitElements(driver, this);
        }
     
        //Page Object Factory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement CheckBox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInBtn;

        //encapsulation used - variable is private and accessed through public method
        public IWebElement getUsername()
        {
            return username;
        }

        //Actions
        public ProductLocators validLogin(String user, String pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            CheckBox.Click();
            signInBtn.Click();

            //after sign in it will not stop exceution here, it will go to next page so we need to return the next page object
            return new ProductLocators(driver);
        }



    }
}
