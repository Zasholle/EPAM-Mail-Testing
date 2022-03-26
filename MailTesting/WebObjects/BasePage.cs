using OpenQA.Selenium;

namespace MailTesting.WebObjects
{
    public class BasePage
    {
        protected By TitleLocator;
        protected string Title;
        public static string TitleForm;

        protected BasePage(By titleLocator, string title)
        {
            TitleLocator = titleLocator;
            Title = TitleForm = title;
            AssertIsOpen();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(TitleLocator, Title);
            label.WaitForIsVisible();
        }
    }
}
