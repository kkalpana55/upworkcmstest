using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upworkcmstest.BaseClass;
using upworkcmstest.pages;

namespace upworkcmstest.tests
{
    [TestFixture]
    internal class resourcetestcase1 : Basetest
    {
        [Test]
        public void resourcedocinternal()
        {
            loginpage lp = new loginpage(driver);
            Resourcemanagerpage rp = new Resourcemanagerpage(driver);
            
        }

    }
}