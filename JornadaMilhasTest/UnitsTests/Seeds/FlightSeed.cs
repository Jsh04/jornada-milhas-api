using AutoFixture;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public static class FlightSeed
{
    public static Flight GetFlightTest(Fixture fixture)
    {
        return fixture.Build<Flight>()
            .FromFactory(CustomizeCreateFlight(fixture))
            .OmitAutoProperties()
            .Create();
    }

    public static IEnumerable<Flight> GetDestiniesByNumberOfObjects(Fixture fixture, int numberOfObjects)
    {
        return fixture.Build<Flight>()
            .FromFactory(CustomizeCreateFlight(fixture))
            .OmitAutoProperties()
            .CreateMany(numberOfObjects);
    }

    private static Func<Flight> CustomizeCreateFlight(Fixture fixture)
    {
        return () =>
        {
            var flight = FlightBuilder
                .Create()
                .AddDestiny(fixture.Create<string>(), fixture.Create<string>(), fixture.Create<string>(), fixture.Create<string>())
                .AddDepartureDate(fixture.Create<DateTime>())
                .AddFlightCode(Guid.NewGuid().ToString())
                .AddPlane(PlaneSeed.GetPlaneTest(fixture))
                .Build();

            return flight.Value;
        };
    }
    
    
}