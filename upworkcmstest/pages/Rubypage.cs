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
    public class Rubypage

    {

        private IWebDriver driver;
        public Rubypage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Ruby']")]
        private IWebElement rubyspage;


        public void verifyingrubypage()
        {
            Thread.Sleep(2000);
            menu.Click();
            rubyspage.Click();
            String expecttitle = "Ruby's page - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);


        }

    }
}
