using NUnit.Framework;
using MarsFramework.Config;
using MarsFramework.Global;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Pages;
using OpenQA.Selenium;
using static MarsFramework.Pages.ShareSkill;
using System.Threading;
using System;




namespace MarsFramework
{
    public class TestStarts
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void Test_AddShareSkills()
            {
               // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //Log 'info'
                test = extent.StartTest("Test_AddShareSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_AddShareSkill demo");
                ShareSkill page = new ShareSkill();
                page.AddShareSkill();
                //  Assert.IsTrue(true);
                // test.Pass("Assertion passed");
                //Assert.AreEqual(10, 10);

                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test AddShareSkill Passed");

            }

            [Test]
            public void Test_ChangeSkills()
            {
                test = extent.StartTest("Test_ChangeSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_ChangeSkills demo");
                ShareSkill page = new ShareSkill();
                page.EditShareSkill();
                //  Assert.IsTrue(true);
                //test.Pass("Assertion passed");

                test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed ChangeSkills Passed");
            }

            [Test]
            public void Test_DeleteSkills()
            {
                test = extent.StartTest("Test_DeleteSkills");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Test_DeleteSkills demo");
                ShareSkill page = new ShareSkill();
                page.DeleteShareSkill();
                //  Assert.IsTrue(true);
                //  test.Pass("Assertion passed");
                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test DeleteSkills Passed");
            }

        }
    }
}