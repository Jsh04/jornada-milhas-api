using AutoFixture;
using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Core.Entities.Depoiments;

namespace JornadaMilhasTest.UnitsTests.DtoExtensionsTest;

[TestFixture]
public class DtoExtensionTest
{
    private readonly Fixture fixture;

    public DtoExtensionTest()
    {
        fixture = SharingResources.AutoFixture;
    }

    [Test]
    public void DeveraCriarObjetoDtoApartirDeUmObjetoDepoimento()
    {
        //arrange
        var depoimentTest = Depoiment.Create(fixture.Create<string>(), fixture.Create<string>(), fixture.Create<long>()).ValueOrDefault;

        //act
        var depoimentDto = DtoExtensions<Depoiment, DepoimentDto>.ToDto(depoimentTest);

        //assert
        Assert.That(depoimentDto.Name, Is.EqualTo(depoimentTest.Name));
    }
}