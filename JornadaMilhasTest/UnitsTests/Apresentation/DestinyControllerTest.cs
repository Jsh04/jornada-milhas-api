using JornadaMilhas.API;
using JornadaMilhas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Apresentation;

[TestFixture]
public class DestinyControllerTest
{
    [Test]
    public async Task GetAllDestiniesAsync_DeveraRetornarOk_PassandoUmaRequestValida()
    {
        var destinyServiceMock = new Mock<IDestinyService>();

        var destinyController = new DestinyController(destinyServiceMock.Object);

        //act
        var resultRequest = await destinyController.GetAllDestinies();

        //assert
        Assert.That(resultRequest, Is.InstanceOf<OkObjectResult>());
        var okObject = resultRequest as OkObjectResult;
        Assert.That(okObject.Value, Is.Null);
    }
}