namespace MrKWatkins.Assertions.Tests;

public sealed class FormatTests
{
    [Test]
    public void Null()
    {
        string? value = null;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo("null"));
    }

    [Test]
    public void Default()
    {
        var value = new object();

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo("System.Object"));
    }

    [Test]
    public void NullableValueType()
    {
        int? value = null;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo("null"));
    }

    [TestCase('X', "'X'")]
    [TestCase('\u2122', "'\u2122'")]
    [TestCase('\x00', "'\\u0000'")]
    [TestCase('\x13', "'\\u0013'")]
    public void Char(char value, string expected)
    {
        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("", "\"\"")]
    [TestCase(" ", "\" \"")]
    [TestCase("Test", "\"Test\"")]
    public void String(string value, string expected)
    {
        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Type()
    {
        var actual = Format.Value(typeof(string));

        Assert.That(actual, Is.EqualTo("String"));
    }

    [TestCase(null, 15, "15")]
    [TestCase(IntegerFormat.Decimal, 15, "15")]
    [TestCase(IntegerFormat.Hexadecimal, 15, "0x0F")]
    [TestCase(IntegerFormat.Binary, 15, "0b00001111")]
    public void Byte(IntegerFormat? integerFormat, byte value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(null, -15, "-15")]
    [TestCase(null, 15, "15")]
    [TestCase(IntegerFormat.Decimal, -15, "-15")]
    [TestCase(IntegerFormat.Decimal, 15, "15")]
    [TestCase(IntegerFormat.Hexadecimal, -15, "0xF1")]
    [TestCase(IntegerFormat.Hexadecimal, 15, "0x0F")]
    [TestCase(IntegerFormat.Binary, -15, "0b11110001")]
    [TestCase(IntegerFormat.Binary, 15, "0b00001111")]
    public void SByte(IntegerFormat? integerFormat, sbyte value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(null, (ushort)1234, "1234")]
    [TestCase(IntegerFormat.Decimal, (ushort)1234, "1234")]
    [TestCase(IntegerFormat.Hexadecimal, (ushort)1234, "0x04D2")]
    [TestCase(IntegerFormat.Binary, (ushort)1234, "0b0000010011010010")]
    public void UShort(IntegerFormat? integerFormat, ushort value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(null, (short)-1234, "-1234")]
    [TestCase(null, (short)1234, "1234")]
    [TestCase(IntegerFormat.Decimal, (short)-1234, "-1234")]
    [TestCase(IntegerFormat.Decimal, (short)1234, "1234")]
    [TestCase(IntegerFormat.Hexadecimal, (short)-1234, "0xFB2E")]
    [TestCase(IntegerFormat.Hexadecimal, (short)1234, "0x04D2")]
    [TestCase(IntegerFormat.Binary, (short)-1234, "0b1111101100101110")]
    [TestCase(IntegerFormat.Binary, (short)1234, "0b0000010011010010")]
    public void Short(IntegerFormat? integerFormat, short value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(null, 12345678U, "12345678")]
    [TestCase(IntegerFormat.Decimal, 12345678U, "12345678")]
    [TestCase(IntegerFormat.Hexadecimal, 12345678U, "0x00BC614E")]
    [TestCase(IntegerFormat.Binary, 12345678U, "0b00000000101111000110000101001110")]
    public void UInt(IntegerFormat? integerFormat, uint value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(null, -12345678, "-12345678")]
    [TestCase(null, 12345678, "12345678")]
    [TestCase(IntegerFormat.Decimal, -12345678, "-12345678")]
    [TestCase(IntegerFormat.Decimal, 12345678, "12345678")]
    [TestCase(IntegerFormat.Hexadecimal, -12345678, "0xFF439EB2")]
    [TestCase(IntegerFormat.Hexadecimal, 12345678, "0x00BC614E")]
    [TestCase(IntegerFormat.Binary, -12345678, "0b11111111010000111001111010110010")]
    [TestCase(IntegerFormat.Binary, 12345678, "0b00000000101111000110000101001110")]
    public void Int(IntegerFormat? integerFormat, int value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(null, 1234567890123456UL, "1234567890123456")]
    [TestCase(IntegerFormat.Decimal, 1234567890123456UL, "1234567890123456")]
    [TestCase(IntegerFormat.Hexadecimal, 1234567890123456UL, "0x000462D53C8ABAC0")]
    [TestCase(IntegerFormat.Binary, 1234567890123456UL, "0b0000000000000100011000101101010100111100100010101011101011000000")]
    public void ULong(IntegerFormat? integerFormat, ulong value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(null, -1234567890123456L, "-1234567890123456")]
    [TestCase(null, 1234567890123456L, "1234567890123456")]
    [TestCase(IntegerFormat.Decimal, -1234567890123456L, "-1234567890123456")]
    [TestCase(IntegerFormat.Decimal, 1234567890123456L, "1234567890123456")]
    [TestCase(IntegerFormat.Hexadecimal, -1234567890123456L, "0xFFFB9D2AC3754540")]
    [TestCase(IntegerFormat.Hexadecimal, 1234567890123456L, "0x000462D53C8ABAC0")]
    [TestCase(IntegerFormat.Binary, -1234567890123456L, "0b1111111111111011100111010010101011000011011101010100010101000000")]
    [TestCase(IntegerFormat.Binary, 1234567890123456L, "0b0000000000000100011000101101010100111100100010101011101011000000")]
    public void Long(IntegerFormat? integerFormat, long value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(UInt128TestCases))]
    public void UInt128(IntegerFormat? integerFormat, UInt128 value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Pure]
    public static IEnumerable<TestCaseData> UInt128TestCases()
    {
        yield return new TestCaseData(null, System.UInt128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return new TestCaseData(IntegerFormat.Decimal, System.UInt128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return new TestCaseData(IntegerFormat.Hexadecimal, System.UInt128.Parse("123456789012345678901234567890"), "0x000000018EE90FF6C373E0EE4E3F0AD2");
        yield return new TestCaseData(IntegerFormat.Binary, System.UInt128.Parse("123456789012345678901234567890"), "0b00000000000000000000000000000001100011101110100100001111111101101100001101110011111000001110111001001110001111110000101011010010");
    }

    [TestCaseSource(nameof(Int128TestCases))]
    public void Int128(IntegerFormat? integerFormat, Int128 value, string expected)
    {
        using var _ = integerFormat.HasValue ? With.IntegerFormat(integerFormat.Value) : NullDisposable.Instance;

        var actual = Format.Value(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Pure]
    public static IEnumerable<TestCaseData> Int128TestCases()
    {
        yield return new TestCaseData(null, System.Int128.Parse("-123456789012345678901234567890"), "-123456789012345678901234567890");
        yield return new TestCaseData(null, System.Int128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return new TestCaseData(IntegerFormat.Decimal, System.Int128.Parse("-123456789012345678901234567890"), "-123456789012345678901234567890");
        yield return new TestCaseData(IntegerFormat.Decimal, System.Int128.Parse("123456789012345678901234567890"), "123456789012345678901234567890");
        yield return new TestCaseData(IntegerFormat.Hexadecimal, System.Int128.Parse("-123456789012345678901234567890"), "0xFFFFFFFE7116F0093C8C1F11B1C0F52E");
        yield return new TestCaseData(IntegerFormat.Hexadecimal, System.Int128.Parse("123456789012345678901234567890"), "0x000000018EE90FF6C373E0EE4E3F0AD2");
        yield return new TestCaseData(IntegerFormat.Binary, System.Int128.Parse("-123456789012345678901234567890"), "0b11111111111111111111111111111110011100010001011011110000000010010011110010001100000111110001000110110001110000001111010100101110");
        yield return new TestCaseData(IntegerFormat.Binary, System.Int128.Parse("123456789012345678901234567890"), "0b00000000000000000000000000000001100011101110100100001111111101101100001101110011111000001110111001001110001111110000101011010010");
    }
}