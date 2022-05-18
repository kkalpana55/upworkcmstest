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
    public class Personaltraininglogpage
    {
        private IWebDriver driver;
        public Personaltraininglogpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;

        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Personal']")]
        private IWebElement personaltraininglog;

        [FindsBy(How = How.CssSelector, Using = "button.sub-menu-toggle ")]
        private IWebElement submenutoggle;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>ul>li>a[title^='Four']")]
        private IWebElement fourcolumntestpage;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>ul>li>a[title^='Tile']")]
        private IWebElement tiletestpage;

        public void verifyingtraininglog()
        {
            Thread.Sleep(2000);
            menu.Click();
            personaltraininglog.Click();
            String expecttitle = "Personal Training Log - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);
            menu.Click();
            Thread.Sleep(2000);
            submenutoggle.Click();
            fourcolumntestpage.Click();
            String expectitle = "Four column test page - typo11";
            Assert.AreEqual(expectitle, driver.Title);
            Console.WriteLine(driver.Title);
            menu.Click();
            Thread.Sleep(2000);
            submenutoggle.Click();
            Thread.Sleep(2000);
            tiletestpage.Click();
            String expectitle1 = "Tile test page - typo11";
            Assert.AreEqual(expectitle1, driver.Title);
            Console.WriteLine(driver.Title);

        }


    }
}
