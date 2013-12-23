using OpenQA.Selenium;

namespace FluentSelenium
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

        public void Into(string selector)
        {
            driver.FindElement(By.CssSelector(selector)).SendKeys(text);
        }
    }
}