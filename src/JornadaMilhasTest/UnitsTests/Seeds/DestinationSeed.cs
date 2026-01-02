using AutoFixture;
using AutoFixture.Kernel;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public class DestinationSeed
{
    private static Func<Destination> CustomizeCreateDestination(Fixture fixture)
    {
        return () =>
        {
            var destinationResult = DestinationBuilder
                .Create()
                .WithDescription(fixture.Create<string>())
                .WithLocale(fixture.Create<string>(), fixture.Create<string>(), fixture.Create<string>(), fixture.Create<string>())
                .WithTitle(fixture.Create<string>())
                .Build();

            return destinationResult.Value;
        };
    }
}