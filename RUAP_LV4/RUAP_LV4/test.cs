using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demowebshop.tricentis.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheTest()
        {
            Random rnd = new Random();
            int i = rnd.Next(1,100);
            string j = "mmm" + i + "@mmm.mm";
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            Console.WriteLine(i);
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.LinkText("Register")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("gender-male")));
            driver.FindElement(By.Id("gender-male")).Click();
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys("hhh");
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("hhh");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(j);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register-button")));
            driver.FindElement(By.Id("register-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-1.register-continue-button")));
            driver.FindElement(By.CssSelector("input.button-1.register-continue-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log out")));
            driver.FindElement(By.LinkText("Log out")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log in")));
            driver.FindElement(By.LinkText("Log in")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(j);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.button-1.login-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body")));
            driver.FindElement(By.CssSelector("body")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Notebooks")));
            driver.FindElement(By.LinkText("Notebooks")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[alt=\"Picture of 14.1-inch Laptop\"]")));
            driver.FindElement(By.CssSelector("img[alt=\"Picture of 14.1-inch Laptop\"]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("add-to-cart-button-31")));
            driver.FindElement(By.Id("add-to-cart-button-31")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-1.cart-button")));
            driver.FindElement(By.CssSelector("input.button-1.cart-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("termsofservice")));
            driver.FindElement(By.Id("termsofservice")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("checkout")));
            driver.FindElement(By.Id("checkout")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("BillingNewAddress_City")));
            driver.FindElement(By.Id("BillingNewAddress_City")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_City")).SendKeys("city");
            driver.FindElement(By.Id("BillingNewAddress_Address1")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).SendKeys("add");
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).SendKeys("12365");
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).SendKeys("123654");
            //driver.FindElement(By.CssSelector("input.button-1.new-address-next-step-button")).Click();
            new SelectElement(driver.FindElement(By.Id("BillingNewAddress_CountryId"))).SelectByText("United States");
            new SelectElement(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("BillingNewAddress_StateProvinceId")))).SelectByText("Georgia");
            driver.FindElement(By.CssSelector("input.button-1.new-address-next-step-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#shipping-buttons-container > input.button-1.new-address-next-step-button")));
            driver.FindElement(By.CssSelector("#shipping-buttons-container > input.button-1.new-address-next-step-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-1.shipping-method-next-step-button")));
            driver.FindElement(By.CssSelector("input.button-1.shipping-method-next-step-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-1.payment-method-next-step-button")));
            driver.FindElement(By.CssSelector("input.button-1.payment-method-next-step-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-1.payment-info-next-step-button")));
            driver.FindElement(By.CssSelector("input.button-1.payment-info-next-step-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log out")));
            driver.FindElement(By.LinkText("Log out")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
