using System;
using System.Threading;
using MailTesting.Entities;
using MailTesting.WebDriver;
using OpenQA.Selenium;

namespace MailTesting.WebObjects
{
    public class MailBoxPage : BasePage
    {
        private static readonly By MailBoxLabel = By.ClassName("AutoAppContainer-inner-1B");

        public MailBoxPage() : base(MailBoxLabel, "MailBoxPage") { }

        private readonly BaseElement _writeButton = new BaseElement(By.ClassName("rui-Button-content"));
        private readonly BaseElement _saveButton = new BaseElement(By.XPath("//span[.='Сохранить черновик']"));
        private readonly BaseElement _profileButton = new BaseElement(By.ClassName("rui__2FTrL"));
        private readonly BaseElement _logOutButton = new BaseElement(By.XPath("//button[@class='rui__1iR9f']"));
        private readonly BaseElement _draftsButton = new BaseElement(By.XPath("//span[.='Черновики']"));
        private readonly BaseElement _deleteButton = new BaseElement(By.XPath("//div[@data-list-view='letter::trash']"));

        private readonly BaseElement _receiverInput = new BaseElement(By.Id("receivers"));
        private readonly BaseElement _subjectInput = new BaseElement(By.Id("subject"));
        private readonly BaseElement _textInput = new BaseElement(By.XPath("//body[@id='tinymce']//div"));
        
        private readonly BaseElement _searchFrame = new BaseElement(By.Id("editor_ifr"));

        private readonly BaseElement _draftsCount =
            new BaseElement(By.XPath("//div[@class='FoldersItem-right-2G']/div[2]"));

        public int GetDraftsCount()
        {
            Thread.Sleep(1000);

            int.TryParse(_draftsCount.GetText(), out var res);
            return res;
        }

        public void CreateMessage(Letter letter)
        {
            _writeButton.Click();
            _receiverInput.SendKeys(letter.LetterData[0]);
            _subjectInput.SendKeys(letter.LetterData[1]);
            Browser.GetDriver().SwitchTo().Frame(_searchFrame.GetElement());
            _textInput.SendKeys(letter.LetterData[2]);
            Browser.GetDriver().SwitchTo().DefaultContent();
            _saveButton.Click();
        }

        public void LogOut()
        {
            _profileButton.Click();
            _logOutButton.Click();
        }

        public void DeleteDraft(string subject)
        {
            var draftButton = new BaseElement(By.XPath($"//span[text()='{subject}']"));

            _draftsButton.Click();
            draftButton.Click();
            _deleteButton.Click();
        }
    }
}
