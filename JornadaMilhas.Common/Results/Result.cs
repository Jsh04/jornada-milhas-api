using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Common.Results;

public class Result : ResultBase
{
    protected Result()
    {
    }

    protected Result(IError error)
    {
        _errors.Add(error);
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors is null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        _errors.AddRange(errors);
    }

    public static Result Ok()
    {
        return new Result();
    }

    public static Result Fail(IError error)
    {
        return new Result(error);
    }

    public static Result Fail(IEnumerable<IError> errors)
    {
        return new Result(errors);
    }

    public static Result<TValue> Ok<TValue>(TValue value)
    {
        return Result<TValue>.Ok(value);
    }

    public static Result<TValue> Fail<TValue>(IError error)
    {
        return Result<TValue>.Fail<TValue>(error);
    }

    public static Result<TValue> Fail<TValue>(IEnumerable<IError> errors)
    {
        return Result<TValue>.Fail<TValue>(errors);
    }
}

public class Result<TValue> : ResultBase<TValue>
{
    protected Result(TValue value)
    {
        _value = value;
    }

    protected Result(IError error)
    {
        _errors.Add(error);
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors == null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        _errors.AddRange(errors);
    }

    public static Result<TValue> Ok<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }

    public static Result<TValue> Fail<TValue>(IError error)
    {
        return new Result<TValue>(error);
    }

    public static Result<TValue> Fail<TValue>(IEnumerable<IError> errors)
    {
        return new Result<TValue>(errors);
    }
}