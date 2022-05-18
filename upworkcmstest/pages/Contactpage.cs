using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using upworkcmstest.BaseClass;
using Zu.WebBrowser.AsyncInteractions;

namespace upworkcmstest.pages
{
     public class Contactpage
    {
        private IWebDriver driver;
        public Contactpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Contact']")]
        private IWebElement contact;
        [FindsBy(How = How.XPath, Using = "//input[@id='contactSimple-13-name']")]
        private IWebElement contactname;
        [FindsBy(How = How.XPath, Using = "//input[@id='contactSimple-13-email']")]
        private IWebElement contactemail;
        [FindsBy(How = How.XPath, Using = "//textarea[@id='contactSimple-13-message']")]
        private IWebElement contactmessage;
        [FindsBy(How = How.CssSelector, Using ="button.btn.btn-primary")]
        private IWebElement contactsubmit;
        [FindsBy(How = How.XPath, Using = "//*[@id='contactSimple-13']/div[2]/div/span")]
        private IWebElement mandatoryname;
        [FindsBy(How = How.XPath, Using = "//*[@id='contactSimple-13']/div[3]/div/span")]
        private IWebElement mandatoryemail;
        [FindsBy(How = How.XPath, Using = "//*[@id='contactSimple-13']/div[4]/div/span")]
        private IWebElement mandatorymessage;
        [FindsBy(How = How.XPath, Using = "//*[@id='topBar']/div/div/div[2]/div/p")]
        private IWebElement useremail;
        [FindsBy(How = How.CssSelector, Using = "div.search-toggle.mobile-toggle.d-flex.d-lg-none")]
        private IWebElement searchtog;
        [FindsBy(How = How.XPath, Using = "//header//form//span//input[@type='submit'] ")]
        private IWebElement searchsubmit;
        [FindsBy(How = How.CssSelector, Using = "input[id='ke_search_sword'] ")]
        private IWebElement searchtext;
        
        public void verifyingcontact()
        {

            Thread.Sleep(2000);
           
            menu.Click();
            contact.Click();
           
            String expecttitle = "Contact - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);
            


        }

        public void verifyingtextfield_isenabled()
        {

            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            //verifies whether the textbox is enabled to type the text//
            Assert.AreEqual(true, contactname.Enabled);
            Assert .AreEqual(true, contactemail.Enabled);
            Assert.AreEqual(true, contactmessage.Enabled);

            Console.WriteLine("All the text fields are enabled");

        }
        public void verifyingcontactformwithemptyfields()
        {

            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            // highlight the element with red border 3px width
            
            // added sleep to give little time for browser to respond
            Thread.Sleep(3000);
            //verifies whether the user is not able to submit on empty text fields //
            contactname.SendKeys("");
            contactemail.SendKeys("");
            contactmessage.SendKeys("");
            contactsubmit.Click();
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", contactname);
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", contactemail);
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", contactmessage);
            Console.WriteLine("Name:"+mandatoryname.Text);
            Console.WriteLine("Email:" + mandatoryemail.Text);
            Console.WriteLine("Message:" + mandatorymessage.Text);
        }
        
        
        //failed test case -the element is highlighted by rectangle box //
        public void verifyinguserid()
        {

            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            // highlight the element with red border 3px width

            // added sleep to give little time for browser to respond
            Thread.Sleep(3000);
            //verifies whether the user is not able to submit on empty text fields //
            
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", useremail);
            
            String exceptedtitle = "kk@gmail.com";
            Assert.AreEqual(exceptedtitle, useremail.Text);
            Console.WriteLine("The useremail displayed is wrong");
            
        }


        public void verifyingsearch()
        {
            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            OpenQA.Selenium.IJavaScriptExecutor js = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", searchtog);
           //By using sendkeys() enters the value in the search text box//.//
            searchtext.SendKeys("abcv");

            string val = searchtext.GetAttribute("value");
           int size=val.Length;

            searchsubmit.Click();
            if (size < 3)

            {
                Assert.Fail( "please enter the more characteres");

                Console.WriteLine("Please enter the characters greater than 3");
            }
            else
            {
                Assert.True(true,"success");
                Console.WriteLine("success");
            }
        }

        }


    }

