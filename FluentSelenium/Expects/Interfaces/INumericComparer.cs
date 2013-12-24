namespace FluentSelenium.Expects.Interfaces
{
    public interface INumericComparer
    {
        void AtLeast(int minimumExpectedCount);
        void LessThan(int maximumExpectedAmount);
        void Exactly(int expectedAmount);
    }
}