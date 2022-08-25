using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    internal class CertificatePage
    {
        #region Add Certificate

        public CertificatePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        //Click on Dropdown link
        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'item ui dropdown link')]")]
        private IWebElement DropDownLink { get; set; }

        //Go to Profile Page
        [FindsBy(How = How.XPath, Using = "//a[text()[contains(.,'Go to Profile')]]")]
        private IWebElement GotoProfile { get; set; }

        // Go to Certifications Tab
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Certifications']")]
        private IWebElement CertificationsTab { get; set; }

        // Click on Add New Button
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(), 'Add New')])[4]")]
        private IWebElement AddNewCertificationButton { get; set; }

        // Enter a new Cerification
        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement AddCertificationTextBox { get; set; }

        //Enter From Where Received the Certification
        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement FromWhereReceivedTextBox { get; set; }

        //Click on the Received Year Dropdown
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement YearDropDown { get; set; }

        //Click on AddCertification Button
        [FindsBy(How = How.XPath, Using = "//input[@type = 'button'][@value = 'Add']")]
        private IWebElement AddCertificationButton { get; set; }

        //Click on Edit Write Icon
        [FindsBy(How = How.XPath, Using = "(//i[@class ='outline write icon'])[5]")]
        private IWebElement EditIcon { get; set; }

        // Enter Edited Certificate
        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement EditCertificationTextBox { get; set; }

        // Enter From where received the Edited certificate
        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement EditFromWhereTextBox { get; set; }

        //Click on the Edited Received Year Dropdown
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement EditedYearDropDown { get; set; }

        // Click on update button
        [FindsBy(How = How.XPath, Using = "//input[@type = 'button'][@value = 'Update']")]
        private IWebElement UpdateButton { get; set; }

        //Click on Remove Icon
        [FindsBy(How = How.XPath, Using = "(//i[@class = 'remove icon'])[4]")]
        private IWebElement DeleteButton { get; set; }

        private void GoToCertificationTab(IWebDriver Driver)
        {
            //Click on Dropdown Link
            GlobalDefinitions.WaitForElement(Driver, By.XPath("//span[contains(@class, 'item ui dropdown link')]"), 30);
            DropDownLink.Click();

            //Go to Profile Page
            Extension.WaitForElementDisplayed(Driver, By.XPath("//a[text()[contains(.,'Go to Profile')]]"), 20);
            GotoProfile.Click();

            // Go to Certifications Tab
            Extension.WaitForElementDisplayed(Driver, By.XPath("//a[text() = 'Certifications']"), 20);
            CertificationsTab.Click();
        }

        public void AddCertificate(IWebDriver Driver)
        {
            //Populate Excel Lib
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "CetificationsPageData");

            GoToCertificationTab(Driver);

            // Click on Add New Button
            Extension.WaitForElementDisplayed(Driver, By.XPath("(//div[contains(text(), 'Add New')])[4]"), 20);
            AddNewCertificationButton.Click();

            // Enter a new Cerification
            AddCertificationTextBox.Clear();
            AddCertificationTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

            //Enter From Where Received the Certification
            FromWhereReceivedTextBox.Clear();
            FromWhereReceivedTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "From"));

            //Click on the Received Year Dropdown
            new SelectElement(YearDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Year"));

            //Click on AddCertification Button
            Extension.WaitForElementClickable(AddCertificationButton, Driver, 50);
            AddCertificationButton.Click();
        }
        #endregion

        #region Edit Certificate
        public void EditCertificate(IWebDriver Driver)
        {
            //Populate Excel Lib
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "CetificationsPageData");

            GoToCertificationTab(Driver);

            //Click on Edit Write Icon
            GlobalDefinitions.WaitForElement(Driver, By.XPath("(//i[@class ='outline write icon'])[5]"), 30);
            EditIcon.Click();

            // Enter Edited Certificate
            EditCertificationTextBox.Clear();
            Extension.WaitForElementClickable(EditCertificationTextBox, Driver, 30);
            EditCertificationTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EditedCertificate"));

            // Enter From where received the Edited certificate
            EditFromWhereTextBox.Clear();
            Extension.WaitForElementClickable(EditFromWhereTextBox, Driver, 30);
            EditFromWhereTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EditedFrom"));

            //Click on the Edited Received Year Dropdown
            new SelectElement(EditedYearDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Edited Year"));

            // Click on update button
            Extension.WaitForElementClickable(UpdateButton, Driver, 50);
            UpdateButton.Click();
        }
        #endregion

        #region Delete Certificate
        public bool DeleteCertificate(IWebDriver Driver)
        {
            //Populate Excel Lib
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathProfilePage, "CetificationsPageData");

            GoToCertificationTab(Driver);

            //Validation Delete Button
            var EditedCertificate = GlobalDefinitions.ExcelLib.ReadData(2, "EditedCertificate");

            if (EditedCertificate == "Java")
            {
                //Click on Remove Icon
                GlobalDefinitions.WaitForElement(Driver, By.XPath("(//i[@class = 'remove icon'])[4]"), 30);
                DeleteButton.Click();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

