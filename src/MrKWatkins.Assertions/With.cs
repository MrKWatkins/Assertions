namespace MrKWatkins.Assertions;

/// <summary>
/// Provides methods for configuring assertion formatting options.
/// </summary>
public static class With
{
    /// <summary>
    /// Sets the display format for integer values in assertion messages within the returned scope.
    /// </summary>
    /// <param name="format">The integer display format to use.</param>
    /// <returns>An <see cref="IDisposable" /> that restores the previous format when disposed.</returns>
    [MustDisposeResource]
    public static IDisposable IntegerFormat(IntegerFormat format) => FormattingScope.GetCurrentOrNew().WithIntegerFormat(format);
}