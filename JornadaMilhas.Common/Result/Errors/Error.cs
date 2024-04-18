

namespace JornadaMilhas.Common.Result.Errors;

public sealed record Error(int Code, string Message, ErrorType Type) : IError
{
    public static readonly Error None = new(200, string.Empty, ErrorType.None);
}

