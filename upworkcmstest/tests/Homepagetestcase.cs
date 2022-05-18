using AventStack.ExtentReports;
using Docker.DotNet.Models;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Threading;
using upworkcmstest.BaseClass;
using upworkcmstest.pages;

namespace upworkcmstest.tests
{
    [TestFixture]
    [Parallelizable]
     class Homepagetestcase : Basetest
    {

        ExtentReports rp = Basetest.getInstance();
        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]

        public void Tc2(string browsername)
        {
            ExtentTest test = null;

            test = extent.CreateTest("<h3> Verifying on clicking the Menu option should display all the pages<h3>").Info("<h3>Test Started in </h3>" + browsername+"Browser" );
            parallelbrowser(browsername);
            test.Log(Status.Info, "The test case started:");
            var lp = new Homepage(driver);
            lp.menuoptionlist();
            test.Log(Status.Info, "The Menu should be displayed");
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;

            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");

        }
        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]

        public void Tc5(string browsername)
        {
            ExtentTest test = null;

            test = extent.CreateTest("<h3> Verifying on clicking the Menu option should display all the pages with submenu of personnal Training Log<h3>").Info("<h3>Test Started in </h3>" + browsername +"Browser");
            test.Log(Status.Info, "The test case started:");
            parallelbrowser(browsername);
            var lp = new Homepage(driver);
            
            lp.menuoptionlistwithpersonallog();
            test.Log(Status.Info, "The Menu should be displayed");
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;
            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");

        }




        [Test]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void Tc3(string browsername)
        {
            ExtentTest test = null;
            test = extent.CreateTest("<h3>Verifyingtogglingbutton</h3>").Info("<h3>Test Started in</h3> " + browsername + "<h3>browser---------->Verifying Toggling Button</h3>");
            parallelbrowser(browsername);
            var lp = new Homepage(driver);
            string screenshotpath = Getscreenshot(driver, "screenshot2");

            lp.verifyingtogglingbutton();
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;

            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");


        }



        [Test]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void Tc4(string browsername)
        {
            ExtentTest test = null;
            test = extent.CreateTest("<h3>Verifyinglogoblank</h3>").Info("<h3>Test Started in </h3>" + browsername + "<h3>browser-------->Verifying Logo Blank</h3>");
            parallelbrowser(browsername);
            var lp = new Homepage(driver);

            lp.verifyinglogoblank();
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;

            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");

        }


        [TearDown]
        public void screeshotteardown()
        {
            ExtentTest test1 = null;
            test1 = extent.CreateTest("<h3>Contact Page-Title</h3>").Info("<h3>Test Started in </h3>" + " <h3>browser ---->Verifying Contact Page Title</h3>");
            if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
                string image = file.AsBase64EncodedString;
                ExtentTest extentTest = test1.Fail("<b><font color=green>" + "Screenshot of Pass" + "</font></b>" + NUnit.Framework.TestContext.CurrentContext.Result.StackTrace + NUnit.Framework.TestContext.CurrentContext.Result.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());



            }
            else if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != ResultState.Failure)
            {
                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
                string image = file.AsBase64EncodedString;
                ExtentTest extentTest = test1.Pass("<b><font color=green>" + "Screenshot of Pass" + "</font></b>" + NUnit.Framework.TestContext.CurrentContext.Result.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());

            }

        }





        [TearDown]
        public void exit()
        {
            rp.Flush();

        }
    }
}