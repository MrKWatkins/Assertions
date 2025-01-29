using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

public sealed class FormatInterpolatedStringHandlerTests
{
    [Test]
    public async Task Format_Value()
    {
        var intValue = 5;
        var stringValue = "string";
        var actual = DoFormat($"This is a {stringValue} and this a {intValue}.");

        await Assert.That(actual).IsEqualTo("This is a \"string\" and this a 5.");
    }

    [Test]
    public async Task Format_Value_Format()
    {
        var stringValue = "string";

        var actual = DoFormat($"This is not a literal {stringValue} but this is a literal {stringValue:L}.");

        await Assert.That(actual).IsEqualTo("This is not a literal \"string\" but this is a literal string.");
    }

    [Test]
    public async Task Format_Value_Format_UnknownFormatThrows()
    {
        var stringValue = "string";

        await Assert.That(() => DoFormat($"Invalid {stringValue:X}.")).Throws<ArgumentException>()
            .WithMessageMatching("Unknown format \"X\".*");
    }

    [Pure]
    private static string DoFormat(FormatInterpolatedStringHandler format) => format.ToString();
}