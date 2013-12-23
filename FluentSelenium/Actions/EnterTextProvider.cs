using FluentSelenium.Actions.Interfaces;
using OpenQA.Selenium;

namespace FluentSelenium.Actions
{
    public class EnterTextProvider : IEnterTextProvider
    {
        private readonly IWebDriver driver;
        private readonly string text;

        internal EnterTextProvider(string text, IWebDriver driver)
        {
            this.text = text;
            this.driver = driver;
        }

        public void Into(FluentSelector selector)
        {
            driver.FindElement(selector.Criteria).SendKeys(text);
        }
    }
}