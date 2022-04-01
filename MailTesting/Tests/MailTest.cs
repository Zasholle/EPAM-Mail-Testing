using MailTesting.Entities;
using MailTesting.WebObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailTesting.Tests
{
    [DeploymentItem(@"Resources")]
    [TestClass]
    public class MailTest : BaseTest
    {
        private HomePage _homePage;
        private MailBoxPage _mailBoxPage;

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void MessageCreationTest()
        {
            _homePage = new HomePage();
            _homePage.SignIn(InitUser());

            _mailBoxPage = new MailBoxPage();
            _mailBoxPage.CreateMessage(InitLetter());
            _mailBoxPage.LogOut();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void DraftDeletionTest()
        {
            _homePage = new HomePage();
            _homePage.SignIn(InitUser());

            var subject = TestContext.DataRow["subject"].ToString();

            _mailBoxPage = new MailBoxPage();

            _mailBoxPage.DeleteDraft(subject);

            _mailBoxPage.LogOut();
        }

        public User InitUser()
        {
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();

            return new User(email, password);
        }

        public Letter InitLetter()
        {
            var receiver = TestContext.DataRow["receiver"].ToString();
            var subject = TestContext.DataRow["subject"].ToString();
            var text = TestContext.DataRow["text"].ToString();

            return new Letter(receiver, subject, text);
        }
    }
}
