using System.Configuration;

namespace MailTesting.WebDriver
{
    public class Configuration
    {
        public static string GetEnvironment(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironment("ElementTimeout", "10");
        public static string Browser => GetEnvironment("Browser", "Chrome");
        public static string StartUrl => GetEnvironment("startUrl", "https://mail.rambler.ru/");
    }
}
