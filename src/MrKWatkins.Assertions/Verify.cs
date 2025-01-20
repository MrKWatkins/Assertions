using System.Linq.Expressions;

namespace MrKWatkins.Assertions;

internal static class Verify
{
    private static readonly Func<string, Exception?, Exception> ExceptionConstructor = BuildExceptionConstructor();

    [Pure]
    internal static Exception CreateException(string message, Exception? innerException = null) => ExceptionConstructor(message, innerException);

    internal static void That(bool condition, string exceptionMessage)
    {
        if (!condition)
        {
            throw CreateException(exceptionMessage);
        }
    }

    internal static void That(bool condition, Func<string> exceptionMessage)
    {
        if (!condition)
        {
            throw CreateException(exceptionMessage());
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0>(bool condition, string exceptionMessageFormat, T0? arg0)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0)));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0>(bool condition, string exceptionMessageFormat, Func<T0?> arg0)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0())));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1>(bool condition, string exceptionMessageFormat, T0? arg0, T1? arg1)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0), Format.Value(arg1)));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1>(bool condition, string exceptionMessageFormat, Func<T0?> arg0, Func<T1?> arg1)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0()), Format.Value(arg1())));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1, T2>(bool condition, string exceptionMessageFormat, T0? arg0, T1? arg1, T2? arg2)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0), Format.Value(arg1), Format.Value(arg2)));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1, T2>(bool condition, string exceptionMessageFormat, Func<T0?> arg0, Func<T1?> arg1, Func<T2?> arg2)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0()), Format.Value(arg1()), Format.Value(arg2())));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1, T2, T3>(bool condition, string exceptionMessageFormat, T0? arg0, T1? arg1, T2? arg2, T3? arg3)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0), Format.Value(arg1), Format.Value(arg2), Format.Value(arg3)));
        }
    }

    [StringFormatMethod("exceptionMessageFormat")]
    internal static void That<T0, T1, T2, T3>(bool condition, string exceptionMessageFormat, Func<T0?> arg0, Func<T1?> arg1, Func<T2?> arg2, Func<T3?> arg3)
    {
        if (!condition)
        {
            throw CreateException(string.Format(exceptionMessageFormat, Format.Value(arg0()), Format.Value(arg1()), Format.Value(arg2()), Format.Value(arg3())));
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