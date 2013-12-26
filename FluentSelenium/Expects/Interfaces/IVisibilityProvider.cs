namespace FluentSelenium.Expects.Interfaces
{
    public interface IVisibilityProvider
    {
        void Immediately();
        void WithIn(int milliseconds);
    }
}