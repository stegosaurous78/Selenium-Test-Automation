using OpenQA.Selenium;
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
            PageFactory.InitElements(driver, this);
        }

        //Page Object Factory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;
        //encapsulation used - variable is private and accessed through public method
        public IWebElement getUsername()
        {
            return username; 
        }


    }
}
