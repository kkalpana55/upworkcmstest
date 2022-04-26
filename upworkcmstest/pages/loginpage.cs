using OpenQA.Selenium;

using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upworkcmstest.pages
{
     class loginpage
    {
        private IWebDriver driver;
        public loginpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "t3-username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "t3-password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "t3-login-submit")]
        private IWebElement loginbutton;

        public void login()
        {

            username.SendKeys("kka@gmail.com");
            password.SendKeys("12345");
            loginbutton.Click();


        }
        

    }

}

