using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace FluentTests
{
    [TestFixture]
    public class SeleniumConfigTests
    {
        private static IWebDriver driver;

        private IWebDriver GetDriver()
        {
            return driver ?? (driver = new FirefoxDriver());
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }

        [Test]
        public void ShouldBeAbleToConfigAFireFoxDriver()
        {
            GetDriver();
        }

        [Test]
        public void ShouldBeAbleToOpenAPage()
        {
            var driver = GetDriver();

            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Title.Should().Contain("oogle");
        }
    }
}