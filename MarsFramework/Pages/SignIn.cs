using MarsFramework.Config;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public static string ApplicationUrl = MarsResource.ApplicationUrl;
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign In')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public void LoginSteps(IWebDriver Driver)
        {

            GlobalDefinitions.Driver.Navigate().GoToUrl(ApplicationUrl);

            try
            {
                // Populate the excel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

                //Click on SignIn button
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//a[contains(text(),'Sign In')]"), 5);
                // Thread.Sleep(3000);
                SignIntab.Click();

                //Enter Email Address
                Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

                //Enter Password
                Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

                //Click on LoginButton
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//button[contains(text(), 'Login')]"), 5);
                LoginBtn.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("Didn't launch the url", ex.Message);
            }
        }
    }
}