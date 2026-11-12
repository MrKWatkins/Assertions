using System.Diagnostics;

namespace MrKWatkins.Assertions.Tests;

public sealed class VerifyTests
{
    [Test]
    public void That_True()
    {
        Assert.DoesNotThrow(() => Verify.That(true, "Unused"));
        Assert.DoesNotThrow(() => Verify.That(true, $"Unused {42}"));
    }

    [TestCase(null, "Verified message.\nVerified formatted.\nVerified inner.")]
    [TestCase("message", "Verified message.")]
    [TestCase("formatted", "Verified formatted.")]
    [TestCase("inner", "Verified inner.")]
    public async Task That_WithoutNUnit(string? scenario, string expectedOutput)
    {
        var start = new ProcessStartInfo("dotnet")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };
        start.ArgumentList.Add(Path.Combine(TestContext.CurrentContext.TestDirectory, "fallback-host", "MrKWatkins.Assertions.TestsWithoutNUnit.dll"));
        if (scenario is not null)
        {
            start.ArgumentList.Add(scenario);
        }

        using var process = Process.Start(start) ?? throw new InvalidOperationException("Could not start fallback test host.");
        var output = process.StandardOutput.ReadToEndAsync();
        var error = process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        Assert.That(process.ExitCode, Is.Zero, await error);
        Assert.That((await output).Trim().ReplaceLineEndings("\n"), Is.EqualTo(expectedOutput));
    }
}