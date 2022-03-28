using MailTesting.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailTesting.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;

        [TestInitialize]
        public virtual void InitTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TestCleanup]
        public virtual void TestClean()
        {
            Browser.Quit();
        }
    }
}
