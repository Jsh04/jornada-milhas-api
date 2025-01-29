using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Flights;

public static class FlightErrors
{
    public static IError FlightAlreadyFull => new Error("FlightErrors.FlightAlreadyFull",
        "Voo já está lotado, procure outro horário", ErrorType.Validation);

    public static IError NotFound => new Error("FlightErrors.NotFound", "Voo não encontrado", ErrorType.NotFound);
    
    public static IError CannotBeDeleted => new Error("FlightErrors.CannotBeDeleted", "Erro ao deletar voo", ErrorType.Failure);
    
    public static IError CannotBeCreated => new Error("FlightErrors.CannotBeCreated", "Erro ao cadastrar voo", ErrorType.Failure);

    public static IError PlaneNotDefined => new Error("FlightErrors.PlaneNotDefined", "Avião não definido, por favor, procure outro voou", ErrorType.Validation);
}