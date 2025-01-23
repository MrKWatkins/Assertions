using System.Runtime.CompilerServices;
using System.Text;

namespace MrKWatkins.Assertions;

[InterpolatedStringHandler]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public readonly struct FormatInterpolatedStringHandler
{
    private readonly StringBuilder message;

    public FormatInterpolatedStringHandler(int literalLength, int _)
    {
        message = new StringBuilder(literalLength);
    }

    public void AppendLiteral(string literal) => message.Append(literal);

    public void AppendFormatted<T>(T value) => Format.Append(message, value);

    public void AppendFormatted<T>(IEnumerable<T> value) => Format.AppendEnumerable(message, value);

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

    public override string ToString() => message.ToString();
}