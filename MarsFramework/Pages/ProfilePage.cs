using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
     internal class ProfilePage
     {
            #region Add Language

            public void AddLanguageSteps(IWebDriver Driver)
            {
                 //Populate the excel data    
                 GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "LanguagePageData");
              
                //Click on Dropdown link
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 50);
                IWebElement DropDownLink = Driver.FindElement(By.XPath("//span[contains(@class, 'item ui dropdown link')]"));
                DropDownLink.Click();
            
                //Go to Profile Page
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 50);
                IWebElement GotoProfile = Driver.FindElement(By.XPath("//a[text()[contains(.,'Go to Profile')]]"));
                GotoProfile.Click();
                
                // Click on Description Write Icon
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//i[@class = 'outline write icon']"), 50);
                IWebElement DescriptionWriteIcon = Driver.FindElement(By.XPath("//i[@class = 'outline write icon']"));
                DescriptionWriteIcon.Click();

                // Clean the former descriptions
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//form/div/div/div[2]/div[1]/textarea"), 50);
                IWebElement Description = Driver.FindElement(By.XPath("//form/div/div/div[2]/div[1]/textarea"));
                Description.Clear();

                //Enter Description
                //take the description and if not exits then write,
                var ExistingDescription = Description.Text;
                if (ExistingDescription == null)
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            
                //Save Description
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//form/div/div/div[2]/button"), 30);
                IWebElement SaveDescription = Driver.FindElement(By.XPath("//form/div/div/div[2]/button"));
                SaveDescription.Click();
              
                //Select Language tab
                IWebElement LanguageTab = Driver.FindElement(By.XPath("//a[text()[contains(. , 'Languages')]]"));
                LanguageTab.Click();

                //Click on Language AddNew Button
                GlobalDefinitions.WaitForElement(Driver, By.XPath("(//div[contains(text(),'Add New')])[1]"), 30);
                IWebElement LanguageAddNewButton = Driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[1]"));
                LanguageAddNewButton.Click();
                
               
                //Enter a New Language
                IWebElement AddLanguageTextBox = Driver.FindElement(By.XPath("//input[@placeholder = 'Add Language']"));
                AddLanguageTextBox.Clear();
                AddLanguageTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

                //Click on Language Level Dropdown
                IWebElement LanguageLevelDropDown = Driver.FindElement(By.XPath("//select[@class = 'ui dropdown'][@name = 'level']"));
                new SelectElement(LanguageLevelDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Level"));

                //Validate Add Language
                var expectedLanguage = "Maori";
                var expectedLanguageLevel = "Basic";
                var actualLanguage = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
                var actualLanguageLevel = GlobalDefinitions.ExcelLib.ReadData(2, "Level");

                Assert.That(expectedLanguage == actualLanguage, "Language does not match");
                Assert.That(expectedLanguageLevel == actualLanguageLevel, "Language Level does not match");
                
                //Click on Add Button
                IWebElement AddLanguageButton = Driver.FindElement(By.XPath("//input[@type = 'button'][@value = 'Add']"));
                Extension.WaitForElementClickable(AddLanguageButton, Driver, 50); ;
                AddLanguageButton.Click();
              
            }
            #endregion

            #region Edit Language
            public void EditLanguageSteps(IWebDriver Driver)
            {
                //Populate the EXcel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "LanguagePageData");


                //Click on Dropdown link
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 30);
                IWebElement DropDownLink = Driver.FindElement(By.XPath("//span[contains(@class, 'item ui dropdown link')]"));
                DropDownLink.Click();

                //Go to Profile Page
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 30);
                IWebElement GotoProfile = Driver.FindElement(By.XPath("//a[text()[contains(.,'Go to Profile')]]"));
                GotoProfile.Click();

                //Select Language tab
                IWebElement LanguageTab = Driver.FindElement(By.XPath("//a[text()[contains(. , 'Languages')]]"));
                LanguageTab.Click();

                var ExpectedEditedLanguage = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage");

                if(ExpectedEditedLanguage == "Sinhalese")
                { 
                
                //Click on language edit write icon
                GlobalDefinitions.WaitForElement(Driver, By.XPath("(//i[@class = 'outline write icon'])[2]"), 50);
                IWebElement LanguageEditWriteIcon = Driver.FindElement(By.XPath("(//i[@class = 'outline write icon'])[2]"));
                LanguageEditWriteIcon.Click();
                }
                else
                {
                    Assert.Fail("Record to be edited hasn't been found");
                }

                // Enter Edited Language
                IWebElement EditLanguageTextBox = Driver.FindElement(By.XPath("//input[@placeholder = 'Add Language']"));
                EditLanguageTextBox.Clear();
                EditLanguageTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage"));

                // Click on Edit Language Dropdown
                IWebElement EditLanguageLevelDropDown = Driver.FindElement(By.XPath("//select[@class = 'ui dropdown'][@name = 'level']"));
                new SelectElement(EditLanguageLevelDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLevel"));
            

                //Click on Update Button
                GlobalDefinitions.WaitForElement(Driver, By.XPath("(//input[@type = 'button'][@value = 'Update'])[1]"), 30);
                IWebElement LanguageUpdateButton = Driver.FindElement(By.XPath("(//input[@type = 'button'][@value = 'Update'])[1]"));
                LanguageUpdateButton.Click();
            }

        #endregion

            #region Delete Language
            public void DeleteLanguageSteps(IWebDriver Driver)
            {
                //Populate the EXcel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "LanguagePageData");


                //Click on Dropdown link
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 50);
                IWebElement DropDownLink = Driver.FindElement(By.XPath("//span[contains(@class, 'item ui dropdown link')]"));
                DropDownLink.Click();

                //Go to Profile Page
                GlobalDefinitions.WaitForElement(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 50);
                IWebElement GotoProfile = Driver.FindElement(By.XPath("//a[text()[contains(.,'Go to Profile')]]"));
                GotoProfile.Click();

                //Select Language tab
                IWebElement LanguageTab = Driver.FindElement(By.XPath("//a[text()[contains(. , 'Languages')]]"));
                LanguageTab.Click();

                //Validate Delete Language
                var editedLanguage = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage");

                if (editedLanguage == "Sinhalese")
                {
                    //Click on Delete Icon
                    Extension.WaitForElementDisplayed(Driver, By.XPath("(//i[@class = 'remove icon'])[1]"), 10);
                    IWebElement DeleteLanguage = Driver.FindElement(By.XPath("(//i[@class = 'remove icon'])[1]"));
                    DeleteLanguage.Click();
                }
                else
                {
                    Assert.Fail("Record to be deleted hasn't been found");
                }
            }
            #endregion
     }
}



