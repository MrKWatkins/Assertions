namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on an exception value after a successful assertion.
/// </summary>
/// <typeparam name="T">The type of the exception being asserted on.</typeparam>
/// <param name="exceptionAssertions">The assertions object to chain from.</param>
public readonly struct ExceptionAssertionsChain<T>(ExceptionAssertions<T> exceptionAssertions)
    where T : Exception
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public ExceptionAssertions<T> And { get; } = exceptionAssertions;

    /// <summary>
    /// Gets the exception value being asserted on.
    /// </summary>
    public T Value => And.Value;
}