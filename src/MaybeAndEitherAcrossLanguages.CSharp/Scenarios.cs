namespace MaybeAndEitherAcrossLanguages.CSharp;

public static class Scenarios
{
    public static Maybe<int> MaybeChain(int? value)
        => Maybe
            .FromNullable(value)
            .Map(v => v + 1)
            .Map(v => v + 1)
            .Map(v => v + 1)
            .Map(v => v + 1);

    public static Maybe<int> MaybeChainnWithClosure(int? value, int anotherValue)
        => Maybe
            .FromNullable(value)
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue);

    public static Either<string, int> EitherChain(int value)
        => (value > 0 ? Either.Right<string, int>(value) : Either.Left<string, int>("error"))
            .Map(v => v + 1)
            .Map(v => v + 1)
            .Map(v => v + 1)
            .Map(v => v + 1);

    public static Either<string, int> EitherChainWithClosure(int value, int anotherValue)
        => (value > 0 ? Either.Right<string, int>(value) : Either.Left<string, int>("error"))
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue);

    public static ValueEither<string, int> ValueEitherChain(int value)
        => (value > 0 ? new ValueEither<string, int>(value) : new ValueEither<string, int>("error"))
            .Map(v => v + 1)
            .Map(v => v + 1)
            .Map(v => v + 1)
            .Map(v => v + 1);

    public static ValueEither<string, int> ValueEitherChainWithClosure(int value, int anotherValue)
        => (value > 0 ? new ValueEither<string, int>(value) : new ValueEither<string, int>("error"))
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue)
            .Map(v => v + anotherValue);
}
