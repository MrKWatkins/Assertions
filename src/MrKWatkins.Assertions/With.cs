namespace MrKWatkins.Assertions;

public static class With
{
    [MustDisposeResource]
    public static IDisposable IntegerFormat(IntegerFormat format) => FormattingScope.GetCurrentOrNew().WithIntegerFormat(format);
}