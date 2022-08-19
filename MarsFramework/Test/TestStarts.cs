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
                page.AddShareSkill(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test AddShareSkill Passed");
            }


            [Test, Order(2)]
            public void Test_EditShareSkills()
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                test = extent.StartTest("Test_ChangeSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_ChangeSkills demo");
                ShareSkill page = new ShareSkill();
                page.EditShareSkill(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Failed ChangeSkills Passed");
            }

            [Test, Order(3)]
            public void Test_DeleteShareSkills()
            {
                test = extent.StartTest("Test_DeleteSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_DeleteSkills demo");
                ShareSkill page = new ShareSkill();
                page.DeleteShareSkill(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test DeleteSkills Passed");
            }
            [Test, Order(4)]
            public void Test_AddLanguage()
            {
                test = extent.StartTest("Test_AddLanguage");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_AddLanguage demo");
                ProfilePage page = new ProfilePage();
                page.AddLanguageSteps(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test AddLanguage Passed");
            }

            [Test, Order(5)]
            public void Test_EditLanguage()
            {
                test = extent.StartTest("Test_EditLanguage");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_EditLanguage demo");
                ProfilePage page = new ProfilePage();
                page.EditLanguageSteps(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test EditLanguage Passed");
            }

            [Test, Order(6)]
            public void Test_DeleteLanguage()
            {
                test = extent.StartTest("Test_DeleteLanguage");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_DeleteLanguage demo");
                ProfilePage page = new ProfilePage();
                page.DeleteLanguageSteps(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test DeleteLanguage Passed");
            }

            [Test, Order(7)]
            public void Test_AddCertificate()
            {
                test = extent.StartTest("Test_AddCertification");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_AddCertification demo");
                CertificatePage page = new CertificatePage();
                page.AddCertificate(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test AddCertification Passed");
            }

            [Test, Order(8)]
            public void Test_EditCertificate()
            {
                test = extent.StartTest("Test_EditCertification");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_EditCertification demo");
                CertificatePage page = new CertificatePage();
                page.EditCertificate(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test EditCertification Passed");
            }

            [Test, Order(9)]
            public void Test_DeleteCertificate()
            {
                test = extent.StartTest("Test_DeleteCertification");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_DeleteCertification demo");
                CertificatePage page = new CertificatePage();
                page.DeleteCertificate(Driver);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test DeleteCertification Passed");
            }
        }
    }
}