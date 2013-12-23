namespace FluentSelenium.Expects.Interfaces
{
    public interface IVisibilityProvider
    {
        void Now();
        void WithIn(int milliseconds);
    }
}