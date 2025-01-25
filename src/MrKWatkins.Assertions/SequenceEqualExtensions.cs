using System.Collections;

namespace MrKWatkins.Assertions;

// TODO: Interpret one string as [string] rather than [char]. IEnumerable<T> overloads, with higher priority for params T[]. Try a U[] where U : T again.
[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public static class SequenceEqualExtensions
{
    public static ObjectAssertionsChain<TEnumerable> SequenceEqual<TEnumerable, T>(this ObjectAssertions<TEnumerable> assertions, [InstantHandle] params IEnumerable<T> expected)
        where TEnumerable : IEnumerable
    {
        assertions.NotBeNull();

        var actual = assertions.Value;
        if (actual.TryGetCount(out var actualCount) &&
            expected.TryGetCount(out var expectedCount) &&
            actualCount != expectedCount)
        {
            throw Verify.CreateException(
                $"Value {Format.Enumerable(actual)} should sequence equal {Format.Enumerable(expected)} but it has {actualCount} element{(actualCount == 1 ? "" : "s")} rather than the expected {expectedCount}.");
        }

        var actualList = new List<object?>();
        var expectedList = new List<T>();

        var actualEnumerator = actual.GetEnumerator();
        try
        {
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
                        $"Value {Format.Enumerable(actual)} should sequence equal {Format.Enumerable(expected)} but it has more elements than the expected {expectedList.Count}.");
                }

                if (!Equals(actualEnumerator.Current, expectedEnumerator.Current))
                {
                    var index = actualList.Count - 1;
                    throw Verify.CreateException(
                        $"Value {Format.Collection(actualList, index, true)} should sequence equal {Format.Collection(expectedList, index, true)} but it differs at index {index}.");
                }
            }

            if (expectedEnumerator.MoveNext())
            {
                throw Verify.CreateException(
                    $"Value {Format.Enumerable(actual)} should sequence equal {Format.Enumerable(expected)} but it has less elements ({actualList.Count}) than expected.");
            }

            return new ObjectAssertionsChain<TEnumerable>(assertions);
        }
        finally
        {
            (actualEnumerator as IDisposable)?.Dispose();
        }
    }

    public static ObjectAssertionsChain<TEnumerable> NotSequenceEqual<TEnumerable, T>(this ObjectAssertions<TEnumerable> assertions, params IEnumerable<T> expected)
        where TEnumerable : IEnumerable<T>
    {
        assertions.NotBeNull();

        if (assertions.Value.SequenceEqual(expected))
        {
            throw Verify.CreateException($"Value should not sequence equal {Format.Enumerable(expected)}.");
        }

        return new ObjectAssertionsChain<TEnumerable>(assertions);
    }
}