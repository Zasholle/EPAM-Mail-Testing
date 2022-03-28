using MailTesting.WebObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailTesting.Tests
{
    [TestClass]
    public class MailTest : BaseTest
    {
        private HomePage _homePage;
        private MailBoxPage _mailBoxPage;

        [TestMethod]
        public void MessageCreationTest()
        {
            _homePage = new HomePage();
            _homePage.SignIn();

            _mailBoxPage = new MailBoxPage();
            _mailBoxPage.CreateMessage();
            _mailBoxPage.LogOut();
        }

        [TestMethod]
        public void DraftDeletionTest()
        {
            _homePage = new HomePage();
            _homePage.SignIn();

            _mailBoxPage = new MailBoxPage();

            if (_mailBoxPage.CheckDraft())
                _mailBoxPage.DeleteDraft();

            _mailBoxPage.LogOut();
        }
    }
}
