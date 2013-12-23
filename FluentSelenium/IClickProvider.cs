using OpenQA.Selenium;

namespace FluentSelenium
{
    public interface IClickProvider
    {
        void On(FluentSelector selector);
    }
}