using MrKWatkins.Assertions;

var scenarios = args.Length == 0
    ? ["message", "formatted", "inner"]
    : args;
var inner = new InvalidOperationException("Inner");

foreach (var scenario in scenarios)
{
    var passed = scenario switch
    {
        "message" => Check(() => Verify.That(false, "Expected"), "Expected", null),
        "formatted" => Check(() => Verify.That(false, $"Expected {42}"), "Expected 42", null),
        "inner" => Check(
            () => AssertThat.Invoking(() => throw inner).Should().NotThrow(),
            "Function should not throw but threw an InvalidOperationException with message \"Inner\".",
            inner),
        _ => throw new ArgumentException("Unknown scenario.", nameof(args))
    };

    if (!passed)
    {
        return 1;
    }

    Console.WriteLine($"Verified {scenario}.");
}

return 0;

static bool Check(Action action, string message, Exception? inner)
{
    try
    {
        action();
        return false;
    }
    catch (AssertionException exception)
    {
        return string.Equals(exception.Message, message, StringComparison.Ordinal)
            && ReferenceEquals(exception.InnerException, inner);
    }
}