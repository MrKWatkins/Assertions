namespace MrKWatkins.Assertions.Tests;

public sealed class NullDisposable : IDisposable
{
    public static readonly IDisposable Instance = new NullDisposable();

    private NullDisposable()
    {
    }

    public void Dispose()
    {
    }
}