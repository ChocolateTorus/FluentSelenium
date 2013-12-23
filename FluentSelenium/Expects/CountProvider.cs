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

        public void ToBe(int count)
        {
            throw new System.NotImplementedException();
        }
    }
}