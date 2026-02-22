using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest
{
    public static class ExtentReport
    {
        private static ExtentReports extent = null;
        private static ExtentSparkReporter htmlReporter = null;


        public static void Report()
        {
            string path = @"D:\Reports\" + DateTime.Now.ToString("ddMMyyyy-HHmmss") + "Report.html";
            extent = new ExtentReports();
            htmlReporter = new ExtentSparkReporter(path);
            extent.AttachReporter(htmlReporter);

        }
        // Create a test entry
        public static ExtentTest CreateTest(string testName)
        {
            return extent.CreateTest(testName);
        }

        // Flush the report to write changes
        public static void Flush()
        {
            extent.Flush();
        }

    }
}
