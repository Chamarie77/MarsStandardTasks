using MarsFramework.SpecFlowPages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsFramework.StepDefinitions
{
    [Binding]

    public class ProfilePageStepDefinitions : Global.Base
    {

        IWebDriver Driver = Global.GlobalDefinitions.Driver;


        [Given(@"i enter the description")]
        public void GivenIEnterTheDescription()
        {
            // public IWebDriver Driver { get; set; }
          //  test = extent.StartTest("Test_AddLanguage");
          //  test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_AddLanguage demo");
            ProfilePage page = new ProfilePage();
            page.GoToProfilePage();
            page.EnterDescription();
        }

        [Then(@"i can see the description")]
        public void ThenICanSeeTheDescription()
        {
            var expectedDescription = "Happy to help Elderly People & kids";
            var actualDescription = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description");

            Assert.That(expectedDescription != actualDescription, "Actual and Expected Description does not match");
        }

        [Given(@"i clicked on the language tab under the profile page")]
        public void GivenIClickedOnTheLanguageTabUnderTheProfilePage()
        {
            ProfilePage page = new ProfilePage();
            page.GoToProfilePage();
        }

        [When(@"i entered a language")]
        public void WhenIEnteredALanguage()
        {
            ProfilePage page = new ProfilePage();
            page.AddLanguageSteps();
        }

        [Then(@"i can see the language on my list")]
        public void ThenICanSeeTheLanguageOnMyList()
        {
            var expectedLanguage = "Maori";
            var expectedLanguageLevel = "Basic";
            var actualLanguage = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Language");
            var actualLanguageLevel = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Level");

            Assert.That(expectedLanguage == actualLanguage, "Actual Language and Expected Language does not match");
            Assert.That(expectedLanguageLevel == actualLanguageLevel, "Actual Language Level and Expected Language Level does not match");
        }

        


        [When(@"i edited the '([^']*)', '([^']*)'")]
        public void WhenIEditedThe(string language, string p1)
        {
            ProfilePage page = new ProfilePage();
            page.GoToProfilePage();
            page.EditLanguageSteps(language, p1);


        }

        [Then(@"i can see the edited '([^']*)' and '([^']*)' on my list")]
        public void ThenICanSeeTheEditedAndOnMyList(string language, string p1)
        {
            var expectedEditedLanguage = Global.GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage");
            var expectedEditedLanguageLevel = Global.GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLevel");

            Assert.That(expectedEditedLanguage == language, "Actual Edited Language and Expected Edited Language does not match");
            Assert.That(expectedEditedLanguageLevel == p1, "Actual Edited Language and Expected Edited Language does not match");
        }


        

        [When(@"i delete the language")]
        public void WhenIDeleteTheLanguage()
        {
            ProfilePage page = new ProfilePage();
            page.GoToProfilePage();
            page.DeleteLanguageSteps();
        }

        [Then(@"i can not see the delete language on my list")]
        public void ThenICanNotSeeTheDeleteLanguageOnMyList()
        {
            ProfilePage page = new ProfilePage();

            Assert.IsTrue(page.DeleteLanguageSteps(), "Record deleted. I can't see edited language");
        }

               

        [Given(@"i clicked on the certifications tab under the profile page")]
        public void GivenIClickedOnTheCertificationsTabUnderTheProfilePage()
        {
            CertificationPage page = new CertificationPage();
            page.GoToCertificationTab();
        }

        [When(@"i entered a certification")] 
        public void WhenIEnteredACertification()
        {
            CertificationPage page = new CertificationPage();
            page.AddCertificate();
        }

        [Then(@"i can see the certification on my list")]
        public void ThenICanSeeTheCertificationOnMyList()
        {
            //Validate Add Certificate
            var expectedCertificate = "Software Tester (Foundation Level)";
            var expectedFromWhereCertificateReceived = "ISTQB";
            var actualCertificate = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
            var actualFromWhereCertificateReceived = Global.GlobalDefinitions.ExcelLib.ReadData(2, "From");

            Assert.That(expectedCertificate == actualCertificate, "Actual Certificate and Expected Certificate does not match");
            Assert.That(expectedFromWhereCertificateReceived == actualFromWhereCertificateReceived, "Actual and Expected From Where Received does not match");
        }

       
        [When(@"i updated the '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIUpdatedThe(string p0, string p1, string p2)
        {
            CertificationPage page = new CertificationPage();
            page.GoToCertificationTab();
            page.EditCertificate(p0, p1, p2);
        }

        [Then(@"i can see the updated '([^']*)', '([^']*)', '([^']*)' on my list")]
        public void ThenICanSeeTheUpdatedOnMyList(string p0, string p1, string p2)
        {
            var expectedEditedCertificate = Global.GlobalDefinitions.ExcelLib.ReadData(2, "EditedCertificate");
            var expectedEditedFromWhereCertificateReceived = Global.GlobalDefinitions.ExcelLib.ReadData(2, "EditedFrom");
            var expectedEditedCertificateYear = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Edited Year");

            Assert.That(expectedEditedCertificate == p0, "Actual Edited Certificate and Expected Edited Certificate does not match");
            Assert.That(expectedEditedFromWhereCertificateReceived == p1, "Actual Edited Certificate Received and Expected Edited Certificate Received does not match");
            Assert.That(expectedEditedCertificateYear == p2, "Actual Edited Certificate Year and Expected Edited Certificate Year does not match");
        }

                        
        [When(@"i delete the certification")]
        public void WhenIDeleteTheCertification()
        {
            CertificationPage page = new CertificationPage();
            page.GoToCertificationTab();
            page.DeleteCertificate();
        }

        [Then(@"i can not see the delete certification on my list")]
        public void ThenICanNotSeeTheDeleteCertificationOnMyList()
        {
            CertificationPage page = new CertificationPage();
            Assert.IsTrue(page.DeleteCertificate(), "Record deleted. I can't see edited certificate");

        }

        
    }
}
