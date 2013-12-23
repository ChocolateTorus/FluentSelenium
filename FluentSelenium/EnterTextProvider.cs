using OpenQA.Selenium;

namespace FluentSelenium
{
    public class EnterTextProvider : IEnterTextProvider
    {
        private readonly string text;
        private readonly IWebDriver driver;

        internal EnterTextProvider(string text, IWebDriver driver)
        {
            this.text = text;
            this.driver = driver;
        }

        public void Into(string selector)
        {
            driver.FindElement(By.CssSelector(selector)).SendKeys(text);
        }
    }
}