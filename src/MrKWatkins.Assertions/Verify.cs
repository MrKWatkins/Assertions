namespace MrKWatkins.Assertions;

internal static class Verify
{
    internal static void That(bool condition, string exceptionMessageFormat)
    {
        if (!condition)
        {
            throw new AssertionException(exceptionMessageFormat);
        }
    }
}