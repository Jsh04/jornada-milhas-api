﻿using AutoFixture;
using JornadaMilhas.Core.Entities.Destinies;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public static class DestinySeed
{
    public static Destiny GetDestinyTest(Fixture fixture)
    {
        return fixture.Build<Destiny>()
            .FromFactory(CustomizeCreateDestiny(fixture))
            .OmitAutoProperties()
            .Create();
    }

    public static IEnumerable<Destiny> GetDestiniesByNumberOfObjects(Fixture fixture, int numberOfObjects)
    {
        return fixture.Build<Destiny>()
            .FromFactory(CustomizeCreateDestiny(fixture))
            .OmitAutoProperties()
            .CreateMany(numberOfObjects);
    }

    private static Func<Destiny> CustomizeCreateDestiny(Fixture fixture)
    {
        return () =>
        {
            return Destiny.Create(
                fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<decimal>(),
                fixture.Create<string>(),
                fixture.Create<string>()).Value;
        };
    }
}