using AutoFixture;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.ValueObjects.Locales;
using JornadaMilhas.Infrastruture.Persistence.Repository;
using JornadaMilhasTest.UnitsTests.Infraestruture.Persistence.ContextsMock;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Persistence.RepositoryTests;

[TestFixture]
public class FlightRepositoryTest
{
    private readonly Fixture _fixture;
    
    public FlightRepositoryTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [TestCase(1, 10, 20)]
    [TestCase(2, 10, 20)]
    [TestCase(1, 5, 5)]
    public async Task GetAllAsync_DeveraRetornarAQuantidadeCertaSolicitado_QuandoChamadoNoRepositorio(int page,
        int size, int numberObjects)
    {
        //arrange
        var contextMock = JornadaMilhasContextMock<Flight>
            .CreateInstance(
                GenericSeed<Flight>.GetObjectCreatedByNumberObjects(_fixture, FlightSeed.CustomizeCreateFlight(_fixture), numberObjects).ToList(), x => x.Flights)
            .AddDbSet()
            .Build();
        var destinyRespository = new FlightRepository(contextMock.Object);

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
        contextMock.Verify(x => x.Flights, Times.Once);
    }

    [Test]
    public async Task Create_DeveraSerChamadoOMetodoCreateUmaVez_QuandoForCadastrar()
    {
        //arrange
        var destiny = GenericSeed<Flight>.GetObjectTest(_fixture, FlightSeed.CustomizeCreateFlight(_fixture));

        var contextMock = JornadaMilhasContextMock<Flight>.CreateInstance(
                GenericSeed<Flight>.GetObjectCreatedByNumberObjects(
                    _fixture, 
                    FlightSeed.CustomizeCreateFlight(_fixture), 
                    10).ToList(), 
                x => x.Flights)
            .AddDbSet()
            .AddDbSetEventAddObject(destiny)
            .Build();

        var destinyRespository = new FlightRepository(contextMock.Object);

        //act
        await destinyRespository.CreateAsync(destiny);
        var destinies = await destinyRespository.GetAllAsync(2);

        //assert
        Assert.That(destinies.Data, Has.Count.EqualTo(1));
    }
}