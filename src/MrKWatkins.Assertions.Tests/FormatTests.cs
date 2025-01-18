namespace MrKWatkins.Assertions.Tests;

public sealed class FormatTests
{
    [Test]
    public async Task Null()
    {
        string? value = null;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo("null");
    }

    [Test]
    public async Task Default()
    {
        var value = new object();

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo("System.Object");
    }

    [Test]
    public async Task NullableValueType()
    {
        int? value = null;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo("null");
    }

    [Test]
    [Arguments('X', "'X'")]
    [Arguments('\u2122', "'\u2122'")]
    [Arguments('\x00', "'\\u0000'")]
    [Arguments('\x13', "'\\u0013'")]
    public async Task Char(char value, string expected)
    {
        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments("", "\"\"")]
    [Arguments(" ", "\" \"")]
    [Arguments("Test", "\"Test\"")]
    public async Task String(string value, string expected)
    {
        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    public async Task Type()
    {
        var actual = Format.Value(typeof(string));

        await Assert.That(actual).IsEqualTo("String");
    }

    [Test]
    [Arguments(null, 15, "15")]
    [Arguments(IntegerFormat.Decimal, 15, "15")]
    [Arguments(IntegerFormat.Hexadecimal, 15, "0x0F")]
    [Arguments(IntegerFormat.Binary, 15, "0b00001111")]
    public async Task Byte(IntegerFormat? integerFormat, int intValue, string expected)
    {
        var value = (byte)intValue;
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, -15, "-15")]
    [Arguments(null, 15, "15")]
    [Arguments(IntegerFormat.Decimal, -15, "-15")]
    [Arguments(IntegerFormat.Decimal, 15, "15")]
    [Arguments(IntegerFormat.Hexadecimal, -15, "0xF1")]
    [Arguments(IntegerFormat.Hexadecimal, 15, "0x0F")]
    [Arguments(IntegerFormat.Binary, -15, "0b11110001")]
    [Arguments(IntegerFormat.Binary, 15, "0b00001111")]
    public async Task SByte(IntegerFormat? integerFormat, int intValue, string expected)
    {
        var value = (sbyte)intValue;
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, (ushort)1234, "1234")]
    [Arguments(IntegerFormat.Decimal, (ushort)1234, "1234")]
    [Arguments(IntegerFormat.Hexadecimal, (ushort)1234, "0x04D2")]
    [Arguments(IntegerFormat.Binary, (ushort)1234, "0b0000010011010010")]
    public async Task UShort(IntegerFormat? integerFormat, ushort value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, -1234, "-1234")]
    [Arguments(null, 1234, "1234")]
    [Arguments(IntegerFormat.Decimal, -1234, "-1234")]
    [Arguments(IntegerFormat.Decimal, 1234, "1234")]
    [Arguments(IntegerFormat.Hexadecimal, -1234, "0xFB2E")]
    [Arguments(IntegerFormat.Hexadecimal, 1234, "0x04D2")]
    [Arguments(IntegerFormat.Binary, -1234, "0b1111101100101110")]
    [Arguments(IntegerFormat.Binary, 1234, "0b0000010011010010")]
    public async Task Short(IntegerFormat? integerFormat, int intValue, string expected)
    {
        var value = (short)intValue;
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, 12345678U, "12345678")]
    [Arguments(IntegerFormat.Decimal, 12345678U, "12345678")]
    [Arguments(IntegerFormat.Hexadecimal, 12345678U, "0x00BC614E")]
    [Arguments(IntegerFormat.Binary, 12345678U, "0b00000000101111000110000101001110")]
    public async Task UInt(IntegerFormat? integerFormat, uint value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, -12345678, "-12345678")]
    [Arguments(null, 12345678, "12345678")]
    [Arguments(IntegerFormat.Decimal, -12345678, "-12345678")]
    [Arguments(IntegerFormat.Decimal, 12345678, "12345678")]
    [Arguments(IntegerFormat.Hexadecimal, -12345678, "0xFF439EB2")]
    [Arguments(IntegerFormat.Hexadecimal, 12345678, "0x00BC614E")]
    [Arguments(IntegerFormat.Binary, -12345678, "0b11111111010000111001111010110010")]
    [Arguments(IntegerFormat.Binary, 12345678, "0b00000000101111000110000101001110")]
    public async Task Int(IntegerFormat? integerFormat, int value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, 1234567890123456UL, "1234567890123456")]
    [Arguments(IntegerFormat.Decimal, 1234567890123456UL, "1234567890123456")]
    [Arguments(IntegerFormat.Hexadecimal, 1234567890123456UL, "0x000462D53C8ABAC0")]
    [Arguments(IntegerFormat.Binary, 1234567890123456UL, "0b0000000000000100011000101101010100111100100010101011101011000000")]
    public async Task ULong(IntegerFormat? integerFormat, ulong value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, -1234567890123456L, "-1234567890123456")]
    [Arguments(null, 1234567890123456L, "1234567890123456")]
    [Arguments(IntegerFormat.Decimal, -1234567890123456L, "-1234567890123456")]
    [Arguments(IntegerFormat.Decimal, 1234567890123456L, "1234567890123456")]
    [Arguments(IntegerFormat.Hexadecimal, -1234567890123456L, "0xFFFB9D2AC3754540")]
    [Arguments(IntegerFormat.Hexadecimal, 1234567890123456L, "0x000462D53C8ABAC0")]
    [Arguments(IntegerFormat.Binary, -1234567890123456L, "0b1111111111111011100111010010101011000011011101010100010101000000")]
    [Arguments(IntegerFormat.Binary, 1234567890123456L, "0b0000000000000100011000101101010100111100100010101011101011000000")]
    public async Task Long(IntegerFormat? integerFormat, long value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [MethodDataSource(nameof(UInt128TestCases))]
    public async Task UInt128(IntegerFormat? integerFormat, UInt128 value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Pure]
    public static IEnumerable<(IntegerFormat? IntegerFormat, UInt128 Value, string Expected)> UInt128TestCases()
    {
        yield return (null, System.UInt128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return (IntegerFormat.Decimal, System.UInt128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return (IntegerFormat.Hexadecimal, System.UInt128.Parse("123456789012345678901234567890"), "0x000000018EE90FF6C373E0EE4E3F0AD2");
        yield return (IntegerFormat.Binary, System.UInt128.Parse("123456789012345678901234567890"), "0b00000000000000000000000000000001100011101110100100001111111101101100001101110011111000001110111001001110001111110000101011010010");
    }

    [Test]
    [MethodDataSource(nameof(Int128TestCases))]
    public async Task Int128(IntegerFormat? integerFormat, Int128 value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Pure]
    public static IEnumerable<(IntegerFormat? IntegerFormat, Int128 Value, string Expected)> Int128TestCases()
    {
        yield return (null, System.Int128.Parse("-123456789012345678901234567890"), "-123456789012345678901234567890");
        yield return (null, System.Int128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return (IntegerFormat.Decimal, System.Int128.Parse("-123456789012345678901234567890"), "-123456789012345678901234567890");
        yield return (IntegerFormat.Decimal, System.Int128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return (IntegerFormat.Hexadecimal, System.Int128.Parse("-123456789012345678901234567890"), "0xFFFFFFFE7116F0093C8C1F11B1C0F52E");
        yield return (IntegerFormat.Hexadecimal, System.Int128.Parse("123456789012345678901234567890"), "0x000000018EE90FF6C373E0EE4E3F0AD2");
        yield return (IntegerFormat.Binary, System.Int128.Parse("-123456789012345678901234567890"), "0b11111111111111111111111111111110011100010001011011110000000010010011110010001100000111110001000110110001110000001111010100101110");
        yield return (IntegerFormat.Binary, System.Int128.Parse("123456789012345678901234567890"), "0b00000000000000000000000000000001100011101110100100001111111101101100001101110011111000001110111001001110001111110000101011010010");
    }
}