using System;
using System.Collections.ObjectModel;
using FluentSelenium.Actions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FluentSelenium.Expects
{
    public abstract class WaitableElementProvider
    {
        private readonly WebDriverWait driver;
        private readonly FluentSelector selector;

        protected WaitableElementProvider(FluentSelector selector, IWebDriver driver)
        {
            this.driver = new WebDriverWait(driver, new TimeSpan(0));
            this.selector = selector;
        }

        protected WaitableElementProvider(FluentSelector selector, IWebDriver driver, TimeSpan timeSpan)
            : this(selector, driver)
        {
            this.driver.Timeout = timeSpan;
        }

        protected void WithIn(int milliseconds)
        {
            driver.Timeout = new TimeSpan(0, 0, 0, 0, milliseconds);
        }

        protected IWebElement GetWebElement()
        {
            return driver.Until(d => d.FindElement(selector.Criteria));
        }

        protected ReadOnlyCollection<IWebElement> GetWebElements()
        {
            return driver.Until(d => d.FindElements(selector.Criteria));
        }
    }
}