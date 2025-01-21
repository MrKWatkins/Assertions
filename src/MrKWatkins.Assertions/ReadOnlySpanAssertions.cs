namespace MrKWatkins.Assertions;

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

    public ReadOnlySpanAssertionsChain<T> SequenceEqual(IReadOnlyList<T> expected)
    {
        var equalityComparer = EqualityComparer<T>.Default;
        if (Value.Length != expected.Count)
        {
            throw Verify.CreateException(
                $"Value {Format.Value(Value)} should sequence equal {Format.Value(expected)} but it has {Value.Length} element{(Value.Length == 1 ? "" : "s")} rather than the expected {expected.Count}.");
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

    public ReadOnlySpanAssertionsChain<T> NotSequenceEqual(IReadOnlyList<T> expected)
    {
        var equalityComparer = EqualityComparer<T>.Default;
        if (Value.Length != expected.Count)
        {
            return new ReadOnlySpanAssertionsChain<T>(this);
        }

        for (var f = 0; f < Value.Length; f++)
        {
            var actualItem = Value[f];
            var expectedItem = expected[f];
            if (!equalityComparer.Equals(actualItem, expectedItem))
            {
                return new ReadOnlySpanAssertionsChain<T>(this);
            }
        }

        throw Verify.CreateException($"Value should not sequence equal {Format.Value(expected)}.");
    }
}