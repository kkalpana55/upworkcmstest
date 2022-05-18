using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Microsoft.Scripting.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Runtime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using upworkcmstest.BaseClass;
using upworkcmstest.pages;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace upworkcmstest.tests
{
    [TestFixture]
    [Parallelizable]
     class Contacttestpage:Basetest
    { ExtentReports rp= Basetest.getInstance();
        [Test ,Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void testcaseverifyingcontactpagetitle(string browsername)
        {
            
            parallelbrowser(browsername);
           
            var lp = new Contactpage(driver);
            lp.verifyingcontact();
           
        }

        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void testcaseverifyingtextfieldisenabled(string browsername)
        {
           

            parallelbrowser(browsername);
            var lp1 = new Contactpage(driver);
            lp1.verifyingtextfield_isenabled();

            
        }

        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void testcaseverifyingcontactformwithemptyfields(string browsername)
        {
                     

            parallelbrowser(browsername);
            var lp2 = new Contactpage(driver);
          lp2.verifyingcontactformwithemptyfields();
          

        }
                [Test,Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void testcaseverifyinguserid(string browsername)
        {
            ExtentTest test = null;

            parallelbrowser(browsername);
            var lp2 = new Contactpage(driver);
            lp2.verifyinguserid();


        }
        [Test, Category("Regression Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void testcaseverifyingsearch(string browsername)
        {
            ExtentTest test = null;


            parallelbrowser(browsername);
            var lp4 = new Contactpage(driver);
            lp4.verifyingsearch();

                    }
        
       
       [TearDown]
       [Obsolete]
        public void screeshotteardown()
        {
                       
            ExtentTest test1;
            string browsername = NUnit.Framework.TestContext.CurrentContext.Test.Arguments[0] as string;
            string methodname= NUnit.Framework.TestContext.CurrentContext.Test.MethodName as string;
           string resultmessage= NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Site.ToString();
             test1 = extent.CreateTest("<h3>Contact Page-Title</h3>").Info(methodname+"<h5>Started in </h5>" +browsername);
            
             test1.Log(Status.Info, "The title of the Contact page is verified."+resultmessage);

            



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
        public void exit() {
            rp.Flush();

        }
    }
}


   
    
      