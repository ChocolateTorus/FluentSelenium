using System;
using FluentAssertions;
using FluentSelenium;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FluentTests.Expects
{
    [TestFixture]
    public class InputValueProviderTests
    {
        [Test]
        public void ShouldBeAbleToVerifyIfValueOfElementMatches()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("foo");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").ToBe("foo");
                act.ShouldNotThrow();
            }
        }

        [Test]
        public void ShouldThrowExceptionIfValueOfElementDoesNotMatchWhenExpectedTo()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("fizz");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").ToBe("buzz");
                act.ShouldThrow<Exception>();
            }
        }

        [Test]
        public void ShouldBeAbleToVerifyIfValueOfElementDoesNotMatch()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("foo");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").NotToBe("bar");
                act.ShouldNotThrow();
            }
        }

        [Test]
        public void ShouldThrowExceptionIfValueOfElementMatchesWhenExpectedNotTo()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("fizz");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").NotToBe("fizz");
                act.ShouldThrow<Exception>();
            }
        }
    }
}
