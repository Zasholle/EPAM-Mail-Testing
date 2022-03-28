using MailTesting.WebDriver;
using OpenQA.Selenium;

namespace MailTesting.WebObjects
{
    public class MailBoxPage : BasePage
    {
        private static readonly By MailBoxLabel = By.ClassName("AutoAppContainer-inner-1B");
        private const string Receiver = "testmail@rambler.ru";
        private const string Subject = "Test Subject";
        private const string Text = "Test text for my task in EPAM";

        public MailBoxPage() : base(MailBoxLabel, "MailBoxPage") {}

        private readonly BaseElement _writeButton = new BaseElement(By.ClassName("rui-Button-content"));
        private readonly BaseElement _saveButton = new BaseElement(By.XPath("//span[.='Сохранить черновик']"));
        private readonly BaseElement _profileButton = new BaseElement(By.ClassName("rui__2FTrL"));
        private readonly BaseElement _logOutButton = new BaseElement(By.XPath("//button[@class='rui__1iR9f']"));
        private readonly BaseElement _draftsButton = new BaseElement(By.XPath("//span[.='Черновики']"));
        private readonly BaseElement _draftButton = new BaseElement(By.XPath($"//span[.='{Subject}']"));
        private readonly BaseElement _deleteButton = new BaseElement(By.XPath("//div[@data-list-view='letter::trash']"));

        private readonly BaseElement _receiverInput = new BaseElement(By.Id("receivers"));
        private readonly BaseElement _subjectInput = new BaseElement(By.Id("subject"));
        private readonly BaseElement _textInput = new BaseElement(By.XPath("//body[@id='tinymce']//div"));
        
        private readonly BaseElement _searchFrame = new BaseElement(By.Id("editor_ifr"));

        public void CreateMessage()
        {
            _writeButton.Click();
            _receiverInput.SendKeys(Receiver);
            _subjectInput.SendKeys(Subject);
            Browser.GetDriver().SwitchTo().Frame(_searchFrame.GetElement());
            _textInput.SendKeys(Text);
            Browser.GetDriver().SwitchTo().DefaultContent();
            _saveButton.Click();
        }

        public void LogOut()
        {
            _profileButton.Click();
            _logOutButton.Click();
        }

        public bool CheckDraft()
        {
            _draftsButton.Click();
            return _draftButton.Text == Subject;
        }

        public void DeleteDraft()
        {
            _draftButton.Click();
            _deleteButton.Click();
        }
    }
}
