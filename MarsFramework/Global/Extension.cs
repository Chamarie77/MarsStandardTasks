using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Global
{
    public static class Extension
    {
        #region WaitforElement 

        public static bool WaitForElementDisplayed(this IWebDriver Driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed);
        }

        public static IWebElement WaitForElementClickable(this IWebElement element, IWebDriver Driver, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
        #endregion
    }
}