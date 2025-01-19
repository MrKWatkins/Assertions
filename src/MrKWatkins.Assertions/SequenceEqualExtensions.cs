using System.Runtime.CompilerServices;

namespace MrKWatkins.Assertions;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public static class SequenceEqualExtensions
{
    [OverloadResolutionPriority(1)]
    public static ReadOnlySpanAssertionsChain<T> SequenceEqual<T>(this ReadOnlySpanAssertions<T> assertions, params ReadOnlySpan<T> expected)
        where T : IEquatable<T>
    {
        var value = assertions.Value;
        if (assertions.Value.Length != expected.Length)
        {
            throw Verify.CreateException(
                $"Value {Format.Value(value)} should sequence equal {Format.Value(expected)} but it has {value.Length} element{(value.Length == 1 ? "" : "s")} rather than the expected {expected.Length}.");
        }

        for (var f = 0; f < value.Length; f++)
        {
            var actualItem = value[f];
            var expectedItem = expected[f];
            if (!actualItem.Equals(expectedItem))
            {
                throw Verify.CreateException(
                    $"Value {Format.Value(value, f)} should sequence equal {Format.Value(expected, f)} but it differs at index {f}.");
            }
        }

        return new ReadOnlySpanAssertionsChain<T>(assertions);
    }

    [OverloadResolutionPriority(1)]
    public static ReadOnlySpanAssertionsChain<T> SequenceEqual<T>(this ReadOnlySpanAssertions<T> assertions, params IReadOnlyList<T> expected)
        where T : IEquatable<T>
    {
        var value = assertions.Value;
        if (assertions.Value.Length != expected.Count)
        {
            throw Verify.CreateException(
                $"Value {Format.Value(value)} should sequence equal {Format.Value(expected)} but it has {value.Length} element{(value.Length == 1 ? "" : "s")} rather than the expected {expected.Count}.");
        }

        for (var f = 0; f < value.Length; f++)
        {
            var actualItem = value[f];
            var expectedItem = expected[f];
            if (!actualItem.Equals(expectedItem))
            {
                throw Verify.CreateException(
                    $"Value {Format.Value(value, f)} should sequence equal {Format.Value(expected, f)} but it differs at index {f}.");
            }
        }

        return new ReadOnlySpanAssertionsChain<T>(assertions);
    }

    [OverloadResolutionPriority(1)]
    public static ReadOnlySpanAssertionsChain<T> NotSequenceEqual<T>(this ReadOnlySpanAssertions<T> assertions, params ReadOnlySpan<T> expected)
        where T : IEquatable<T>
    {
        if (assertions.Value.SequenceEqual(expected))
        {
            throw Verify.CreateException($"Value should not sequence equal {Format.Value(expected)}.");
        }

        return new ReadOnlySpanAssertionsChain<T>(assertions);
    }

    public static ReadOnlySpanAssertionsChain<T> NotSequenceEqual<T>(this ReadOnlySpanAssertions<T> assertions, params IReadOnlyList<T> expected)
        where T : IEquatable<T>
    {
        var value = assertions.Value;
        if (assertions.Value.Length != expected.Count)
        {
            return new ReadOnlySpanAssertionsChain<T>(assertions);
        }

        for (var f = 0; f < value.Length; f++)
        {
            var actualItem = value[f];
            var expectedItem = expected[f];
            if (!actualItem.Equals(expectedItem))
            {
                return new ReadOnlySpanAssertionsChain<T>(assertions);
            }
        }

        throw Verify.CreateException($"Value should not sequence equal {Format.Value(expected)}.");
    }

    // Allow sequence equal for actual IEnumerables, but not all things that implement IEnumerable, e.g. sets.
    public static EnumerableAssertionsChain<IEnumerable<T>, T> SequenceEqual<T>(this EnumerableAssertions<IEnumerable<T>, T> assertions, params IEnumerable<T> expected)
        where T : IEquatable<T>
    {
        var actual = assertions.Value;
        if (actual.TryGetCount(out var actualCount) &&
            expected.TryGetCount(out var expectedCount) &&
            actualCount != expectedCount)
        {
            throw Verify.CreateException(
                $"Value {Format.Value(actual)} should sequence equal {Format.Value(expected)} but it has {actualCount} element{(actualCount == 1 ? "" : "s")} rather than the expected {expectedCount}.");
        }

        var actualList = new List<T>();
        var expectedList = new List<T>();

        using var actualEnumerator = actual.GetEnumerator();
        using var expectedEnumerator = expected.GetEnumerator();

        while (true)
        {
            if (actualEnumerator.MoveNext())
            {
                actualList.Add(actualEnumerator.Current);
            }
            else
            {
                break;
            }

            if (expectedEnumerator.MoveNext())
            {
                expectedList.Add(expectedEnumerator.Current);
            }
            else
            {
                throw Verify.CreateException(
                    $"Value {Format.Value(actual)} should sequence equal {Format.Value(expected)} but it has more elements than the expected {expectedList.Count}.");
            }

            if (!actualEnumerator.Current.Equals(expectedEnumerator.Current))
            {
                var index = actualList.Count - 1;
                throw Verify.CreateException(
                    $"Value {Format.Value(actualList, index, true)} should sequence equal {Format.Value(expectedList, index, true)} but it differs at index {index}.");
            }
        }

        if (expectedEnumerator.MoveNext())
        {
            throw Verify.CreateException(
                $"Value {Format.Value(actual)} should sequence equal {Format.Value(expected)} but it has less elements ({actualList.Count}) than expected.");
        }

        return new EnumerableAssertionsChain<IEnumerable<T>, T>(assertions);
    }

    public static EnumerableAssertionsChain<IEnumerable<T>, T> NotSequenceEqual<T>(this EnumerableAssertions<IEnumerable<T>, T> assertions, params IEnumerable<T> expected)
        where T : IEquatable<T>
    {
        if (assertions.Value.SequenceEqual(expected))
        {
            throw Verify.CreateException($"Value should not sequence equal {Format.Value(expected)}.");
        }

        return new EnumerableAssertionsChain<IEnumerable<T>, T>(assertions);
    }
}