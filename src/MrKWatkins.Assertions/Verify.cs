using System.Linq.Expressions;

namespace MrKWatkins.Assertions;

public static class Verify
{
    private static readonly Func<string, Exception?, Exception> ExceptionConstructor = BuildExceptionConstructor();

    [Pure]
    internal static Exception CreateException(string message, Exception? innerException = null) => ExceptionConstructor(message, innerException);

    public static void That([DoesNotReturnIf(true)] bool condition, string exceptionMessage)
    {
        if (!condition)
        {
            throw CreateException(exceptionMessage);
        }
    }

    public static void That([DoesNotReturnIf(true)] bool condition, FormatInterpolatedStringHandler message)
    {
        if (!condition)
        {
            throw CreateException(message.ToString());
        }
    }

    [Pure]
    [ExcludeFromCodeCoverage]
    private static Func<string, Exception?, Exception> BuildExceptionConstructor()
    {
        Func<string, Exception?, Exception>? constructor = null;
        try
        {
            var nunitExceptionType = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetExportedTypes())
                .FirstOrDefault(t => t.FullName == "NUnit.Framework.AssertionException");

            constructor = BuildCreateException(nunitExceptionType);
        }
        // ReSharper disable once EmptyGeneralCatchClause
        catch
        {
        }

        return constructor ?? ((message, innerException) => new AssertionException(message, innerException));
    }

    [Pure]
    [ExcludeFromCodeCoverage]
    private static Func<string, Exception?, Exception>? BuildCreateException(Type? exceptionType)
    {
        if (exceptionType == null)
        {
            return null;
        }

        var constructor = exceptionType.GetConstructor([typeof(string), typeof(Exception)]);
        if (constructor == null)
        {
            return null;
        }

        var message = Expression.Parameter(typeof(string), "message");
        var innerException = Expression.Parameter(typeof(Exception), "innerException");
        var construct = Expression.New(constructor, message, innerException);
        var lambda = Expression.Lambda<Func<string, Exception?, Exception>>(construct, message, innerException);

        return lambda.Compile();
    }
}