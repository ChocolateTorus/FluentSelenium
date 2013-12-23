using System.Net.NetworkInformation;
using OpenQA.Selenium;

namespace FluentSelenium
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

    public class FluentSelector
    {
        public By Criteria { get; set; }

        public FluentSelector(string selector)
        {
            this.Criteria = By.CssSelector(selector);
        }

        public FluentSelector(By criteria)
        {
            Criteria = criteria;
        }

        public static implicit operator FluentSelector(string selector)
        {
            return new FluentSelector(selector);
        }

        public static implicit operator FluentSelector(By selector)
        {
            return new FluentSelector(selector);
        }
    }
}