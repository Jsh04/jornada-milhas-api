using AutoFixture;
using JornadaMilhas.Application.Commands.FlightCommands.DeleteFlight;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;
using JornadaMilhasTest.UnitsTests.Seeds;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.FlightCommandTests;

[TestFixture]
public class DeleteFlightCommandTest
{
    private readonly Fixture _fixture;

    public DeleteFlightCommandTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task DeveraRetornarSucessoPassandoOIdCorretoQuandoDeletarDestino()
    {
        var unitOfWorkMockObject = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
        
        var flight = FlightSeed.GetFlightTest(_fixture);
        var destinyRepositoryMockObject = FlightRepositoryMockBuilder.Create(_fixture).AddGetFlightById(flight).Build();

        var deleteDestinyCommandHandler =
            new DeleteFlightCommandHandler(unitOfWorkMockObject.Object, destinyRepositoryMockObject.Object);

        //act
        var result = await deleteDestinyCommandHandler.Handle(new DeleteFlightCommand(1), CancellationToken.None);

        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.Errors, Is.Empty);
        });
    }

    [Test]
    public async Task DeveraRetornarFalhaPassandoOIdErroQuandoDeletarDestino()
    {
        var unitOfWorkMockObject = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
        var destinyRepositoryMockObject = FlightRepositoryMockBuilder.Create(_fixture).AddGetFlightById(null).Build();

        var deleteDestinyCommandHandler =
            new DeleteFlightCommandHandler(unitOfWorkMockObject.Object, destinyRepositoryMockObject.Object);

        //act
        var result = await deleteDestinyCommandHandler.Handle(new DeleteFlightCommand(2), CancellationToken.None);

        //assert
        var errorMessage = result.Errors[0].Message;
        Assert.Multiple(() =>
        {
            StringAssert.AreEqualIgnoringCase(errorMessage, FlightErrors.NotFound.Message);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
        });
    }
}