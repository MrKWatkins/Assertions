namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlySetAssertionsTests
{
    [Test]
    public void SetEquals_IReadOnlySet()
    {
        IReadOnlySet<int> nullValue = null!;
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };
        IReadOnlySet<int> empty = new HashSet<int>();

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().SetEquals(1, 2, 3));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should set equal [1, 2, 3, 4] but it is missing [4]."),
            () => value.Should().SetEquals(1, 2, 3, 4)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should set equal [1, 2] but it has extra item [3]."),
            () => value.Should().SetEquals(1, 2)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should set equal [1] but it has extra items [2, 3]."),
            () => value.Should().SetEquals(1)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should set equal [1, 2, 4] but it is missing [4] and has extra item [3]."),
            () => value.Should().SetEquals(1, 2, 4)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should set equal [4, 4] but it is missing [4] and has extra items [1, 2, 3]."),
            () => value.Should().SetEquals(4, 4)
        );
        Assert.DoesNotThrow(() => value.Should().SetEquals(1, 2, 3));
        Assert.DoesNotThrow(() => value.Should().SetEquals(3, 2, 1));
        Assert.DoesNotThrow(() => value.Should().SetEquals(1, 2, 3, 3));
        Assert.DoesNotThrow(() => empty.Should().SetEquals());
    }

    [Test]
    public void SetEquals_IReadOnlySet_Chain()
    {
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().SetEquals(1, 2, 3);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void SetEquals_HashSet()
    {
        HashSet<int> nullValue = null!;
        var value = new HashSet<int> { 1, 2, 3 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().SetEquals(1, 2, 3));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should set equal [1, 2, 3, 4] but it is missing [4]."),
            () => value.Should().SetEquals(1, 2, 3, 4)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should set equal [1, 2] but it has extra item [3]."),
            () => value.Should().SetEquals(1, 2)
        );
        Assert.DoesNotThrow(() => value.Should().SetEquals(1, 2, 3));
    }

    [Test]
    public void SetEquals_HashSet_Chain()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().SetEquals(1, 2, 3);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void IsSupersetOf_IReadOnlySet()
    {
        IReadOnlySet<int> nullValue = null!;
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().IsSupersetOf(1, 2));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should be a superset of [1, 4] but it is missing [4]."),
            () => value.Should().IsSupersetOf(1, 4)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should be a superset of [4, 5, 4] but it is missing [4, 5]."),
            () => value.Should().IsSupersetOf(4, 5, 4)
        );
        Assert.DoesNotThrow(() => value.Should().IsSupersetOf(1, 2));
        Assert.DoesNotThrow(() => value.Should().IsSupersetOf(1, 2, 3));
        Assert.DoesNotThrow(() => value.Should().IsSupersetOf());
    }

    [Test]
    public void IsSupersetOf_IReadOnlySet_Chain()
    {
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSupersetOf(1, 2);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void IsSupersetOf_HashSet()
    {
        HashSet<int> nullValue = null!;
        var value = new HashSet<int> { 1, 2, 3 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().IsSupersetOf(1, 2));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should be a superset of [1, 4] but it is missing [4]."),
            () => value.Should().IsSupersetOf(1, 4)
        );
        Assert.DoesNotThrow(() => value.Should().IsSupersetOf(1, 2));
    }

    [Test]
    public void IsSupersetOf_HashSet_Chain()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSupersetOf(1, 2);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void IsSubsetOf_IReadOnlySet()
    {
        IReadOnlySet<int> nullValue = null!;
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };
        IReadOnlySet<int> empty = new HashSet<int>();

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().IsSubsetOf(1, 2, 3));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should be a subset of [1, 2] but it has extra item [3]."),
            () => value.Should().IsSubsetOf(1, 2)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should be a subset of [1] but it has extra items [2, 3]."),
            () => value.Should().IsSubsetOf(1)
        );
        Assert.DoesNotThrow(() => value.Should().IsSubsetOf(1, 2, 3));
        Assert.DoesNotThrow(() => value.Should().IsSubsetOf(1, 2, 3, 4));
        Assert.DoesNotThrow(() => empty.Should().IsSubsetOf(1));
    }

    [Test]
    public void IsSubsetOf_IReadOnlySet_Chain()
    {
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSubsetOf(1, 2, 3, 4);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void IsSubsetOf_HashSet()
    {
        HashSet<int> nullValue = null!;
        var value = new HashSet<int> { 1, 2, 3 };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().IsSubsetOf(1, 2, 3));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, 2, 3] should be a subset of [1, 2] but it has extra item [3]."),
            () => value.Should().IsSubsetOf(1, 2)
        );
        Assert.DoesNotThrow(() => value.Should().IsSubsetOf(1, 2, 3));
    }

    [Test]
    public void IsSubsetOf_HashSet_Chain()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSubsetOf(1, 2, 3, 4);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }
}