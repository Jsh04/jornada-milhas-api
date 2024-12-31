using FluentAssertions;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Passages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        var plane = Plane

        var flight = FlightBuilder.Create()
            .AddPlane(PLane)
            .Build().Value;

        var passage = PassageBuilder.Create()
            .Build().Value;

        //act
        var result = flight.BuyPassageInFlight(passage);

        //assert
        result.Success.Should().BeFalse();
    }
}

