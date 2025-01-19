namespace MrKWatkins.Assertions;

public static class SequenceEqualExtensions
{
    public static ReadOnlySpanAssertionsChain<T> SequenceEqual<T>(this ReadOnlySpanAssertions<T> assertions, ReadOnlySpan<T> expected)
        where T : IEquatable<T>
    {
        var value = assertions.Value;
        if (assertions.Value.Length != expected.Length)
        {
            throw Verify.CreateException(
                $"Value {Format.Value(value)} should sequence equal {Format.Value(expected)} but it has {value.Length} element{(value.Length == 1 ? "" : "s")} rather than the expected {expected.Length}.");
        }

        for (var f = 0; f < value.Length; f++)
        {
            var actualItem = value[f];
            var expectedItem = expected[f];
            if (!actualItem.Equals(expectedItem))
            {
                throw Verify.CreateException(
                    $"Value {Format.Value(value, f)} should sequence equal {Format.Value(expected, f)} but it differs at index {f}.");
            }
        }

        return new ReadOnlySpanAssertionsChain<T>(assertions);
    }
}