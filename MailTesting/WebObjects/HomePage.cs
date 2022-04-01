using MailTesting.Entities;
using MailTesting.WebDriver;
using OpenQA.Selenium;

namespace MailTesting.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By HomeLabel = By.ClassName("c021");

        public HomePage() : base(HomeLabel, "HomePage") { }

        private readonly BaseElement _searchFrame = new BaseElement(By.XPath("//div[@class='c0219']//iframe"));
        private readonly BaseElement _emailInput = new BaseElement(By.XPath("//input[@type='email']"));
        private readonly BaseElement _passwordInput = new BaseElement(By.XPath("//input[@type='password']"));
        private readonly BaseElement _submit = new BaseElement(By.ClassName("rui-Button-content"));

        public void SignIn(User user)
        {
            Browser.GetDriver().SwitchTo().Frame(_searchFrame.GetElement());
            _emailInput.SendKeys(user.UserData[0]);
            _passwordInput.SendKeys(user.UserData[1]);
            _submit.Click();
            Browser.GetDriver().SwitchTo().DefaultContent();
        }
    }
}
