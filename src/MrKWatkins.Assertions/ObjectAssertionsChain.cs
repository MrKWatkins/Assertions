namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on an object value after a successful assertion.
/// </summary>
/// <typeparam name="T">The type of the value being asserted on.</typeparam>
/// <param name="objectAssertions">The assertions object to chain from.</param>
public readonly struct ObjectAssertionsChain<T>(ObjectAssertions<T> objectAssertions)
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public ObjectAssertions<T> And => objectAssertions;

    /// <summary>
    /// Gets the value being asserted on, for use in further assertions via <c>.Should()</c>.
    /// </summary>
    public T That => And.Value;

    /// <summary>
    /// Gets the value being asserted on.
    /// </summary>
    public T Value => And.Value;
}