using FluentSelenium.Actions.Interfaces;
using OpenQA.Selenium;

namespace FluentSelenium.Actions
{
    public class ClickProvider : IClickProvider
    {
        private readonly IWebDriver driver;

        public ClickProvider(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void On(FluentSelector selector)
        {
            driver.FindElement(selector.Criteria).Click();
        }
    }
}