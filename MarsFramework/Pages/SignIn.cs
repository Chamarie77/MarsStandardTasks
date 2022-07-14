using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Config;

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

        public  void LoginSteps()
        {

          // GlobalDefinitions.wait(30);
           Thread.Sleep(3000);
            GlobalDefinitions.Driver.Navigate().GoToUrl(ApplicationUrl);

            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Click on SignIn button
            // GlobalDefinitions.WaitForElement(driver, By.("//a[contains(text(),'Sign In')]"), 10);
            Thread.Sleep(3000);
            SignIntab.Click();

            //Enter Email Address
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on LoginButton
            // GlobalDefinitions.WaitForElement(Driver, By.Name("password"), 10);
            //GlobalDefinitions.wait(30);
            Thread.Sleep(3000);
            LoginBtn.Click();
        }
    }
}