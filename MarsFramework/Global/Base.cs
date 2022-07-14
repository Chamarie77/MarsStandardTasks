using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
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
        public static ExtentReports extent;
        public static ExtentTest test;
        int count = 1;

        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
           // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
             Thread.Sleep(3000);
            // GlobalDefinitions.wait(30);
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

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = path.Substring(0, path.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;

            //Append the html report file to current project path
            string reportPath = projectPath + ReportPath;



            //Boolean value for replacing exisisting report

            extent = new ExtentReports(reportPath, false);

            //extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            //  extent.LoadConfig(MarsResource.ReportXMLPath);
            extent.LoadConfig(projectPath + ReportXMLpath);
           
             //  test = extent.StartTest("Mars Reports");

            #endregion



            if (MarsResource.IsLogin.ToLower() == "true")
            {
                //GlobalDefinitions.WaitForElement(driver, By.XPath("//a[contains(text(),'Sign In')]"), 10);
              //  Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
               // GlobalDefinitions.wait(10);
                Thread.Sleep(3000);
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.Register();
                Thread.Sleep(2000);
               //GlobalDefinitions.wait(30);
            }
        }
              

        public void CloseReports()
        {
            extent.EndTest(test);
            extent.Flush();
        }

        [TearDown]
        public void TearDown()
        {
            // Screenshot
            Thread.Sleep(2000);
            //GlobalDefinitions.wait(30);
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "Report");
            //Status logstatus = Status.Pass;
            test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (TestReports)
            count++;
            extent.EndTest(test);
           
            
            // calling Flush writes everything to the log file (TestReports)
            extent.Flush();
            
            // Close the driver :)            
            GlobalDefinitions.Driver.Close();
            GlobalDefinitions.Driver.Quit();


            
        }

        #endregion

    }
}