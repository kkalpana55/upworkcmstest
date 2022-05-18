using AventStack.ExtentReports;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace upworkcmstest.pages
{
     public class Locationspage
    {

        private IWebDriver driver;
        public Locationspage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Locations']")]
        private IWebElement locations;
        public void verifyinglocations()
        {
            ExtentTest test;

            Thread.Sleep(2000);
            menu.Click();
           
            locations.Click();
            
            String expecttitle = "Locations - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
          
            Console.WriteLine(driver.Title);

        }


    }
}
