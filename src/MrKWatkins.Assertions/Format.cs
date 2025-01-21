using System.Collections.Frozen;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MrKWatkins.Assertions;

internal static class Format
{
    private static readonly FrozenSet<char> Vowels = new[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' }.ToFrozenSet();
    private const int MaximumItemsToShow = 5;
    private const int ItemsToShowInSequence = 2;

    [Pure]
    internal static string PrefixWithAOrAn(string value) => Vowels.Contains(value[0]) ? $"an {value}" : $"a {value}";

    [Pure]
    internal static string Value<T>(T? value)
        where T : struct
    {
        if (value.HasValue)
        {
            return Value(value.Value);
        }
        return "null";
    }

    [Pure]
    internal static string Value<T>(T value)
    {
        if (value is null)
        {
            return "null";
        }

        return value switch
        {
            bool boolValue => boolValue ? "true" : "false",
            char charValue => char.IsControl(charValue) ? $"'\\u{(ushort)charValue:X4}'" : $"'{charValue}'",
            string stringValue => $"\"{stringValue}\"",
            Type typeValue => typeValue.Name,
            Exception exceptionValue => $"{exceptionValue.GetType().Name} with message \"{exceptionValue.Message}\"",
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

    [Pure]
    internal static string Enumerable<T>(IEnumerable<T> value)
    {
        if (value is IReadOnlyCollection<T> collection)
        {
            return Collection(collection);
        }

        var formatted = new StringBuilder().Append('[');
        if (AppendValues(formatted, value.Take(ItemsToShowInSequence)))
        {
            formatted.Append(", ...");
        }
        formatted.Append(']');
        return formatted.ToString();
    }

    [Pure]
    [OverloadResolutionPriority(1)]
    internal static string Collection<T>(IReadOnlyCollection<T> value, bool openEnded = false)
    {
        var formatted = new StringBuilder().Append('[');
        if (value.Count <= MaximumItemsToShow)
        {
            AppendValues(formatted, value);
        }
        else
        {
            AppendValues(formatted, value.Take(ItemsToShowInSequence));
            formatted.Append(", ... ");
            AppendValues(formatted, value.TakeLast(ItemsToShowInSequence));
        }

        if (openEnded)
        {
            formatted.Append(", ...");
        }
        formatted.Append(']');
        return formatted.ToString();
    }

    [Pure]
    internal static string Collection<T>(IReadOnlyCollection<T> value, int highlightIndex, bool openEnded = false)
    {
        var formatted = new StringBuilder().Append('[');
        if (value.Count <= MaximumItemsToShow)
        {
            AppendValues(formatted, value, highlightIndex);

            if (openEnded)
            {
                formatted.Append(", ...");
            }
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

            AppendValues(formatted, value.Skip(startIndex).Take(highlightIndex - startIndex));
            if (highlightIndex > 0)
            {
                formatted.Append(", ");
            }

            formatted.Append('*');
            formatted.Append(Value(value.Skip(highlightIndex).First()));
            formatted.Append('*');

            var endIndex = highlightIndex + ItemsToShowInSequence;
            if (endIndex >= value.Count - 1)
            {
                endIndex = value.Count - 1;
            }

            if (highlightIndex < value.Count - 1)
            {
                formatted.Append(", ");
            }

            AppendValues(formatted, value.Skip(highlightIndex + 1).Take(endIndex - highlightIndex));

            if (openEnded || endIndex < value.Count - 1)
            {
                formatted.Append(", ...");
            }
        }

        formatted.Append(']');
        return formatted.ToString();
    }

    private static void AppendValues<T>(StringBuilder formatted, ReadOnlySpan<T> values)
    {
        var enumerator = values.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return;
        }

        formatted.Append(Value(enumerator.Current));
        while (enumerator.MoveNext())
        {
            formatted.Append(", ");
            formatted.Append(Value(enumerator.Current));
        }
    }

    private static bool AppendValues<T>(StringBuilder formatted, IEnumerable<T> values)
    {
        using var enumerator = values.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return false;
        }

        formatted.Append(Value(enumerator.Current));
        while (enumerator.MoveNext())
        {
            formatted.Append(", ");
            formatted.Append(Value(enumerator.Current));
        }

        return true;
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

    private static void AppendValues<T>(StringBuilder formatted, IReadOnlyCollection<T> values, int highlightIndex)
    {
        var index = 0;
        foreach (var value in values)
        {
            if (index > 0)
            {
                formatted.Append(", ");
            }
            if (index == highlightIndex)
            {
                formatted.Append('*');
            }
            formatted.Append(Value(value));
            if (index == highlightIndex)
            {
                formatted.Append('*');
            }
            index++;
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