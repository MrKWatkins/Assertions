namespace MrKWatkins.Assertions.Tests;

public sealed class AsyncActionAssertionsTests
{
    [Test]
    public async Task ThrowAsync()
    {
        Func<Task> doesNotThrow = () => Task.CompletedTask;

        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        Func<Task> throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>()).ThrowsNothing();

        await Assert.That(() => doesNotThrow.Should().ThrowAsync<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throwsWrongException.Should().ThrowAsync<InvalidOperationException>())
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task ThrowAsync_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>().ConfigureAwait(false);

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task ThrowAsync_String()
    {
        Func<Task> doesNotThrow = () => Task.CompletedTask;

        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        Func<Task> throwsWrongException = () => throw new NotSupportedException("Wrong");

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>("Test")).ThrowsNothing();

        await Assert.That(() => throws.Should().ThrowAsync<InvalidOperationException>("Wrong Message"))
            .Throws<AssertionException>().WithMessage("Value should have Message \"Wrong Message\" but was \"Test\".");

        await Assert.That(() => doesNotThrow.Should().ThrowAsync<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException.");

        await Assert.That(() => throwsWrongException.Should().ThrowAsync<InvalidOperationException>("Test"))
            .Throws<AssertionException>().WithMessage("Function should throw an InvalidOperationException but threw a NotSupportedException with message \"Wrong\".");
    }

    [Test]
    public async Task ThrowAsync_String_Chain()
    {
        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        var chain = await throws.Should().ThrowAsync<InvalidOperationException>("Test").ConfigureAwait(false);

        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
        await Assert.That(chain.That).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task NotThrowAsync()
    {
        Func<Task> doesNotThrow = () => Task.CompletedTask;

        var exception = new InvalidOperationException("Test");
        Func<Task> throws = () => throw exception;

        await Assert.That(() => doesNotThrow.Should().NotThrowAsync()).ThrowsNothing();

        var actualException = await Assert.That(() => throws.Should().NotThrowAsync())
            .Throws<AssertionException>()
            .WithMessage("Function should not throw but threw an InvalidOperationException with message \"Test\".");
        await Assert.That(actualException!.InnerException).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task ThrowAsync_ActuallyAsync()
    {
        var exception = new InvalidOperationException("AsyncTest");
        Func<Task> throwsAsync = async () =>
        {
            await Task.Yield();
            throw exception;
        };

        var chain = await throwsAsync.Should().ThrowAsync<InvalidOperationException>("AsyncTest").ConfigureAwait(false);
        await Assert.That(chain.Exception).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task NotThrowAsync_ActuallyAsync()
    {
        Func<Task> doesNotThrow = async () => await Task.Yield();

        await Assert.That(() => doesNotThrow.Should().NotThrowAsync()).ThrowsNothing();
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

    private sealed class TestClass
    {
        public Task ThrowAsync() => throw new InvalidOperationException();

        public async Task NotThrowAsync() => await Task.Yield();

        public Task<string> ThrowWithReturnAsync() => throw new InvalidOperationException();
    }
}
