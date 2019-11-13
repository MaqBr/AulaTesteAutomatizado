using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

namespace AulaTesteAutomatizado.Config
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver,
            TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void SetDropDown(this IWebDriver webDriver,
    By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            var selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(text);
        }

        public static void SetText(this IWebDriver webDriver,
            By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            if (!(webDriver is InternetExplorerDriver))
                webElement.Submit();
            else
                webElement.SendKeys(Keys.Enter);
        }
    }
}