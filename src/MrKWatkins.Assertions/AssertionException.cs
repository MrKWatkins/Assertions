namespace MrKWatkins.Assertions;

/// <summary>
/// Exception class for assertions.
/// </summary>
/// <param name="message">The message.</param>
/// <param name="innerException">Optional inner exception.</param>
public sealed class AssertionException(string message, Exception? innerException = null) : Exception(message, innerException);