﻿using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Common.Results;

public interface IResultBase
{
    IReadOnlyList<IError> Errors { get; }
    bool Success { get; }
}

public abstract class ResultBase : IResultBase
{
    public IReadOnlyList<IError> Errors => _errors.AsReadOnly();

    public bool Success => _errors.Count == 0;

    protected readonly List<IError> _errors = new();
}

public abstract class ResultBase<TValue> : ResultBase
{
    public TValue? Value => _value;
    public TValue? ValueOrDefault => _value ?? default;

    protected TValue? _value;
}

