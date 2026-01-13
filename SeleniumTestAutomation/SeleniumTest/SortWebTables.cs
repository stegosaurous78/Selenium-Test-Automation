using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTest
{
    public class SortWebTables
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
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortTables()
        {
            //dropdown is static so use "SelectElement" to create an object
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            ArrayList a = new ArrayList();

            //Step 1 : Get all vegetable into arraylist a
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in veggies)
            {
                //Add all the veggies in arraylist a
                a.Add(veggie.Text);
            }

            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }
            //Step 2 : sort arraylist a
            a.Sort();
            //Expected arraylist
            TestContext.Progress.WriteLine("After Sorting :");
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            //Go and click column get css selectors
            driver.FindElement(By.CssSelector("th[aria-label*= 'fruit name']")).Click();
            ArrayList b = new ArrayList();
            IList<IWebElement> actualveggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in actualveggies)
            {
                //Add all the veggies in arraylist a
                b.Add(veggie.Text);  //actual value
            }
            //Not working in my pc(NUnit installed -> but inside Assert class AreEqual method is not coming)
            //Assert.AreEqual(a, b);
        }

    }
}