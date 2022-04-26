using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upworkcmstest.pages
{
    internal class Resourcemanagerpage
    {
        private IWebDriver driver;
        public Resourcemanagerpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        





    }
}
