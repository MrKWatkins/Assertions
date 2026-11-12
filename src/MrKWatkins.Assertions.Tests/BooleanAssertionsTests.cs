namespace MrKWatkins.Assertions.Tests;

public sealed class BooleanAssertionsTests
{
    [Test]
    public void BeTrue()
    {
        Assert.DoesNotThrow(() => true.Should().BeTrue());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be true but was false."), () => false.Should().BeTrue());
    }

    [Test]
    public void BeTrue_Chain()
    {
        var chain = true.Should().BeTrue();
        Assert.That(chain.Value, Is.True);
        Assert.That(chain.And.Value, Is.True);
    }

    [Test]
    public void NotBeTrue()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be true."), () => true.Should().NotBeTrue());
        Assert.DoesNotThrow(() => false.Should().NotBeTrue());
    }

    [Test]
    public void NotBeTrue_Chain()
    {
        var chain = false.Should().NotBeTrue();
        Assert.That(chain.Value, Is.False);
        Assert.That(chain.And.Value, Is.False);
    }

    [Test]
    public void BeFalse()
    {
        Assert.DoesNotThrow(() => false.Should().BeFalse());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be false but was true."), () => true.Should().BeFalse());
    }

    [Test]
    public void BeFalse_Chain()
    {
        var chain = false.Should().BeFalse();
        Assert.That(chain.Value, Is.False);
        Assert.That(chain.And.Value, Is.False);
    }

    [Test]
    public void NotBeFalse()
    {
        Assert.DoesNotThrow(() => true.Should().NotBeFalse());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be false."), () => false.Should().NotBeFalse());
    }

    [Test]
    public void NotBeFalse_Chain()
    {
        var chain = true.Should().NotBeFalse();
        Assert.That(chain.Value, Is.True);
        Assert.That(chain.And.Value, Is.True);
    }

    [Test]
    public void InheritedMethods_FromObjectAssertions()
    {
        // BooleanAssertions methods work alongside ObjectAssertions methods
        Assert.DoesNotThrow(() => true.Should().NotBeNull());
        Assert.DoesNotThrow(() => true.Should().Equal(true));
        Assert.DoesNotThrow(() => true.Should().NotEqual(false));
    }

    [Test]
    public void ChainWithInheritedMethods()
    {
        // Should be able to chain boolean-specific and object assertions
        Assert.DoesNotThrow(() => true.Should().BeTrue().And.NotEqual(false));
        Assert.DoesNotThrow(() => false.Should().BeFalse().And.NotEqual(true));
    }
}