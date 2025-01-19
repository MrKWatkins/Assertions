using System.Numerics;
using System.Text;

namespace MrKWatkins.Assertions;

internal static class Format
{
    private const int MaximumItemsToShow = 5;
    private const int ItemsToShowInSequence = 2;

    [Pure]
    internal static string Value<T>(T value)
    {
        if (value is null)
        {
            return "null";
        }

        return value switch
        {
            char charValue => char.IsControl(charValue) ? $"'\\u{(ushort)charValue:X4}'" : $"'{charValue}'",
            string stringValue => $"\"{stringValue}\"",
            Type typeValue => typeValue.Name,
            byte byteValue => Value(byteValue, 1),
            sbyte sbyteValue => Value(sbyteValue, 1),
            ushort ushortValue => Value(ushortValue, 2),
            short shortValue => Value(shortValue, 2),
            int intValue => Value(intValue, 4),
            uint uintValue => Value(uintValue, 4),
            long longValue => Value(longValue, 8),
            ulong ulongValue => Value(ulongValue, 8),
            Int128 int128Value => Value(int128Value, 16),
            UInt128 uint128Value => Value(uint128Value, 16),
            _ => value.ToString()!
        };
    }

    [Pure]
    internal static string Value<T>(Span<T> value) => Value((ReadOnlySpan<T>)value);

    [Pure]
    internal static string Value<T>(ReadOnlySpan<T> value)
    {
        var formatted = new StringBuilder().Append('[');
        if (value.Length <= MaximumItemsToShow)
        {
            AppendValues(formatted, value);
        }
        else
        {
            AppendValues(formatted, value[..ItemsToShowInSequence]);
            formatted.Append(", ... ");
            AppendValues(formatted, value[^ItemsToShowInSequence..]);
        }
        formatted.Append(']');
        return formatted.ToString();
    }


    [Pure]
    internal static string Value<T>(Span<T> value, int highlightIndex) => Value((ReadOnlySpan<T>)value, highlightIndex);

    [Pure]
    internal static string Value<T>(ReadOnlySpan<T> value, int highlightIndex)
    {
        var formatted = new StringBuilder().Append('[');
        if (value.Length <= MaximumItemsToShow)
        {
            AppendValues(formatted, value, highlightIndex);
        }
        else
        {
            var startIndex = highlightIndex - ItemsToShowInSequence;
            if (startIndex > 0)
            {
                formatted.Append("... ");
            }
            else
            {
                startIndex = 0;
            }

            AppendValues(formatted, value.Slice(startIndex, highlightIndex - startIndex));
            if (highlightIndex > 0)
            {
                formatted.Append(", ");
            }

            formatted.Append('*');
            formatted.Append(Value(value[highlightIndex]));
            formatted.Append('*');

            var endIndex = highlightIndex + ItemsToShowInSequence;
            if (endIndex >= value.Length - 1)
            {
                endIndex = value.Length - 1;
            }

            if (highlightIndex < value.Length - 1)
            {
                formatted.Append(", ");
            }

            AppendValues(formatted, value.Slice(highlightIndex + 1, endIndex - highlightIndex));

            if (endIndex < value.Length - 1)
            {
                formatted.Append(", ...");
            }
        }

        formatted.Append(']');
        return formatted.ToString();
    }

    private static void AppendValues<T>(StringBuilder formatted, ReadOnlySpan<T> values)
    {
        for (var f = 0; f < values.Length; f++)
        {
            formatted.Append(Value(values[f]));
            if (f < values.Length - 1)
            {
                formatted.Append(", ");
            }
        }
    }

    private static void AppendValues<T>(StringBuilder formatted, ReadOnlySpan<T> values, int highlightIndex)
    {
        for (var f = 0; f < values.Length; f++)
        {
            if (f == highlightIndex)
            {
                formatted.Append('*');
            }
            formatted.Append(Value(values[f]));
            if (f == highlightIndex)
            {
                formatted.Append('*');
            }
            if (f < values.Length - 1)
            {
                formatted.Append(", ");
            }
        }
    }

    [Pure]
    private static string Value<T>(IBinaryInteger<T> value, int? byteSize)
        where T : IBinaryInteger<T>?
    {
        var (prefix, format) = FormattingScope.Current?.GetIntegerFormat<T>(byteSize) ?? ("", null);

        return prefix + value.ToString(format, null);
    }
}