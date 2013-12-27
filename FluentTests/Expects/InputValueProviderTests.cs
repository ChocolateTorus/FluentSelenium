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

        [Test]
        public void ShouldBeAbleToVerifyIfIntegerValueOfElementMatches()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("7");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").ToBe("7");
                act.ShouldNotThrow();
            }
        }

        [Test]
        public void ShouldThrowExceptionIfIntegerValueOfElementDoesNotMatchWhenExpectedTo()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("7");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").ToBe("34");
                act.ShouldThrow<Exception>();
            }
        }

        [Test]
        public void ShouldBeAbleToVerifyIfIntegerValueOfElementDoesNotMatch()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("4");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").NotToBe("23");
                act.ShouldNotThrow();
            }
        }

        [Test]
        public void ShouldThrowExceptionIfIntegerValueOfElementMatchesWhenExpectedNotTo()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("3");
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object);

            using (var I = new FluentDriver(driver.Object))
            {
                Action act = () => I.Expect().ValueOf("input").NotToBe("3");
                act.ShouldThrow<Exception>();
            }
        }
    }
}
