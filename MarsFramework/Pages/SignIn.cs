﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework.Pages
{
    class SignIn 
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        //WaitForElement(10);
        

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

      //  Thread.Sleep(1000);

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public  void LoginSteps()
        {

            Thread.Sleep(3000);

            GlobalDefinitions.Driver.Navigate().GoToUrl("http://localhost:5000/");

            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Click on SignIn button
            SignIntab.Click();

            //Enter Email Address
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            Thread.Sleep(3000);
            //Click on LoginButton
            LoginBtn.Click();

            //Validate the logged in
            //IWebDriver driver = GlobalDefinitions.Driver;
            //IWebElement loggedin = driver.FindElement(By.XPath("//a/button[contains(text(), 'Sign Out')]"));
            //Assert.AreEqual(loggedin.Text, "Sign Out");
        }
    }
}