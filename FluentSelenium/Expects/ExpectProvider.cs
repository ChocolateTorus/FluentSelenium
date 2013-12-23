using FluentSelenium.Actions;
using FluentSelenium.Expects.Interfaces;
using OpenQA.Selenium;

namespace FluentSelenium.Expects
{
    public class ExpectProvider : IExpectProvider
    {
        private readonly IWebDriver driver;

        public ExpectProvider(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IElementValueProvider ValueOf(FluentSelector selector)
        {
            return new InputValueProvider(selector, driver);
        }

        public IVisibilityProvider ToSee(FluentSelector selector)
        {
            return new VisibilityProvider(selector, driver);
        }
    }
}