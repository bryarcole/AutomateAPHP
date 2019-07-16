using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace AutomateAPHP
{
    public class Extent
    {
        ExtentReports extent = null;
        public void ExtentStart(string reportLocation)
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(reportLocation);
            extent.AttachReporter(htmlReporter);
        }
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
