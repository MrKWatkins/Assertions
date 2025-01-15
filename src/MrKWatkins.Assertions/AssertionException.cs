namespace MrKWatkins.Assertions;

/// <summary>
/// Exception class for assertions.
/// </summary>
public sealed class AssertionException : Exception
{
    internal AssertionException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}