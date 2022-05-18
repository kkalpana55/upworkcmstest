using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upworkcmstest.pages
{
    class Loginpage
    {

        private IWebDriver driver;
        public Loginpage(IWebDriver driver)
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


    }
}
