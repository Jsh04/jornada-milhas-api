using AutoFixture;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhasTest.UnitsTests.Seeds;
using MockQueryable.Moq;
using Moq;


namespace JornadaMilhasTest.UnitsTests.Infraestruture.Persistence.ContextsMock
{
    public class ContextDestinyMock : JornadaMilhasContextMock<Destiny>
    {
        private readonly List<Destiny> SeedObjects;
        private ContextDestinyMock(Fixture fixture, int numberObjects, List<Destiny>? seedCustom = default) : base(fixture)
        {
            SeedObjects = seedCustom ?? DestinySeed.GetDestiniesByNumberOfObjects(fixture, numberObjects).ToList();
        }

        public static ContextDestinyMock CreateInstance(Fixture fixture, int numberObjects = 10) => new(fixture, numberObjects);

        public override JornadaMilhasContextMock<Destiny> AddDbSetDestiny()
        {
            var dbSetDestiny = SeedObjects.AsQueryable().BuildMockDbSet();

            _mockDbContext.Setup(x => x.Destinos).Returns(dbSetDestiny.Object);

            return this;
        }

        public override JornadaMilhasContextMock<Destiny> AddDbSetEventAddObject(Destiny destiny)
        {
            _mockDbContext.Setup(x => x.Destinos.Add(It.IsAny<Destiny>())).Callback<Destiny>(destino => SeedObjects.Add(destiny));

            return this;
        }

        public override Mock<JornadaMilhasDbContext> Build()
        {
            return _mockDbContext;
        }
    }
}
