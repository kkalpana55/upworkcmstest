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
    public class Resourcespage
    {
        private IWebDriver driver;
        public Resourcespage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "a[title='Resouces']")]
        private IWebElement resources;

        [FindsBy(How = How.CssSelector, Using = "button.btn")]
        private IWebElement filterdropdown;
        [FindsBy(How = How.CssSelector, Using = "a#category-3.dropdown-item")]
        private IWebElement news;
        [FindsBy(How = How.CssSelector, Using = "ul.pagination.pagination-block")]
        private IWebElement pagebar;
        [FindsBy(How = How.XPath, Using = "//span[text()='next']")]
        private IWebElement nextbutton;
        [FindsBy(How = How.XPath, Using = "//span[text()='previous']")]
        private IWebElement previousbutton;
        [FindsBy(How = How.CssSelector, Using = "ul.pagination-block")]
        private IWebElement paginationbar;
        [FindsBy(How = How.XPath, Using = "//*[@id='c7']/div/div/div/div/div/div/div[2]/small")]
        private IWebElement currentpagenumber;
        public void resourcedropdown()

        {
            Thread.Sleep(2000);
            /* username.SendKeys("client");
             password.SendKeys("ocular");
             loginbutton.Click();*/

            menu.Click();
            Thread.Sleep(2000);
            resources.Click();
            filterdropdown.Click();
            news.Click();
            //Console.WriteLine(pagebar.Text);
        }



        public void verifyingresources()
        {
            Thread.Sleep(2000);
            menu.Click();
            Thread.Sleep(2000);
            resources.Click();
            String expecttitle = "Resouces - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);

        }
        public void verifyingpagination()
        {
            Thread.Sleep(2000);
            menu.Click();
            Thread.Sleep(2000);
            resources.Click();
            Thread.Sleep(2000);
            OpenQA.Selenium.IJavaScriptExecutor js = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            IList <IWebElement> totalpages= driver.FindElements(By.XPath("//div//div//div//div//ul//li[@class='active' or @class='waves-effect']"));
            
            int totalpages1=totalpages.Count();
            Console.WriteLine("Totalnumber of pages:" + totalpages1);
            //for (int i = 0; i <= totalpages1; i++)
            
                Thread.Sleep(2000);
                Console.WriteLine("Current Page number:" + currentpagenumber.Text);
                Thread.Sleep(2000);
                OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].click()", nextbutton);
                             Thread.Sleep(2000);
            Console.WriteLine("Current Page number:" + currentpagenumber.Text);
            OpenQA.Selenium.IJavaScriptExecutor jse1 = (OpenQA.Selenium.IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].click()", nextbutton);
                Thread.Sleep(2000);
            Console.WriteLine("Current Page number:" + currentpagenumber.Text);
            OpenQA.Selenium.IJavaScriptExecutor jse3 = (OpenQA.Selenium.IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].click()", previousbutton);
                Thread.Sleep(2000);
            Console.WriteLine("Current Page number:" + currentpagenumber.Text);
            OpenQA.Selenium.IJavaScriptExecutor jse4 = (OpenQA.Selenium.IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].click()", previousbutton);
                Thread.Sleep(2000);
            Console.WriteLine("Current Page number:" + currentpagenumber.Text);

        }


    }
}
