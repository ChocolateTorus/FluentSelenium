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

        public void On(string selector)
        {
            driver.FindElement(By.CssSelector(selector)).Click();
        }
    }
}