using System.Runtime.CompilerServices;

namespace MrKWatkins.Assertions;

[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
public class EnumerableAssertions<TEnumerable, T> : ObjectAssertions<TEnumerable>
    where TEnumerable : IEnumerable<T>
{
    protected internal EnumerableAssertions([NoEnumeration] TEnumerable? value)
        : base(value)
    {
    }

    public EnumerableAssertionsChain<TEnumerable, T> OnlyContain([InstantHandle] Func<T, bool> predicate, [CallerArgumentExpression(nameof(predicate))] string? predicateExpression = null)
    {
        NotBeNull();

        var index = 0;
        foreach (var item in Value)
        {
            Verify.That(predicate(item), $"Value should only contain items that satisfy the predicate {predicateExpression:L} but the item {item} at index {index} does not.");
            index++;
        }

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public EnumerableAssertionsChain<TEnumerable, T> SequenceEqual([InstantHandle] params IEnumerable<T> expected)
    {
        NotBeNull();

        if (Value.TryGetCount(out var actualCount) &&
            expected.TryGetCount(out var expectedCount) &&
            actualCount != expectedCount)
        {
            throw Verify.CreateException(
                $"Value {Format.Enumerable(Value)} should sequence equal {Format.Enumerable(expected)} but it has {actualCount} element{(actualCount == 1 ? "" : "s")} rather than the expected {expectedCount}.");
        }

        var actualList = new List<T>();
        var expectedList = new List<T>();
        var equalityComparer = EqualityComparer<T>.Default;

        using var actualEnumerator = Value.GetEnumerator();
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
                    $"Value {Format.Enumerable(Value)} should sequence equal {Format.Collection(expectedList)} but it has more elements than the expected {expectedList.Count}.");
            }

            if (!equalityComparer.Equals(actualEnumerator.Current, expectedEnumerator.Current))
            {
                var index = actualList.Count - 1;
                throw Verify.CreateException(
                    $"Value {Format.Collection(actualList, index, true)} should sequence equal {Format.Collection(expectedList, index, true)} but it differs at index {index}.");
            }
        }

        if (expectedEnumerator.MoveNext())
        {
            throw Verify.CreateException(
                $"Value {Format.Enumerable(Value)} should sequence equal {Format.Enumerable(expected)} but it has less elements ({actualList.Count}) than expected.");
        }

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public EnumerableAssertionsChain<TEnumerable, T> NotSequenceEqual(params IEnumerable<T> expected)
    {
        NotBeNull();

        if (Value.SequenceEqual(expected))
        {
            throw Verify.CreateException($"Value should not sequence equal {Format.Enumerable(expected)}.");
        }

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }
}