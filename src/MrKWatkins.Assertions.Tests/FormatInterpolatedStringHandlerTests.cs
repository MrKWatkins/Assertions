namespace MrKWatkins.Assertions.Tests;

public sealed class FormatInterpolatedStringHandlerTests
{
    [Test]
    public void Format_Value()
    {
        var intValue = 5;
        var stringValue = "string";
        var actual = DoFormat($"This is a {stringValue} and this a {intValue}.");

        Assert.That(actual, Is.EqualTo("This is a \"string\" and this a 5."));
    }

    [Test]
    public void Format_Value_Format()
    {
        var stringValue = "string";

        var actual = DoFormat($"This is not a literal {stringValue} but this is a literal {stringValue:L}.");

        Assert.That(actual, Is.EqualTo("This is not a literal \"string\" but this is a literal string."));
    }

    [Test]
    public void Format_Value_Format_UnknownFormatThrows()
    {
        var stringValue = "string";

        Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.Matches("Unknown format \"X\".*"), () => _ = DoFormat($"Invalid {stringValue:X}."));
    }

    [Test]
    public void Format_Enumerable()
    {
        IEnumerable<int> items = new List<int> { 1, 2, 3 };
        var actual = DoFormat($"Items: {items}");

        Assert.That(actual, Is.EqualTo("Items: [1, 2, 3]"));
    }

    [Test]
    public void Format_Value_Format_NullString()
    {
        string? nullValue = null;
        var actual = DoFormat($"before{nullValue:L}after");

        Assert.That(actual, Is.EqualTo("beforeafter"));
    }

    [Pure]
    private static string DoFormat(FormatInterpolatedStringHandler format) => format.ToString();
}