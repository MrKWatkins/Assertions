namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class ActionAssertionsTests
{
    [Test]
    public async Task Throw()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().Throw<InvalidOperationException>()).ThrowsNothing();

        await Assert.That(() => doesNotThrow.Should().Throw<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throwsWrongException.Should().Throw<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task Throw_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw<InvalidOperationException>();

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task Throw_String()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().Throw<InvalidOperationException>("Test")).ThrowsNothing();

        await Assert.That(() => throws.Should().Throw<InvalidOperationException>("Wrong Message"))
            .Throws<AssertionException>().WithMessage("Value should have Message \"Wrong Message\" but was \"Test\".");

        await Assert.That(() => doesNotThrow.Should().Throw<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throwsWrongException.Should().Throw<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task Throw_String_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw<InvalidOperationException>("Test");

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task Throw_String_Exception()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var exceptionWithInner = new NotSupportedException("HasInner", exception);
        Action throwsExceptionWithInner = () => throw exceptionWithInner;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().Throw<InvalidOperationException>("Test", null)).ThrowsNothing();

        await Assert.That(() => throws.Should().Throw<InvalidOperationException>("Test", exception))
            .Throws<AssertionException>().WithMessage("Value should have InnerException InvalidOperationException with message \"Test\" but was null.");

        await Assert.That(() => throwsExceptionWithInner.Should().Throw<NotSupportedException>("HasInner", exception)).ThrowsNothing();

        await Assert.That(() => throwsExceptionWithInner.Should().Throw<NotSupportedException>("HasInner", null))
            .Throws<AssertionException>().WithMessage("Value should not have an InnerException but has InvalidOperationException with message \"Test\".");

        await Assert.That(() => throws.Should().Throw<InvalidOperationException>("Wrong Message"))
            .Throws<AssertionException>().WithMessage("Value should have Message \"Wrong Message\" but was \"Test\".");

        await Assert.That(() => doesNotThrow.Should().Throw<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throwsWrongException.Should().Throw<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task Throw_String_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw<InvalidOperationException>("Test", null);

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task Throw_Exception()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var otherException = new InvalidOperationException("Other");

        await Assert.That(() => throws.Should().Throw(exception)).ThrowsNothing();

        await Assert.That(() => doesNotThrow.Should().Throw<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throws.Should().Throw(otherException))
            .Throws<AssertionException>().WithMessage("Value should be the same instance as InvalidOperationException with message \"Other\" but was InvalidOperationException with message \"Test\".");
    }

    [Test]
    public async Task Throw_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        var chain = throws.Should().Throw(exception);

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task Throw_ArgumentException()
    {
        var doesNotThrow = () => { };

        var exception = new ArgumentException("TestMessage", "TestParam");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().ThrowArgumentException("TestMessage", "TestParam")).ThrowsNothing();

        await Assert.That(() => throws.Should().ThrowArgumentException("OtherMessage", "TestParam"))
            .Throws<AssertionException>().WithMessage("Value should have Message starting with \"OtherMessage\" but was \"TestMessage (Parameter 'TestParam')\".");

        await Assert.That(() => throws.Should().ThrowArgumentException("TestMessage", "OtherParam"))
            .Throws<AssertionException>().WithMessage("Value should have ParamName \"OtherParam\" but was \"TestParam\".");

        await Assert.That(() => doesNotThrow.Should().ThrowArgumentException("TestMessage", "TestParam"))
            .Throws<AssertionException>().WithMessage("Function should throw an ArgumentException.");

        await Assert.That(() => throwsWrongException.Should().ThrowArgumentException("TestMessage", "TestParam"))
            .Throws<AssertionException>().WithMessage("Function should throw an ArgumentException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task Throw_ArgumentException_Chain()
    {
        var exception = new ArgumentException("TestMessage", "TestParam");
        Action throws = () => throw exception;

        var chain = throws.Should().ThrowArgumentException("TestMessage", "TestParam");

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task Throw_ArgumentOutOfRangeException()
    {
        var doesNotThrow = () => { };

        var exception = new ArgumentOutOfRangeException("TestParam", 123, "TestMessage");
        Action throws = () => throw exception;

        Action throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123)).ThrowsNothing();

        await Assert.That(() => throws.Should().ThrowArgumentOutOfRangeException("OtherMessage", "TestParam", 123))
            .Throws<AssertionException>().WithMessage($"Value should have Message starting with \"OtherMessage\" but was \"TestMessage (Parameter 'TestParam'){Environment.NewLine}Actual value was 123.\".");

        await Assert.That(() => throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "OtherParam", 123))
            .Throws<AssertionException>().WithMessage("Value should have ParamName \"OtherParam\" but was \"TestParam\".");

        await Assert.That(() => throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 456))
            .Throws<AssertionException>().WithMessage("Value should have ActualValue 456 but was 123.");

        await Assert.That(() => doesNotThrow.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123))
            .Throws<AssertionException>().WithMessage("Function should throw an ArgumentOutOfRangeException.");

        await Assert.That(() => throwsWrongException.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123))
            .Throws<AssertionException>().WithMessage("Function should throw an ArgumentOutOfRangeException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task Throw_ArgumentOutOfRangeException_Chain()
    {
        var exception = new ArgumentOutOfRangeException("TestParam", 123, "TestMessage");
        Action throws = () => throw exception;

        var chain = throws.Should().ThrowArgumentOutOfRangeException("TestMessage", "TestParam", 123);

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task NotThrow()
    {
        var doesNotThrow = () => { };

        var exception = new InvalidOperationException("Test");
        Action throws = () => throw exception;

        await Assert.That(() => doesNotThrow.Should().NotThrow()).ThrowsNothing();
        var actualException = await Assert.That(() => throws.Should().NotThrow())
            .Throws<AssertionException>()
            .WithMessage("Function should not throw but threw an InvalidOperationException with message \"Test\".")
            .WithInnerException();
        await Assert.That(actualException!.InnerException).IsSameReferenceAs(exception);
    }
}