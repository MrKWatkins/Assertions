namespace MrKWatkins.Assertions.Tests;

public sealed class NumericExtensionsTests
{
    [Test]
    public async Task BeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().BeZero()).Throws<AssertionException>().WithMessage("Value should be 0 but was 1.");
        await Assert.That(() => zero.Should().BeZero()).ThrowsNothing();
        await Assert.That(() => negative.Should().BeZero()).Throws<AssertionException>().WithMessage("Value should be 0 but was -1.");
    }

    [Test]
    public async Task BeZero_Chain()
    {
        const int zero = 0;

        var chain = zero.Should().BeZero();
        await Assert.That(chain.Value).IsEqualTo(zero);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(zero);
    }

    [Test]
    public async Task NotBeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().NotBeZero()).ThrowsNothing();
        await Assert.That(() => zero.Should().NotBeZero()).Throws<AssertionException>().WithMessage("Value should not be 0.");
        await Assert.That(() => negative.Should().NotBeZero()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeZero_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeZero();
        await Assert.That(chain.Value).IsEqualTo(positive);
        await Assert.That(chain.And.Value).IsEqualTo(positive);
    }

    [Test]
    public async Task BeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().BeNegative()).Throws<AssertionException>().WithMessage("Value should be negative but was 1.");
        await Assert.That(() => zero.Should().BeNegative()).Throws<AssertionException>().WithMessage("Value should be negative but was 0.");
        await Assert.That(() => negative.Should().BeNegative()).ThrowsNothing();
    }

    [Test]
    public async Task BeNegative_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().BeNegative();
        await Assert.That(chain.Value).IsEqualTo(negative);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(negative);
    }

    [Test]
    public async Task NotBeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => zero.Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => negative.Should().NotBeNegative()).Throws<AssertionException>().WithMessage("Value should not be negative but was -1.");
    }

    [Test]
    public async Task NotBeNegative_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeNegative();
        await Assert.That(chain.Value).IsEqualTo(positive);
        await Assert.That(chain.And.Value).IsEqualTo(positive);
    }

    [Test]
    public async Task BePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        await Assert.That(() => negative.Should().BePositive()).Throws<AssertionException>().WithMessage("Value should be positive but was -1.");
        await Assert.That(() => zero.Should().BePositive()).ThrowsNothing();
        await Assert.That(() => positive.Should().BePositive()).ThrowsNothing();
    }

    [Test]
    public async Task BePositive_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().BePositive();
        await Assert.That(chain.Value).IsEqualTo(positive);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(positive);
    }

    [Test]
    public async Task NotBePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        await Assert.That(() => negative.Should().NotBePositive()).ThrowsNothing();
        await Assert.That(() => zero.Should().NotBePositive()).Throws<AssertionException>().WithMessage("Value should not be positive but was 0.");
        await Assert.That(() => positive.Should().NotBePositive()).Throws<AssertionException>().WithMessage("Value should not be positive but was 1.");
    }

    [Test]
    public async Task NotBePositive_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().NotBePositive();
        await Assert.That(chain.Value).IsEqualTo(negative);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(negative);
    }
}