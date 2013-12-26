using System;
using FluentSelenium.Actions;
using FluentSelenium.Expects.Interfaces;
using OpenQA.Selenium;


namespace FluentSelenium.Expects
{
    public class InputValueProvider : WaitableElementProvider, IElementValueProvider
    {
        public InputValueProvider(FluentSelector selector, IWebDriver driver)
            : base(selector, driver)
        { }

        public void NotToBe(string value)
        {
            string elementValue = GetWebElement().GetAttribute("value");

            if (elementValue == value)
            {
                throw new Exception(string.Format("Expected value not to be {0} but it was {1}", value, elementValue));
            }
        }
        
        public void ToBe(string value)
        {
            string elementValue = GetWebElement().GetAttribute("value");

            if (elementValue != value)
            {
                throw new Exception(string.Format("Expected value to be {0} but it was {1}", value, elementValue));
            }
        }

        public void NotToBe(int value)
        {
            NotToBe(value.ToString());
        }

        public void ToBe(int value)
        {
            ToBe(value.ToString());
        }

        public IElementValueProvider WithIn(int milliseconds)
        {
            base.WithIn(milliseconds);

            return this;
        }
    }
}