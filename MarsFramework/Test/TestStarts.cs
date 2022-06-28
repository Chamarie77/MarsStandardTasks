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
            public void Test_ShareSkills()
            {
                ShareSkill page = new ShareSkill();
                page.EnterShareSkill();
                //page.EditShareSkill();
            }



            [Test]
            public void Test_EditSkills()
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