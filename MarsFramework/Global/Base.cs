using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static String ExcelPathEdit = MarsResource.ExcelPathEdit;
        public static String ExcelPathDelete = MarsResource.ExcelPathDelete;
        public static String ExcelPathProfilePage = MarsResource.ExcelPathProfilePage;
        public static string ScreenShotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLpath = MarsResource.ReportXMLPath;
        public static string ImagePath = MarsResource.ImagePath;

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

            Thread.Sleep(1000);

            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.Driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.Driver = new ChromeDriver();
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

            extent.LoadConfig(projectPath + ReportXMLpath);

            #endregion


            if (MarsResource.IsLogin.ToLower() == "true")
            {
                Thread.Sleep(1000);

                SignIn loginobj = new SignIn();
                loginobj.LoginSteps(Driver);
            }
            else
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                SignUp obj = new SignUp();
                obj.Register();
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
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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