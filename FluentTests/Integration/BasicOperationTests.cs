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
                I.Expect().ValueOf("input").ToBe(4);
            }
        }


    }
}