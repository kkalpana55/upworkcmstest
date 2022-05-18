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
    public class Newspage
    {

        private IWebDriver driver;
        public Newspage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title='News']")]
        private IWebElement newsmenu;
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.XPath, Using = "//*[@id='news-container-29']/ul/li[1]/a/div/div[3]/span")]
        private IWebElement newarticletest1;

        [FindsBy(How = How.XPath, Using = "//*[@id='news-container-29']/ul/li[2]/a/div/div[3]/span")]
        private IWebElement newarticletest2;

        public void verifyingnews()
        {
            Thread.Sleep(2000);
            menu.Click();
            newsmenu.Click();
            String expecttitle = "News - typo12";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);

        }

        public void verifyreadmorearticle1() {

            Thread.Sleep(2000);
            menu.Click();
            newsmenu.Click();
            Thread.Sleep(2000);
            newarticletest1.Click();
            String expecttitle = "News Article Test 1 - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);
        }
        public void verifyreadmorearticle2()
        {

            Thread.Sleep(2000);
            menu.Click();
            newsmenu.Click();
            Thread.Sleep(2000);
            newarticletest2.Click();
            String expecttitle = "News Test 2 - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);
        }


    }
}
