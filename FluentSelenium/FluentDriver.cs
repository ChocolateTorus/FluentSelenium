using System;
using OpenQA.Selenium;

namespace FluentSelenium
{
    public class FluentDriver : IDisposable
    {
        public FluentDriver(IWebDriver browserDriver)
        {
            Driver = browserDriver;
        }

        [Obsolete("This is an escape hatch that should not be depended on.")]
        internal IWebDriver Driver { get; set; }

        public void Dispose()
        {
            if (Driver == null) return;

            Driver.Dispose();
            Driver = null;
        }

        public FluentDriver OpenPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
            return this;
        }

        public IEnterTextProvider EnterText(string text)
        {
            return new EnterTextProvider(text, Driver);
        }

        public IClickProvider Click()
        {
            return new ClickProvider(Driver);
        }

        public IExpectProvider Expect()
        {
            return new ExpectProvider(Driver);
        }
    }
}