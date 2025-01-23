using System.Numerics;

namespace MrKWatkins.Assertions;

internal sealed class FormattingScope : IDisposable
{
    private static readonly AsyncLocal<FormattingScope?> AsyncLocal = new();

    internal static FormattingScope? Current => AsyncLocal.Value;

    [MustUseReturnValue]
    internal static FormattingScope GetCurrentOrNew() => Current ?? new FormattingScope();

    private IntegerFormat integerFormat = IntegerFormat.Decimal;

    private FormattingScope()
    {
        AsyncLocal.Value = this;
    }

    [MustUseReturnValue]
    internal FormattingScope WithIntegerFormat(IntegerFormat format)
    {
        integerFormat = format;
        return this;
    }

    [Pure]
    internal (string prefix, string format) GetIntegerFormat<T>(int? byteSize)
        where T : IBinaryInteger<T>? =>
        integerFormat switch
        {
            IntegerFormat.Hexadecimal => ("0x", byteSize != null ? $"X{byteSize * 2}" : "X"),
            IntegerFormat.Binary => ("0b", byteSize != null ? $"B{byteSize * 8}" : "B"),
            _ => ("", "")
        };

    public void Dispose() => AsyncLocal.Value = null;
}