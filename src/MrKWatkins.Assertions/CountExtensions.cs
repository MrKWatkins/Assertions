using System.Collections;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that provide count-related assertions for enumerables.
/// </summary>
public static class CountExtensions
{
    private static readonly ConcurrentDictionary<Type, Func<IEnumerable, int>> CountAccessors = new();

    /// <summary>
    /// Asserts that the enumerable is empty.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> BeEmpty<T>(this ObjectAssertions<T> assertions)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        if (assertions.Value is ICollection collection)
        {
            Verify.That(collection.Count == 0, $"Value should be empty but has {collection.Count} items.");
        }
        else
        {
            var enumerator = assertions.Value.GetEnumerator();
            try
            {
                Verify.That(!enumerator.MoveNext(), "Value should be empty.");
            }
            finally
            {
                (enumerator as IDisposable)?.Dispose();
            }
        }

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the enumerable is not empty.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> NotBeEmpty<T>(this ObjectAssertions<T> assertions)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        if (assertions.Value is ICollection collection)
        {
            Verify.That(collection.Count != 0, "Value should not be empty.");
        }
        else
        {
            var enumerator = assertions.Value.GetEnumerator();
            try
            {
                Verify.That(enumerator.MoveNext(), "Value should not be empty.");
            }
            finally
            {
                (enumerator as IDisposable)?.Dispose();
            }
        }

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the enumerable has the specified number of elements.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expectedCount">The expected number of elements.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> HaveCount<T>(this ObjectAssertions<T> assertions, int expectedCount)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        var type = assertions.Value.GetType();
        var actualCount = CountAccessors.GetOrAdd(type, CreateCountAccessor)(assertions.Value);

        Verify.That(actualCount == expectedCount, $"Value should have a count of {expectedCount} but has a count of {actualCount}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the enumerable does not have the specified number of elements.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expectedCount">The number of elements that is not expected.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> NotHaveCount<T>(this ObjectAssertions<T> assertions, int expectedCount)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        var type = assertions.Value.GetType();
        var actualCount = CountAccessors.GetOrAdd(type, CreateCountAccessor)(assertions.Value);

        Verify.That(actualCount != expectedCount, $"Value should not have a count of {expectedCount}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    [Pure]
    private static Func<IEnumerable, int> CreateCountAccessor(Type type)
    {
        if (type.IsAssignableTo(typeof(ICollection)))
        {
            return CountByCollection;
        }

        var countProperty = type.GetProperty("Count");
        if (countProperty is null)
        {
            return CountByEnumeration;
        }

        var parameter = Expression.Parameter(typeof(IEnumerable), "enumerable");
        var cast = Expression.Convert(parameter, type);
        var get = Expression.Property(cast, countProperty);
        var lambda = Expression.Lambda(get, parameter);
        return (Func<IEnumerable, int>)lambda.Compile();
    }

    [Pure]
    private static int CountByCollection(IEnumerable enumerable) => ((ICollection)enumerable).Count;

    [Pure]
    private static int CountByEnumeration(IEnumerable enumerable)
    {
        var enumerator = enumerable.GetEnumerator();
        try
        {
            var count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }
    }
}