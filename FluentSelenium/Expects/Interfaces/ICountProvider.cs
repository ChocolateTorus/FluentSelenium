namespace FluentSelenium.Expects
{
    public interface ICountProvider
    {
        void ToBe(int expectedCount);
        INumericComparer ToBe();
    }
}