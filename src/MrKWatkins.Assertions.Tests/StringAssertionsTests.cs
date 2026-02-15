namespace MrKWatkins.Assertions.Tests;

public sealed class StringAssertionsTests
{
    [Test]
    public async Task Contain()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().Contain("test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "test".Should().Contain("invalid")).Throws<AssertionException>().WithMessage("Value should contain the string \"invalid\".");
        await Assert.That(() => "test".Should().Contain("es")).ThrowsNothing();
    }

    [Test]
    public async Task Contain_Chain()
    {
        var chain = "test".Should().Contain("es");
        await Assert.That(chain.Value).IsEqualTo("test");
        await Assert.That(chain.And.Value).IsEqualTo("test");
    }

    [Test]
    public async Task NotContain()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().NotContain("test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "test".Should().NotContain("es")).Throws<AssertionException>().WithMessage("Value should not contain the string \"es\".");
        await Assert.That(() => "test".Should().NotContain("invalid")).ThrowsNothing();
    }

    [Test]
    public async Task NotContain_Chain()
    {
        var chain = "test".Should().NotContain("invalid");
        await Assert.That(chain.Value).IsEqualTo("test");
        await Assert.That(chain.And.Value).IsEqualTo("test");
    }
}