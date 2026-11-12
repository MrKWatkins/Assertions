using System.Collections;

namespace MrKWatkins.Assertions.Tests;

public sealed class EnumerableExtensionsTests
{
    [Test]
    public void SequenceEqual_Null()
    {
        IEnumerable nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().SequenceEqual(1));
    }

    [Test]
    public void SequenceEqual()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        Assert.DoesNotThrow(() => value.Should().SequenceEqual(1, 2, 3));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, ...] should sequence equal [1, 2] but it has more elements than the expected 2."),
            () => value.Should().SequenceEqual(1, 2)
        );
    }

    [Test]
    public void SequenceEqual_Chain()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(1, 2, 3);
        Assert.That(ReferenceEquals(chain.Value, value), Is.True);
        Assert.That(ReferenceEquals(chain.And.Value, value), Is.True);
    }

    [Test]
    public void NotSequenceEqual_Null()
    {
        IEnumerable nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().NotSequenceEqual(1));
    }

    [Test]
    public void NotSequenceEqual()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        Assert.DoesNotThrow(() => value.Should().NotSequenceEqual(1, 2));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not sequence equal [1, 2, 3]."),
            () => value.Should().NotSequenceEqual(1, 2, 3)
        );
    }

    [Test]
    public void NotSequenceEqual_Chain()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        var chain = value.Should().NotSequenceEqual(1, 2);
        Assert.That(ReferenceEquals(chain.Value, value), Is.True);
        Assert.That(ReferenceEquals(chain.And.Value, value), Is.True);
    }
}