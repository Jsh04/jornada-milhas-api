using AutoFixture;
using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Core.Entities.Depoiments;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.DtoExtensionsTest;

[TestFixture]
public class DtoExtensionTest
{

    private readonly Fixture fixture;
    public DtoExtensionTest()
    {
        fixture = new Fixture();
    }

    [Test]
    public void DeveraCriarObjetoDtoApartirDeUmObjetoDepoimento()
    {
        //arrange
        var depoimentTest = Depoiment.Create(fixture.Create<string>(), fixture.Create<string>(), fixture.Create<byte[]>(), fixture.Create<long>()).ValueOrDefault;

        //act
        var depoimentDto = DtoExtensions<Depoiment, DepoimentDto>.ToDto(depoimentTest);

        //assert
        Assert.That(depoimentDto.Name, Is.EqualTo(depoimentTest.Name));

    }

}
