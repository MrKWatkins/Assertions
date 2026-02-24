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

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>()).ThrowsNothing();
        await Assert.That(() => throwsAsync.Should().ThrowAsync<InvalidOperationException>()).ThrowsNothing();

        await Assert.That(() => doesNotThrow.Should().ThrowAsync<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");
        await Assert.That(() => doesNotThrowAsync.Should().ThrowAsync<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throwsWrongException.Should().ThrowAsync<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
        await Assert.That(() => throwsWrongExceptionAsync.Should().ThrowAsync<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task ThrowAsync_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>().ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);

        chain = await throwsAsync.Should().ThrowAsync<InvalidOperationException>().ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
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

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>("Test")).ThrowsNothing();
        await Assert.That(() => throwsAsync.Should().ThrowAsync<InvalidOperationException>("Test")).ThrowsNothing();

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>("Wrong Message"))
            .Throws<AssertionException>().WithMessage("Value should have Message \"Wrong Message\" but was \"Test\".");
        await Assert.That(() => throwsAsync.Should().ThrowAsync<InvalidOperationException>("Wrong Message"))
            .Throws<AssertionException>().WithMessage("Value should have Message \"Wrong Message\" but was \"Test\".");

        await Assert.That(() => doesNotThrow.Should().ThrowAsync<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");
        await Assert.That(() => doesNotThrowAsync.Should().ThrowAsync<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throwsWrongException.Should().ThrowAsync<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
        await Assert.That(() => throwsWrongExceptionAsync.Should().ThrowAsync<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task ThrowAsync_String_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>("Test").ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);

        chain = await throwsAsync.Should().ThrowAsync<InvalidOperationException>("Test").ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task NotThrowAsync()
    {
        var doesNotThrow = () => Task.CompletedTask;
        var doesNotThrowAsync = async () => await Task.Yield();

        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;
        var throwsAsync = async () => { await Task.Yield(); throw exception; };

        await Assert.That(() => doesNotThrow.Should().NotThrowAsync()).ThrowsNothing();
        await Assert.That(() => doesNotThrowAsync.Should().NotThrowAsync()).ThrowsNothing();

        var actualException = await Assert.That(() => throws.Should().NotThrowAsync())
            .Throws<AssertionException>()
            .WithMessage("Function should not throw but threw an InvalidOperationException with message \"Test\".");
        await Assert.That(actualException!.InnerException).IsSameReferenceAs(exception);

        actualException = await Assert.That(() => throwsAsync.Should().NotThrowAsync())
            .Throws<AssertionException>()
            .WithMessage("Function should not throw but threw an InvalidOperationException with message \"Test\".");
        await Assert.That(actualException!.InnerException).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task Awaiting_InvokingExtensions()
    {
        var value = new TestClass();

        await Assert.That(() => value.Awaiting(v => v.ThrowAsync()).Should().ThrowAsync<InvalidOperationException>())
            .ThrowsNothing();

        await Assert.That(() => value.Awaiting(v => v.NotThrowAsync()).Should().NotThrowAsync())
            .ThrowsNothing();
    }

    [Test]
    public async Task Awaiting_InvokingExtensions_WithReturn()
    {
        var value = new TestClass();

        await Assert.That(() => value.Awaiting(v => v.ThrowWithReturnAsync()).Should().ThrowAsync<InvalidOperationException>())
            .ThrowsNothing();
    }

    [Test]
    public async Task ThrowAsync_String_Exception()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var innerException = new InvalidOperationException("Inner");
        var exceptionWithInner = new NotSupportedException("HasInner", innerException);
        Func<Task> throwsWithInner = () => throw exceptionWithInner;

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>("Test", null)).ThrowsNothing();
        await Assert.That(() => throwsWithInner.Should().ThrowAsync<NotSupportedException>("HasInner", innerException)).ThrowsNothing();

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>("Test", innerException))
            .Throws<AssertionException>().WithMessage("Value should have InnerException InvalidOperationException with message \"Inner\" but was null.");

        await Assert.That(() => throwsWithInner.Should().ThrowAsync<NotSupportedException>("HasInner", null))
            .Throws<AssertionException>().WithMessage("Value should not have an InnerException but has InvalidOperationException with message \"Inner\".");
    }

    [Test]
    public async Task ThrowAsync_String_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>("Test", null).ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task ThrowAsync_Exception()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var otherException = new InvalidOperationException("Other");

        await Assert.That(() => throws.Should().ThrowAsync(exception)).ThrowsNothing();

        await Assert.That(() => throws.Should().ThrowAsync(otherException))
            .Throws<AssertionException>().WithMessage("Value should be the same instance as InvalidOperationException with message \"Other\" but was InvalidOperationException with message \"Test\".");
    }

    [Test]
    public async Task ThrowAsync_Exception_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowAsync(exception).ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task ThrowArgumentExceptionAsync()
    {
        var exception = new ArgumentException("TestMessage", "TestParam");
        Func<Task> throws = () => throw exception;

        Func<Task> throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().ThrowArgumentExceptionAsync("TestMessage", "TestParam")).ThrowsNothing();

        await Assert.That(() => throwsWrongException.Should().ThrowArgumentExceptionAsync("TestMessage", "TestParam"))
            .Throws<AssertionException>().WithMessage("Function should throw an ArgumentException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task ThrowArgumentExceptionAsync_Chain()
    {
        var exception = new ArgumentException("TestMessage", "TestParam");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowArgumentExceptionAsync("TestMessage", "TestParam").ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task ThrowArgumentOutOfRangeExceptionAsync()
    {
        var exception = new ArgumentOutOfRangeException("TestParam", 42, "TestMessage");
        Func<Task> throws = () => throw exception;

        await Assert.That(() => throws.Should().ThrowArgumentOutOfRangeExceptionAsync("TestMessage", "TestParam", 42)).ThrowsNothing();
    }

    [Test]
    public async Task ThrowArgumentOutOfRangeExceptionAsync_Chain()
    {
        var exception = new ArgumentOutOfRangeException("TestParam", 42, "TestMessage");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowArgumentOutOfRangeExceptionAsync("TestMessage", "TestParam", 42).ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    private sealed class TestClass
    {
        public Task ThrowAsync() => throw new InvalidOperationException();

        public async Task NotThrowAsync() => await Task.Yield();

        public Task<string> ThrowWithReturnAsync() => throw new InvalidOperationException();
    }
}