using AmazonTest.Pages;
using AmazonTest.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest.Tests
{
    [TestFixture]
    internal class ToolsQATest
    {
        private IWebDriver driver;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Initialize report once before all tests
            ExtentReport.Report();
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.Amazon.in");
            string url = MyResourse.Url;
            string url2 = MyResourse.Rediff;
            driver.Navigate().GoToUrl(url2);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ToolsQAcs._ToolsQAcs(driver);
            UtilitiesClass._uitility(driver);
            ExtentReport.Report();

        }
        [Test]
        public void Test1()
        {
            ExtentTest test = ExtentReport.CreateTest("TestCase1");
            test.Log(Status.Pass, "Launch browser successfully");
            Assert.IsTrue(ToolsQAcs.NavigateToSubmitForm());
            test.Log(Status.Pass, "Navigated to submit form successfully");
            Assert.IsTrue(ToolsQAcs.SubmitForm("Shahab", "shahab.dev@gmail.com"));
            test.Log(Status.Pass, "Submit the form successfully");
            Assert.IsTrue(ToolsQAcs.ClickSubmit());
            //test.Log(Status.Pass, "Click on the submit button successfully");
        }
        [Test]
        public void Test2()
        {
            ExtentTest test = ExtentReport.CreateTest("TestCase1");
            test.Log(Status.Pass, "Launch browser successfully");
            string value=ToolsQAcs.GetPerClosevaueBSESenSex();
            Console.WriteLine(value);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Flush report after all tests
            ExtentReport.Flush();
        }


    }
}
