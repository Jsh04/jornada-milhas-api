using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Flights;

public static class FlightErrors
{

    public static IError FlightAlreadyFull => new Error("FlightErrors.FlightAlreadyFull",
        "Voo já está lotado, procure outro horário", ErrorType.Validation);
}