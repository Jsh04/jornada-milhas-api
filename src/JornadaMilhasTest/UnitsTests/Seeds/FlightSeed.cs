using AutoFixture;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public static class FlightSeed
{
    public static Func<Flight> CustomizeCreateFlight(Fixture fixture, Plane plane = null, Destination destination = null)
    {
        return () =>
        {
            var flight = FlightBuilder
                .Create()
                .AddDestiny(destination)
                .AddDepartureDate(fixture.Create<DateTime>())
                .AddFlightCode(Guid.NewGuid().ToString())
                .AddPlane(plane)
                .Build();

            return flight.Value;
        };
    }
    
    
}