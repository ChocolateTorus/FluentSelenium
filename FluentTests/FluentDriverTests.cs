using FluentSelenium;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FluentTests
{
    [TestFixture]
    public class FluentDriverTests
    {


        private const string google = "http://www.google.com";
        [Test]
        public void ShouldGoToPage()
        {
            var driver = new Mock<IWebDriver>();
            var navigation = new Mock<INavigation>();

            driver.Setup(d => d.Navigate()).Returns(navigation.Object);
            navigation.Setup(n => n.GoToUrl(google)).Verifiable();

            using (var I = new FluentDriver(driver.Object))
            {
                I.OpenPage(google);
            }

            navigation.Verify();
        }

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

        
    }
}