namespace FluentSelenium.Expects.Interfaces
{
    public interface IElementValueProvider
    {
        void ToBe(string value);
        void ToBe(int value);
        IElementValueProvider WithIn(int milliseconds);
        void NotToBe(string value);
        void NotToBe(int value);
    }
}