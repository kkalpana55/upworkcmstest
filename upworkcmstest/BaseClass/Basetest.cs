using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BaseLibS.Util;
using DocumentFormat.OpenXml.Wordprocessing;
using Google.Protobuf.WellKnownTypes;
using Io.Cucumber.Messages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Management.SqlScriptPublish;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject.OpenSDK.Internal.Reporting;
using Zu.WebBrowser.AsyncInteractions;
using TestContext = NUnit.Framework.TestContext;

namespace upworkcmstest.BaseClass
{
   
    internal class Basetest
    {
            //Declaring the variables for the driver, reports, extenttest//         
        public IWebDriver driver;
      

        public static  ExtentReports extent;
        private ExtentTest test;
        public  Basetest() { }
            // Created method  for the Extent Report creation 
        public static  ExtentReports getInstance()
        {     //On condition if extent report is empty new report is generated//
            if (extent == null)

            {       // path to store the extent report//
                string reportpath = @"C:\Users\User\source\repos\upworkcmstest\upworkcmstest\ExtentReports\";
                // Creating the instance of the htmlreporter//
                var htmlReporter = new ExtentHtmlReporter(reportpath);
                extent = new ExtentReports();
                // Defining the system information in the environmental  of the extent report//
                extent.AddSystemInfo("Environment", "QA CMSTesting");
                extent.AddSystemInfo("Operating System:", "Win 10");
                extent.AddSystemInfo("HostName:", "ABCDEFG");
                extent.AddSystemInfo("UserName", "Kalpana");
                //attaching the htmlreport //
                extent.AttachReporter(htmlReporter);
                //Adding the config file//
                string extentConfigPath = @"C:\\Users\\User\\source\\repos\\upworkcmstest\\upworkcmstest\\extent-config.xml";
                //adding the configuration path to the htmlreport
                htmlReporter.LoadConfig(extentConfigPath);
                
            }// extent report will be returned
            return extent;
        }
        
        [OneTimeTearDown]
        //Method is created to flush extent report every time so that it will be created newly every time and updated//
        public void ExtentClose()
        {
            extent.Flush(); }
        
        // method for the NotImplementedexception 
        private string Capture(IWebDriver driver, object name)
        {
            throw new NotImplementedException();
        }
        // Method is created for the screeshot to take the screenshot of the application//
        public  string Getscreenshot(IWebDriver driver,string screenshotname)
        {
           // creating an instance of ITakescreenshot //
            OpenQA.Selenium.ITakesScreenshot ts = (OpenQA.Selenium.ITakesScreenshot)driver;

            //getscreenshot method is called to take the screeshot to create the image file //
            Screenshot screenshot = ts.GetScreenshot();
            // to get the location of the assembly as specified//
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            // storing the image in the path//
            string uptobinPath = path.Substring(0, path.LastIndexOf("upworkcmstest")) + "ScreenShots\\"
           + "screenshotname" + ".png";
            // to embedd the file in to report taking the half of the path (local path)//

            string localPath = new Uri(uptobinPath).LocalPath;
            // saving the file in the local path with the file extention .Png//
            screenshot.SaveAsFile(localPath,ScreenshotImageFormat.Png);
            ///path is returned //
            return localPath;
        }
        
       




// method created to initialise multiple browsers//
  public void parallelbrowser(string browsername)

{//Headless chrome browser is initialised by calling Chromeoptions//
ChromeOptions options = new ChromeOptions();
            //definint  the  headless browser//
options.AddArguments("headless", "--window-size=1920,1200");


if (browsername.Equals("Chrome"))

// if the browser=chrome chrome driver is loaded
    driver = new ChromeDriver();

// if the browser=firefox firefox driver is intialised

else if (browsername.Equals("Firefox"))


    driver = new FirefoxDriver();

            // if the browser=headless  the headless driver is intialised

            else if (browsername.Equals("headlesschrome"))

    driver = new ChromeDriver(options);
else
    driver = new FirefoxDriver();
        // go to the url//

      driver.Navigate().GoToUrl("https://client:ocular@www.typo11.dev2.ocular.co.nz/");

Thread.Sleep(2000);
            // implicit wait is used to make the driver to wait untill all the page elements are loaded//
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
           
            // to maximise the window//

            driver.Manage().Window.Maximize();

    Thread.Sleep(2000);

}      



        [TearDown]
        public void Close()
        {// to close the driver//
            driver.Quit();
            Thread.Sleep(2000); }

        [TearDown]
        public void AfterTest()
        {// report creation with the status //
            // testcontext gives the information of test ,current status will be stored in the variable status ////
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            // gets the stacktrace assocaited with the   error failure of the test//
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            // switch is used to define the different status of the test result to be displayed in the report//
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            if (test != null)
            {
                test.Log(logstatus, "Test ended with " + logstatus);
            }
        }
        //  alist of browsers are defined in the IEnumerable//
            public static IEnumerable<string> browsertorunwith()
{// list of browsers//
string[] browsers = { "Chrome", "Firefox","headlesschrome" };
// for each item in the list is iterated //
foreach (string b in browsers) {

                // browser is returned//
                yield return b; }
}





}
}