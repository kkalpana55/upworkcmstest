using AventStack.ExtentReports;
using BaseLibS.Util;
using Docker.DotNet.Models;
using Magnum.FileSystem;
using Microsoft.SqlServer.Management.SqlScriptPublish;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upworkcmstest.BaseClass;
using upworkcmstest.pages;
using Zu.WebBrowser.AsyncInteractions;
using static com.sun.corba.se.spi.orbutil.fsm.Guard;
using File = System.IO.File;
using ITakesScreenshot = OpenQA.Selenium.ITakesScreenshot;

namespace upworkcmstest.tests
{
    [TestFixture]
    [Parallelizable]
    internal class Slidertestcase : Basetest
    {
        ExtentReports rp = Basetest.getInstance();
        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void Tc10(string browsername)
        {

        ExtentTest test1;
           
            parallelbrowser(browsername);
            var rp1 = new Slidepage(driver);
            test1 = extent.CreateTest("<h3>Contact Page-Title</h3>").Info("<h3>Test Started in </h3>" + " <h3>browser ---->Verifying Contact Page Title</h3>");
            
            test1.Log(Status.Info, "I am in actual test method");
            rp1.slide();
            test1.Log(Status.Info, "The Slides are tested ");
            
                   
          

          
           
            
           /* //To load it for Selenium Extent Report
            rp1.TakeScreenshot(driver, driver.FindElement(By.XPath("//a//img")));

            //string image = file.AsBase64EncodedString;
            test1.Pass("<b><font color=Green>" + "Screenshot of passed" + "</font></b>", MediaEntityBuilder.CreateScreenCaptureFromPath("rp1.TakeScreenshot(driver, driver.FindElement(By.XPath('//a//img')))").Build());
*/
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
