using NUnit.Framework.Internal;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject.Projects
{
    public class AlertActionsAutoSuggestive
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void test_Alert()
        {
            driver.FindElement(By.CssSelector("#name")).SendKeys("Sweta");  //expected
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();
            //Will show an alert popup.
            //selenium cannot work on alerts/pop uo.
            //It works with web browser only
            String AlertText = driver.SwitchTo().Alert().Text;   //actual

            driver.SwitchTo().Alert().Accept(); //Accept -> Ok/Yes
                                                //Dismiss -> No/Cancel
            String Name = "Sweta";
            StringAssert.Contains(Name, AlertText);  //check the name(expected) written in the box, is showing the same as in alert box(actual)
        }

        [Test]
        public void test_AutoSuggestivedropdowns()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("Ind");
            Thread.Sleep(3000);

            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
            }
            // TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).Text);  //will not produce "India" in the output (because we are getting the dynamically typed values in runtime)
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }

        [Test]
        public void test_Actions()
        {
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            Actions a = new Actions(driver);  //It will now work on driver related things and UI.

            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
        }
        [Test]
        public void frames()
        {
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            //Scroll :  Selenium can't scroll, use Javascript executer
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
        }

    }
}