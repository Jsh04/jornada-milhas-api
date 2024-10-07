using AutoFixture;
using JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhasTest.UnitsTests.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.DestinyCommandTests;

[TestFixture]
public class DeleteDestinyCommandTest
{
    private readonly Fixture _fixture;
    public DeleteDestinyCommandTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task DeveraRetornarSucessoPassandoOIdCorretoQuandoDeletarDestino()
    {
        var unitOfWorkMockObject = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
        var destinyRepositoryMockObject = DestinyRepositoryMockBuilder.Create(_fixture).AddGetDestinyById(1).Build();

        var deleteDestinyCommandHandler = new DeleteDestinyCommandHandler(unitOfWorkMockObject.Object, destinyRepositoryMockObject.Object);

        //act
        var result = await deleteDestinyCommandHandler.Handle(new DeleteDestinyCommand(1), CancellationToken.None);

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
        var destinyRepositoryMockObject = DestinyRepositoryMockBuilder.Create(_fixture).AddGetDestinyById(1).Build();

        var deleteDestinyCommandHandler = new DeleteDestinyCommandHandler(unitOfWorkMockObject.Object, destinyRepositoryMockObject.Object);

        //act
        var result = await deleteDestinyCommandHandler.Handle(new DeleteDestinyCommand(2), CancellationToken.None);

        //assert
        var errorMessage = result.Errors[0].Message;
        Assert.Multiple(() =>
        {
            StringAssert.AreEqualIgnoringCase(errorMessage, DestinyErrors.NotFound.Message);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
        });
    }
}

