using FluentSelenium.Actions;

namespace FluentSelenium.Expects.Interfaces
{
    public interface IExpectProvider
    {
        IElementValueProvider ValueOf(FluentSelector selector);
        IVisibilityProvider ToSee(FluentSelector selector);
    }
}