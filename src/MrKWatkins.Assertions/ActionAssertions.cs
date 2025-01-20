namespace MrKWatkins.Assertions;

public sealed class ActionAssertions
{
    private readonly Action action;

    internal ActionAssertions(Action action)
    {
        this.action = action;
    }

    public ActionAssertionsChain<TException> Throw<TException>()
        where TException : Exception
    {
        TException? thrown = null;
        try
        {
            action();
        }
        catch (Exception exception)
        {
            if (exception is not TException typedException)
            {
                throw Verify.CreateException($"Function should throw {Format.PrefixWithAOrAn(typeof(TException).Name)} but threw {Format.PrefixWithAOrAn(exception.GetType().Name)} with message {Format.Value(exception.Message)}.", exception);
            }
            thrown = typedException;
        }

        if (thrown == null)
        {
            throw Verify.CreateException($"Function should throw {Format.PrefixWithAOrAn(typeof(TException).Name)}.");
        }

        return new ActionAssertionsChain<TException>(thrown);
    }

    public void NotThrow()
    {
        try
        {
            action();
        }
        catch (Exception exception)
        {
            throw Verify.CreateException($"Function should not throw but threw {Format.PrefixWithAOrAn(exception.GetType().Name)} with message {Format.Value(exception.Message)}.", exception);
        }
    }
}