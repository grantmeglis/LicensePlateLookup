using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PageFramework
{
    public static class Browser
    {
        static IWebDriver _webDriver;

        public static ISearchContext Driver { get { return _webDriver; } }

        public static void Initialize()
        {
            _webDriver = new ChromeDriver(@"..\..\..\PageFramework\bin\Debug\netcoreapp2.0");
            Goto("");
        }

        public static void Goto(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public static string Title { get { return _webDriver.Title; } }

        internal static IWebElement FindElement(By by)
        {
            return _webDriver.FindElement(by);
        }

        #region Wait
        public static bool WaitUntilElementIsDisplayed(By element, int timeoutInSeconds)
        {
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                if (ElementIsDisplayed(element))
                {
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }

        public static bool ElementIsDisplayed(By element)
        {
            var present = false;
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                present = _webDriver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
            }
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return present;
        }
        #endregion
    }
}
