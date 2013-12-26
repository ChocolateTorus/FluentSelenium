using System;
using FluentSelenium.Actions;
using FluentSelenium.Expects.Interfaces;
using OpenQA.Selenium;

namespace FluentSelenium.Expects
{
    public class VisibilityProvider : WaitableElementProvider, IVisibilityProvider
    {
        public VisibilityProvider(FluentSelector selector, IWebDriver driver)
            : base(selector, driver)
        { }
        public void Immediately()
        {
            CheckVisibility(GetWebElement());
        }

        public new void WithIn(int milliseconds)
        {
            base.WithIn(milliseconds);
            CheckVisibility(GetWebElement());
        }

        private void CheckVisibility(IWebElement element)
        {
            //TODO : custom exceptions
            if (!element.Displayed) throw new Exception();
        }
    }
}