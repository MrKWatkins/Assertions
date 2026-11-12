namespace MrKWatkins.Assertions.Tests;

public sealed class EnumerableAssertionsTests
{
    [Test]
    public void AllBeOfType_Null()
    {
        IEnumerable<object> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().AllBeOfType<string>());
    }

    [Test]
    public void AllBeOfType()
    {
        var value = new List<object> { "one", 2, "three" };

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should only contain items of type String but the item at index 1 is not."),
            () => value.Should().AllBeOfType<string>()
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should only contain items of type Int32 but the items at indices 0, 2 are not."),
            () => value.Should().AllBeOfType<int>()
        );

        Assert.DoesNotThrow(() => value.Should().AllBeOfType<object>());
    }

    [Test]
    public void AllBeOfType_Chain()
    {
        var value = new List<object> { "one", "two", "three" };

        var chain = value.Should().AllBeOfType<string>();
        Assert.That(chain.Value, Is.EquivalentTo(new[] { "one", "two", "three" }));
        Assert.That(chain.And.Value, Is.EquivalentTo(new[] { "one", "two", "three" }));
    }

    [Test]
    public void OnlyContain_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().OnlyContain(x => x != 2));
    }

    [Test]
    public void OnlyContain()
    {
        var value = new List<int> { 1, 2, 3 };

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should only contain items that satisfy the predicate x => x != 2 but the item 2 at index 1 does not."
            ),
            () => value.Should().OnlyContain(x => x != 2)
        );

        Assert.DoesNotThrow(() => value.Should().OnlyContain(x => x < 5));
    }

    [Test]
    public void OnlyContain_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().OnlyContain(x => x < 5);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void ContainSingle_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().ContainSingle(x => x != 2));
    }

    [Test]
    public void ContainSingle()
    {
        var value = new List<int> { 1, 2, 3 };

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should only contain a single item that satisfies the predicate x => x == 5 but it contains 0 items."
            ),
            () => value.Should().ContainSingle(x => x == 5)
        );

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should only contain a single item that satisfies the predicate x => x != 2 but it contains 2 items."
            ),
            () => value.Should().ContainSingle(x => x != 2)
        );

        Assert.DoesNotThrow(() => value.Should().ContainSingle(x => x == 2));
    }

    [Test]
    public void ContainSingle_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().ContainSingle(x => x == 3);
        Assert.That(chain.That, Is.EqualTo(3));
        Assert.That(chain.Value, Is.EqualTo(3));
        Assert.That(chain.And.Value, Is.EqualTo(3));
    }

    [Test]
    public void SequenceEqual_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().SequenceEqual(1));
    }
    [TestCase(new int[0], true, new[] { 1, 2, 3 }, true, "Value [] should sequence equal [1, 2, 3] but it has 0 elements rather than the expected 3.")]
    [TestCase(new int[0], true, new[] { 1, 2, 3 }, false, "Value [] should sequence equal [1, 2, ...] but it has fewer elements (0) than expected.")]
    [TestCase(new int[0], false, new[] { 1, 2, 3 }, true, "Value [] should sequence equal [1, 2, 3] but it has 0 elements rather than the expected 3.")]
    [TestCase(new int[0], false, new[] { 1, 2, 3 }, false, "Value [] should sequence equal [1, 2, ...] but it has fewer elements (0) than expected.")]
    [TestCase(new[] { 1 }, true, new int[0], true, "Value [1] should sequence equal [] but it has 1 element rather than the expected 0.")]
    [TestCase(new[] { 1, 2, 3 }, true, new int[0], false, "Value [1, 2, 3] should sequence equal [] but it has 3 elements rather than the expected 0.")]
    [TestCase(new[] { 1, 2, 3 }, false, new int[0], true, "Value [1, 2, ...] should sequence equal [] but it has more elements than the expected 0.")]
    [TestCase(new[] { 1, 2, 3 }, false, new int[0], false, "Value [1, 2, ...] should sequence equal [] but it has more elements than the expected 0.")]
    [TestCase(new[] { 1, 2, 3 }, true, new[] { 1, 2, 4 }, true, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    [TestCase(new[] { 1, 2, 3 }, false, new[] { 1, 2, 4 }, true, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    [TestCase(new[] { 1, 2, 3 }, true, new[] { 1, 2, 4 }, false, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    [TestCase(new[] { 1, 2, 3 }, false, new[] { 1, 2, 4 }, false, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    public void SequenceEqual_Throws(int[] actual, bool actualIsCollection, int[] expected, bool expectedIsCollection, string expectedMessage)
    {
        var actualEnumerable = actualIsCollection ? actual : actual.Select(x => x);
        var expectedEnumerable = expectedIsCollection ? expected : expected.Select(x => x);

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(expectedMessage), () => actualEnumerable.Should().SequenceEqual(expectedEnumerable));
    }
    [TestCase(new int[0], true, new int[0], true)]
    [TestCase(new int[0], false, new int[0], true)]
    [TestCase(new int[0], true, new int[0], false)]
    [TestCase(new int[0], false, new int[0], false)]
    [TestCase(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, true)]
    [TestCase(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, true)]
    [TestCase(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, false)]
    [TestCase(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, false)]
    public void SequenceEqual(int[] actual, bool actualIsCollection, int[] expected, bool expectedIsCollection)
    {
        var actualEnumerable = actualIsCollection ? actual : actual.Select(x => x);
        var expectedEnumerable = expectedIsCollection ? expected : expected.Select(x => x);

        Assert.DoesNotThrow(() => actualEnumerable.Should().SequenceEqual(expectedEnumerable));
    }

    [Test]
    public void SequenceEqual_SubType()
    {
        var value = new List<object> { "A", "B", "C" };

        Assert.DoesNotThrow(() => value.Should().SequenceEqual("A", "B", "C"));
    }

    [Test]
    public void SequenceEqual_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(value);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void SequenceEqual_Comparer()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().SequenceEqual(new List<string> { "A", "B", "D" }, StringComparer.OrdinalIgnoreCase));
        Assert.DoesNotThrow(() => value.Should().SequenceEqual(new List<string> { "A", "B", "C" }, StringComparer.OrdinalIgnoreCase));
    }

    [Test]
    public void SequenceEqual_Comparer_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().SequenceEqual(new List<string> { "A", "B", "C" }, StringComparer.OrdinalIgnoreCase);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void SequenceEqual_Predicate()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>(),
            () => value.Should().SequenceEqual(new List<string> { "A", "B", "D" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
        );
        Assert.DoesNotThrow(() => value.Should().SequenceEqual(new List<string> { "A", "B", "C" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
    }

    [Test]
    public void SequenceEqual_Predicate_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().SequenceEqual(new List<string> { "A", "B", "C" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotSequenceEqual_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().NotSequenceEqual(1));
    }
    [TestCase(new int[0], true, new int[0], true, "Value should not sequence equal [].")]
    [TestCase(new int[0], false, new int[0], true, "Value should not sequence equal [].")]
    [TestCase(new int[0], true, new int[0], false, "Value should not sequence equal [].")]
    [TestCase(new int[0], false, new int[0], false, "Value should not sequence equal [].")]
    [TestCase(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, true, "Value should not sequence equal [1, 2, 3].")]
    [TestCase(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, true, "Value should not sequence equal [1, 2, 3].")]
    [TestCase(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, false, "Value should not sequence equal [1, 2, ...].")]
    [TestCase(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, false, "Value should not sequence equal [1, 2, ...].")]
    public void NotSequenceEqual_Throws(int[] actual, bool actualIsCollection, int[] expected, bool expectedIsCollection, string expectedMessage)
    {
        var actualEnumerable = actualIsCollection ? actual : actual.Select(x => x);
        var expectedEnumerable = expectedIsCollection ? expected : expected.Select(x => x);

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(expectedMessage), () => actualEnumerable.Should().NotSequenceEqual(expectedEnumerable));
    }

    [Test]
    public void NotSequenceEqual_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(value);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotSequenceEqual_Comparer()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not sequence equal [\"A\", \"B\", \"C\"]."),
            () => value.Should().NotSequenceEqual(new List<string> { "A", "B", "C" }, StringComparer.OrdinalIgnoreCase)
        );
        Assert.DoesNotThrow(() => value.Should().NotSequenceEqual(new List<string> { "A", "B", "D" }, StringComparer.OrdinalIgnoreCase));
    }

    [Test]
    public void NotSequenceEqual_Comparer_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().NotSequenceEqual(new List<string> { "x", "y", "z" }, StringComparer.OrdinalIgnoreCase);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotSequenceEqual_Predicate()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not sequence equal [\"A\", \"B\", \"C\"]."),
            () => value.Should().NotSequenceEqual(new List<string> { "A", "B", "C" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
        );
        Assert.DoesNotThrow(() => value.Should().NotSequenceEqual(new List<string> { "A", "B", "D" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
        Assert.DoesNotThrow(() => value.Should().NotSequenceEqual(new List<string> { "A", "B" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
        Assert.DoesNotThrow(() => value.Should().NotSequenceEqual(new List<string> { "A", "B", "C", "D" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
    }

    [Test]
    public void NotSequenceEqual_Predicate_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().NotSequenceEqual(new List<string> { "x", "y", "z" }, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void Contain_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().Contain(1));
    }

    [Test]
    public void Contain()
    {
        var value = new List<int> { 1, 2, 3 };

        Assert.DoesNotThrow(() => value.Should().Contain(2));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain 5 but did not."), () => value.Should().Contain(5));
    }

    [Test]
    public void Contain_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().Contain(2);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void Contain_Comparer()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.DoesNotThrow(() => value.Should().Contain("A", StringComparer.OrdinalIgnoreCase));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain \"D\" but did not."),
            () => value.Should().Contain("D", StringComparer.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void Contain_Comparer_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().Contain("A", StringComparer.OrdinalIgnoreCase);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void Contain_Predicate()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.DoesNotThrow(() => value.Should().Contain("A", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain \"D\" but did not."),
            () => value.Should().Contain("D", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
        );
    }

    [Test]
    public void Contain_Predicate_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().Contain("A", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotContain_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().NotContain(1));
    }

    [Test]
    public void NotContain()
    {
        var value = new List<int> { 1, 2, 3 };

        Assert.DoesNotThrow(() => value.Should().NotContain(5));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not contain 2."), () => value.Should().NotContain(2));
    }

    [Test]
    public void NotContain_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().NotContain(5);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotContain_Comparer()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.DoesNotThrow(() => value.Should().NotContain("D", StringComparer.OrdinalIgnoreCase));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not contain \"A\"."),
            () => value.Should().NotContain("A", StringComparer.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void NotContain_Comparer_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().NotContain("D", StringComparer.OrdinalIgnoreCase);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotContain_Predicate()
    {
        var value = new List<string> { "a", "b", "c" };

        Assert.DoesNotThrow(() => value.Should().NotContain("D", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not contain \"A\"."),
            () => value.Should().NotContain("A", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
        );
    }

    [Test]
    public void NotContain_Predicate_Chain()
    {
        var value = new List<string> { "a", "b", "c" };

        var chain = value.Should().NotContain("D", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void ContainSingle_NoArg_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullEnumerable.Should().ContainSingle());
    }

    [Test]
    public void ContainSingle_NoArg()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var empty = new List<int>();
        var single = new List<int> { 42 };
        var multiple = new List<int> { 1, 2, 3 };

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain a single item but was empty."),
            () => empty.Should().ContainSingle()
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should contain a single item but contains more than one item."),
            () => multiple.Should().ContainSingle()
        );
        Assert.DoesNotThrow(() => single.Should().ContainSingle());
    }

    [Test]
    public void ContainSingle_NoArg_Chain()
    {
        var single = new List<int> { 42 };

        var chain = single.Should().ContainSingle();
        Assert.That(chain.That, Is.EqualTo(42));
        Assert.That(chain.Value, Is.EqualTo(42));
        Assert.That(chain.And.Value, Is.EqualTo(42));
    }
}