namespace MrKWatkins.Assertions;

public sealed class StringAssertions(string? value) : EnumerableAssertions<string, char>(value)
{
    public StringAssertionsChain Contain(string expected)
    {
        NotBeNull();
        Verify.That(Value.Contains(expected), $"Value should contain the string {expected}.");

        return new StringAssertionsChain(this);
    }

    public StringAssertionsChain NotContain(string expected)
    {
        NotBeNull();
        Verify.That(!Value.Contains(expected), $"Value should not contain the string {expected}.");

        return new StringAssertionsChain(this);
    }
}