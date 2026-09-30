namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a value after a successful assertion.
/// </summary>
/// <typeparam name="TAssertions">The type of the assertions object to chain from.</typeparam>
/// <typeparam name="T">The type of the value being asserted on.</typeparam>
/// <param name="assertions">The assertions object to chain from.</param>
public readonly struct AssertionsChain<TAssertions, T>(TAssertions assertions)
    where TAssertions : ObjectAssertions<TAssertions, T>
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public TAssertions And { get; } = assertions;

    /// <summary>
    /// Gets the value being asserted on, for use in further assertions via <c>.Should()</c>.
    /// </summary>
    public T That => And.Value;

    /// <summary>
    /// Gets the value being asserted on.
    /// </summary>
    public T Value => And.Value;
}