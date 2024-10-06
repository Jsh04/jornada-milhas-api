using AutoFixture;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhasTest.UnitsTests.Seeds;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System.Xml;


namespace JornadaMilhasTest.UnitsTests.Infraestruture.Persistence
{
    public class JornadaMilhasContextMock
    {
        private readonly Mock<JornadaMilhasDbContext> _mockDbContext;

        private readonly Fixture _fixture;

        private JornadaMilhasContextMock(Fixture fixture)
        {
            _mockDbContext = new Mock<JornadaMilhasDbContext>();
            _fixture = fixture;
           
        }
        public static JornadaMilhasContextMock CreateInstance(Fixture fixture) => new(fixture);

        public JornadaMilhasContextMock AddDbSetDestiny(int numberObjects)
        {
            var dbSetDestiny = GetDbSetToMock(numberObjects);
            _mockDbContext.Setup(x => x.Destinos).Returns(dbSetDestiny.Object);

            return this;
        }

        public Mock<JornadaMilhasDbContext> Build()
        {
            return _mockDbContext;
        }

        private Mock<DbSet<Destiny>> GetDbSetToMock(int numberObjects)
        {
            return DestinySeed.GetDestiniesByNumberOfObjects(_fixture, numberObjects)
                .AsQueryable().BuildMockDbSet();
        }
    }
}
