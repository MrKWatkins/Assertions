using System.Linq.Expressions;

namespace MrKWatkins.Assertions;

internal static class Verify
{
    private static readonly Func<string, Exception> CreateException = BuildCreateException();

    internal static void That(bool condition, string exceptionMessage)
    {
        if (!condition)
        {
            throw CreateException(exceptionMessage);
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0>(bool condition, string exceptionMessageFormat, T0 arg0)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0)));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1>(bool condition, string exceptionMessageFormat, T0 arg0, T1 arg1)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0), Format.Value(arg1)));
        }
    }

    [Pure]
    [ExcludeFromCodeCoverage]
    private static Func<string, Exception> BuildCreateException()
    {
        var nunitExceptionType = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.FullName == "NUnit.Framework.AssertionException");

        return BuildCreateException(nunitExceptionType) ?? (message => new ApplicationException(message));
    }

    [Pure]
    [ExcludeFromCodeCoverage]
    private static Func<string, Exception>? BuildCreateException(Type? exceptionType)
    {
        if (exceptionType == null)
        {
            return null;
        }

        var constructor = exceptionType.GetConstructor([typeof(string)]);
        if (constructor == null)
        {
            return null;
        }

        var parameter = Expression.Parameter(typeof(string), "message");
        var construct = Expression.New(constructor, parameter);
        var lambda = Expression.Lambda<Func<string, Exception>>(construct, parameter);

        return lambda.Compile();
    }
}