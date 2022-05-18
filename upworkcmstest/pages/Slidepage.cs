using BaseLibS.Util;
using com.sun.istack.@internal.logging;
using java.awt.image;
using java.lang;
using java.time;
using javax.imageio;
using Magnum.FileSystem;
using Microsoft.SqlServer.Management.SqlScriptPublish;
using Microsoft.VisualStudio.Services.Organization.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zu.WebBrowser.AsyncInteractions;
using Byte = System.Byte;
using ITakesScreenshot = OpenQA.Selenium.ITakesScreenshot;
using Thread = System.Threading.Thread;

namespace upworkcmstest.pages
{
   public class Slidepage
    {

        private IWebDriver driver;

        public Slidepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#ocular-slider-4")]
        private IWebElement slides;
        [FindsBy(How = How.XPath, Using = "//section//div//div//img")]
        private IWebElement image;

        internal string TakeScreenshot1(object bASE64)
        {
            throw new NotImplementedException();
        }

        [FindsBy(How = How.XPath, Using = "//a//img")]
        private IWebElement logoimage;
        [FindsBy(How = How.CssSelector, Using = "span.swiper-pagination-total")]
        private IWebElement numberofslides;
        [FindsBy(How = How.CssSelector, Using = "div.swiper-button-next")]
        private IWebElement nextbutton;
        [FindsBy(How = How.CssSelector, Using = "span.swiper-pagination-current")]
        private IWebElement currentslidenumber;

        [FindsBy(How = How.CssSelector, Using = "div.swiper-button-prev")]
        private IWebElement previousbutton;
        private string im1;

        public void slide()
        {
            IList<IWebElement> slideimages = driver.FindElements(By.CssSelector("div[class^='ocular-slider-slide ']"));
            int numberofslides1 = slideimages.Count();
            // Console.WriteLine(slideimages.Count());
            Console.WriteLine(numberofslides.Text);
            System.Threading.Thread.Sleep(5000);
            for (int i = 1; i <= slideimages.Count(); i++)
            {
                Console.WriteLine("Previous button is clicked");
                nextbutton.Click();
                Thread.Sleep(2000);
                Console.WriteLine("Image Height and Width:" + image.Size);
                Console.WriteLine("current slide number=" + currentslidenumber.Text);

            }
            for (int j = 1; j <= slideimages.Count(); j++)
            {
                Console.WriteLine("Next button is clicked");
                previousbutton.Click();
                Console.WriteLine("Image Height and Width:" + image.Size);
                Thread.Sleep(2000);
                Console.WriteLine("current slide number=" + currentslidenumber.Text);

                Console.WriteLine("Image Height and Width:" + logoimage.Size);
               

            }
            TakeScreenshot(driver, driver.FindElement(By.XPath("//a//img")));





        }

        public  void TakeScreenshot(IWebDriver driver, IWebElement element)
        {

            string fileName = "C:\\Users\\User\\source\\repos\\upworkcmstest\\upworkcmstest\\ExtentReports\\" + DateTime.Now.ToString("yyyy -MM-dd HH-mm-ss")+ ".jpg";
            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new System.IO.MemoryStream(byteArray));
            Rectangle croppedImage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            screenshot = screenshot.Clone(croppedImage,screenshot.PixelFormat);
            screenshot.Save(System.String.Format( fileName,ImageFormat.Png));

            return;
            
        }
        



        
    }
       
    }


    


