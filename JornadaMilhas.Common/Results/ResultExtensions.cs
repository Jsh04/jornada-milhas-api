using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Results;

public static class ResultExtensions
{
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<Result, T> onFailure) 
    {
        return result.Success ? onSuccess() : onFailure(result);
    }

    public static T Match<TValue, T>(this Result<TValue> result, Func<TValue?, T> onSuccess, Func<Result<TValue>, T> onFailure)
    {
        return result.Success ? onSuccess(result.ValueOrDefault) : onFailure.Invoke(result);
    }
}
