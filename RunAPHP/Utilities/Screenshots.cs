using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateAPHP
{
    public class Screenshots
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

    }
}
