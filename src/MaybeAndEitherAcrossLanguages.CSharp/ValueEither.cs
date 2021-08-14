using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaybeAndEitherAcrossLanguages.CSharp;


public struct ValueEither<TLeft, TRight>
{
    private readonly TLeft _left;
    private readonly TRight _right;
    private readonly bool _isRight;

    public ValueEither(TLeft left)
    {
        _left = left;
        _right = default!;
        _isRight = false;
    }

    public ValueEither(TRight right)
    {
        _left = default!;
        _right = right;
        _isRight = false;
    }

    public bool TryGetRight([MaybeNullWhen(false)] out TRight value)
    {
        value = _isRight ? _right : default;
        return _isRight;
    }

    public bool TryGetLeft([MaybeNullWhen(false)] out TLeft value)
    {
        value = !_isRight ? _left : default;
        return !_isRight;
    }
}

public static class ValueEitherExtensions
{
    public static ValueEither<TLeft, TRightOut> Map<TLeft, TRightIn, TRightOut>(
        this ValueEither<TLeft, TRightIn> result,
        Func<TRightIn, TRightOut> right)
    {
        if (result.TryGetRight(out var success))
        {
            return new ValueEither<TLeft, TRightOut>(right(success));
        }

        if (result.TryGetLeft(out var error))
        {
            return new ValueEither<TLeft, TRightOut>(error);
        }

        throw CreateUnexpectedResultTypeException(nameof(result));
    }

    public static ValueEither<TLeft, TRight> Do<TLeft, TRight>(
        this ValueEither<TLeft, TRight> result,
        Action<TRight> action)
    {
        if (result.TryGetRight(out var right))
        {
            action(right);
        }

        return result;
    }

    private static Exception CreateUnexpectedResultTypeException(string parameterName)
        => new ArgumentOutOfRangeException(
            parameterName,
            "Should never happen -> Either is always Left or Right");
}
