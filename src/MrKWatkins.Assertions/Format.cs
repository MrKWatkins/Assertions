using System.Collections;
using System.Collections.Frozen;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MrKWatkins.Assertions;

// TODO: Use format string for plurals and a/an.
// TODO: Tidy up and rationalise methods.
// TODO: Use more if possible.
internal static class Format
{
    private static readonly FrozenSet<char> Vowels = new[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' }.ToFrozenSet();
    private const int MaximumItemsToShow = 5;
    private const int ItemsToShowInSequence = 2;

    [Pure]
    internal static string PrefixWithAOrAn(string value) => Vowels.Contains(value[0]) ? $"an {value}" : $"a {value}";

    internal static string Value(object? value)
    {
        var message = new StringBuilder();
        Append(message, value);
        return message.ToString();
    }

    internal static void Append(StringBuilder message, object? value)
    {
        if (value is null)
        {
            message.Append("null");
            return;
        }

        switch (value)
        {
            case bool boolValue:
                message.Append(boolValue ? "true" : "false");
                return;

            case char charValue:
                Append(message, charValue);
                return;

            case string stringValue:
                Append(message, stringValue);
                return;

            case Type typeValue:
                message.Append(typeValue.Name);
                return;

            case Exception exceptionValue:
                Append(message, exceptionValue);
                return;

            case byte byteValue:
                Append(message, byteValue, 1);
                return;

            case sbyte sbyteValue:
                Append(message, sbyteValue, 1);
                return;

            case ushort ushortValue:
                Append(message, ushortValue, 2);
                return;

            case short shortValue:
                Append(message, shortValue, 2);
                return;

            case int intValue:
                Append(message, intValue, 4);
                return;

            case uint uintValue:
                Append(message, uintValue, 4);
                return;

            case long longValue:
                Append(message, longValue, 8);
                return;

            case ulong ulongValue:
                Append(message, ulongValue, 8);
                return;

            case Int128 int128Value:
                Append(message, int128Value, 16);
                return;

            case UInt128 uint128Value:
                Append(message, uint128Value, 16);
                return;

            default:
                message.Append(value);
                return;
        }
    }

    private static void Append(StringBuilder message, string value)
    {
        message.Append('\"');
        message.Append(value);
        message.Append('\"');
    }

    private static void Append(StringBuilder message, char value)
    {
        message.Append('\'');
        if (char.IsControl(value))
        {
            message.Append("\\u");
            message.Append(((ushort)value).ToString("X4"));
        }
        else
        {
            message.Append(value);
        }
        message.Append('\'');
    }

    private static void Append(StringBuilder message, Exception value)
    {
        message.Append(value.GetType().Name);
        message.Append(" with message \"");
        message.Append(value.Message);
        message.Append('\"');
    }

    private static void Append<T>(StringBuilder message, IBinaryInteger<T> value, int? byteSize)
        where T : IBinaryInteger<T>?
    {
        var (prefix, format) = FormattingScope.Current?.GetIntegerFormat<T>(byteSize) ?? ("", "");

        message.Append(prefix);
        message.Append(value.ToString(format, null));
    }

    [Pure]
    internal static string Value<T>(Span<T> value) => Value((ReadOnlySpan<T>)value);

    [Pure]
    internal static string Value<T>(ReadOnlySpan<T> value)
    {
        var message = new StringBuilder().Append('[');
        if (value.Length <= MaximumItemsToShow)
        {
            AppendValues(message, value);
        }
        else
        {
            AppendValues(message, value[..ItemsToShowInSequence]);
            message.Append(", ... ");
            AppendValues(message, value[^ItemsToShowInSequence..]);
        }
        message.Append(']');
        return message.ToString();
    }
    [Pure]
    internal static string Value<T>(Span<T> value, int highlightIndex) => Value((ReadOnlySpan<T>)value, highlightIndex);

    [Pure]
    internal static string Value<T>(ReadOnlySpan<T> value, int highlightIndex)
    {
        var message = new StringBuilder().Append('[');
        if (value.Length <= MaximumItemsToShow)
        {
            AppendValues(message, value, highlightIndex);
        }
        else
        {
            var startIndex = highlightIndex - ItemsToShowInSequence;
            if (startIndex > 0)
            {
                message.Append("... ");
            }
            else
            {
                startIndex = 0;
            }

            AppendValues(message, value.Slice(startIndex, highlightIndex - startIndex));
            if (highlightIndex > 0)
            {
                message.Append(", ");
            }

            message.Append('*');
            Append(message, value[highlightIndex]);
            message.Append('*');

            var endIndex = highlightIndex + ItemsToShowInSequence;
            if (endIndex >= value.Length - 1)
            {
                endIndex = value.Length - 1;
            }

            if (highlightIndex < value.Length - 1)
            {
                message.Append(", ");
            }

            AppendValues(message, value.Slice(highlightIndex + 1, endIndex - highlightIndex));

            if (endIndex < value.Length - 1)
            {
                message.Append(", ...");
            }
        }

        message.Append(']');
        return message.ToString();
    }

    [Pure]
    internal static string Enumerable(IEnumerable value) => value is ICollection collection ? Collection(collection) : Enumerable(value.OfType<object>());

    [Pure]
    internal static string Enumerable<T>(IEnumerable<T> value)
    {
        var message = new StringBuilder();
        AppendEnumerable(message, value);
        return message.ToString();
    }

    internal static void AppendEnumerable<T>(StringBuilder message, IEnumerable<T> value)
    {
        if (value is IReadOnlyCollection<T> collection)
        {
            AppendCollection(message, collection);
            return;
        }

        message.Append('[');
        if (AppendValues(message, value.Take(ItemsToShowInSequence)))
        {
            message.Append(", ...");
        }
        message.Append(']');
    }

    [Pure]
    internal static string Collection(ICollection value, bool openEnded = false)
    {
        var message = new StringBuilder();
        AppendCollection(message, value, openEnded);
        return message.ToString();
    }

    internal static void AppendCollection(StringBuilder message, ICollection value, bool openEnded = false)
    {
        message.Append('[');
        if (value.Count <= MaximumItemsToShow)
        {
            AppendValues(message, value.OfType<object>());
        }
        else
        {
            AppendValues(message, value.OfType<object>().Take(ItemsToShowInSequence));
            message.Append(", ... ");
            AppendValues(message, value.OfType<object>().TakeLast(ItemsToShowInSequence));
        }

        if (openEnded)
        {
            message.Append(", ...");
        }
        message.Append(']');
    }

    [Pure]
    [OverloadResolutionPriority(1)]
    internal static string Collection<T>(IReadOnlyCollection<T> value, bool openEnded = false)
    {
        var message = new StringBuilder();
        AppendCollection(message, value, openEnded);
        return message.ToString();
    }

    [OverloadResolutionPriority(1)]
    internal static void AppendCollection<T>(StringBuilder message, IReadOnlyCollection<T> value, bool openEnded = false)
    {
        message.Append('[');
        if (value.Count <= MaximumItemsToShow)
        {
            AppendValues(message, value);
        }
        else
        {
            AppendValues(message, value.Take(ItemsToShowInSequence));
            message.Append(", ... ");
            AppendValues(message, value.TakeLast(ItemsToShowInSequence));
        }

        if (openEnded)
        {
            message.Append(", ...");
        }
        message.Append(']');
    }

    [Pure]
    internal static string Collection<T>(IReadOnlyCollection<T> value, int highlightIndex, bool openEnded = false)
    {
        var message = new StringBuilder().Append('[');
        if (value.Count <= MaximumItemsToShow)
        {
            AppendValues(message, value, highlightIndex);

            if (openEnded)
            {
                message.Append(", ...");
            }
        }
        else
        {
            var startIndex = highlightIndex - ItemsToShowInSequence;
            if (startIndex > 0)
            {
                message.Append("... ");
            }
            else
            {
                startIndex = 0;
            }

            AppendValues(message, value.Skip(startIndex).Take(highlightIndex - startIndex));
            if (highlightIndex > 0)
            {
                message.Append(", ");
            }

            message.Append('*');
            Append(message, value.Skip(highlightIndex).First());
            message.Append('*');

            var endIndex = highlightIndex + ItemsToShowInSequence;
            if (endIndex >= value.Count - 1)
            {
                endIndex = value.Count - 1;
            }

            if (highlightIndex < value.Count - 1)
            {
                message.Append(", ");
            }

            AppendValues(message, value.Skip(highlightIndex + 1).Take(endIndex - highlightIndex));

            if (openEnded || endIndex < value.Count - 1)
            {
                message.Append(", ...");
            }
        }

        message.Append(']');
        return message.ToString();
    }

    private static void AppendValues<T>(StringBuilder message, ReadOnlySpan<T> values)
    {
        var enumerator = values.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return;
        }

        Append(message, enumerator.Current);
        while (enumerator.MoveNext())
        {
            message.Append(", ");
            Append(message, enumerator.Current);
        }
    }

    private static bool AppendValues<T>(StringBuilder message, IEnumerable<T> values)
    {
        using var enumerator = values.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return false;
        }

        Append(message, enumerator.Current);
        while (enumerator.MoveNext())
        {
            message.Append(", ");
            Append(message, enumerator.Current);
        }

        return true;
    }

    private static void AppendValues<T>(StringBuilder message, ReadOnlySpan<T> values, int highlightIndex)
    {
        for (var f = 0; f < values.Length; f++)
        {
            if (f == highlightIndex)
            {
                message.Append('*');
            }
            Append(message, values[f]);
            if (f == highlightIndex)
            {
                message.Append('*');
            }
            if (f < values.Length - 1)
            {
                message.Append(", ");
            }
        }
    }

    private static void AppendValues<T>(StringBuilder message, IReadOnlyCollection<T> values, int highlightIndex)
    {
        var index = 0;
        foreach (var value in values)
        {
            if (index > 0)
            {
                message.Append(", ");
            }
            if (index == highlightIndex)
            {
                message.Append('*');
            }
            Append(message, value);
            if (index == highlightIndex)
            {
                message.Append('*');
            }
            index++;
        }
    }
}