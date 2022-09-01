using MarsFramework.Pages;
using NUnit.Framework;
using System;
using static MarsFramework.Global.GlobalDefinitions;



namespace MarsFramework
{
    public class TestStarts
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void Test_AddShareSkills()
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                test = extent.StartTest("Test_AddShareSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_AddShareSkill demo");
                ShareSkill page = new ShareSkill();
                page.AddShareSkill();

                //Validate AddShareSkill
                var expectedTitle = "SpecFlow";
                var expectedDescription = "Could Be Provide";
                var actualTitle = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                var actualDescription = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description");

                Assert.That(actualTitle == expectedTitle, "title does not match");
                Assert.That(actualDescription == expectedDescription, "description does not match");
            }

            [Test, Order(2)]
            public void Test_EditShareSkills()
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                test = extent.StartTest("Test_ChangeSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_ChangeSkills demo");
                ShareSkill page = new ShareSkill();
                page.EditShareSkill();

                //Validate Edit Share Skill
                var actualTitle = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                var expectedTitle = "SpecFlow";
                Assert.That(actualTitle == expectedTitle, "Actual Title and Expected Title does not match");
            }

            [Test, Order(3)]
            public void Test_DeleteShareSkills()
            {
                test = extent.StartTest("Test_DeleteSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_DeleteSkills demo");
                ShareSkill page = new ShareSkill();
                page.DeleteShareSkill();

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test DeleteSkills Passed");
            }

            [Test, Order(4)]
            public void Test_AddLanguage()
            {
                test = extent.StartTest("Test_AddLanguage");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_AddLanguage demo");
                ProfilePage page = new ProfilePage();
                page.AddLanguageSteps();

                //Validate Add Language
                var expectedLanguage = "Maori";
                var expectedLanguageLevel = "Basic";
                var actualLanguage = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Language");
                var actualLanguageLevel = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Level");

                Assert.That(expectedLanguage == actualLanguage, "Actual Language and Expected Language does not match");
                Assert.That(expectedLanguageLevel == actualLanguageLevel, "Actual Language Level and Expected Language Level does not match");
            }

            [Test, Order(5)]
            public void Test_EditLanguage()
            {
                test = extent.StartTest("Test_EditLanguage");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_EditLanguage demo");
                ProfilePage page = new ProfilePage();
                page.EditLanguageSteps();

                // Validte Edit Language
                var ExpectedEditedLanguage = "Sinhalese";
                var ExpectedEditedLanguageLevel = "Native/Bilingual";
                var ActualEditedLanguage = Global.GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage");
                var ActualEditedLanguageLevel = Global.GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLevel");

                Assert.That(ExpectedEditedLanguage == ActualEditedLanguage, "Actual Edited Language and Expected EDited Language does not match");
                Assert.That(ExpectedEditedLanguageLevel == ActualEditedLanguageLevel, "Actual Edited Language Level and Expected E#dited Language Level does not match");
            }

            [Test, Order(6)]
            public void Test_DeleteLanguage()
            {
                test = extent.StartTest("Test_DeleteLanguage");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_DeleteLanguage demo");
                ProfilePage page = new ProfilePage();

                Assert.IsTrue(page.DeleteLanguageSteps(), "Recorded deleted");
            }

            [Test, Order(7)]
            public void Test_AddCertificate()
            {
                test = extent.StartTest("Test_AddCertification");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_AddCertification demo");
                CertificatePage page = new CertificatePage();
                page.AddCertificate();

                //Validate Add Certificate
                var expectedCertificate = "Software Tester (Foundation Level)";
                var expectedFromWhereCertificateReceived = "ISTQB";
                var actualCertificate = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
                var actualFromWhereCertificateReceived = Global.GlobalDefinitions.ExcelLib.ReadData(2, "From");

                Assert.That(expectedCertificate == actualCertificate, "Actual Certificate and Expected Certificate does not match");
                Assert.That(expectedFromWhereCertificateReceived == actualFromWhereCertificateReceived, "Actual and Expected From Where Received does not match");
            }

            [Test, Order(8)]
            public void Test_EditCertificate()
            {
                test = extent.StartTest("Test_EditCertification");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_EditCertification demo");
                CertificatePage page = new CertificatePage();
                page.EditCertificate();

                // Validte Edit Certificate
                var ExpectedEditedCertificate = "Java";
                var ExpectedEditedFromWhereCertificateReceived = "Oracle";
                var ActualEditedCertificate = Global.GlobalDefinitions.ExcelLib.ReadData(2, "EditedCertificate");
                var ActualEditedFromWhereCertificateReceived = Global.GlobalDefinitions.ExcelLib.ReadData(2, "EditedFrom");

                Assert.That(ExpectedEditedCertificate == ActualEditedCertificate, "Actual Edited Certificate and Expected Edited Certificate does not match");
                Assert.That(ExpectedEditedFromWhereCertificateReceived == ActualEditedFromWhereCertificateReceived, "Actual and Expected Edited From Where Received does not match");
            }

            [Test, Order(9)]
            public void Test_DeleteCertificate()
            {
                test = extent.StartTest("Test_DeleteCertification");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_DeleteCertification demo");
                CertificatePage page = new CertificatePage();

                Assert.IsTrue(page.DeleteCertificate(), "Record Deleted");
            }
        }
    }
}