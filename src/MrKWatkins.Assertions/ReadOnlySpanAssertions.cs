namespace MrKWatkins.Assertions;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public readonly ref struct ReadOnlySpanAssertions<T>
{
    internal ReadOnlySpanAssertions(ReadOnlySpan<T> value)
    {
        Value = value;
    }

    public ReadOnlySpan<T> Value { get; }

    public ReadOnlySpanAssertionsChain<T> BeEmpty()
    {
        Verify.That(Value.IsEmpty, "Value should be empty but contained {0} elements.", Value.Length);

        return new ReadOnlySpanAssertionsChain<T>(this);
    }

    public ReadOnlySpanAssertionsChain<T> NotBeEmpty()
    {
        Verify.That(!Value.IsEmpty, "Value should not be empty.");

        return new ReadOnlySpanAssertionsChain<T>(this);
    }

    public ReadOnlySpanAssertionsChain<T> SequenceEqual(params ReadOnlySpan<T> expected)
    {
        var equalityComparer = EqualityComparer<T>.Default;
        if (Value.Length != expected.Length)
        {
            throw Verify.CreateException(
                $"Value {Format.Value(Value)} should sequence equal {Format.Value(expected)} but it has {Value.Length} element{(Value.Length == 1 ? "" : "s")} rather than the expected {expected.Length}.");
        }

        for (var f = 0; f < Value.Length; f++)
        {
            var actualItem = Value[f];
            var expectedItem = expected[f];
            if (!equalityComparer.Equals(actualItem, expectedItem))
            {
                throw Verify.CreateException(
                    $"Value {Format.Value(Value, f)} should sequence equal {Format.Value(expected, f)} but it differs at index {f}.");
            }
        }

        return new ReadOnlySpanAssertionsChain<T>(this);
    }

    public ReadOnlySpanAssertionsChain<T> NotSequenceEqual(params ReadOnlySpan<T> expected)
    {
        if (Value.SequenceEqual(expected))
        {
            throw Verify.CreateException($"Value should not sequence equal {Format.Value(expected)}.");
        }

        return new ReadOnlySpanAssertionsChain<T>(this);
    }

    public ReadOnlySpanAssertionsChain<T> SequenceEqual([InstantHandle] IEnumerable<T> expected)
    {
        var equalityComparer = EqualityComparer<T>.Default;
        if (expected.TryGetCount(out var expectedCount) && Value.Length != expectedCount)
        {
            throw Verify.CreateException(
                $"Value {Format.Value(Value)} should sequence equal {Format.Value(expected)} but it has {Value.Length} element{(Value.Length == 1 ? "" : "s")} rather than the expected {expectedCount}.");
        }

        var actualList = new List<T>();
        var expectedList = new List<T>();

        var actualEnumerator = Value.GetEnumerator();
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
                    $"Value {Format.Value(Value)} should sequence equal {Format.Value(expected)} but it has more elements than the expected {expectedList.Count}.");
            }

            if (!equalityComparer.Equals(actualEnumerator.Current, expectedEnumerator.Current))
            {
                var index = actualList.Count - 1;
                throw Verify.CreateException(
                    $"Value {Format.Value(actualList, index, true)} should sequence equal {Format.Value(expectedList, index, true)} but it differs at index {index}.");
            }
        }

        if (expectedEnumerator.MoveNext())
        {
            throw Verify.CreateException(
                $"Value {Format.Value(Value)} should sequence equal {Format.Value(expected)} but it has less elements ({actualList.Count}) than expected.");
        }

        return new ReadOnlySpanAssertionsChain<T>(this);
    }

    public ReadOnlySpanAssertionsChain<T> NotSequenceEqual([InstantHandle] IEnumerable<T> expected)
    {
        var equalityComparer = EqualityComparer<T>.Default;
        if (expected.TryGetCount(out var expectedCount) && Value.Length != expectedCount)
        {
            return new ReadOnlySpanAssertionsChain<T>(this);
        }

        var actualEnumerator = Value.GetEnumerator();
        using var expectedEnumerator = expected.GetEnumerator();

        while (true)
        {
            // No actual.
            if (!actualEnumerator.MoveNext())
            {
                if (expectedEnumerator.MoveNext())
                {
                    // We do not have an actual, but we have an expected, different sizes, not sequence equal.
                    return new ReadOnlySpanAssertionsChain<T>(this);
                }

                // Same size, all elements match, sequence equal.
                break;
            }

            if (!expectedEnumerator.MoveNext())
            {
                // We do not have an actual, but we have an expected, different sizes, not sequence equal.
                return new ReadOnlySpanAssertionsChain<T>(this);
            }

            if (!equalityComparer.Equals(actualEnumerator.Current, expectedEnumerator.Current))
            {
                // Items not equal, not sequence equal.
                return new ReadOnlySpanAssertionsChain<T>(this);
            }
        }

        throw Verify.CreateException($"Value should not sequence equal {Format.Value(Value)}.");
    }
}