using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Result.Errors;

public interface IError
{
    int Code { get; init; }
    string Message { get; init; }
    public ErrorType Type { get; init; }
}
