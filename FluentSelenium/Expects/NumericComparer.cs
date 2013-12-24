using System;
using FluentSelenium.Actions;
using OpenQA.Selenium;

namespace FluentSelenium.Expects
{
    public class NumericComparer : INumericComparer
    {
        private readonly FluentSelector selector;
        private readonly IWebDriver driver;

        public NumericComparer(FluentSelector selector, IWebDriver driver)
        {
            this.selector = selector;
            this.driver = driver;
        }

        public void AtLeast(int minimumExpectedCount)
        {
            var actualCount = driver.FindElements(selector.Criteria).Count;

            if (actualCount < minimumExpectedCount) throw new Exception(string.Format("Expected atleast {0} elements but found {1}", minimumExpectedCount, actualCount));
        }

        public void LessThan(int maximumExpectedAmount)
        {
            var actualCount = driver.FindElements(selector.Criteria).Count;

            if (actualCount >= maximumExpectedAmount) throw new Exception(string.Format("Expected less than {0} elements but found {1}", maximumExpectedAmount, actualCount));
        }
    }
}