using FluentSelenium;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FluentTests.Actions
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void ShouldBeAbleToFindAnElement()
        {

            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.SendKeys(It.IsAny<string>())).Verifiable();

            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object).Verifiable();

            using (var I = new FluentDriver(driver.Object))
            {
                I.EnterText("cats").Into("#gbqfq");
            }

            driver.Verify();
            webElement.Verify();
        }

        [Test]
        public void ShouldBeAbleToClickOnAnElement()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.Click()).Verifiable();
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object).Verifiable();

            using (var I = new FluentDriver(driver.Object))
            {
                I.Click().On("#search");
            }

            driver.Verify();
            webElement.Verify();
        }
    }
}