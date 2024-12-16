using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.ValueObjects;
using JornadaMilhas.Core.ValueObjects.Locales;
using System.Diagnostics.Metrics;

namespace JornadaMilhas.Core.Entities.Flights;

public class FlightBuilder : Builder<Flight, FlightBuilder>
{
    public DateTime DepartureDate { get; private set; }

    public DateTime LandingDate  { get; private set; }
    
    public string FlightCode  { get; private set; }

    public Locale Destiny  { get; private set; }
    
    
    public Locale Source  { get; private set; }
    
    public Plane Plane  { get; private set; }
    
    
    protected List<Picture> Images = new();
    
    public static FlightBuilder Create() => new();

    public FlightBuilder AddDestiny(string country, string city, string latitude, string longitude)
    {
        var destiny = CreateLocale(country, city, latitude, longitude);

        if (destiny is not null)
            Destiny = destiny;

        return this;
    }

    public FlightBuilder AddSource(string country, string city, string latitude, string longitude)
    {
        var source = CreateLocale(country, city, latitude, longitude);

        if (source is not null)
            Source = source;

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
    public override Result<Flight> Build()
    {
        if (_errors.Count > 0)
            return Result.Fail<Flight>(_errors);

        var flight = Flight
            .Create(this);

        return Result.Ok(flight);
    }

    private Locale? CreateLocale(string country, string city, string latitude, string longitude)
    {
        var result = Locale.Create(country, city, latitude, longitude);

        if (result.Success)
            return result.Value;

        _errors.AddRange(_errors);

        return result.ValueOrDefault;
    }
}