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
    /// Asserts that the enumerable contains exactly one item.
    /// </summary>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for the single item.</returns>
    public ObjectAssertionsChain<T> ContainSingle()
    {
        NotBeNull();

        using var enumerator = Value.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            throw Verify.CreateException("Value should contain a single item but was empty.");
        }

        var item = enumerator.Current;

        if (enumerator.MoveNext())
        {
            throw Verify.CreateException("Value should contain a single item but contains more than one item.");
        }

        return new ObjectAssertionsChain<T>(new ObjectAssertions<T>(item));
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
    public EnumerableAssertionsChain<TEnumerable, T> SequenceEqual([InstantHandle] params IEnumerable<T?> expected) =>
        SequenceEqualCore(expected, EqualityComparer<T>.Default.Equals);

    /// <summary>
    /// Asserts that the enumerable is sequence equal to the expected elements using the specified equality comparer.
    /// </summary>
    /// <param name="expected">The expected elements.</param>
    /// <param name="comparer">The equality comparer to use for element comparison.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public EnumerableAssertionsChain<TEnumerable, T> SequenceEqual([InstantHandle] IEnumerable<T?> expected, IEqualityComparer<T> comparer) =>
        SequenceEqualCore(expected, comparer.Equals);

    /// <summary>
    /// Asserts that the enumerable is sequence equal to the expected elements using the specified predicate.
    /// </summary>
    /// <param name="expected">The expected elements.</param>
    /// <param name="predicate">The predicate to use for element comparison.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public EnumerableAssertionsChain<TEnumerable, T> SequenceEqual([InstantHandle] IEnumerable<T?> expected, Func<T?, T?, bool> predicate) =>
        SequenceEqualCore(expected, predicate);

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    private EnumerableAssertionsChain<TEnumerable, T> SequenceEqualCore(IEnumerable<T?> expected, Func<T?, T?, bool> equals)
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

            if (!equals(actualEnumerator.Current, expectedEnumerator.Current))
            {
                var index = actualList.Count - 1;
                throw Verify.CreateException(
                    $"Value {Format.Collection(actualList, index, true)} should sequence equal {Format.Collection(expectedList, index, true)} but it differs at index {index}.");
            }
        }

        if (expectedEnumerator.MoveNext())
        {
            throw Verify.CreateException(
                $"Value {Format.Enumerable(Value)} should sequence equal {Format.Enumerable(expected)} but it has fewer elements ({actualList.Count}) than expected.");
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

    /// <summary>
    /// Asserts that the enumerable is not sequence equal to the expected elements using the specified equality comparer.
    /// </summary>
    /// <param name="expected">The elements the enumerable should not be sequence equal to.</param>
    /// <param name="comparer">The equality comparer to use for element comparison.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public EnumerableAssertionsChain<TEnumerable, T> NotSequenceEqual(IEnumerable<T> expected, IEqualityComparer<T> comparer)
    {
        NotBeNull();

        if (Value.SequenceEqual(expected, comparer))
        {
            throw Verify.CreateException($"Value should not sequence equal {Format.Enumerable(expected)}.");
        }

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    /// <summary>
    /// Asserts that the enumerable is not sequence equal to the expected elements using the specified predicate.
    /// </summary>
    /// <param name="expected">The elements the enumerable should not be sequence equal to.</param>
    /// <param name="predicate">The predicate to use for element comparison.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public EnumerableAssertionsChain<TEnumerable, T> NotSequenceEqual(IEnumerable<T> expected, Func<T?, T?, bool> predicate)
    {
        NotBeNull();

        using var actualEnumerator = Value.GetEnumerator();
        using var expectedEnumerator = expected.GetEnumerator();

        while (true)
        {
            var actualHasNext = actualEnumerator.MoveNext();
            var expectedHasNext = expectedEnumerator.MoveNext();

            if (!actualHasNext && !expectedHasNext)
            {
                break;
            }

            if (!actualHasNext || !expectedHasNext)
            {
                return new EnumerableAssertionsChain<TEnumerable, T>(this);
            }

            if (!predicate(actualEnumerator.Current, expectedEnumerator.Current))
            {
                return new EnumerableAssertionsChain<TEnumerable, T>(this);
            }
        }

        throw Verify.CreateException($"Value should not sequence equal {Format.Enumerable(expected)}.");
    }

    /// <summary>
    /// Asserts that the enumerable contains the specified item.
    /// </summary>
    /// <param name="expected">The item that should be present in the enumerable.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    public EnumerableAssertionsChain<TEnumerable, T> Contain(T expected)
    {
        NotBeNull();

        Verify.That(Value.Contains(expected), $"Value should contain {expected} but did not.");

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    /// <summary>
    /// Asserts that the enumerable contains the specified item using the specified equality comparer.
    /// </summary>
    /// <param name="expected">The item that should be present in the enumerable.</param>
    /// <param name="comparer">The equality comparer to use for element comparison.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    public EnumerableAssertionsChain<TEnumerable, T> Contain(T expected, IEqualityComparer<T> comparer)
    {
        NotBeNull();

        Verify.That(Value.Contains(expected, comparer), $"Value should contain {expected} but did not.");

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    /// <summary>
    /// Asserts that the enumerable contains the specified item using the specified predicate.
    /// </summary>
    /// <param name="expected">The item that should be present in the enumerable.</param>
    /// <param name="predicate">The predicate to use for element comparison, taking the actual item and expected item as arguments.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    public EnumerableAssertionsChain<TEnumerable, T> Contain(T expected, Func<T?, T?, bool> predicate)
    {
        NotBeNull();

        Verify.That(Value.Any(item => predicate(item, expected)), $"Value should contain {expected} but did not.");

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    /// <summary>
    /// Asserts that the enumerable does not contain the specified item.
    /// </summary>
    /// <param name="expected">The item that should not be present in the enumerable.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    public EnumerableAssertionsChain<TEnumerable, T> NotContain(T expected)
    {
        NotBeNull();

        Verify.That(!Value.Contains(expected), $"Value should not contain {expected}.");

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    /// <summary>
    /// Asserts that the enumerable does not contain the specified item using the specified equality comparer.
    /// </summary>
    /// <param name="expected">The item that should not be present in the enumerable.</param>
    /// <param name="comparer">The equality comparer to use for element comparison.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    public EnumerableAssertionsChain<TEnumerable, T> NotContain(T expected, IEqualityComparer<T> comparer)
    {
        NotBeNull();

        Verify.That(!Value.Contains(expected, comparer), $"Value should not contain {expected}.");

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    /// <summary>
    /// Asserts that the enumerable does not contain the specified item using the specified predicate.
    /// </summary>
    /// <param name="expected">The item that should not be present in the enumerable.</param>
    /// <param name="predicate">The predicate to use for element comparison, taking the actual item and expected item as arguments.</param>
    /// <returns>An <see cref="EnumerableAssertionsChain{TEnumerable, T}" /> for chaining further assertions.</returns>
    public EnumerableAssertionsChain<TEnumerable, T> NotContain(T expected, Func<T?, T?, bool> predicate)
    {
        NotBeNull();

        Verify.That(!Value.Any(item => predicate(item, expected)), $"Value should not contain {expected}.");

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }
}