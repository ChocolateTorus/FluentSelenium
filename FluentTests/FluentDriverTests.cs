using FluentSelenium;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FluentTests
{
    [TestFixture]
    public class FluentDriverTests
    {

        [Test]
        public void ShouldGoToPage()
        {
            var driver = new Mock<IWebDriver>();
            var navigation = new Mock<INavigation>();

            driver.Setup(d => d.Navigate()).Returns(navigation.Object);
            navigation.Setup(n => n.GoToUrl(It.IsAny<string>())).Verifiable();

            using (var I = new FluentDriver(driver.Object))
            {
                I.OpenPage("http://www.google.com");
            }

            navigation.Verify();
        }
    }
}