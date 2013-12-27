using System;
using FluentAssertions;
using FluentSelenium;
using NUnit.Framework;
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
        public void CanVerifyValueOfTextbox()
        {
            using (var I = new FluentDriver(new FirefoxDriver(null, new FirefoxProfile { EnableNativeEvents = false })))
            {
                I.OpenPage(google);
                I.EnterText("cats").Into("input[name=\"q\"]");
                
                Action toBeAction = () => I.Expect().ValueOf("input[name=\"q\"]").ToBe("cats");
                toBeAction.ShouldNotThrow<Exception>();

                Action notToBeAction = () => I.Expect().ValueOf("input[name=\"q\"]").NotToBe("dogs");
                notToBeAction.ShouldNotThrow<Exception>();
            }
        }

        [Test]
        public void ShouldGoToPageEnterTextClickButtonAndWaitForElementsToAppear()
        {
            using (var I = new FluentDriver(new FirefoxDriver(null, new FirefoxProfile { EnableNativeEvents = false })))
            {
                I.OpenPage(google);
                I.EnterText("cats").Into("input[name=\"q\"]");
                Action act = () => I.Expect().ValueOf("input[name=\"q\"]").ToBe("cats");
                act.ShouldNotThrow<Exception>();
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
                Action act = () => I.Expect().ValueOf("#lst-ib").WithIn(2000).ToBe("cats");
                act.ShouldNotThrow<Exception>();
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