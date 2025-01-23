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
            Verify.That(predicate(item), "Value should only contain items that satisfy the predicate {0} but the item {1} at index {2} does not.", predicateExpression, item, index);
            index++;
        }

        return new EnumerableAssertionsChain<T>(this);
    }
}