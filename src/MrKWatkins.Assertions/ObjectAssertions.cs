using System.ComponentModel;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for any object value.
/// </summary>
/// <typeparam name="T">The type of the value being asserted on.</typeparam>
/// <param name="value">The value to assert on.</param>
[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
public class ObjectAssertions<T>(T? value)
{
    /// <summary>
    /// Gets the value being asserted on.
    /// </summary>
    public T Value { get; } = value!;

    /// <summary>
    /// Asserts that the value is <see langword="null" />.
    /// </summary>
    public void BeNull()
    {
        Verify.That(Value is null, $"Value should be null but was {Value}.");
    }

    /// <summary>
    /// Asserts that the value is not <see langword="null" />.
    /// </summary>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ObjectAssertionsChain<T> NotBeNull()
    {
        Verify.That(Value is not null, "Value should not be null.");

        return new ObjectAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value using the default equality comparer.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
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

    /// <summary>
    /// Asserts that the value is not equal to the expected value using the default equality comparer.
    /// </summary>
    /// <param name="expected">The value that is not expected.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
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

    /// <summary>
    /// Asserts that the value is the same instance as the expected value.
    /// </summary>
    /// <param name="expected">The expected instance.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ObjectAssertionsChain<T> BeTheSameInstanceAs(T? expected)
    {
        Verify.That(ReferenceEquals(Value, expected), $"Value should be the same instance as {expected} but was {Value}.");

        return new ObjectAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the value is not the same instance as the expected value.
    /// </summary>
    /// <param name="expected">The instance that is not expected.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ObjectAssertionsChain<T> NotBeTheSameInstanceAs(T? expected)
    {
        Verify.That(!ReferenceEquals(Value, expected), $"Value should not be the same instance as {expected}.");

        return new ObjectAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the value is assignable to the specified type.
    /// </summary>
    /// <typeparam name="TOther">The expected type.</typeparam>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for the value cast to <typeparamref name="TOther" />.</returns>
    public ObjectAssertionsChain<TOther> BeOfType<TOther>()
        where TOther : notnull
    {
        Verify.That(Value is not null, "Value should not be null.");

        var type = Value!.GetType();
        Verify.That(type.IsAssignableTo(typeof(TOther)), $"Value should be of type {typeof(TOther)} but was of type {type}.");

        return new ObjectAssertionsChain<TOther>(new ObjectAssertions<TOther>((TOther)(object)Value));
    }

    /// <summary>
    /// Asserts that the value is not assignable to the specified type.
    /// </summary>
    /// <typeparam name="TOther">The type that is not expected.</typeparam>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
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
    /// <inheritdoc />
    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(Equals)} is not supported.")]
    public sealed override bool Equals(object? other) => throw new NotSupportedException(nameof(Equals));

    /// <inheritdoc />
    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(GetHashCode)} is not supported.")]
    public sealed override int GetHashCode() => throw new NotSupportedException(nameof(GetHashCode));

    /// <inheritdoc />
    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(ToString)} is not supported.")]
    public sealed override string ToString() => throw new NotSupportedException(nameof(ToString));

    /// <summary>
    /// Not supported. This method is hidden to prevent accidental use.
    /// </summary>
    /// <returns>This method always throws.</returns>
    [PublicAPI]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete($"{nameof(GetType)} is not supported.")]
    public new Type GetType() => throw new NotSupportedException(nameof(GetType));
#pragma warning restore CS0809
#pragma warning restore CA1065
}