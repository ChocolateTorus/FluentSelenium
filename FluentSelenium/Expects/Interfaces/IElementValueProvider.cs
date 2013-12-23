namespace FluentSelenium.Expects.Interfaces
{
    public interface IElementValueProvider
    {
        void ToBe(string value);
        void ToBe(int value);
    }
}