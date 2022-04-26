using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upworkcmstest.BaseClass
{
    internal class Basetest
    {
        public IWebDriver driver;
        [SetUp]
        public void open() {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl (" https://www.stpats.school.nz/typo3/");
               
        
        }
[TearDown]
public void Close()
        {
            driver.Quit();

        }


    }
}
