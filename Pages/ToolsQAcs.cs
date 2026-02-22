using AmazonTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AmazonTest.Pages
{
    internal static class ToolsQAcs
    {
        private static IWebDriver driver = null;
        private static readonly By firstName = By.CssSelector("#firstName");
        private static readonly By lastName = By.CssSelector("#lastName");
        private static readonly By emailID = By.CssSelector("#userEmail");
        private static readonly By gender = By.CssSelector("#gender-radio-1");
        private static readonly By userName = By.CssSelector("#userNumber");
        private static readonly By dateOfbirth = By.CssSelector("#dateOfBirthInput");
        private static readonly By subJect = By.CssSelector("#subjectsInput");
        private static readonly By hobbies = By.CssSelector("#hobbies-checkbox-1");
        private static readonly By currentAdd = By.CssSelector("#currentAddress");
        private static readonly By fileUpload = By.CssSelector("##uploadPicture");
        private static readonly By ddlState = By.CssSelector("#react-select-3-input");
        private static readonly By dllcity = By.CssSelector("#react-select-4-input");
        private static readonly By btnsubmit = By.CssSelector("#submit");
        private static readonly By txtForms = By.XPath("(//div[@class='card-body'])[2]/h5");
        private static readonly By txtPForm = By.XPath("//span[text()='Practice Form']");

        public static void _ToolsQAcs(IWebDriver _driver)
        {
            if (driver == null)
                driver = _driver;
        }
        public static bool SubmitForm(string _fistName, string _emailId,string _lastname="")
        {
            try
            {
                driver.FindElement(firstName).SendKeys(_fistName);
                driver.FindElement(lastName).SendKeys(_lastname);
                driver.FindElement(emailID).SendKeys(_emailId);
                UtilitiesClass.TakeScreenShot();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
        }
        public static bool NavigateToSubmitForm()
        {
            IWebElement txtFormsweb = driver.FindElement(txtForms);
           
            Assert.IsTrue(UtilitiesClass.ClickwebElement(txtFormsweb, 10));
            IWebElement txtpFormsweb = driver.FindElement(txtPForm);
            Assert.IsTrue(UtilitiesClass.ClickwebElement(txtpFormsweb, 10));
            // Wait until the element is clickable
            /*  WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              IWebElement txtForm = wait.Until(ExpectedConditions.ElementToBeClickable(txtForms));
              ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", txtForm);

              WebDriverWait waitforPform = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              IWebElement txtPerForm = waitforPform.Until(ExpectedConditions.ElementToBeClickable(txtPForm));
              ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", txtPerForm);*/
            UtilitiesClass.TakeScreenShot();
            return true;

        }
        public static bool ClickSubmit()
        {
            try
            {
                // Wait until the element is clickable
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(btnsubmit));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitButton);
                // Move to element (hover/scroll into view)
                //Utilities.moveToElement(btnsubmit);

                // Click
                //submitButton.Click();
                UtilitiesClass.TakeScreenShot();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string GetPerClosevaueBSESenSex()
        {
            string retVal = null;
            IList<IWebElement> list=driver.FindElements(By.XPath("//table[@id='dataTable']//tr"));
            for (int i = 0; i < list.Count; i++)
            {
                string name = driver.FindElement(By.XPath("//table[@id='dataTable']/tbody/tr[1]/td[1]")).Text;
                if (name == "BSE Sensex")
                {
                    string value = driver.FindElement(By.XPath("//table[@id='dataTable']/tbody/tr[1]/td[2]")).Text;
                    retVal = value;

                }
            }
            return retVal;
        }


    }
}
