using System;
using System.Collections.ObjectModel;
using System.Drawing;
using MailTesting.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailTesting.WebObjects
{
    public class BaseElement : IWebElement
    {
        private readonly IWebDriver _driver = Browser.GetDriver();
        protected string Name;
        protected By Locator;
        protected IWebElement Element;

        public BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name == "" ? GetText() : name;
        }

        public string GetText()
        {
            WaitForIsVisible();
            return Element.Text;
        }

        public IWebElement GetElement()
        {
            try
            {
                Element = Browser.GetDriver().FindElement(Locator);
            }
            catch (Exception)
            {
                throw;
            }
            return Element;
        }

        public void WaitForIsVisible()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0,0,30));

            wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _driver.FindElement(Locator);
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public IWebElement FindElement(By @by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(Locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(Locator).Click();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public string TagName { get; }
        public string Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed { get; }
    }
}
