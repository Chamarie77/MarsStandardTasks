using NUnit.Framework;
using MarsFramework.Config;
using MarsFramework.Global;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Pages;
using OpenQA.Selenium;
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
                var x = System.Environment.CurrentDirectory;
                ShareSkill page = new ShareSkill();
                page.EnterShareSkill();
            }



            [Test]
            public void Test_ChangeSkills()
            {
                ShareSkill page = new ShareSkill();
                page.EditShareSkill();
            }

            [Test]
            public void Test_DeleteSkills()
            {
                ShareSkill page = new ShareSkill();
                page.DeleteShareSkill();
            }

        }
    }
}