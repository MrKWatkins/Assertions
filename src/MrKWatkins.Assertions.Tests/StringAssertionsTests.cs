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
    public async Task Contain_WithComparison()
    {
        await Assert.That(() => "Test".Should().Contain("test")).Throws<AssertionException>().WithMessage("Value should contain the string \"test\".");
        await Assert.That(() => "Test".Should().Contain("test", StringComparison.OrdinalIgnoreCase)).ThrowsNothing();
        await Assert.That(() => "Test".Should().Contain("invalid", StringComparison.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should contain the string \"invalid\" (using OrdinalIgnoreCase).");
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

    [Test]
    public async Task NotContain_WithComparison()
    {
        await Assert.That(() => "Test".Should().NotContain("test")).ThrowsNothing();
        await Assert.That(() => "Test".Should().NotContain("test", StringComparison.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should not contain the string \"test\" (using OrdinalIgnoreCase).");
        await Assert.That(() => "Test".Should().NotContain("invalid", StringComparison.OrdinalIgnoreCase)).ThrowsNothing();
    }

    [Test]
    public async Task StartWith()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().StartWith("test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "hello world".Should().StartWith("world")).Throws<AssertionException>().WithMessage("Value should start with \"world\" but was \"hello world\".");
        await Assert.That(() => "hello world".Should().StartWith("hello")).ThrowsNothing();
    }

    [Test]
    public async Task StartWith_Chain()
    {
        var chain = "hello world".Should().StartWith("hello");
        await Assert.That(chain.Value).IsEqualTo("hello world");
        await Assert.That(chain.And.Value).IsEqualTo("hello world");
    }

    [Test]
    public async Task StartWith_WithComparison()
    {
        await Assert.That(() => "Hello".Should().StartWith("hello")).Throws<AssertionException>().WithMessage("Value should start with \"hello\" but was \"Hello\".");
        await Assert.That(() => "Hello".Should().StartWith("hello", StringComparison.OrdinalIgnoreCase)).ThrowsNothing();
        await Assert.That(() => "Hello".Should().StartWith("world", StringComparison.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should start with \"world\" (using OrdinalIgnoreCase) but was \"Hello\".");
    }

    [Test]
    public async Task NotStartWith()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().NotStartWith("test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "hello world".Should().NotStartWith("hello")).Throws<AssertionException>().WithMessage("Value should not start with \"hello\".");
        await Assert.That(() => "hello world".Should().NotStartWith("world")).ThrowsNothing();
    }

    [Test]
    public async Task NotStartWith_Chain()
    {
        var chain = "hello world".Should().NotStartWith("world");
        await Assert.That(chain.Value).IsEqualTo("hello world");
        await Assert.That(chain.And.Value).IsEqualTo("hello world");
    }

    [Test]
    public async Task NotStartWith_WithComparison()
    {
        await Assert.That(() => "Hello".Should().NotStartWith("hello")).ThrowsNothing();
        await Assert.That(() => "Hello".Should().NotStartWith("hello", StringComparison.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should not start with \"hello\" (using OrdinalIgnoreCase).");
    }

    [Test]
    public async Task EndWith()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().EndWith("test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "hello world".Should().EndWith("hello")).Throws<AssertionException>().WithMessage("Value should end with \"hello\" but was \"hello world\".");
        await Assert.That(() => "hello world".Should().EndWith("world")).ThrowsNothing();
    }

    [Test]
    public async Task EndWith_Chain()
    {
        var chain = "hello world".Should().EndWith("world");
        await Assert.That(chain.Value).IsEqualTo("hello world");
        await Assert.That(chain.And.Value).IsEqualTo("hello world");
    }

    [Test]
    public async Task EndWith_WithComparison()
    {
        await Assert.That(() => "Hello World".Should().EndWith("world")).Throws<AssertionException>().WithMessage("Value should end with \"world\" but was \"Hello World\".");
        await Assert.That(() => "Hello World".Should().EndWith("world", StringComparison.OrdinalIgnoreCase)).ThrowsNothing();
        await Assert.That(() => "Hello World".Should().EndWith("hello", StringComparison.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should end with \"hello\" (using OrdinalIgnoreCase) but was \"Hello World\".");
    }

    [Test]
    public async Task NotEndWith()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().NotEndWith("test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "hello world".Should().NotEndWith("world")).Throws<AssertionException>().WithMessage("Value should not end with \"world\".");
        await Assert.That(() => "hello world".Should().NotEndWith("hello")).ThrowsNothing();
    }

    [Test]
    public async Task NotEndWith_Chain()
    {
        var chain = "hello world".Should().NotEndWith("hello");
        await Assert.That(chain.Value).IsEqualTo("hello world");
        await Assert.That(chain.And.Value).IsEqualTo("hello world");
    }

    [Test]
    public async Task NotEndWith_WithComparison()
    {
        await Assert.That(() => "Hello World".Should().NotEndWith("world")).ThrowsNothing();
        await Assert.That(() => "Hello World".Should().NotEndWith("world", StringComparison.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should not end with \"world\" (using OrdinalIgnoreCase).");
    }

    [Test]
    public async Task BeEmpty()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().BeEmpty()).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "test".Should().BeEmpty()).Throws<AssertionException>().WithMessage("Value should be empty but was \"test\".");
        await Assert.That(() => "".Should().BeEmpty()).ThrowsNothing();
    }

    [Test]
    public async Task BeEmpty_Chain()
    {
        var chain = "".Should().BeEmpty();
        await Assert.That(chain.Value).IsEqualTo("");
        await Assert.That(chain.And.Value).IsEqualTo("");
    }

    [Test]
    public async Task NotBeEmpty()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().NotBeEmpty()).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "".Should().NotBeEmpty()).Throws<AssertionException>().WithMessage("Value should not be empty.");
        await Assert.That(() => "test".Should().NotBeEmpty()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeEmpty_Chain()
    {
        var chain = "test".Should().NotBeEmpty();
        await Assert.That(chain.Value).IsEqualTo("test");
        await Assert.That(chain.And.Value).IsEqualTo("test");
    }

    [Test]
    public async Task BeNullOrEmpty()
    {
        await Assert.That(() => "test".Should().BeNullOrEmpty()).Throws<AssertionException>().WithMessage("Value should be null or empty but was \"test\".");
        await Assert.That(() => ((string?)null).Should().BeNullOrEmpty()).ThrowsNothing();
        await Assert.That(() => "".Should().BeNullOrEmpty()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeNullOrEmpty()
    {
        await Assert.That(() => ((string?)null).Should().NotBeNullOrEmpty()).Throws<AssertionException>().WithMessage("Value should not be null or empty.");
        await Assert.That(() => "".Should().NotBeNullOrEmpty()).Throws<AssertionException>().WithMessage("Value should not be null or empty.");
        await Assert.That(() => "test".Should().NotBeNullOrEmpty()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeNullOrEmpty_Chain()
    {
        var chain = "test".Should().NotBeNullOrEmpty();
        await Assert.That(chain.Value).IsEqualTo("test");
        await Assert.That(chain.And.Value).IsEqualTo("test");
    }

    [Test]
    public async Task BeNullOrWhiteSpace()
    {
        await Assert.That(() => "test".Should().BeNullOrWhiteSpace()).Throws<AssertionException>().WithMessage("Value should be null or white space but was \"test\".");
        await Assert.That(() => ((string?)null).Should().BeNullOrWhiteSpace()).ThrowsNothing();
        await Assert.That(() => "".Should().BeNullOrWhiteSpace()).ThrowsNothing();
        await Assert.That(() => "   ".Should().BeNullOrWhiteSpace()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeNullOrWhiteSpace()
    {
        await Assert.That(() => ((string?)null).Should().NotBeNullOrWhiteSpace()).Throws<AssertionException>().WithMessage("Value should not be null or white space.");
        await Assert.That(() => "".Should().NotBeNullOrWhiteSpace()).Throws<AssertionException>().WithMessage("Value should not be null or white space.");
        await Assert.That(() => "   ".Should().NotBeNullOrWhiteSpace()).Throws<AssertionException>().WithMessage("Value should not be null or white space.");
        await Assert.That(() => "test".Should().NotBeNullOrWhiteSpace()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeNullOrWhiteSpace_Chain()
    {
        var chain = "test".Should().NotBeNullOrWhiteSpace();
        await Assert.That(chain.Value).IsEqualTo("test");
        await Assert.That(chain.And.Value).IsEqualTo("test");
    }

    [Test]
    public async Task HaveLength()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().HaveLength(4)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "test".Should().HaveLength(5)).Throws<AssertionException>().WithMessage("Value should have length 5 but was 4.");
        await Assert.That(() => "test".Should().HaveLength(4)).ThrowsNothing();
    }

    [Test]
    public async Task HaveLength_Chain()
    {
        var chain = "test".Should().HaveLength(4);
        await Assert.That(chain.Value).IsEqualTo("test");
        await Assert.That(chain.And.Value).IsEqualTo("test");
    }

    [Test]
    public async Task NotHaveLength()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().NotHaveLength(4)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "test".Should().NotHaveLength(4)).Throws<AssertionException>().WithMessage("Value should not have length 4.");
        await Assert.That(() => "test".Should().NotHaveLength(5)).ThrowsNothing();
    }

    [Test]
    public async Task NotHaveLength_Chain()
    {
        var chain = "test".Should().NotHaveLength(5);
        await Assert.That(chain.Value).IsEqualTo("test");
        await Assert.That(chain.And.Value).IsEqualTo("test");
    }

    [Test]
    public async Task Match()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().Match("\\d+")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "abc".Should().Match("\\d+")).Throws<AssertionException>().WithMessage("Value should match the pattern \"\\d+\" but was \"abc\".");
        await Assert.That(() => "123".Should().Match("\\d+")).ThrowsNothing();
    }

    [Test]
    public async Task Match_Chain()
    {
        var chain = "123".Should().Match("\\d+");
        await Assert.That(chain.Value).IsEqualTo("123");
        await Assert.That(chain.And.Value).IsEqualTo("123");
    }

    [Test]
    public async Task NotMatch()
    {
        string? nullString = null;

        await Assert.That(() => nullString.Should().NotMatch("\\d+")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => "123".Should().NotMatch("\\d+")).Throws<AssertionException>().WithMessage("Value should not match the pattern \"\\d+\".");
        await Assert.That(() => "abc".Should().NotMatch("\\d+")).ThrowsNothing();
    }

    [Test]
    public async Task NotMatch_Chain()
    {
        var chain = "abc".Should().NotMatch("\\d+");
        await Assert.That(chain.Value).IsEqualTo("abc");
        await Assert.That(chain.And.Value).IsEqualTo("abc");
    }
}