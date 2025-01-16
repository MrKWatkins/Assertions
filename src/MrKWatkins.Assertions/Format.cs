using System.Numerics;

namespace MrKWatkins.Assertions;

internal static class Format
{
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
    private static string Value<T>(IBinaryInteger<T> value, int? byteSize)
        where T : IBinaryInteger<T>?
    {
        var (prefix, format) = FormattingScope.Current?.GetIntegerFormat<T>(byteSize) ?? ("", null);

        return prefix + value.ToString(format, null);
    }
}