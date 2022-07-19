using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class SignUp
    {
        public static string ApplicationUrl = MarsResource.ApplicationUrl;
        public SignUp()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Join 
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Join')]")]
        private IWebElement Join { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.Name, Using = "terms")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.Id, Using = "submit-btn")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        internal void Register()
        {
            GlobalDefinitions.Driver.Navigate().GoToUrl(ApplicationUrl);
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            //Click on Join button
            Join.Click();

            //Enter FirstName
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "First Name"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Last Name"));

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm(
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Confirm Password"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();

        }    
    }
}
