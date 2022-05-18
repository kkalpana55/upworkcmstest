﻿using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
    internal class Resourcetestcase: Basetest
    {
        ExtentReports rp = Basetest.getInstance();
        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]

        public void Tc8(string browsername)
        {
            ExtentTest test;

            test = extent.CreateTest("<h3>Resources page</h3> ").Info("<h3>Test Started in </h3>" + browsername + " <h3>browser ---->Verifying Resources Page</h3>");
            parallelbrowser(browsername);
            var lp = new Resourcespage(driver);
            lp.verifyingresources();
           
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;
            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");
        }
        
        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]

        public void Tc20(string browsername)

        {

            ExtentTest test;

            test = extent.CreateTest("<h3>Resources page</h3> ").Info("<h3>Test Started in </h3>" + browsername + " <h3>browser ---->Verifying Resources Page</h3>");
            parallelbrowser(browsername);
            var lp1 = new Resourcespage(driver);
           
            lp1.resourcedropdown();
             Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;
            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");


        }
        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]

        public void Tc21(string browsername)

        {

            ExtentTest test;

            test = extent.CreateTest("<h3>Resources page</h3> ").Info("<h3>Test Started in </h3>" + browsername + " <h3>browser ---->Verifying Resources Page</h3>");
            parallelbrowser(browsername);
            var lp2 = new Resourcespage(driver);

            lp2.verifyingpagination();
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string image = file.AsBase64EncodedString;
            test.Pass("<b><font color=green>" + "Screenshot of successful execution" + "</font></b>The Test is passed :", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            System.Diagnostics.Trace.WriteLine("PASS >>>>  " + "msg");


        }


        [TearDown]
        public void screeshotteardown()
        {
            ExtentTest test1;
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

