using System;
using FluentSelenium.Actions;
using FluentSelenium.Expects.Interfaces;
using OpenQA.Selenium;

namespace FluentSelenium.Expects
{
    public class InputValueProvider : IElementValueProvider
    {
        private readonly IWebDriver driver;
        private readonly FluentSelector selector;

        public InputValueProvider(FluentSelector selector, IWebDriver driver)
        {
            this.selector = selector;
            this.driver = driver;
        }

        public void ToBe(string value)
        {
            IWebElement element = driver.FindElement(selector.Criteria);
            string elementValue = element.GetAttribute("value");

            if (elementValue != value)
            {
                throw new Exception(string.Format("Expected value to be {0} but it was {1}", value, elementValue));
            }
        }

        public void ToBe(int value)
        {
            ToBe(value.ToString());
        }
    }
}