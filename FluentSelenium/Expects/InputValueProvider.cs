using System;
using FluentSelenium.Actions;
using FluentSelenium.Expects.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace FluentSelenium.Expects
{
    public class InputValueProvider : IElementValueProvider
    {
        private readonly WebDriverWait driver;
        private readonly FluentSelector selector;


        public InputValueProvider(FluentSelector selector, IWebDriver driver)
        {
            this.selector = selector;
            this.driver = new WebDriverWait(driver, new TimeSpan(0));
        }

        public void ToBe(string value)
        {
            IWebElement element = driver.Until(d => d.FindElement(selector.Criteria));
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

        public IElementValueProvider WithIn(int milliseconds)
        {
            driver.Timeout = new TimeSpan(0, 0, 0, 0, milliseconds);
            return this;
        }
    }
}