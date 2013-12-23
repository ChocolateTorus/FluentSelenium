﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentSelenium;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FluentTests.Expects
{
    [TestFixture]
    public class ExpectTests
    {
        [Test]
        public void ShouldBeAbleToReadValueOfTextInput()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.GetAttribute("value")).Returns("foo").Verifiable();
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object).Verifiable();

            using (var I = new FluentDriver(driver.Object))
            {
                I.Expect().ValueOf("input").ToBe("foo");
            }

            driver.Verify();
            webElement.Verify();
        }

        [Test]
        public void ShouldWaitForCheckingVisibilityImmediately()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.Displayed).Returns(true).Verifiable();
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object).Verifiable();

            using (var I = new FluentDriver(driver.Object))
            {
                I.Expect().ToSee("#id").Now();
            }
        }

        [Test]
        public void ShouldWaitForCheckingVisibilityWithIn1Second()
        {
            var driver = new Mock<IWebDriver>();
            var webElement = new Mock<IWebElement>();

            webElement.Setup(e => e.Displayed).Returns(true).Verifiable();
            driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(webElement.Object).Verifiable();

            using (var I = new FluentDriver(driver.Object))
            {
                I.Expect().ToSee("#id").WithIn(1000);
            }
        }

        [Test]
        public void ShouldExpect4Items()
        {
            var driver = new Mock<IWebDriver>();
            var elementsList = new List<IWebElement>
            {
                new FirefoxWebElement(null, "@"),
                new FirefoxWebElement(null, "@"),
                new FirefoxWebElement(null, "@"),
                new FirefoxWebElement(null, "@")
            };

            var foundElements = new ReadOnlyCollection<IWebElement>(elementsList);
            driver.Setup(el => el.FindElements(It.IsAny<By>())).Returns(foundElements);

            using (var I = new FluentDriver(driver.Object))
            {
                I.Expect().TheNumberOf("ds").ToBe(4);
            }
        }
    }
}