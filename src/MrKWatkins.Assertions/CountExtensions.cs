using System.Collections;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace MrKWatkins.Assertions;

public static class CountExtensions
{
    private static readonly ConcurrentDictionary<Type, Func<IEnumerable, int>> CountAccessors = new();

    public static ObjectAssertionsChain<T> BeEmpty<T>(this ObjectAssertions<T> assertions)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        if (assertions.Value is ICollection collection)
        {
            Verify.That(collection.Count == 0, "Value should be empty but has {0} items.", collection.Count);
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

    public static ObjectAssertionsChain<T> HaveCount<T>(this ObjectAssertions<T> assertions, int expectedCount)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        var type = assertions.Value.GetType();
        var actualCount = CountAccessors.GetOrAdd(type, CreateCountAccessor)(assertions.Value);

        Verify.That(actualCount == expectedCount, "Value should have a count of {0} but has a count of {1}.", expectedCount, actualCount);

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotHaveCount<T>(this ObjectAssertions<T> assertions, int expectedCount)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        var type = assertions.Value.GetType();
        var actualCount = CountAccessors.GetOrAdd(type, CreateCountAccessor)(assertions.Value);

        Verify.That(actualCount != expectedCount, "Value should not have a count of {0}.", expectedCount);

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