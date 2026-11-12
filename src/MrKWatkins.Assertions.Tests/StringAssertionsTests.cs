namespace MrKWatkins.Assertions.Tests;

public sealed class StringAssertionsTests
{
    [Test]
    public void Contain()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().Contain("test"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain the string \"invalid\"."),
            () => "test".Should().Contain("invalid")
        );
        Assert.DoesNotThrow(() => "test".Should().Contain("es"));
    }

    [Test]
    public void Contain_Chain()
    {
        var chain = "test".Should().Contain("es");
        Assert.That(chain.Value, Is.EqualTo("test"));
        Assert.That(chain.And.Value, Is.EqualTo("test"));
    }

    [Test]
    public void Contain_WithComparison()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain the string \"test\"."), () => "Test".Should().Contain("test"));
        Assert.DoesNotThrow(() => "Test".Should().Contain("test", StringComparison.OrdinalIgnoreCase));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain the string \"invalid\" (using OrdinalIgnoreCase)."),
            () => "Test".Should().Contain("invalid", StringComparison.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void NotContain()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().NotContain("test"));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not contain the string \"es\"."), () => "test".Should().NotContain("es"));
        Assert.DoesNotThrow(() => "test".Should().NotContain("invalid"));
    }

    [Test]
    public void NotContain_Chain()
    {
        var chain = "test".Should().NotContain("invalid");
        Assert.That(chain.Value, Is.EqualTo("test"));
        Assert.That(chain.And.Value, Is.EqualTo("test"));
    }

    [Test]
    public void NotContain_WithComparison()
    {
        Assert.DoesNotThrow(() => "Test".Should().NotContain("test"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not contain the string \"test\" (using OrdinalIgnoreCase)."),
            () => "Test".Should().NotContain("test", StringComparison.OrdinalIgnoreCase)
        );
        Assert.DoesNotThrow(() => "Test".Should().NotContain("invalid", StringComparison.OrdinalIgnoreCase));
    }

    [Test]
    public void StartWith()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().StartWith("test"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should start with \"world\" but was \"hello world\"."),
            () => "hello world".Should().StartWith("world")
        );
        Assert.DoesNotThrow(() => "hello world".Should().StartWith("hello"));
    }

    [Test]
    public void StartWith_Chain()
    {
        var chain = "hello world".Should().StartWith("hello");
        Assert.That(chain.Value, Is.EqualTo("hello world"));
        Assert.That(chain.And.Value, Is.EqualTo("hello world"));
    }

    [Test]
    public void StartWith_WithComparison()
    {
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should start with \"hello\" but was \"Hello\"."),
            () => "Hello".Should().StartWith("hello")
        );
        Assert.DoesNotThrow(() => "Hello".Should().StartWith("hello", StringComparison.OrdinalIgnoreCase));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should start with \"world\" (using OrdinalIgnoreCase) but was \"Hello\"."),
            () => "Hello".Should().StartWith("world", StringComparison.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void NotStartWith()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().NotStartWith("test"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not start with \"hello\"."),
            () => "hello world".Should().NotStartWith("hello")
        );
        Assert.DoesNotThrow(() => "hello world".Should().NotStartWith("world"));
    }

    [Test]
    public void NotStartWith_Chain()
    {
        var chain = "hello world".Should().NotStartWith("world");
        Assert.That(chain.Value, Is.EqualTo("hello world"));
        Assert.That(chain.And.Value, Is.EqualTo("hello world"));
    }

    [Test]
    public void NotStartWith_WithComparison()
    {
        Assert.DoesNotThrow(() => "Hello".Should().NotStartWith("hello"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not start with \"hello\" (using OrdinalIgnoreCase)."),
            () => "Hello".Should().NotStartWith("hello", StringComparison.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void EndWith()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().EndWith("test"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should end with \"hello\" but was \"hello world\"."),
            () => "hello world".Should().EndWith("hello")
        );
        Assert.DoesNotThrow(() => "hello world".Should().EndWith("world"));
    }

    [Test]
    public void EndWith_Chain()
    {
        var chain = "hello world".Should().EndWith("world");
        Assert.That(chain.Value, Is.EqualTo("hello world"));
        Assert.That(chain.And.Value, Is.EqualTo("hello world"));
    }

    [Test]
    public void EndWith_WithComparison()
    {
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should end with \"world\" but was \"Hello World\"."),
            () => "Hello World".Should().EndWith("world")
        );
        Assert.DoesNotThrow(() => "Hello World".Should().EndWith("world", StringComparison.OrdinalIgnoreCase));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should end with \"hello\" (using OrdinalIgnoreCase) but was \"Hello World\"."),
            () => "Hello World".Should().EndWith("hello", StringComparison.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void NotEndWith()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().NotEndWith("test"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not end with \"world\"."),
            () => "hello world".Should().NotEndWith("world")
        );
        Assert.DoesNotThrow(() => "hello world".Should().NotEndWith("hello"));
    }

    [Test]
    public void NotEndWith_Chain()
    {
        var chain = "hello world".Should().NotEndWith("hello");
        Assert.That(chain.Value, Is.EqualTo("hello world"));
        Assert.That(chain.And.Value, Is.EqualTo("hello world"));
    }

    [Test]
    public void NotEndWith_WithComparison()
    {
        Assert.DoesNotThrow(() => "Hello World".Should().NotEndWith("world"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not end with \"world\" (using OrdinalIgnoreCase)."),
            () => "Hello World".Should().NotEndWith("world", StringComparison.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void BeEmpty()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().BeEmpty());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be empty but was \"test\"."), () => "test".Should().BeEmpty());
        Assert.DoesNotThrow(() => "".Should().BeEmpty());
    }

    [Test]
    public void BeEmpty_Chain()
    {
        var chain = "".Should().BeEmpty();
        Assert.That(chain.Value, Is.EqualTo(""));
        Assert.That(chain.And.Value, Is.EqualTo(""));
    }

    [Test]
    public void NotBeEmpty()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().NotBeEmpty());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be empty."), () => "".Should().NotBeEmpty());
        Assert.DoesNotThrow(() => "test".Should().NotBeEmpty());
    }

    [Test]
    public void NotBeEmpty_Chain()
    {
        var chain = "test".Should().NotBeEmpty();
        Assert.That(chain.Value, Is.EqualTo("test"));
        Assert.That(chain.And.Value, Is.EqualTo("test"));
    }

    [Test]
    public void BeNullOrEmpty()
    {
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be null or empty but was \"test\"."),
            () => "test".Should().BeNullOrEmpty()
        );
        Assert.DoesNotThrow(() => ((string?)null).Should().BeNullOrEmpty());
        Assert.DoesNotThrow(() => "".Should().BeNullOrEmpty());
    }

    [Test]
    public void NotBeNullOrEmpty()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null or empty."), () => ((string?)null).Should().NotBeNullOrEmpty());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null or empty."), () => "".Should().NotBeNullOrEmpty());
        Assert.DoesNotThrow(() => "test".Should().NotBeNullOrEmpty());
    }

    [Test]
    public void NotBeNullOrEmpty_Chain()
    {
        var chain = "test".Should().NotBeNullOrEmpty();
        Assert.That(chain.Value, Is.EqualTo("test"));
        Assert.That(chain.And.Value, Is.EqualTo("test"));
    }

    [Test]
    public void BeNullOrWhiteSpace()
    {
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be null or white space but was \"test\"."),
            () => "test".Should().BeNullOrWhiteSpace()
        );
        Assert.DoesNotThrow(() => ((string?)null).Should().BeNullOrWhiteSpace());
        Assert.DoesNotThrow(() => "".Should().BeNullOrWhiteSpace());
        Assert.DoesNotThrow(() => "   ".Should().BeNullOrWhiteSpace());
    }

    [Test]
    public void NotBeNullOrWhiteSpace()
    {
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null or white space."),
            () => ((string?)null).Should().NotBeNullOrWhiteSpace()
        );
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null or white space."), () => "".Should().NotBeNullOrWhiteSpace());
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null or white space."),
            () => "   ".Should().NotBeNullOrWhiteSpace()
        );
        Assert.DoesNotThrow(() => "test".Should().NotBeNullOrWhiteSpace());
    }

    [Test]
    public void NotBeNullOrWhiteSpace_Chain()
    {
        var chain = "test".Should().NotBeNullOrWhiteSpace();
        Assert.That(chain.Value, Is.EqualTo("test"));
        Assert.That(chain.And.Value, Is.EqualTo("test"));
    }

    [Test]
    public void HaveLength()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().HaveLength(4));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have length 5 but was 4."), () => "test".Should().HaveLength(5));
        Assert.DoesNotThrow(() => "test".Should().HaveLength(4));
    }

    [Test]
    public void HaveLength_Chain()
    {
        var chain = "test".Should().HaveLength(4);
        Assert.That(chain.Value, Is.EqualTo("test"));
        Assert.That(chain.And.Value, Is.EqualTo("test"));
    }

    [Test]
    public void NotHaveLength()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().NotHaveLength(4));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have length 4."), () => "test".Should().NotHaveLength(4));
        Assert.DoesNotThrow(() => "test".Should().NotHaveLength(5));
    }

    [Test]
    public void NotHaveLength_Chain()
    {
        var chain = "test".Should().NotHaveLength(5);
        Assert.That(chain.Value, Is.EqualTo("test"));
        Assert.That(chain.And.Value, Is.EqualTo("test"));
    }

    [Test]
    public void Match()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().Match("\\d+"));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should match the pattern \"\\d+\" but was \"abc\"."),
            () => "abc".Should().Match("\\d+")
        );
        Assert.DoesNotThrow(() => "123".Should().Match("\\d+"));
    }

    [Test]
    public void Match_Chain()
    {
        var chain = "123".Should().Match("\\d+");
        Assert.That(chain.Value, Is.EqualTo("123"));
        Assert.That(chain.And.Value, Is.EqualTo("123"));
    }

    [Test]
    public void NotMatch()
    {
        string? nullString = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullString.Should().NotMatch("\\d+"));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not match the pattern \"\\d+\"."), () => "123".Should().NotMatch("\\d+"));
        Assert.DoesNotThrow(() => "abc".Should().NotMatch("\\d+"));
    }

    [Test]
    public void NotMatch_Chain()
    {
        var chain = "abc".Should().NotMatch("\\d+");
        Assert.That(chain.Value, Is.EqualTo("abc"));
        Assert.That(chain.And.Value, Is.EqualTo("abc"));
    }
}