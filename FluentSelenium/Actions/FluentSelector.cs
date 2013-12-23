using OpenQA.Selenium;

namespace FluentSelenium.Actions
{
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