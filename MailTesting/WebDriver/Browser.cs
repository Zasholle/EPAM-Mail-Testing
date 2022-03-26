using System;
using OpenQA.Selenium;

namespace MailTesting.WebDriver
{
    public class Browser
    {
        private static Browser _instance;
        private static IWebDriver _driver;
        public static BrowserFactory.BrowserType CurrentBrowser;
        public static int Wait;
        public static double TimeoutForElement;
        private static string _browser;

        private Browser()
        {
            InitParams();
            BrowserFactory.GetDriver(CurrentBrowser, Wait);
        }

        private static void InitParams()
        {
            int.TryParse(Configuration.ElementTimeout, out Wait);
            double.TryParse(Configuration.ElementTimeout, out TimeoutForElement);
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out CurrentBrowser);
        }

        public static Browser GetInstance() => _instance ?? (_instance = new Browser());

        public static void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void Quit()
        {
            _driver.Quit();
            _instance = null;
            _driver = null;
            _browser = null;
        }
    }
}
