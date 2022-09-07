using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.SpecFlowPages;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Config;
using OpenQA.Selenium;

namespace MarsFramework.Global
{
    public class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
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
        public void Initialize()
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
            IWebDriver Driver = Global.GlobalDefinitions.Driver;
            
            // Screenshot
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "Report");
           

            // Close the driver            
            GlobalDefinitions.Driver.Close();
            GlobalDefinitions.Driver.Quit();
        }

        #endregion
    }
}
