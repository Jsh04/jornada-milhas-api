using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.ValueObjects;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Core.Entities.Flights;

public class FlightBuilder : Builder<Flight, FlightBuilder>
{
    private DateTime DepartureDate;

    private DateTime LandingDate;

    private decimal BasePrice;

    private string FlightCode;

    private Locale Locale;

    private Plane Plane;

    private int MaxCountPassagens;

    protected List<Picture> Images = new();

    public static FlightBuilder Create() => new();

    public FlightBuilder AddLocale(string country, string city, string latitude, string longitude)
    {
        var result = Locale.Create(country, city, latitude, longitude);
        
        if (!result.Success)
            _errors.AddRange(_errors);
        else
            Locale = result.Value;

        return this;
    }

    public FlightBuilder AddFlightCode(string flightCode)
    {
        FlightCode = flightCode;
        return this;
    }

    public FlightBuilder AddPlane(Plane plane)
    {
        Plane = plane;
        return this;
    }

    public FlightBuilder AddDepartureDate(DateTime departureDate)
    {
        DepartureDate = departureDate;
        return this;
    }

    public FlightBuilder AddLandingDate(DateTime landingDate)
    {
        LandingDate = landingDate;
        return this;
    }

    public FlightBuilder AddLandingDate(DateTime landingDate)
    {
        LandingDate = landingDate;
        return this;
    }

    public override Result<Flight> Build()
    {
        if (_errors.Count > 0)
            return Result.Fail<Flight>(_errors);

        var destinyCreated = Flight
            .Create(Name, Subtitle, Price, DescriptionPortuguese, DescriptionEnglish);

        return destinyCreated;
    }
}