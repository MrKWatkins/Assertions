using System.Collections;

namespace MrKWatkins.Assertions;

public static class EnumerableExtensions
{
    public static ObjectAssertionsChain<T> SequenceEqual<T>(this ObjectAssertions<T> assertions, [InstantHandle] params IEnumerable<object> expected)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        assertions.Value.OfType<object>().Should().SequenceEqual(expected);

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotSequenceEqual<T>(this ObjectAssertions<T> assertions, [InstantHandle] params IEnumerable<object> expected)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        assertions.Value.OfType<object>().Should().NotSequenceEqual(expected);

        return new ObjectAssertionsChain<T>(assertions);
    }
}