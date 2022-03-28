using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace MailTesting.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Firefox,
            Chrome,
            Edge,
            Opera
        }

        public static IWebDriver GetDriver(BrowserType type, int timeoutSec)
        {
            IWebDriver driver;

            switch (type)
            {
                case BrowserType.Chrome:
                {
                    var services = ChromeDriverService.CreateDefaultService();
                    var option = new ChromeOptions();
                    option.AddArgument("disable-infobars");
                    driver = new ChromeDriver(services, option, TimeSpan.FromSeconds(timeoutSec));
                    break;
                }
                case BrowserType.Firefox:
                {
                    var services = FirefoxDriverService.CreateDefaultService();
                    var option = new FirefoxOptions();
                    driver = new FirefoxDriver(services, option, TimeSpan.FromSeconds(timeoutSec));
                    break;
                }
                case BrowserType.Edge:
                {
                    var services = EdgeDriverService.CreateDefaultService();
                    var option = new EdgeOptions();
                    driver = new EdgeDriver(services, option, TimeSpan.FromSeconds(timeoutSec));
                    break;
                }
                case BrowserType.Opera:
                {
                    var services = OperaDriverService.CreateDefaultService();
                    var option = new OperaOptions();
                    driver = new OperaDriver(services, option, TimeSpan.FromSeconds(timeoutSec));
                    break;
                }
                default:
                {
                    var services = ChromeDriverService.CreateDefaultService();
                    var option = new ChromeOptions();
                    option.AddArgument("disable-infobars");
                    driver = new ChromeDriver(services, option, TimeSpan.FromSeconds(timeoutSec));
                    break;
                }
            }

            return driver;
        }
    }

}
