using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Planes;

public static class PlaneErrors
{
    public static IError PlaneNotFound =>
        new Error("PlaneErrors.PlaneNotFound", "Avião não encontrado", ErrorType.NotFound);
}