using JornadaMilhas.API;
using JornadaMilhas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Apresentation;

[TestFixture]
public class FlightControllerTest
{
    [Test]
    public async Task GetAllDestiniesAsync_DeveraRetornarOk_PassandoUmaRequestValida()
    {
        var destinyServiceMock = new Mock<IFlightService>();

        var destinyController = new FlightController(destinyServiceMock.Object);

        //act
        var resultRequest = await destinyController.GetAllFlights();

        //assert
        Assert.That(resultRequest, Is.InstanceOf<OkObjectResult>());
        var okObject = resultRequest as OkObjectResult;
        Assert.That(okObject.Value, Is.Null);
    }
}