using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using upworkcmstest.BaseClass;
using upworkcmstest.pages;

namespace upworkcmstest.tests
{
    [TestFixture]
    class Testcase1 : Basetest
    {[Test]
        public void testmethod()
        {
            var lp = new loginpage(driver);
            lp.login();
            

        }

    }
    } 
