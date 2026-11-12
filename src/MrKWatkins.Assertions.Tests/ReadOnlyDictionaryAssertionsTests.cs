namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlyDictionaryAssertionsTests
{
    [Test]
    public void ContainKey_IReadOnlyDictionary()
    {
        IReadOnlyDictionary<string, int> nullValue = null!;
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().ContainKey("Test"));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain key \"Other\"."), () => value.Should().ContainKey("Other"));
        Assert.DoesNotThrow(() => value.Should().ContainKey("Test"));
    }

    [Test]
    public void ContainKey_IReadOnlyDictionary_Chain()
    {
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().ContainKey("Test");
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotContainKey_IReadOnlyDictionary()
    {
        IReadOnlyDictionary<string, int> nullValue = null!;
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().NotContainKey("Test"));
        Assert.DoesNotThrow(() => value.Should().NotContainKey("Other"));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not contain key \"Test\"."), () => value.Should().NotContainKey("Test"));
    }

    [Test]
    public void NotContainKey_IReadOnlyDictionary_Chain()
    {
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().NotContainKey("Other");
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void ContainKey_Dictionary()
    {
        Dictionary<string, int> nullValue = null!;
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().ContainKey("Test"));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain key \"Other\"."), () => value.Should().ContainKey("Other"));
        Assert.DoesNotThrow(() => value.Should().ContainKey("Test"));
    }

    [Test]
    public void ContainKey_Dictionary_Chain()
    {
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().ContainKey("Test");
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotContainKey_Dictionary()
    {
        Dictionary<string, int> nullValue = null!;
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().NotContainKey("Test"));
        Assert.DoesNotThrow(() => value.Should().NotContainKey("Other"));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not contain key \"Test\"."), () => value.Should().NotContainKey("Test"));
    }

    [Test]
    public void NotContainKey_Dictionary_Chain()
    {
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().NotContainKey("Other");
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }
}