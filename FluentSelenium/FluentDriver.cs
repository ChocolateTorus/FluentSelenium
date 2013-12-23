using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FluentSelenium
{
    public class FluentDriver : IDisposable
    {
        public FluentDriver(IWebDriver browserDriver)
        {
            Driver = browserDriver;
        }
        internal IWebDriver Driver { get; set; }

        public FluentDriver OpenPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
            return this;
        }

        public IEnterTextProvider EnterText(string text)
        {
            return new EnterTextProvider(text, Driver);
        }

        public void Dispose()
        {
            if (Driver == null) return;

            Driver.Dispose();
            Driver = null;
        }

        public IClickProvider Click()
        {
            return new ClickProvider(Driver);
        }
    }

    public interface IClickProvider
    {
        void On(string selector);
    }

    public class ClickProvider : IClickProvider
    {
        private readonly IWebDriver driver;

        public ClickProvider(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void On(string selector)
        {
            driver.FindElement(By.CssSelector(selector)).Click();
        }
    }
}