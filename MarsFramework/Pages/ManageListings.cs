using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "//i[@class = 'eye icon']")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//i[@class = 'remove icon']")]
        private IWebElement Delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//i[@class = 'outline write icon']")]
        private IWebElement Edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class = 'actions']")]
        private IWebElement ActionsButton { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditTestData");

            //click on manage listings link
            manageListingsLink.Click();

            //click on view icon
            view.Click();

            //Click on edit icon
            Edit.Click();

            //Click on delete
            Delete.Click();

            //Click action button
            ActionsButton.Click();

        }

    }
}
