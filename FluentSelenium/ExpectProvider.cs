﻿using OpenQA.Selenium;

namespace FluentSelenium
{
    public class ExpectProvider : IExpectProvider
    {
        private readonly IWebDriver driver;

        public ExpectProvider(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IElementValueProvider ValueOf(FluentSelector selector)
        {
            return new InputValueProvider(selector, driver);
        }
    }
}