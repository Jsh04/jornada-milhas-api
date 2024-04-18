﻿using JornadaMilhas.Common.Result.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Result;

public interface IResultBase
{
    IReadOnlyList<IError> Errors { get; }
    bool Success { get; }
}

public abstract class ResultBase : IResultBase
{
    public IReadOnlyList<IError> Errors => _errors.ToList().AsReadOnly();

    public bool Success => _errors.Count == 0;

    protected readonly List<IError> _errors = new();
}

public abstract class ResultBase<TValue> : ResultBase
{
    public TValue? Value => _value;
    public TValue? ValueOrDefault => _value ?? default;

    protected TValue? _value;
}

