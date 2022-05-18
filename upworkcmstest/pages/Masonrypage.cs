using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zu.WebBrowser.AsyncInteractions;

namespace upworkcmstest.pages
{
     public class Masonrypage
    {
        private IWebDriver driver;
        public Masonrypage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Masonry']")]
        private IWebElement masonrylayout;

        [FindsBy(How = How.XPath, Using = "//*[@id='c9']/div/div/div/div/div/div")]
        private IWebElement masonryresources;

        [FindsBy(How = How.XPath, Using = "//*[@id='c9']/div/div/div/div/div/div/a[8]")]
        private IWebElement resourcearticle8;

        public void verifyingmasonrylayout()
        {
            Thread.Sleep(2000);
            menu.Click();
            masonrylayout.Click();
            String expecttitle = "Masonry Layout - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);


        }

        public void verifymasonryresourcelinks() {

            menu.Click();
            masonrylayout.Click();

            IList<IWebElement> resource = driver.FindElements(By.XPath("//*[@id='c9']/div/div/div/div/div/div/a"));
            int numberofresources = resource.Count();
           
            Console.WriteLine("The number of resources displayed : "+resource.Count());

            System.Threading.Thread.Sleep(5000);
            for (int i = 1; i <= numberofresources; i++)
            {
               Console.WriteLine(resource[i].Text);
                

            }


        }
        public void verifyresourcearticle8()
        {
            menu.Click();
            Thread.Sleep(2000);
            masonrylayout.Click();
            OpenQA.Selenium.IJavaScriptExecutor js = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)");
            Thread.Sleep(2000);
            resourcearticle8.Click();
            string actualresult = driver.Title;
            String expectedresult = "R8 - external article(ocular.nz rightway-page)";
            Assert.AreEqual(expectedresult, actualresult);


        }
    }
}
