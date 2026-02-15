namespace MrKWatkins.Assertions;

public readonly struct StringAssertionsChain(StringAssertions stringAssertions)
{
    public StringAssertions And { get; } = stringAssertions;

    public string Value => And.Value;
}