namespace FluentSelenium
{
    public interface IExpectProvider
    {
        IElementValueProvider ValueOf(string selector);
    }
}