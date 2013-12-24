using System;
using System.Reflection;
using FluentSelenium.Actions;
using FluentSelenium.Expects.Interfaces;
using OpenQA.Selenium;

namespace FluentSelenium.Expects
{
    public class NumericComparer : WaitableElementProvider, INumericComparer
    {
        public NumericComparer(FluentSelector selector, IWebDriver driver)
            : base(selector, driver)
        { }

        public NumericComparer(FluentSelector selector, IWebDriver driver, TimeSpan timeSpan)
            : base(selector, driver, timeSpan)
        {
            
        }

        public void AtLeast(int minimumExpectedCount)
        {
            var actualCount = GetWebElements().Count;

            if (actualCount < minimumExpectedCount) throw new Exception(string.Format("Expected atleast {0} elements but found {1}", minimumExpectedCount, actualCount));
        }

        public void LessThan(int maximumExpectedAmount)
        {
            var actualCount = GetWebElements().Count;

            if (actualCount >= maximumExpectedAmount) throw new Exception(string.Format("Expected less than {0} elements but found {1}", maximumExpectedAmount, actualCount));
        }

        public void Exactly(int expectedAmount)
        {
            var actualCount = GetWebElements().Count;

            if (actualCount != expectedAmount) throw new Exception(string.Format("Expected exactly {0} elements for but {1}", expectedAmount, actualCount));
        }
    }
}