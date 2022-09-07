using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.Global;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MarsFramework.SpecFlowTest 
{
    [Binding]
    public  class TestStart : Base
    {
       [BeforeScenario]
        public void SetUp()
        {
            // Initialise the browser
            Initialize();
        }

        [AfterScenario]
        public  void SetDown()
        {
            //close the window
            Thread.Sleep(1000);
            TearDown();
        }
    }
}
