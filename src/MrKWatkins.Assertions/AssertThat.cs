namespace MrKWatkins.Assertions;

/// <summary>
/// Provides static entry points for assertion testing of actions.
/// </summary>
public static class AssertThat
{
    /// <summary>
    /// Wraps an action for assertion testing.
    /// </summary>
    /// <param name="action">The action to test.</param>
    /// <returns>The action, for use with <see cref="ShouldExtensions.Should(Action)" />.</returns>
    [Pure]
    public static Action Invoking([InstantHandle] Action action) => action;

    /// <summary>
    /// Wraps a function as an action for assertion testing, discarding the return value.
    /// </summary>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="action">The function to test.</param>
    /// <returns>An action that invokes the function, for use with <see cref="ShouldExtensions.Should(Action)" />.</returns>
    [Pure]
    public static Action Invoking<TResult>([InstantHandle] Func<TResult> action) => () => action();
}