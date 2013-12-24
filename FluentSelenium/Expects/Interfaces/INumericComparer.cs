namespace FluentSelenium.Expects
{
    public interface INumericComparer
    {
        void AtLeast(int minimumExpectedCount);

        void LessThan(int maximumExpectedAmount);
    }
}