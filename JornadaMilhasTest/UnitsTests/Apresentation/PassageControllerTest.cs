using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using JornadaMilhas.API.Controllers;
using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.OrdersDto;
using JornadaMilhas.Common.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Apresentation;

[TestFixture]
public class PassageControllerTest
{
    private readonly ISpecimenBuilder _fixture;

    public PassageControllerTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task BuyPassage_ShouldReturnOk_WhenRequestIsCorrect()
    {
        //arrange
        var serviceMock = new Mock<IPassageService>();
        var userServiceMock = new Mock<IUserService>();

        userServiceMock.Setup(x => x.GetCustomerId())
            .Returns(Result.Ok(10L));

        serviceMock.Setup(x => x.PayPassagesAsync(It.IsAny<long>(), It.IsAny<List<PaidPassageInputModel>>()))
            .ReturnsAsync(Result.Ok<OrderDto>(null));
        
        var passageController = new PassageController(serviceMock.Object, userServiceMock.Object);

        var listPassageInputModel = _fixture.CreateMany<PaidPassageInputModel>(10).ToList();
        
        //act
        var result = await passageController.PostPayPassages(listPassageInputModel);
        
        //assert
        result.Should().BeOfType<OkResult>();
        var okResult = result as OkResult;
        okResult?.StatusCode.Should().Be(200);
    }
}