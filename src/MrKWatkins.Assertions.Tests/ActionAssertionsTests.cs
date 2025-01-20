namespace MrKWatkins.Assertions.Tests;

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