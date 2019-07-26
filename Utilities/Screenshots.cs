using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace NUnit.Tests1
{
    public class ScreenCaputres
    {
        public static Screenshot TakeSreenShot(IWebDriver context, string fileLocation)
        {
            ITakesScreenshot ts = context as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(fileLocation);
            return screenshot;
        }
        public static Screenshot TakeSreenShot(IWebDriver context, string fileLocation, Exception e)
        {
            ITakesScreenshot ts = context as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
            Console.WriteLine("Here is you the Screenshot from the Exception Given");
            Console.WriteLine(e.StackTrace);
            return screenshot;
        }

        //private ScreenCaptureJob ScreenCaptureJob
        //{
        //    get
        //    {
        //        ScreenCaptureJob video = new ScreenCaptureJob();
        //        return video;
        //    }
        //}

        ////Before WebDriver is initialized 

        //public void TakeVideo(string captureLocation)
        //{
        //    ScreenCaptureJob video = new ScreenCaptureJob();
        //    string Runname = "testVideo";

        //    //video.OutputPath = captureLocation;
        //    video.OutputScreenCaptureFileName = captureLocation + Runname + ".wmv";
        //    video.Start();



        //}

        //public void StopVideo() => ScreenCaptureJob.Stop();
        //public void DisposeVideo() => ScreenCaptureJob.Dispose();
        //string title = ScenarioContext.Current.ScenarioInfo.Title;
        //string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
        //scj.OutputScreenCaptureFileName = @"J:\Recording\"+Runname+".wmv";
        //scj.Start();

        ////After failure
        // scj.Stop();

        ////If there is no failure and if the testcase is a pass
        //scj.Dispose

    }
}
