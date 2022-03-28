using MailTesting.WebDriver;
using OpenQA.Selenium;

namespace MailTesting.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By HomeLabel = By.ClassName("c021");
        private string _email = "testnewmail@rambler.ru";
        private string _password = "TestPassword22";

        public HomePage() : base(HomeLabel, "HomePage") {}

        private readonly BaseElement _searchFrame = new BaseElement(By.XPath("//div[@class='c0219']//iframe"));
        private readonly BaseElement _emailInput = new BaseElement(By.XPath("//input[@type='email']"));
        private readonly BaseElement _passwordInput = new BaseElement(By.XPath("//input[@type='password']"));
        private readonly BaseElement _submit = new BaseElement(By.ClassName("rui-Button-content"));

        public void SignIn()
        {
            Browser.GetDriver().SwitchTo().Frame(_searchFrame.GetElement());
            _emailInput.SendKeys(_email);
            _passwordInput.SendKeys(_password);
            _submit.Click();
            Browser.GetDriver().SwitchTo().DefaultContent();
        }
    }
}
