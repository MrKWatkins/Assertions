namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class ActionAssertionsTests
{
    [Test]
    public void Throw()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        Assert.DoesNotThrow(() => throws.Should().Throw<InvalidOperationException>());

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrow.Should().Throw<InvalidOperationException>()
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().Throw<InvalidOperationException>()
        );
    }

    [Test]
    public void Throw_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw<InvalidOperationException>();

        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public void Throw_String()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        Assert.DoesNotThrow(() => throws.Should().Throw<InvalidOperationException>("Test"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have Message \"Wrong Message\" but was \"Test\"."),
            () => throws.Should().Throw<InvalidOperationException>("Wrong Message")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrow.Should().Throw<InvalidOperationException>("Test")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().Throw<InvalidOperationException>("Test")
        );
    }

    [Test]
    public void Throw_String_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw<InvalidOperationException>("Test");

        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public void Throw_String_Exception()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var exceptionWithInner = new NotSupportedException("HasInner", exception);
        Action throwsExceptionWithInner = () => throw exceptionWithInner;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        Assert.DoesNotThrow(() => throws.Should().Throw<InvalidOperationException>("Test", null));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have InnerException InvalidOperationException with message \"Test\" but was null."),
            () => throws.Should().Throw<InvalidOperationException>("Test", exception)
        );

        Assert.DoesNotThrow(() => throwsExceptionWithInner.Should().Throw<NotSupportedException>("HasInner", exception));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have an InnerException but has InvalidOperationException with message \"Test\"."),
            () => throwsExceptionWithInner.Should().Throw<NotSupportedException>("HasInner", null)
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have Message \"Wrong Message\" but was \"Test\"."),
            () => throws.Should().Throw<InvalidOperationException>("Wrong Message")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrow.Should().Throw<InvalidOperationException>("Test")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().Throw<InvalidOperationException>("Test")
        );
    }

    [Test]
    public void Throw_String_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw<InvalidOperationException>("Test", null);

        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public void Throw_Exception()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var otherException = new InvalidOperationException("Other");

        Assert.DoesNotThrow(() => throws.Should().Throw(exception));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrow.Should().Throw<InvalidOperationException>("Test")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should be the same instance as InvalidOperationException with message \"Other\" but was InvalidOperationException with message \"Test\"."
            ),
            () => throws.Should().Throw(otherException)
        );
    }

    [Test]
    public void Throw_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw(exception);

        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public void Throw_ArgumentException()
    {
        var doesNotThrow = () => { };

        var exception = new ArgumentException("TestMessage", "TestParam");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        Assert.DoesNotThrow(() => throws.Should().ThrowArgumentException("TestMessage", "TestParam"));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should have Message starting with \"OtherMessage\" but was \"TestMessage (Parameter 'TestParam')\"."
            ),
            () => throws.Should().ThrowArgumentException("OtherMessage", "TestParam")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have ParamName \"OtherParam\" but was \"TestParam\"."),
            () => throws.Should().ThrowArgumentException("TestMessage", "OtherParam")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an ArgumentException."),
            () => doesNotThrow.Should().ThrowArgumentException("TestMessage", "TestParam")
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an ArgumentException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().ThrowArgumentException("TestMessage", "TestParam")
        );
    }

    [Test]
    public void Throw_ArgumentException_Chain()
    {
        var exception = new ArgumentException("TestMessage", "TestParam");
        Action throws = () => throw exception;

        var chain = throws.Should().ThrowArgumentException("TestMessage", "TestParam");

        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public void Throw_ArgumentOutOfRangeException()
    {
        var doesNotThrow = () => { };

        var exception = new ArgumentOutOfRangeException("TestParam", 123, "TestMessage");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        Assert.DoesNotThrow(() => throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                $"Value should have Message starting with \"OtherMessage\" but was \"TestMessage (Parameter 'TestParam'){Environment.NewLine}Actual value was 123.\"."
            ),
            () => throws.Should().ThrowArgumentOutOfRangeException("OtherMessage", "TestParam", 123)
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have ParamName \"OtherParam\" but was \"TestParam\"."),
            () => throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "OtherParam", 123)
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have ActualValue 456 but was 123."),
            () => throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 456)
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an ArgumentOutOfRangeException."),
            () => doesNotThrow.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123)
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an ArgumentOutOfRangeException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123)
        );
    }

    [Test]
    public void Throw_ArgumentOutOfRangeException_Chain()
    {
        var exception = new ArgumentOutOfRangeException("TestParam", 123, "TestMessage");
        Action throws = () => throw exception;

        var chain = throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123);

        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public void NotThrow()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        Assert.DoesNotThrow(() => doesNotThrow.Should().NotThrow());
        var actualException = Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should not throw but threw an InvalidOperationException with message \"Test\"."),
            () => throws.Should().NotThrow()
        );
        Assert.That(actualException!.InnerException, Is.SameAs(exception));
    }
}