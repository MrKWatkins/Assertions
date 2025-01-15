namespace MrKWatkins.Assertions;

/// <summary>
/// Exception class for assertions.
/// </summary>
public sealed class AssertionException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssertionException" /> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">Optional inner exception.</param>
    public AssertionException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}