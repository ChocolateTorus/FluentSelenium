using System;
using FluentSelenium.Actions;
using OpenQA.Selenium;

namespace FluentSelenium.Expects
{
    public class CountProvider : ICountProvider
    {
        private readonly IWebDriver driver;
        private readonly FluentSelector selector;

        internal CountProvider(FluentSelector selector, IWebDriver driver)
        {
            this.driver = driver;
            this.selector = selector;
        }

        public void ToBe(int expectedCount)
        {
            var actualCount = driver.FindElements(selector.Criteria).Count;

            if (actualCount != expectedCount) throw new Exception(string.Format("Expected {0} elements but found {1}", expectedCount, actualCount));
        }

        public INumericComparer ToBe()
        {
            return new NumericComparer(selector, driver);
        }
    }
}