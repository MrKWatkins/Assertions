using System.Collections;

namespace MrKWatkins.Assertions;

public static class CountExtensions
{
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
}