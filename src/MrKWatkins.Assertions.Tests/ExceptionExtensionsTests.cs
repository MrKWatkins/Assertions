namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class ExceptionExtensionsTests
{
    [Test]
    public void HaveParamName()
    {
        ArgumentException? nullException = null;
        var exception = new ArgumentException("Message", "Test");

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().HaveParamName("Test"));

        Assert.DoesNotThrow(() => exception.Should().HaveParamName("Test"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have ParamName \"Other\" but was \"Test\"."),
            () => exception.Should().HaveParamName("Other")
        );
    }

    [Test]
    public void HaveParamName_Chain()
    {
        var exception = new ArgumentException("Message", "Test");

        var chain = exception.Should().HaveParamName("Test");
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }

    [Test]
    public void NotHaveParamName()
    {
        ArgumentException? nullException = null;
        var exception = new ArgumentException("Message", "Test");

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().NotHaveParamName("Test"));

        Assert.DoesNotThrow(() => exception.Should().NotHaveParamName("Other"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have ParamName \"Test\"."),
            () => exception.Should().NotHaveParamName("Test")
        );
    }

    [Test]
    public void NotHaveParamName_Chain()
    {
        var exception = new ArgumentException("Message", "Test");

        var chain = exception.Should().NotHaveParamName("Other");
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }

    [Test]
    public void HaveActualValue()
    {
        ArgumentOutOfRangeException? nullException = null;
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().HaveActualValue(5));

        Assert.DoesNotThrow(() => exception.Should().HaveActualValue(5));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have ActualValue 4 but was 5."),
            () => exception.Should().HaveActualValue(4)
        );
    }

    [Test]
    public void HaveActualValue_Chain()
    {
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        var chain = exception.Should().HaveActualValue(5);
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }

    [Test]
    public void NotHaveActualValue()
    {
        ArgumentOutOfRangeException? nullException = null;
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().NotHaveActualValue("Test"));

        Assert.DoesNotThrow(() => exception.Should().NotHaveActualValue(4));

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have ActualValue 5."), () => exception.Should().NotHaveActualValue(5));
    }

    [Test]
    public void NotHaveActualValue_Chain()
    {
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        var chain = exception.Should().NotHaveActualValue(4);
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }
}