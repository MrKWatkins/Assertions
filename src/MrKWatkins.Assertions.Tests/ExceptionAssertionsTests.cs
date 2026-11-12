namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class ExceptionAssertionsTests
{
    [Test]
    public void HaveMessage()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().HaveMessage("Test"));

        Assert.DoesNotThrow(() => exception.Should().HaveMessage("Test"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have Message \"Other\" but was \"Test\"."),
            () => exception.Should().HaveMessage("Other")
        );
    }

    [Test]
    public void HaveMessage_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().HaveMessage("Test");
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }

    [Test]
    public void NotHaveMessage()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().NotHaveMessage("Test"));

        Assert.DoesNotThrow(() => exception.Should().NotHaveMessage("Other"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have Message \"Test\"."),
            () => exception.Should().NotHaveMessage("Test")
        );
    }

    [Test]
    public void NotHaveMessage_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().NotHaveMessage("Other");
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }

    [Test]
    public void HaveMessageStartingWith()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."),
            () => nullException.Should().HaveMessageStartingWith("Tes")
        );

        Assert.DoesNotThrow(() => exception.Should().HaveMessageStartingWith("Tes"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have Message starting with \"Other\" but was \"Test\"."),
            () => exception.Should().HaveMessageStartingWith("Other")
        );
    }

    [Test]
    public void HaveMessageStartingWith_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().HaveMessageStartingWith("Test");
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }

    [Test]
    public void NotHaveMessageStartingWith()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."),
            () => nullException.Should().NotHaveMessageStartingWith("Test")
        );

        Assert.DoesNotThrow(() => exception.Should().NotHaveMessageStartingWith("Other"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have Message starting with \"Tes\" but was \"Test\"."),
            () => exception.Should().NotHaveMessageStartingWith("Tes")
        );
    }

    [Test]
    public void NotHaveMessageStartingWith_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().NotHaveMessageStartingWith("Other");
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }

    [Test]
    public void HaveInnerException()
    {
        ArgumentException? nullException = null;

        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var other = new InvalidOperationException("Other");

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."),
            () => nullException.Should().HaveInnerException<InvalidOperationException>()
        );

        Assert.DoesNotThrow(() => exception.Should().HaveInnerException<InvalidOperationException>());

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have an InnerException but was null."),
            () => other.Should().HaveInnerException<InvalidOperationException>()
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should have an InnerException of type NotSupportedException but was of type InvalidOperationException."
            ),
            () => exception.Should().HaveInnerException<NotSupportedException>()
        );
    }

    [Test]
    public void HaveInnerException_Chain()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var chain = exception.Should().HaveInnerException<InvalidOperationException>();
        Assert.That(chain.That, Is.EqualTo(inner));
    }

    [Test]
    public void HaveInnerException_Exception()
    {
        ArgumentException? nullException = null;

        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var other = new InvalidOperationException("Other");

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().HaveInnerException(inner));

        Assert.DoesNotThrow(() => exception.Should().HaveInnerException(inner));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should have InnerException InvalidOperationException with message \"Other\" but was InvalidOperationException with message \"Inner\"."
            ),
            () => exception.Should().HaveInnerException(other)
        );
    }

    [Test]
    public void HaveInnerException_Exception_Chain()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var chain = exception.Should().HaveInnerException(inner);
        Assert.That(chain.That, Is.EqualTo(inner));
    }

    [Test]
    public void NotHaveInnerException()
    {
        ArgumentException? nullException = null;

        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullException.Should().NotHaveInnerException());

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should not have an InnerException but has InvalidOperationException with message \"Inner\"."
            ),
            () => exception.Should().NotHaveInnerException()
        );

        Assert.DoesNotThrow(() => inner.Should().NotHaveInnerException());
    }

    [Test]
    public void NotHaveInnerException_Chain()
    {
        var exception = new NotSupportedException("Message");

        var chain = exception.Should().NotHaveInnerException();
        Assert.That(chain.Value, Is.EqualTo(exception));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(exception));
    }
}