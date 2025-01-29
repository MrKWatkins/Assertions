using System.Collections;
using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

/// <summary>
/// Set of tests designed to ensure common uses of the various fluent chains and overloads don't break when the assertions and extensions are changed.
/// Actual functionality will be tested by other unit tests.
/// </summary>
public sealed class FluentTests
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

            // Should be able to use null values.
            new string?[] { null }.Should().SequenceEqual((string?)null);
            new[] { null, "Two", "Three" }.Should().SequenceEqual(null, "Two", "Three");

            // Should work with non-generic IEnumerable.
            ((IEnumerable)new object[] { "One" }).Should().SequenceEqual("One");
            ((IEnumerable)new object[] { "One", "Two", "Three" }).Should().SequenceEqual("One", "Two", "Three");
        }).ThrowsNothing();
    }

    [Test]
    public async Task ContainsSingle()
    {
        await Assert.That(() =>
        {
            new[] { "One", "Two", "Three" }.Should().ContainSingle(x => x.Length == 5).That.Should().Equal("Three");
        }).ThrowsNothing();
    }

    [Test]
    public async Task Exceptions()
    {
        var inner = new InvalidOperationException("Inner");
        var outer = new NotSupportedException("Outer", inner);
        await Assert.That(() =>
        {
            AssertThat.Invoking(() => throw inner).Should().Throw<InvalidOperationException>()
                .That.Should()
                .HaveMessage("Inner").And
                .NotHaveInnerException();

            AssertThat.Invoking(() => throw outer).Should().Throw<NotSupportedException>()
                .That.Should().HaveMessage("Outer").And.HaveInnerException<InvalidOperationException>()
                .That.Should().HaveMessage("Inner");
        }).ThrowsNothing();
    }
}