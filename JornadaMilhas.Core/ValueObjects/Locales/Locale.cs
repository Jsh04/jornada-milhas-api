using System.Text.Json.Serialization;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Flights;

namespace JornadaMilhas.Core.ValueObjects.Locales;

public record Locale
{
    public string Country { get; }

    public string City { get; }

    public string Latitude { get; }

    public string Longitude { get; }


    private Locale(string country, string city, string latitude, string longitude)
    {
        Country = country;
        City = city;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Result<Locale> Create(string country, string city, string latitude, string longitude)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Result.Fail<Locale>(LocaleErrors.CountryIsRequired);

        if (string.IsNullOrEmpty(city))
            return Result.Fail<Locale>(LocaleErrors.CityIsRequired);

        if (string.IsNullOrEmpty(latitude))
            return Result.Fail<Locale>(LocaleErrors.LatitudeIsRequired);

        if (string.IsNullOrEmpty(longitude))
            return Result.Fail<Locale>(LocaleErrors.LongitudeIsRequired);

        var locale = new Locale(country, city, latitude, longitude);

        return Result.Ok(locale);
    }
}