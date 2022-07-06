using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
//using RelevantCodes.ExtentReports;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

using static MarsFramework.Global.GlobalDefinitions;
using System.Threading;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static String ExcelPathEdit = MarsResource.ExcelPathEdit;
        public static String ExcelPathDelete = MarsResource.ExcelPathDelete;
        public static string ScreenShotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLpath = MarsResource.ReportXMLPath;

        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
            Thread.Sleep(1000);
           //GlobalDefinitions.WaitForElement(IWebdriver driver, by, 10);
            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.Driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.Driver = new ChromeDriver(@"C:\Personal\Chamarie\IndustryConnect\MarsCompetitionTask\MarsCompetitionTask\MarsFramework");
                    //GlobalDefinitions.Driver = new ChromeDriver();
                    GlobalDefinitions.Driver.Manage().Window.Maximize();
                    break;
            }

            #region Initialise Reports

            //extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent = new ExtentReports();

            //extent.Status.Equals(MarsResource.ReportPath);
           // extent.LoadConfig(MarsResource.ReportXMLPath);
            test = extent.CreateTest("Mars Reports");

            #endregion



            if (MarsResource.IsLogin == "true")
            {
                Thread.Sleep(1000);
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.Register();
                Thread.Sleep(2000);
            }

        }

        

        public void CloseReports()
        {
            extent.Flush();
        }



        [TearDown]
        public void TearDown()
        {

            // Screenshot
            Thread.Sleep(2000);
     
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "ScreenShots");//AddScreenCapture("\MarsFrameWork\TestReports\ScreenShots\");
            test.Log(Status.Info, "Image example: " + img);
            // end test. (TestReports)
            //extent.EndTest(test);
           // extent.Flush();

            StartReportsClass.StartExtent();
            StartReportsClass.ExtentClose();

            // calling Flush writes everything to the log file (TestReports)
            extent.Flush();
            // Close the driver :)            
            GlobalDefinitions.Driver.Close();
            GlobalDefinitions.Driver.Quit();


            
        }

        #endregion

    }
}