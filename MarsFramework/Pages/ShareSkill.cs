using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        IWebDriver Driver = Global.GlobalDefinitions.Driver;


        //Click on ShareSkill Link
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillLink { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Select Category Dropdown Option
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Select Sub Category Option
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryOption { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "(//input[@placeholder = 'Add new tag'])[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'serviceType'][@value = '0']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType'][@value = '1']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//input[@name = 'Available'][@index ='1']")]
        private IWebElement Days { get; set; }

        //Click on StartTime 
        [FindsBy(How = How.XPath, Using = "//input[@name = 'StartTime'][@index ='1']")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime 
        [FindsBy(How = How.XPath, Using = "//input[@name = 'EndTime'][@index ='1']")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'skillTrades'][@value ='true']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "(//input[@placeholder = 'Add new tag'])[2]")]
        private IWebElement SkillExchange { get; set; }

        //Click on Work Sample
        [FindsBy(How = How.XPath, Using = "//i[@class = 'huge plus circle icon padding - 25']")]
        private IWebElement WorkSample { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'isActive'][@value = 'false']")]
        private IWebElement ActiveOption { get; set; }


        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageListings { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//i[@class = 'outline write icon']")]
        private IWebElement Edit { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//i[@class = 'remove icon']")]
        private IWebElement Delete { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//button[@class = 'ui icon positive right labeled button']")]
        private IWebElement ActionsButton { get; set; }

        internal void AddShareSkill()
        {

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "TestDataShareSkill");

            GlobalDefinitions.WaitForElement(Driver, By.LinkText("Share Skill"), 5);

            //Click on Share Skill Link
            ShareSkillLink.Click();

            //Enter the Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter the Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select  Category Dropdown Option
            new SelectElement(CategoryDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            // Select  Sub Category Option
            new SelectElement(SubCategoryOption).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter the tag names

            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Select the Service options
            ServiceTypeOptions.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"));
            ServiceTypeOptions.Click();

            //Select the Location Type Options
            LocationTypeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));
            LocationTypeOption.Click();

            //Click on the Start Date Dropdown
            StartDateDropDown.SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));

            //Click on the End Date Dropdown
            EndDateDropDown.SendKeys(DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"));

            //Select available days
            Days.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SelectDay"));
            Days.Click();

            //Click on the Start Time
            StartTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));

            //Click on the End Time
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            //Select Skill Trade option
            SkillTradeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"));
            SkillTradeOption.Click();

            //Enter Skill Exchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //upload a file
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = path.Substring(0, path.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;

            //Append the image path
            string imagePath = projectPath + Base.ImagePath;

            IWebElement fileUpload = Driver.FindElement(By.XPath("//i[@class = 'huge plus circle icon padding-25']"));
            fileUpload.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");

            Thread.Sleep(1000);
            autoIt.Send(imagePath);
            autoIt.Send("{ENTER}");
            Thread.Sleep(1000);

            //Select Active Hidden Option
            ActiveOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Active"));
            ActiveOption.Click();

            //Click on Save Button   
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//input[@value='Save']"), 5);
            Save.Click();
        }

        internal void EditShareSkill()
        {
            //populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathEdit, "EditTestData");

            //Click on Manage Listing Link
            GlobalDefinitions.WaitForElement(Driver, By.LinkText("Manage Listings"), 20);
            ManageListings.Click();

            GlobalDefinitions.WaitForElement(Driver, By.XPath("//i[@class = 'outline write icon']"), 20);
            Edit.Click();

            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewTitle"));

            GlobalDefinitions.WaitForElement(Driver, By.XPath("//input[@type = 'button'][@value ='Save'] "), 20);
            Save.Click();
        }

        internal void DeleteShareSkill()
        {
            //Click on Manage Listing Link
            GlobalDefinitions.WaitForElement(Driver, By.LinkText("Manage Listings"), 5);
            ManageListings.Click();

            //Click on Delete icon
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//i[@class = 'remove icon']"), 5);
            Delete.Click();

            GlobalDefinitions.WaitForElement(Driver, By.XPath("//button[@class = 'ui icon positive right labeled button']"), 5);
            //Click action button
            ActionsButton.Click();
        }
    }
}
