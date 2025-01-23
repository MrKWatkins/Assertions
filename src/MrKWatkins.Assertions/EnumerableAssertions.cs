using System.Runtime.CompilerServices;

namespace MrKWatkins.Assertions;

[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
public class EnumerableAssertions<T> : ObjectAssertions<IEnumerable<T>>
{
    protected internal EnumerableAssertions([NoEnumeration] IEnumerable<T>? value)
        : base(value)
    {
    }

    public EnumerableAssertionsChain<T> OnlyContain([InstantHandle] Func<T, bool> predicate, [CallerArgumentExpression(nameof(predicate))] string? predicateExpression = null)
    {
        NotBeNull();

        var index = 0;
        foreach (var item in Value)
        {
            Verify.That(predicate(item), $"Value should only contain items that satisfy the predicate {predicateExpression:L} but the item {item} at index {index} does not.");
            index++;
        }

        return new EnumerableAssertionsChain<T>(this);
    }
}