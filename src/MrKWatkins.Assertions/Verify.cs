namespace MrKWatkins.Assertions;

internal static class Verify
{
    internal static void That(bool condition, string exceptionMessage)
    {
        if (!condition)
        {
            throw new AssertionException(exceptionMessage);
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0>(bool condition, string exceptionMessageFormat, T0 arg0)
    {
        if (!condition)
        {
            throw new AssertionException(string.Format(exceptionMessageFormat, Format.Value(arg0)));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1>(bool condition, string exceptionMessageFormat, T0 arg0, T1 arg1)
    {
        if (!condition)
        {
            throw new AssertionException(string.Format(exceptionMessageFormat, Format.Value(arg0), Format.Value(arg1)));
        }
    }
}