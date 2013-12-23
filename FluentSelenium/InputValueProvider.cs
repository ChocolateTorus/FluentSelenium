using System;
using OpenQA.Selenium;

namespace FluentSelenium
{
    public class InputValueProvider : IElementValueProvider
    {
        private readonly IWebDriver driver;
        private readonly string selector;

        public InputValueProvider(string selector, IWebDriver driver)
        {
            this.selector = selector;
            this.driver = driver;
        }

        public void ToBe(string value)
        {
            IWebElement element = driver.FindElement(By.CssSelector(selector));
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