using Humanizer.Localisation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject.OpenSDK.Internal.Rest.Messages;

namespace upworkcmstest.pages
{
   public  class Homepage
    {
        private IWebDriver driver;
        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "input[name='user']")]
        private IWebElement username;

        [FindsBy(How = How.CssSelector, Using = "input[name='pass']")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "input[name='submit']")]
        private IWebElement loginbutton;
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Ruby']")]
        private IWebElement rubyspage;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Login']")]
        private IWebElement loginmenu;
        [FindsBy(How = How.CssSelector, Using = "ul.menu ")]
        private IWebElement menulist;
        [FindsBy(How = How.CssSelector, Using = "div.logo")]
        private IWebElement logo;
        [FindsBy(How = How.CssSelector, Using = "button.sub-menu-toggle ")]
        private IWebElement submenutoggle;


        public void gettitle()
        {
            String pagetitle = driver.Title;
            String exceptedtitle = "TYPO3 CMS Login: St Patrick's College";
            Assert.AreEqual(exceptedtitle, pagetitle);
            Console.WriteLine("title matches");
            Console.WriteLine(pagetitle);
        }

        public void menuoptionlist()
        {

            Thread.Sleep(2000);
            menu.Click();
           
            IList<IWebElement> menuitems = driver.FindElements(By.XPath(("//*[@id='p1']/div[2]/header/div/div/nav/ul/li")));
            int menutotal = menuitems.Count;

            Console.WriteLine("The total number of menu items displayed are:" + menutotal);
            Console.WriteLine("The Menu displayed are:" + menulist.Text);

            if (menutotal == 8)
            {
                Assert.Pass("The Test case is passed");
               
            }

            else
                Assert.Fail("The Test case is failed");


        }
        public void menuoptionlistwithpersonallog()
        {

            Thread.Sleep(2000);
            menu.Click();
            submenutoggle.Click();
            IList<IWebElement> menuitems = driver.FindElements(By.XPath(("//*[@id='p1']/div[2]/header/div/div/nav/ul//li//a")));
            int menutotal = menuitems.Count;

            Console.WriteLine("The total number of menu items displayed are:" + menutotal);
            Console.WriteLine("The Menu displayed are:" + menulist.Text);

            if (menutotal == 10)
            {
                Assert.Pass("The Test case is passed");
            }

            else
                Assert.Fail("The Test case is failed");


        }



        public void verifyingtogglingbutton()
        {
            Thread.Sleep(2000);
            menu.Click();
            Thread.Sleep(2000);
            OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            // highlight the element with red border 3px width

            // added sleep to give little time for browser to respond
            Thread.Sleep(3000);
            //verifies whether the user is not able to submit on empty text fields //

            jse.ExecuteScript("arguments[0].style.border='3px solid red'", menu);
            menu.Click();

        }

        public void verifyinglogoblank()
        {
            menu.Click();
            Thread.Sleep(2000);
            rubyspage.Click();
            String pagetitle1 = driver.Title;
            String exceptedtitle1 = "Ruby's page - typo11";
            Assert.AreEqual(exceptedtitle1, pagetitle1);
            Console.WriteLine("Ruby's Page Title:" + pagetitle1);
            Thread.Sleep(2000);
            logo.Click();
            String pagetitle = driver.Title;
            String exceptedtitle = "Home - typo11";
            Assert.AreEqual(exceptedtitle, pagetitle);
            Console.WriteLine("On clicking Logo BLANK Home Page should be displayed:" + pagetitle);

        }

        

    }
}

