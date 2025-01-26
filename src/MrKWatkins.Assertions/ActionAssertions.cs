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

    public ActionAssertionsChain<TException> Throw<TException>(string expectedMessage)
        where TException : Exception
    {
        var chain = Throw<TException>();

        chain.That.Should().HaveMessage(expectedMessage);

        return chain;
    }

    public ActionAssertionsChain<TException> Throw<TException>(string expectedMessage, Exception? expectedInnerException)
        where TException : Exception
    {
        var chain = Throw<TException>();

        chain.That.Should().HaveMessage(expectedMessage);
        if (expectedInnerException != null)
        {
            chain.That.Should().HaveInnerException(expectedInnerException);
        }
        else
        {
            chain.That.Should().NotHaveInnerException();
        }

        return chain;
    }

    public ActionAssertionsChain<TException> Throw<TException>(TException expected)
        where TException : Exception
    {
        var chain = Throw<TException>();

        chain.Exception.Should().BeTheSameInstanceAs(expected);

        return chain;
    }

    public ActionAssertionsChain<ArgumentException> ThrowArgumentException(string expectedMessage, string expectedParamName)
    {
        var chain = Throw<ArgumentException>();

        chain.Exception.Should().HaveMessageStartingWith(expectedMessage).And.HaveParamName(expectedParamName);

        return chain;
    }

    public ActionAssertionsChain<ArgumentOutOfRangeException> ThrowArgumentOutOfRangeException(string expectedMessage, string expectedParamName, object expectedActualValue)
    {
        var chain = Throw<ArgumentOutOfRangeException>();

        chain.Exception.Should().HaveMessageStartingWith(expectedMessage).And.HaveParamName(expectedParamName).And.HaveActualValue(expectedActualValue);

        return chain;
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