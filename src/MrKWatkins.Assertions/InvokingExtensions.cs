namespace MrKWatkins.Assertions;

public static class InvokingExtensions
{
    [Pure]
    public static Action Invoking<T>(this T value, Action<T> action) => () => action(value);
}