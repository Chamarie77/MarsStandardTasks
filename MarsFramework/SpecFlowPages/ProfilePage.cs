using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.SpecFlowPages
{
    public class ProfilePage
    {
        // Go to Profile page
        public ProfilePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        IWebDriver Driver = Global.GlobalDefinitions.Driver;

        //Click on Dropdown link
        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'item ui dropdown link')]")]
        private IWebElement DropDownLink { get; set; }

        //Go to Profile Page
        [FindsBy(How = How.XPath, Using = "//a[text()[contains(.,'Go to Profile')]]")]
        private IWebElement GotoProfile { get; set; }

        // Click on Description Write Icon
        [FindsBy(How = How.XPath, Using = "//i[@class = 'outline write icon']")]
        private IWebElement DescriptionWriteIcon { get; set; }

        //Enter Description
        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[1]/textarea")]
        private IWebElement Description { get; set; }

        //Save Description
        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/button")]
        private IWebElement SaveDescription { get; set; }

        //Select Language tab
        [FindsBy(How = How.XPath, Using = "//a[text()[contains(. , 'Languages')]]")]
        private IWebElement LanguageTab { get; set; }

        //Click on Language AddNew Button
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[1]")]
        private IWebElement LanguageAddNewButton { get; set; }

        //Enter a New Language
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Add Language']")]
        private IWebElement AddLanguageTextBox { get; set; }

        //Click on Language Level Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui dropdown'][@name = 'level']")]
        private IWebElement LanguageLevelDropDown { get; set; }

        //Click on Add Button
        [FindsBy(How = How.XPath, Using = "//input[@type = 'button'][@value = 'Add']")]
        private IWebElement AddLanguageButton { get; set; }

        //Click on language edit write icon
        [FindsBy(How = How.XPath, Using = "(//i[@class = 'outline write icon'])[2]")]
        private IWebElement LanguageEditWriteIcon { get; set; }

        // Enter Edited Language
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Add Language']")]
        private IWebElement EditLanguageTextBox { get; set; }

        // Click on Edit Language Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui dropdown'][@name = 'level']")]
        private IWebElement EditLanguageLevelDropDown { get; set; }

        //Click on Update Button
        [FindsBy(How = How.XPath, Using = "(//input[@type = 'button'][@value = 'Update'])[1]")]
        private IWebElement LanguageUpdateButton { get; set; }

        //Click on Delete Icon
        [FindsBy(How = How.XPath, Using = "(//i[@class = 'remove icon'])[1]")]
        private IWebElement DeleteLanguage { get; set; }

        public void GoToProfilePage()
        {
            //Click on Dropdown link
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 30);
            DropDownLink.Click();

            //Go to Profile Page
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 30);
            GotoProfile.Click();

            //Select Language tab
            LanguageTab.Click();
        }

        public void EnterDescription()
        {
            //Populate the excel data    
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "LanguagePageData");

            // Click on Description Write Icon
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//i[@class = 'outline write icon']"), 50);
            DescriptionWriteIcon.Click();

            // Clean the former descriptions
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//form/div/div/div[2]/div[1]/textarea"), 50);
            Description.Clear();

            //Enter Description
            //take the description and if not exits then write,
            var ExistingDescription = Description.Text;
            if (ExistingDescription == null)
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Save Description
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//form/div/div/div[2]/button"), 30);
            SaveDescription.Click();
        }


        public void AddLanguageSteps()
        {

            //Populate the excel data    
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "LanguagePageData");
            
            //Click on Language AddNew Button
            GlobalDefinitions.WaitForElement(Driver, By.XPath("(//div[contains(text(),'Add New')])[1]"), 30);
            LanguageAddNewButton.Click();

            //Enter a New Language
            AddLanguageTextBox.Clear();
            AddLanguageTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

            //Click on Language Level Dropdown
            new SelectElement(LanguageLevelDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Level"));

            GlobalDefinitions.WaitForElement(Driver, By.XPath("//input[@type = 'button'][@value = 'Add']"), 50); ;
            AddLanguageButton.Click();
        }

        

        public void EditLanguageSteps(string language, string p1)
        {
           // Populate the EXcel data
              GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "LanguagePageData");

           // Click on Edit write icon 
              GlobalDefinitions.WaitForElement(Driver, By.XPath("(//i[@class = 'outline write icon'])[2]"), 50);
              LanguageEditWriteIcon.Click();

           // Enter Edited Language
              EditLanguageTextBox.Clear();
              EditLanguageTextBox.SendKeys(language);

           // Click on Edit Language Dropdown
              EditLanguageLevelDropDown.SendKeys(p1);

           // Click on Update Button
              GlobalDefinitions.WaitForElement(Driver, By.XPath("(//input[@type = 'button'][@value = 'Update'])[1]"), 30);
              LanguageUpdateButton.Click();

           
        }

        public bool DeleteLanguageSteps()
        {
            //Populate the EXcel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "LanguagePageData");

            //Validate Delete Language
            var editedLanguage = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage");

            if (editedLanguage == "Sinhalese")
            {
                //Click on Delete Icon
                GlobalDefinitions.WaitForElement(Driver, By.XPath("(//i[@class = 'remove icon'])[1]"), 50);
                DeleteLanguage.Click();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
