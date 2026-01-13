using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTest
{
    public class FunctionalTest
    {

        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void StaticDropdown()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            //Use "SelectElement" when the dropdown is static
            SelectElement s = new SelectElement(dropdown);
            dropdown.Click();
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(1);
        }
        [Test]
        public void RadioButtons()
        {
            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio"));
            foreach(IWebElement radio in rdos)
            {
                if (radio.GetAttribute("value").Equals("user"))
                {
                    radio.Click();
                }
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementToBeClickable(By.Id("okayBtn")));

            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean results = driver.FindElement(By.Id("usertype")).Selected;
            Assert.That(results, Is.True);
            TestContext.Progress.WriteLine("Passed");
        }

    }
}
