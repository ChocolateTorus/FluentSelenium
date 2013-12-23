using System;
using System.Linq;
using FluentAssertions;
using FluentSelenium;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FluentTests.Integration
{
    [TestFixture]
    public class BasicOperationTests
    {
        private const string google = "http://www.google.com?complete=0";

        [Test]
        public void ShouldGoToPageEnterTextAndClickButton()
        {
            using (var I = new FluentDriver(new FirefoxDriver(null, new FirefoxProfile { EnableNativeEvents = false })))
            {
                I.OpenPage(google);
                I.EnterText("cats").Into("input[name=\"q\"]");
                I.Click().On("input[name=\"btnK\"]");
            }
        }

        [Test]
        public void ShouldGoToPageEnterTextClickButtonAndWaitForElementsToAppear()
        {
            using (var I = new FluentDriver(new FirefoxDriver(null, new FirefoxProfile { EnableNativeEvents = false })))
            {
                I.OpenPage(google);
                I.EnterText("cats").Into("input[name=\"q\"]");
                I.Expect().ValueOf("input[name=\"q\"]").ToBe("cats");
            }
        }

        [Test]
        public void ShouldWaitForElementsToAppear()
        {
            using (var I = new FluentDriver(new FirefoxDriver(null, new FirefoxProfile { EnableNativeEvents = false })))
            {
                I.OpenPage(google);
                I.EnterText("cats").Into("input[name=\"q\"]");
                I.Click().On("input[name=\"btnK\"]");
                I.Expect().ValueOf("#lst-ib").WithIn(2000).ToBe("cats");
            }
        }

        [Test]
        public void ShouldNotWaitForElementsToAppearAndThrow()
        {
            using (var I = new FluentDriver(new FirefoxDriver(null, new FirefoxProfile { EnableNativeEvents = false })))
            {
                I.OpenPage(google);
                I.EnterText("cats").Into("input[name=\"q\"]");
                I.Click().On("input[name=\"btnK\"]");
                Action act = () => { I.Expect().ValueOf("lst-ib").ToBe("cats"); };
                act.ShouldThrow<Exception>();
            }
        }
    }
}