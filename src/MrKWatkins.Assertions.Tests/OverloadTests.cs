namespace MrKWatkins.Assertions.Tests;

/// <summary>
/// Set of tests designed to ensure common uses of the various overloads don't break when the assertions and extensions are changed.
/// Actual functionality will be tested by other unit tests.
/// </summary>
public sealed class OverloadTests
{
    [Test]
    public async Task SequenceEqual()
    {
        await Assert.That(() =>
        {
            // Params overload of SequenceEqual with a single string should go resolve to IEnumerable<string>, not IEnumerable<char>.
            new[] { "One" }.Should().SequenceEqual("One");
            new[] { "One", "Two", "Three" }.Should().SequenceEqual("One", "Two", "Three");

            // Should be able to use an enumeration of a subtype.
            new object[] { "One" }.Should().SequenceEqual("One");
            new object[] { "One", "Two", "Three" }.Should().SequenceEqual("One", "Two", "Three");
        }).ThrowsNothing();
    }
}