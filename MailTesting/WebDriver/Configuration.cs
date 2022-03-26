using System.Configuration;

namespace MailTesting.WebDriver
{
    public class Configuration
    {
        public static string GetEnvironment(string s, string defaultValue)
        {
            return ConfigurationManager.AppSettings[s] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironment("ElementTimeout", "30");
        public static string Browser => GetEnvironment("Browser", "Chrome");
        public static string StartUrl => GetEnvironment("startUrl", "https://mail.google.com/");
    }
}
