using AutoFixture;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Planes;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public static class PlaneSeed
{
    public static Plane GetPlaneTest(Fixture fixture)
    {
        return fixture.Build<Plane>()
            .FromFactory(CustomizeCreatePlane(fixture))
            .OmitAutoProperties()
            .Create();
    }

    private static Func<Plane> CustomizeCreatePlane(Fixture fixture)
    {
        return () =>
        {
            var plane = PlaneBuilder.Create()
                .WithBusinessClass(new BusinessClass(40, 200, 0))
                .WithEconomicClass(new EconomicClass(40, 150, 0))
                .Build();
            
            return plane.Value;
        };
    }
}