using System.Runtime.CompilerServices;
using System.Text;

namespace MrKWatkins.Assertions;

/// <summary>
/// An interpolated string handler that formats values using the assertion library's formatting rules.
/// </summary>
[InterpolatedStringHandler]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public readonly struct FormatInterpolatedStringHandler
{
    private readonly StringBuilder message;

    /// <summary>
    /// Initializes a new instance of the <see cref="FormatInterpolatedStringHandler" /> struct.
    /// </summary>
    /// <param name="literalLength">The number of literal characters in the interpolated string.</param>
    /// <param name="_">The number of interpolation holes (unused).</param>
    public FormatInterpolatedStringHandler(int literalLength, int _)
    {
        message = new StringBuilder(literalLength);
    }

    /// <summary>
    /// Appends a literal string to the message.
    /// </summary>
    /// <param name="literal">The literal string to append.</param>
    public void AppendLiteral(string literal) => message.Append(literal);

    /// <summary>
    /// Appends a formatted value to the message.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to format and append.</param>
    public void AppendFormatted<T>(T value) => Format.Append(message, value);

    /// <summary>
    /// Appends a formatted enumerable to the message.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="value">The enumerable to format and append.</param>
    public void AppendFormatted<T>(IEnumerable<T> value) => Format.AppendEnumerable(message, value);

    /// <summary>
    /// Appends a formatted string value to the message using the specified format.
    /// </summary>
    /// <param name="value">The string value to append.</param>
    /// <param name="format">The format specifier. Use "L" for literal (unquoted) output.</param>
    public void AppendFormatted(string? value, string format)
    {
        if (value == null)
        {
            return;
        }
        if (format[0] == 'L')
        {
            AppendLiteral(value);
        }
        else
        {
            throw new ArgumentException($"Unknown format \"{format}\".", nameof(format));
        }
    }

    /// <summary>
    /// Returns the formatted message as a string.
    /// </summary>
    /// <returns>The formatted message.</returns>
    public override string ToString() => message.ToString();
}