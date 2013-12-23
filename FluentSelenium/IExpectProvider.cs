namespace FluentSelenium
{
    public interface IExpectProvider
    {
        IElementValueProvider ValueOf(FluentSelector selector);
    }
}