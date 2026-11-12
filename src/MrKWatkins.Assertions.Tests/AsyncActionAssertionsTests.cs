namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class AsyncActionAssertionsTests
{
    [Test]
    public async Task ThrowAsync()
    {
        var doesNotThrow = () => Task.CompletedTask;
        var doesNotThrowAsync = async () => await Task.Yield();

        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        Func<Task> throwsWrongException = () => throw new NotSupportedException("Wrong");
        var throwsWrongExceptionAsync = async () => { await Task.Yield(); throw new NotSupportedException("Wrong"); };

        await Assert.DoesNotThrowAsync(() => throws.Should().ThrowAsync<InvalidOperationException>());
        await Assert.DoesNotThrowAsync(() => throwsAsync.Should().ThrowAsync<InvalidOperationException>());

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrow.Should().ThrowAsync<InvalidOperationException>()
        );
        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrowAsync.Should().ThrowAsync<InvalidOperationException>()
        );

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().ThrowAsync<InvalidOperationException>()
        );
        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongExceptionAsync.Should().ThrowAsync<InvalidOperationException>()
        );
    }

    [Test]
    public async Task ThrowAsync_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>().ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));

        chain = await throwsAsync.Should().ThrowAsync<InvalidOperationException>().ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public async Task ThrowAsync_String()
    {
        var doesNotThrow = () => Task.CompletedTask;
        var doesNotThrowAsync = async () => await Task.Yield();

        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        Func<Task> throwsWrongException = () => throw new NotSupportedException("Wrong");
        var throwsWrongExceptionAsync = async () => { await Task.Yield(); throw new NotSupportedException("Wrong"); };

        await Assert.DoesNotThrowAsync(() => throws.Should().ThrowAsync<InvalidOperationException>("Test"));
        await Assert.DoesNotThrowAsync(() => throwsAsync.Should().ThrowAsync<InvalidOperationException>("Test"));

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have Message \"Wrong Message\" but was \"Test\"."),
            () => throws.Should().ThrowAsync<InvalidOperationException>("Wrong Message")
        );
        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have Message \"Wrong Message\" but was \"Test\"."),
            () => throwsAsync.Should().ThrowAsync<InvalidOperationException>("Wrong Message")
        );

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrow.Should().ThrowAsync<InvalidOperationException>("Test")
        );
        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should throw an InvalidOperationException."),
            () => doesNotThrowAsync.Should().ThrowAsync<InvalidOperationException>("Test")
        );

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().ThrowAsync<InvalidOperationException>("Test")
        );
        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongExceptionAsync.Should().ThrowAsync<InvalidOperationException>("Test")
        );
    }

    [Test]
    public async Task ThrowAsync_String_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>("Test").ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));

        chain = await throwsAsync.Should().ThrowAsync<InvalidOperationException>("Test").ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public async Task NotThrowAsync()
    {
        var doesNotThrow = () => Task.CompletedTask;
        var doesNotThrowAsync = async () => await Task.Yield();

        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        await Assert.DoesNotThrowAsync(() => doesNotThrow.Should().NotThrowAsync());
        await Assert.DoesNotThrowAsync(() => doesNotThrowAsync.Should().NotThrowAsync());

        var actualException = await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should not throw but threw an InvalidOperationException with message \"Test\"."),
            () => throws.Should().NotThrowAsync()
        );
        Assert.That(actualException!.InnerException, Is.SameAs(exception));

        actualException = await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Function should not throw but threw an InvalidOperationException with message \"Test\"."),
            () => throwsAsync.Should().NotThrowAsync()
        );
        Assert.That(actualException!.InnerException, Is.SameAs(exception));
    }

    [Test]
    public async Task Awaiting_InvokingExtensions()
    {
        var value = new TestClass();

        await Assert.DoesNotThrowAsync(() => value.Awaiting(v => v.ThrowAsync()).Should().ThrowAsync<InvalidOperationException>());

        await Assert.DoesNotThrowAsync(() => value.Awaiting(v => v.NotThrowAsync()).Should().NotThrowAsync());
    }

    [Test]
    public async Task Awaiting_InvokingExtensions_WithReturn()
    {
        var value = new TestClass();

        await Assert.DoesNotThrowAsync(() => value.Awaiting(v => v.ThrowWithReturnAsync()).Should().ThrowAsync<InvalidOperationException>());
    }

    [Test]
    public async Task ThrowAsync_String_Exception()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var innerException = new InvalidOperationException("Inner");
        var exceptionWithInner = new NotSupportedException("HasInner", innerException);
        Func<Task> throwsWithInner = () => throw exceptionWithInner;

        await Assert.DoesNotThrowAsync(() => throws.Should().ThrowAsync<InvalidOperationException>("Test", null));
        await Assert.DoesNotThrowAsync(() => throwsWithInner.Should().ThrowAsync<NotSupportedException>("HasInner", innerException));

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have InnerException InvalidOperationException with message \"Inner\" but was null."),
            () => throws.Should().ThrowAsync<InvalidOperationException>("Test", innerException)
        );

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should not have an InnerException but has InvalidOperationException with message \"Inner\"."
            ),
            () => throwsWithInner.Should().ThrowAsync<NotSupportedException>("HasInner", null)
        );
    }

    [Test]
    public async Task ThrowAsync_String_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>("Test", null).ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public async Task ThrowAsync_Exception()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var otherException = new InvalidOperationException("Other");

        await Assert.DoesNotThrowAsync(() => throws.Should().ThrowAsync(exception));

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should be the same instance as InvalidOperationException with message \"Other\" but was InvalidOperationException with message \"Test\"."
            ),
            () => throws.Should().ThrowAsync(otherException)
        );
    }

    [Test]
    public async Task ThrowAsync_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowAsync(exception).ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public async Task ThrowArgumentExceptionAsync()
    {
        var exception = new ArgumentException("TestMessage", "TestParam");
        Func<Task> throws = () => throw exception;

        Func<Task> throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.DoesNotThrowAsync(() => throws.Should().ThrowArgumentExceptionAsync("TestMessage", "TestParam"));

        await Assert.ThrowsAsync(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Function should throw an ArgumentException but threw a NotSupportedException with message \"Wrong\"."
            ),
            () => throwsWrongException.Should().ThrowArgumentExceptionAsync("TestMessage", "TestParam")
        );
    }

    [Test]
    public async Task ThrowArgumentExceptionAsync_Chain()
    {
        var exception = new ArgumentException("TestMessage", "TestParam");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowArgumentExceptionAsync("TestMessage", "TestParam").ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    [Test]
    public async Task ThrowArgumentOutOfRangeExceptionAsync()
    {
        var exception = new ArgumentOutOfRangeException("TestParam", 42, "TestMessage");
        Func<Task> throws = () => throw exception;

        await Assert.DoesNotThrowAsync(() => throws.Should().ThrowArgumentOutOfRangeExceptionAsync("TestMessage", "TestParam", 42));
    }

    [Test]
    public async Task ThrowArgumentOutOfRangeExceptionAsync_Chain()
    {
        var exception = new ArgumentOutOfRangeException("TestParam", 42, "TestMessage");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowArgumentOutOfRangeExceptionAsync("TestMessage", "TestParam", 42).ConfigureAwait(false);
        Assert.That(chain.Exception, Is.SameAs(exception));
        Assert.That(chain.That, Is.SameAs(exception));
    }

    private sealed class TestClass
    {
        public Task ThrowAsync() => throw new InvalidOperationException();

        public async Task NotThrowAsync() => await Task.Yield();

        public Task<string> ThrowWithReturnAsync() => throw new InvalidOperationException();
    }
}