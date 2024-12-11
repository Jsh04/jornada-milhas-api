using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.ValueObjects.Locales;

public static class LocaleErrors
{
    public static IError CountryIsRequired => new Error("LocaleErrors.CountryIsRequired", "País não pode ser nula", ErrorType.Validation);

    public static IError CityIsRequired => new Error("LocaleErrors.CityIsRequired", "Cidade deve ser passado", ErrorType.Validation);

    public static IError LatitudeIsRequired => new Error("LocaleErrors.LatitudeIsRequired", "Latittude é obrigatório", ErrorType.Validation);

    public static IError LongitudeIsRequired => new Error("LogintudeIsRequired.LatitudeIsRequired", "Longitude é obrigatório", ErrorType.Validation);
}