using AutoFixture;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public static class DestinySeed
{
    public static Locale GetDestinyTest(Fixture fixture)
    {
        return fixture.Build<Locale>()
            .FromFactory(CustomizeCreateDestiny(fixture))
            .OmitAutoProperties()
            .Create();
    }

    public static IEnumerable<Locale> GetDestiniesByNumberOfObjects(Fixture fixture, int numberOfObjects)
    {
        return fixture.Build<Locale>()
            .FromFactory(CustomizeCreateDestiny(fixture))
            .OmitAutoProperties()
            .CreateMany(numberOfObjects);
    }

    private static Func<Locale> CustomizeCreateDestiny(Fixture fixture)
    {
        return () =>
        {
            return Locale.Create(
                fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<decimal>(),
                fixture.Create<string>(),
                fixture.Create<string>()).Value;
        };
    }
}