namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that wrap actions on a value for assertion testing.
/// </summary>
public static class InvokingExtensions
{
    /// <summary>
    /// Wraps an action on the specified value for assertion testing.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to pass to the action.</param>
    /// <param name="action">The action to test.</param>
    /// <returns>An action that invokes the specified action with the value, for use with <see cref="ShouldExtensions.Should(Action)" />.</returns>
    [Pure]
    public static Action Invoking<T>(this T value, Action<T> action) => () => action(value);

    /// <summary>
    /// Wraps a function on the specified value as an action for assertion testing, discarding the return value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="value">The value to pass to the function.</param>
    /// <param name="action">The function to test.</param>
    /// <returns>An action that invokes the specified function with the value, for use with <see cref="ShouldExtensions.Should(Action)" />.</returns>
    [Pure]
    public static Action Invoking<T, TResult>(this T value, Func<T, TResult> action) => () => action(value);

    /// <summary>
    /// Wraps an async action on the specified value for assertion testing.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to pass to the async action.</param>
    /// <param name="action">The async action to test.</param>
    /// <returns>A <see cref="Func{Task}"/> that invokes the specified async action with the value, for use with <see cref="ShouldExtensions.Should(Func{Task})" />.</returns>
    [Pure]
    public static Func<Task> Awaiting<T>(this T value, Func<T, Task> action) => () => action(value);

    /// <summary>
    /// Wraps an async function on the specified value for assertion testing, discarding the return value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <typeparam name="TResult">The return type of the async function.</typeparam>
    /// <param name="value">The value to pass to the async function.</param>
    /// <param name="action">The async function to test.</param>
    /// <returns>A <see cref="Func{Task}"/> that invokes the specified async function with the value, for use with <see cref="ShouldExtensions.Should(Func{Task})" />.</returns>
    [Pure]
    public static Func<Task> Awaiting<T, TResult>(this T value, Func<T, Task<TResult>> action) => () => action(value);
}