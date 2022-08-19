using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Pages
{
    internal class CertificatePage
    {
        #region Add Certificate
        public void AddCertificate(IWebDriver Driver)
        {
            //Populate Excel Lib
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "CetificationsPageData");

            //Click on Dropdown Link
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 30);
            IWebElement DropDownLink = Driver.FindElement(By.XPath("//span[contains(@class, 'item ui dropdown link')]"));
            DropDownLink.Click();

            //Go to Profile Page
            Extension.WaitForElementDisplayed(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 20);
            IWebElement DropDownOption = Driver.FindElement(By.XPath("//a[text()[contains(.,'Go to Profile')]] "));
            DropDownOption.Click();

            // Go to Certifications Tab
            IWebElement CertificationsTab = Driver.FindElement(By.XPath("//a[text() = 'Certifications'] "));
            Extension.WaitForElementDisplayed(Driver, By.XPath("//a[text() = 'Certifications']"), 20);
            CertificationsTab.Click();

            // Click on Add New Button
            Extension.WaitForElementDisplayed(Driver, By.XPath("(//div[contains(text(), 'Add New')])[4]"), 20);
            IWebElement AddNewCertificationButton = Driver.FindElement(By.XPath("(//div[contains(text(), 'Add New')])[4]"));
            AddNewCertificationButton.Click();

            // Enter a new Cerification
            IWebElement AddCertificationTextBox = Driver.FindElement(By.Name("certificationName"));
            AddCertificationTextBox.Clear();
            AddCertificationTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

            //Enter From Where Received the Certification
            IWebElement FromWhereReceived = Driver.FindElement(By.Name("certificationFrom"));
            FromWhereReceived.Clear();
            FromWhereReceived.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "From"));

            //Click on the Received Year Dropdown
            IWebElement YearDropDown = Driver.FindElement(By.Name("certificationYear"));
            new SelectElement(YearDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Year"));

            //Click on AddCertification Button
            IWebElement AddCertificationButton = Driver.FindElement(By.XPath("//input[@type = 'button'][@value = 'Add']"));
            Extension.WaitForElementClickable(AddCertificationButton, Driver, 50);
            AddCertificationButton.Click();


        }
        #endregion

        #region Edit Certificate
        public void EditCertificate(IWebDriver Driver)
        {
            //Populate Excel Lib
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "CetificationsPageData");

            //Click on Dropdown Link
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 30);
            IWebElement DropDownLink = Driver.FindElement(By.XPath("//span[contains(@class, 'item ui dropdown link')]"));
            DropDownLink.Click();

            //Go to Profile Page
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 30);
            IWebElement DropDownOption = Driver.FindElement(By.XPath("//a[text()[contains(.,'Go to Profile')]] "));
            DropDownOption.Click();

            // Go to Certifications Tab
            IWebElement CertificationsTab = Driver.FindElement(By.XPath("//a[text() = 'Certifications'] "));
            Extension.WaitForElementDisplayed(Driver, By.XPath("//a[text() = 'Certifications']"), 50);
            CertificationsTab.Click();

            var ExpectedEditedCertificate = (GlobalDefinitions.ExcelLib.ReadData(2, "EditedCertificate"));

            //Validate Edited Certification
            if (ExpectedEditedCertificate == "Java")
            {
                //Click on Edit Write Icon
                GlobalDefinitions.WaitForElement(Driver, By.XPath("(//i[@class ='outline write icon'])[5]"), 30);
                IWebElement EditIcon = Driver.FindElement(By.XPath("(//i[@class ='outline write icon'])[5]"));
                EditIcon.Click();

            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found");
            }

            // Enter Edited Certificate
            IWebElement EditCertificationTextBox = Driver.FindElement(By.Name("certificationName"));
            EditCertificationTextBox.Clear();
            Extension.WaitForElementClickable(EditCertificationTextBox, Driver, 30);
            EditCertificationTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EditedCertificate"));

            // Enter From where received the Edited certificate
            IWebElement EditFromWhereTextBox = Driver.FindElement(By.Name("certificationFrom"));
            EditFromWhereTextBox.Clear();
            Extension.WaitForElementClickable(EditFromWhereTextBox, Driver, 30);
            EditFromWhereTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EditedFrom"));

            //Click on the Edited Received Year Dropdown
            IWebElement EditedYearDropDown = Driver.FindElement(By.Name("certificationYear"));
            new SelectElement(EditedYearDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Edited Year"));


            IWebElement UpdateButton = Driver.FindElement(By.XPath("//input[@type = 'button'][@value = 'Update']"));
            Extension.WaitForElementClickable(UpdateButton, Driver, 50);
            UpdateButton.Click();
        }
        #endregion

        #region Delete Certificate
        public void DeleteCertificate(IWebDriver Driver)
        {
            //Populate Excel Lib
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "CetificationsPageData");

            //Click on Dropdown Link
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 30);
            IWebElement DropDownLink = Driver.FindElement(By.XPath("//span[contains(@class, 'item ui dropdown link')]"));
            DropDownLink.Click();

            //Go to Profile Page
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 30);
            IWebElement DropDownOption = Driver.FindElement(By.XPath("//a[text()[contains(.,'Go to Profile')]] "));
            DropDownOption.Click();

            // Go to Certifications Tab
            IWebElement CertificationsTab = Driver.FindElement(By.XPath("//a[text() = 'Certifications'] "));
            Extension.WaitForElementDisplayed(Driver, By.XPath("//a[text() = 'Certifications']"), 50);
            CertificationsTab.Click();

            //Validation Delete Button
            var EditedCertificate = GlobalDefinitions.ExcelLib.ReadData(2, "EditedCertificate");

            if (EditedCertificate == "Java")
            {
                //Click on Remove Icon
                GlobalDefinitions.WaitForElement(Driver, By.XPath("(//i[@class = 'remove icon'])[5]"), 30);
                IWebElement DeleteButton = Driver.FindElement(By.XPath("(//i[@class = 'remove icon'])[5]"));
                DeleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to be deleted hasn't been found");
            }
        }
        #endregion
    }
}

