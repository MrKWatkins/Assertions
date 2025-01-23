using System.ComponentModel;

namespace MrKWatkins.Assertions;

[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
public class ObjectAssertions<T>
{
    protected internal ObjectAssertions(T? value)
    {
        Value = value!;
    }

    public T Value { get; }

    public void BeNull()
    {
        Verify.That(Value is null, $"Value should be null but was {Value}.");
    }

    public ObjectAssertionsChain<T> NotBeNull()
    {
        Verify.That(Value is not null, "Value should not be null.");

        return new ObjectAssertionsChain<T>(this);
    }

    public ObjectAssertionsChain<T> Equal(T? expected)
    {
        if (Value is null)
        {
            Verify.That(expected is null, $"Value should equal {expected} but was null.");
        }
        else
        {
            Verify.That(EqualityComparer<T>.Default.Equals(Value, expected), $"Value should equal {expected} but was {Value}.");
        }

        return new ObjectAssertionsChain<T>(this);
    }

    public ObjectAssertionsChain<T> NotEqual(T? expected)
    {
        if (Value is null)
        {
            Verify.That(expected is not null, "Value should not equal null.");
        }
        else
        {
            Verify.That(!EqualityComparer<T>.Default.Equals(Value, expected), $"Value should not equal {expected}.");
        }

        return new ObjectAssertionsChain<T>(this);
    }

    public ObjectAssertionsChain<T> BeTheSameInstanceAs(T? expected)
    {
        Verify.That(ReferenceEquals(Value, expected), $"Value should be the same instance as {expected} but was {Value}.");

        return new ObjectAssertionsChain<T>(this);
    }

    public ObjectAssertionsChain<T> NotBeTheSameInstanceAs(T? expected)
    {
        Verify.That(!ReferenceEquals(Value, expected), $"Value should not be the same instance as {expected}.");

        return new ObjectAssertionsChain<T>(this);
    }

    public ObjectAssertionsChain<TOther> BeOfType<TOther>()
        where TOther : notnull
    {
        Verify.That(Value is not null, "Value should not be null.");

        var type = Value!.GetType();
        Verify.That(type.IsAssignableTo(typeof(TOther)), $"Value should be of type {typeof(TOther)} but was of type {type}.");

        return new ObjectAssertionsChain<TOther>(new ObjectAssertions<TOther>((TOther)(object)Value));
    }

    public ObjectAssertionsChain<T> NotBeOfType<TOther>()
        where TOther : notnull
    {
        Verify.That(Value is not null, "Value should not be null.");

        var type = Value!.GetType();
        Verify.That(!type.IsAssignableTo(typeof(TOther)), $"Value should not be of type {type}.");

        return new ObjectAssertionsChain<T>(this);
    }

#pragma warning disable CA1065
#pragma warning disable CS0809
    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(Equals)} is not supported.")]
    public sealed override bool Equals(object? other) => throw new NotSupportedException(nameof(Equals));

    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(GetHashCode)} is not supported.")]
    public sealed override int GetHashCode() => throw new NotSupportedException(nameof(GetHashCode));

    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(ToString)} is not supported.")]
    public sealed override string ToString() => throw new NotSupportedException(nameof(ToString));

    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(GetType)} is not supported.")]
    public new Type GetType() => throw new NotSupportedException(nameof(GetType));
#pragma warning restore CS0809
#pragma warning restore CA1065
}