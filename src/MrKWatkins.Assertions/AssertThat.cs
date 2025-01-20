namespace MrKWatkins.Assertions;

public static class AssertThat
{
    [Pure]
    public static Action Invoking(Action action) => action;
}