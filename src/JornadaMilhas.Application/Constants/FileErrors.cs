using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Application.Constants;

public static class FileErrors
{
    public static IError CannotUploadFile => new Error("FileErrors.CannotUploadFile",
        "Não foi possível salvar o arquivo, tente novamente mais tarde", ErrorType.Failure);
}