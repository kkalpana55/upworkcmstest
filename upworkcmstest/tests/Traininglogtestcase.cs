using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
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
    [Parallelizable]
    internal class Traininglogtestcase:Basetest
    {
        ExtentReports rp = Basetest.getInstance();
        [Test]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void Tc11(string browsername)
        {
            ExtentTest test;

            test = extent.CreateTest("<h3>Verifying Traininglog Page</h3> ").Info("<h3>Test Started in </h3>" + browsername + " <h3>browser ---->Verifying Traininglog Page</h3>");
            parallelbrowser(browsername);
            var rp = new Personaltraininglogpage(driver);
            rp.verifyingtraininglog();
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;
            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");



        }
        [TearDown]
        public void exit()
        {
            rp.Flush();

        }


    }
}


   