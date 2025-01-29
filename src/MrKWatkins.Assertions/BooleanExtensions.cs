namespace MrKWatkins.Assertions;

public static class BooleanExtensions
{
    public static ObjectAssertionsChain<bool> BeTrue(this ObjectAssertions<bool> assertions)
    {
        Verify.That(assertions.Value, "Value should be true but was false.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    public static ObjectAssertionsChain<bool?> BeTrue(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(assertions.Value.HasValue && assertions.Value.Value, $"Value should be true but was {assertions.Value}.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }

    public static ObjectAssertionsChain<bool> NotBeTrue(this ObjectAssertions<bool> assertions)
    {
        Verify.That(!assertions.Value, "Value should not be true but was false.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    public static ObjectAssertionsChain<bool?> NotBeTrue(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(!assertions.Value.HasValue || !assertions.Value.Value, "Value should not be true.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }

    public static ObjectAssertionsChain<bool> BeFalse(this ObjectAssertions<bool> assertions)
    {
        Verify.That(!assertions.Value, "Value should be false but was true.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    public static ObjectAssertionsChain<bool?> BeFalse(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(assertions.Value.HasValue && !assertions.Value.Value, $"Value should be false but was {assertions.Value}.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }

    public static ObjectAssertionsChain<bool> NotBeFalse(this ObjectAssertions<bool> assertions)
    {
        Verify.That(assertions.Value, "Value should not be false.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    public static ObjectAssertionsChain<bool?> NotBeFalse(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(!assertions.Value.HasValue || assertions.Value.Value, "Value should not be false.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }
}