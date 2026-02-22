using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest.Utilities
{
    internal class UtilitiesClass
    {
        private static IWebDriver driver = null;

        public static void _uitility(IWebDriver _driver)
        {
            if (driver == null)
            {
                driver = _driver;

            }
        }
        public static void TakeScreenShot()
        {
            string filePath = @"D:\Screenshots\"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);

        }
        public static bool ClickwebElement(IWebElement element, double timeout, int retries = 3)
        {
            bool retval = false;
            try
            {

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

                try
                {

                    if (!element.Displayed)
                    {
                        Actions action = new Actions(driver);
                        action.MoveToElement(element).Perform();
                    }
                }
               
                catch (Exception)
                {
                    wait.Until(drv => js.ExecuteScript("return document.readystate").Equals("Complete"));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
                    retval = true;
                }
                try
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                    retval = true;
                }
                catch (Exception)
                { 
                
                }

            }
            catch (ElementClickInterceptedException)
            {
                if (0 < retries)
                {
                    return ClickwebElement(element, timeout, retries: retries - 1);

                }

            }
           
            catch (NoSuchElementException)
            {
                //test.Log(Status.Info, "Clicking the web element failed - no such element.");
            }
            catch (StaleElementReferenceException)
            {
                // retry the click if any retries are left
                if (0 < retries)
                {
                   // test.Log(Status.Info, "Clicking the web element failed - element is stale (trying again).");
                    // try again
                    return ClickwebElement(element, timeout, retries: retries - 1);
                }
            }
            catch (WebDriverTimeoutException)
            {
               //test.Log(Status.Info, "Clicking the web element failed - a timeout occurred.");
            }

            return retval;

        }
    }
}
