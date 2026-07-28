namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for read-only set values.
/// </summary>
/// <typeparam name="TSet">The type of the set being asserted on.</typeparam>
/// <typeparam name="T">The type of elements in the set.</typeparam>
/// <param name="value">The set to assert on.</param>
public sealed class ReadOnlySetAssertions<TSet, T>([NoEnumeration] TSet? value) : EnumerableAssertions<TSet, T>(value)
    where TSet : IReadOnlySet<T>
{
    /// <summary>
    /// Asserts that the set contains exactly the expected elements, ignoring order and duplicates.
    /// </summary>
    /// <param name="expected">The expected elements.</param>
    /// <returns>A <see cref="ReadOnlySetAssertionsChain{TSet, T}" /> for chaining further assertions.</returns>
    public ReadOnlySetAssertionsChain<TSet, T> SetEquals([InstantHandle] params IEnumerable<T> expected)
    {
        NotBeNull();

        var expectedItems = expected.ToList();
        if (!Value.SetEquals(expectedItems))
        {
            var missing = expectedItems.Where(item => !Value.Contains(item)).Distinct().ToList();
            var extra = Value.Where(item => !expectedItems.Contains(item)).ToList();

            if (extra.Count == 0)
            {
                throw Verify.CreateException($"Value {Format.Enumerable(Value)} should set equal {Format.Collection(expectedItems)} but it is missing {Format.Collection(missing)}.");
            }

            if (missing.Count == 0)
            {
                throw Verify.CreateException(
                    $"Value {Format.Enumerable(Value)} should set equal {Format.Collection(expectedItems)} but it has extra item{(extra.Count == 1 ? "" : "s")} {Format.Collection(extra)}.");
            }

            throw Verify.CreateException(
                $"Value {Format.Enumerable(Value)} should set equal {Format.Collection(expectedItems)} but it is missing {Format.Collection(missing)} and has extra item{(extra.Count == 1 ? "" : "s")} {Format.Collection(extra)}.");
        }

        return new ReadOnlySetAssertionsChain<TSet, T>(this);
    }

    /// <summary>
    /// Asserts that the set is a superset of the expected elements, i.e. it contains every expected element.
    /// </summary>
    /// <param name="expected">The expected elements.</param>
    /// <returns>A <see cref="ReadOnlySetAssertionsChain{TSet, T}" /> for chaining further assertions.</returns>
    public ReadOnlySetAssertionsChain<TSet, T> IsSupersetOf([InstantHandle] params IEnumerable<T> expected)
    {
        NotBeNull();

        var expectedItems = expected.ToList();
        if (!Value.IsSupersetOf(expectedItems))
        {
            var missing = expectedItems.Where(item => !Value.Contains(item)).Distinct().ToList();

            throw Verify.CreateException($"Value {Format.Enumerable(Value)} should be a superset of {Format.Collection(expectedItems)} but it is missing {Format.Collection(missing)}.");
        }

        return new ReadOnlySetAssertionsChain<TSet, T>(this);
    }

    /// <summary>
    /// Asserts that the set is a subset of the expected elements, i.e. every element in the set is expected.
    /// </summary>
    /// <param name="expected">The expected elements.</param>
    /// <returns>A <see cref="ReadOnlySetAssertionsChain{TSet, T}" /> for chaining further assertions.</returns>
    public ReadOnlySetAssertionsChain<TSet, T> IsSubsetOf([InstantHandle] params IEnumerable<T> expected)
    {
        NotBeNull();

        var expectedItems = expected.ToList();
        if (!Value.IsSubsetOf(expectedItems))
        {
            var extra = Value.Where(item => !expectedItems.Contains(item)).ToList();

            throw Verify.CreateException(
                $"Value {Format.Enumerable(Value)} should be a subset of {Format.Collection(expectedItems)} but it has extra item{(extra.Count == 1 ? "" : "s")} {Format.Collection(extra)}.");
        }

        return new ReadOnlySetAssertionsChain<TSet, T>(this);
    }
}
