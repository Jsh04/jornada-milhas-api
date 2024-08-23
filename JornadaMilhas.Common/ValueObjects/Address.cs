using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Common.ValueObjects;

public sealed record Address
{
    public string City { get; }

    public string State { get; }

    public string? Cep { get; }

    public string? Adress { get; }

    public string? District { get; }

    private Address() { }

    private Address(string city, string state, string? cep, string? adress, string? district)
    {
        City = city;
        State = state;
        Cep = cep;
        Adress = adress;
        District = district;
    }

    public static Result<Address> Create(string city, string state, string? cep, string? addressRequest, string? district)
    {
        var cityFormated = city.Trim();

        if (string.IsNullOrWhiteSpace(cityFormated) || cityFormated.Length < 5)
            return Result.Fail<Address>(AddressErrors.CityIsTooShort);

        var stateFormated = city.Trim();

        if (string.IsNullOrWhiteSpace(stateFormated) || stateFormated.Length < 5)
            return Result.Fail<Address>(AddressErrors.StateIsTooShort);

        if (cep is not null && cep.Trim().Length < 8)
            return Result.Fail<Address>(AddressErrors.ZipCodeIsInvalid);
        
        if (addressRequest is not null && addressRequest.Trim().Length < 5)
            return Result.Fail<Address>(AddressErrors.StreetIsTooShort);

        if (district is not null && district.Trim().Length < 3)
            return Result.Fail<Address>(AddressErrors.CountryIsTooShort);

        var address = new Address(city, state, cep, addressRequest, district);

        return Result.Ok(address);
    }
    
    private static string FormatCep(string cep)
    {
        return cep.Trim().Replace("-", "");
    }
}

public sealed record AddressErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error StreetIsTooShort =
        new("Address.StreetIsTooShort", "Street is too short", ErrorType.Validation);

    public static readonly Error CityIsTooShort =
        new("Address.CityIsTooShort", "City is too short", ErrorType.Validation);

    public static readonly Error StateIsTooShort =
        new("Address.StateIsTooShort", "State is too short", ErrorType.Validation);

    public static readonly Error CountryIsTooShort =
        new("Address.CountryIsTooShort", "Country is too short", ErrorType.Validation);

    public static readonly Error ZipCodeIsInvalid =
        new("Address.ZipCodeIsInvalid", "Código CEP está inválido", ErrorType.Validation);
}
