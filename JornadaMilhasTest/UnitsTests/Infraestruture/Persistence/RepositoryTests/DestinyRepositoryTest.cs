using AutoFixture;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.Repository;
using JornadaMilhasTest.UnitsTests.Infraestruture.Persistence.ContextsMock;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Persistence.RepositoryTests
{
    [TestFixture]
    public class DestinyRepositoryTest
    {
        private readonly Fixture _fixture;

        public DestinyRepositoryTest()
        {
            _fixture = SharingResources.AutoFixture;
        }

        [TestCase(1, 10, 20)]
        [TestCase(2, 10, 20)]
        [TestCase(1, 5, 5)]
        public async Task GetAllAsync_DeveraRetornarAQuantidadeCertaSolicitado_QuandoChamadoNoRepositorio(int page, int size, int numberObjects)
        {
            //arrange
            var contextMock = ContextDestinyMock.CreateInstance(_fixture, numberObjects).AddDbSetDestiny().Build();
            var destinyRespository = new DestinyRepository(contextMock.Object);

            //act
            var result = await destinyRespository.GetAllAsync(page, size);

            //assert
            
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Data, Has.Count.EqualTo(size));
                Assert.That(result.Data, Is.Not.Empty);
                Assert.That(result.PageSize, Is.EqualTo(size));
            });
            contextMock.Verify(x => x.Destinos, Times.Once);
        }

        [Test]
        public async Task Create_DeveraSerChamadoOMetodoCreateUmaVez_QuandoForCadastrar()
        {
            //arrange
            var destiny = DestinySeed.GetDestinyTest(_fixture);

            var contextMock = ContextDestinyMock.CreateInstance(_fixture).AddDbSetDestiny().AddDbSetEventAddObject(destiny).Build();

            var destinyRespository = new DestinyRepository(contextMock.Object);
            
            //act
            destinyRespository.Create(destiny);
            var destinies = await destinyRespository.GetAllAsync(page: 2);
            
            //assert
            Assert.That(destinies.Data, Has.Count.EqualTo(1));
        }


    }
}
