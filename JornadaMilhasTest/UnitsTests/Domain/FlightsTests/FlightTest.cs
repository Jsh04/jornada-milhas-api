using FluentAssertions;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Passages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Passages.Enums;
using JornadaMilhas.Core.Entities.Planes;

namespace JornadaMilhasTest.UnitsTests.Domain.FlightsTests;

[TestFixture]
public class FlightTest
{

    [Test]
    public void BuyPassageInFlight_ShouldBeError_WhenNotPassedPlaneInConstructor()
    {
        //arrange
        var flight = FlightBuilder.Create()
            .Build().Value;

        var passage = PassageBuilder.Create()
            .Build().Value;

        //act
        var result = flight.BuyPassageInFlight(passage);

        //assert
        result.Success.Should().BeFalse();
    }

    [Test]
    public void BuyPassageInFlight_ShouldBeSuccess_WhenBuyPassageInFlight()
    {
        //arrange

        var plane = PlaneBuilder.Create()
            .WithEconomicClass(new EconomicClass(40, 50, 0))
            .Build().Value;

        var flight = FlightBuilder.Create()
            .AddPlane(plane)
            .Build().Value;

        var passage = PassageBuilder.Create()
            .WithEnumTypePassage(EnumTypeClassPlane.Economic)
            .Build().Value;

        //act
        var result = flight.BuyPassageInFlight(passage);

        //assert
        result.Success.Should().BeTrue();
    }
}

