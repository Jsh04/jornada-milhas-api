using AutoFixture;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhasTest.UnitsTests.Seeds;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System.Xml;


namespace JornadaMilhasTest.UnitsTests.Infraestruture.Persistence
{
    public abstract class JornadaMilhasContextMock<TEntity> where TEntity : BaseEntity 
    {
        protected readonly Mock<JornadaMilhasDbContext> _mockDbContext;

        protected readonly Fixture _fixture;

        protected JornadaMilhasContextMock(Fixture fixture)
        {
            _mockDbContext = new Mock<JornadaMilhasDbContext>();
            _fixture = fixture;
        }

        public abstract JornadaMilhasContextMock<TEntity> AddDbSetDestiny();

        public abstract JornadaMilhasContextMock<TEntity> AddDbSetEventAddObject(Destiny destiny);

        public abstract Mock<JornadaMilhasDbContext> Build();

    }
}
