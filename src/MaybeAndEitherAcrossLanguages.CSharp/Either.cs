namespace MaybeAndEitherAcrossLanguages.CSharp;

public static class Either
{
    public static Either<TLeft, TRight> Left<TLeft, TRight>(TLeft value)
        => new Either<TLeft, TRight>.Left(value);

    public static Either<TLeft, TRight> Right<TLeft, TRight>(TRight value)
        => new Either<TLeft, TRight>.Right(value);
}

public abstract class Either<TLeft, TRight>
{
    private Either()
    {
    }

    public sealed class Left : Either<TLeft, TRight>
    {
        public Left(TLeft value)
        {
            Value = value;
        }

        public TLeft Value { get; }
    }

    public sealed class Right : Either<TLeft, TRight>
    {
        public Right(TRight value)
        {
            Value = value;
        }

        public TRight Value { get; }
    }
}

public static class EitherExtensions
{
    public static TOut Fold<TLeftIn, TRightIn, TOut>(
        this Either<TLeftIn, TRightIn> result,
        Func<TLeftIn, TOut> left,
        Func<TRightIn, TOut> right)
    {
        return result switch
        {
            Either<TLeftIn, TRightIn>.Left error => left(error.Value),
            Either<TLeftIn, TRightIn>.Right success => right(success.Value),
            _ => throw CreateUnexpectedResultTypeException(nameof(result))
        };
    }

    public static Either<TLeft, TRightOut> Map<TLeft, TRightIn, TRightOut>(
        this Either<TLeft, TRightIn> result,
        Func<TRightIn, TRightOut> right)
    {

        return result switch
        {
            Either<TLeft, TRightIn>.Left error => Either.Left<TLeft, TRightOut>(error.Value),
            Either<TLeft, TRightIn>.Right success => Either.Right<TLeft, TRightOut>(right(success.Value)),
            _ => throw CreateUnexpectedResultTypeException(nameof(result))
        };
    }

    public static Either<TLeft, TRight> Do<TLeft, TRight>(
        this Either<TLeft, TRight> result,
        Action<TRight> action)
    {
        if (result is Either<TLeft, TRight>.Right right)
        {
            action(right.Value);
        }

        return result;
    }

    public static Either<TLeft, TRightOut> FlatMap<TLeft, TRightIn, TRightOut>(
        this Either<TLeft, TRightIn> result,
        Func<TRightIn, Either<TLeft, TRightOut>> right)
    {

        return result switch
        {
            Either<TLeft, TRightIn>.Left error => Either.Left<TLeft, TRightOut>(error.Value),
            Either<TLeft, TRightIn>.Right success => right(success.Value),
            _ => throw CreateUnexpectedResultTypeException(nameof(result))
        };
    }

    private static Exception CreateUnexpectedResultTypeException(string parameterName)
        => new ArgumentOutOfRangeException(
            parameterName,
            "Should never happen -> Either is always Left or Right");
}