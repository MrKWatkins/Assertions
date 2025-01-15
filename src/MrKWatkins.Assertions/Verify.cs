namespace MrKWatkins.Assertions;

internal static class Verify
{
    private const string IsText = "";
    private const string IsNotText = "not ";

    internal static void That(bool condition, string exceptionMessageFormat, bool isNot)
    {
        condition = isNot ? !condition : condition;

        if (!condition)
        {
            throw new AssertionException(string.Format(exceptionMessageFormat, isNot ? IsNotText : IsText));
        }
    }
}