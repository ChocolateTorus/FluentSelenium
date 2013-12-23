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

        public ICountProvider TheNumberOf(FluentSelector selector)
        {
            return new CountProvider(selector, driver);
        }
    }

    public interface ICountProvider
    {
        void ToBe(int count);
    }

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