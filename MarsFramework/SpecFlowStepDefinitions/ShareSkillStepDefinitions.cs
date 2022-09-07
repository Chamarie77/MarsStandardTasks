using MarsFramework.SpecFlowPages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;


namespace MarsFramework
{
    [Binding]
    public class ShareSkillStepDefinitions
    {
        [Given(@"i clicked on the share skill button on the profile page")]
        public void GivenIClickedOnTheShareSkillButtonOnTheProfilePage()
        {
            ShareSkillPage page = new ShareSkillPage();
            page.GoToShareSkillPage();
        }

        [When(@"i added a new skill")]
        public void WhenIAddedANewSkill()
        {
            ShareSkillPage page = new ShareSkillPage();
            page.AddShareSkill();
        }

        [Then(@"i can see the new skill on listings")]
        public void ThenICanSeeTheNewSkillOnListings()
        {
            //Validate AddShareSkill
            var expectedTitle = "SpecFlow";
            var expectedDescription = "Could Be Provide";
            var actualTitle = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            var actualDescription = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description");

            Assert.That(actualTitle == expectedTitle, "title does not match");
            Assert.That(actualDescription == expectedDescription, "description does not match");
        }

        [Given(@"i clicked on the manage listungs link on the profile page")]
        public void GivenIClickedOnTheManageListungsLinkOnTheProfilePage()
        {
            ShareSkillPage page = new ShareSkillPage();
            page.GoToManageListingPage();
        }

        [When(@"i updated '([^']*)', '([^']*)' of the skill")]
        public void WhenIUpdatedOfTheSkill(string p0, string p1)
        {
            ShareSkillPage page = new ShareSkillPage();
            page.EditShareSkill(p0, p1);
        }

        [Then(@"i can see the updated '([^']*)', '([^']*)' skill on listings")]
        public void ThenICanSeeTheUpdatedSkillOnListings(string p0, string p1)
        {
            //Validate Edit Share Skill
            var actualTitle = p0;
            var actualDescription = p1;
            var expectedTitle = "Selenium";
            var expectedDescription = "Happy to help with API";
            Assert.That(actualTitle == expectedTitle, "Actual Title and Expected Title does not match");
            Assert.That(actualDescription == expectedDescription, "Actual Description  and Expected Description does not match");
        }


        [When(@"i deleted '([^']*)' record")]
        public void WhenIDeletedRecord(string p0)
        {
            ShareSkillPage page = new ShareSkillPage();
            page.GoToManageListingPage();
            page.DeleteShareSkill(p0);
        }

        [Then(@"i can not see the '([^']*)' record on listings")]
        public void ThenICanNotSeeTheRecordOnListings(string p0)
        {
            ShareSkillPage page = new ShareSkillPage();

            Assert.IsTrue(page.DeleteShareSkill(p0), "Record deleted. I can't see edited language");
        }

    }
}
