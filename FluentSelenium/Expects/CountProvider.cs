using System;
using FluentSelenium.Actions;
using FluentSelenium.Expects.Interfaces;
using OpenQA.Selenium;

namespace FluentSelenium.Expects
{
    public class CountProvider : IWaitableCountProvider
    {
        private readonly IWebDriver driver;
        private readonly FluentSelector selector;
        private TimeSpan timeSpan;

        internal CountProvider(FluentSelector selector, IWebDriver driver)
        {
            this.driver = driver;
            this.selector = selector;
        }

        public ICountProvider WithIn(int milliseconds)
        {
            timeSpan = new TimeSpan(0, 0, 0, 0, milliseconds);
            return this;
        }

        public INumericComparer ToBe()
        {
            return new NumericComparer(selector, driver, timeSpan);
        }
    }
}