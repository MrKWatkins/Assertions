using System.Runtime.CompilerServices;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for enumerable values.
/// </summary>
/// <typeparam name="TEnumerable">The type of the enumerable being asserted on.</typeparam>
/// <typeparam name="T">The type of elements in the enumerable.</typeparam>
/// <param name="value">The enumerable value to assert on.</param>
[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
public class EnumerableAssertions<TEnumerable, T>([NoEnumeration] TEnumerable? value) : ObjectAssertions<TEnumerable>(value)
    where TEnumerable : IEnumerable<T>
{
    /// <summary>
    /// Asserts that all items in the enumerable satisfy the specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate that all items must satisfy.</param>
    /// <param name="predicateExpression">The expression text of the predicate, captured automatically.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
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

    /// <summary>
    /// Asserts that the enumerable contains exactly one item that satisfies the specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate to match.</param>
    /// <param name="predicateExpression">The expression text of the predicate, captured automatically.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for the single matching item.</returns>
    public ObjectAssertionsChain<T> ContainSingle([InstantHandle] Func<T, bool> predicate, [CallerArgumentExpression(nameof(predicate))] string? predicateExpression = null)
    {
        NotBeNull();

        var matching = Value.Where(predicate).ToList();
        Verify.That(matching.Count == 1, $"Value should only contain a single item that satisfies the predicate {predicateExpression:L} but it contains {matching.Count} items.");

        return new ObjectAssertionsChain<T>(new ObjectAssertions<T>(matching[0]));
    }

    /// <summary>
    /// Asserts that the enumerable is sequence equal to the expected elements.
    /// </summary>
    /// <param name="expected">The expected elements.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public EnumerableAssertionsChain<TEnumerable, T> SequenceEqual([InstantHandle] params IEnumerable<T?> expected)
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
        var expectedList = new List<T?>();
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

    /// <summary>
    /// Asserts that the enumerable is not sequence equal to the expected elements.
    /// </summary>
    /// <param name="expected">The elements the enumerable should not be sequence equal to.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
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