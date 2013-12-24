namespace FluentSelenium.Expects.Interfaces
{
    public interface ICountProvider
    {
        INumericComparer ToBe();
    }

    public interface IWaitable<T>
    {
        T WithIn(int milliseconds);
    }
}