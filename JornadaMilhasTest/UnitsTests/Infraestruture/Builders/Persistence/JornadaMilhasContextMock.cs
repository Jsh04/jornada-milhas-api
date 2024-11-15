
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace JornadaMilhasTest.UnitsTests.Infraestruture.Persistence.ContextsMock
{
    public class JornadaMilhasContextMock<TEntity> where TEntity : BaseEntity
    {
        private readonly Mock<JornadaMilhasDbContext> _mockDbContext;

        private readonly ICollection<TEntity> _seedObjects;

        private readonly Expression<Func<JornadaMilhasDbContext, DbSet<TEntity>>> _expression;

        private JornadaMilhasContextMock(ICollection<TEntity> seedObjects, Expression<Func<JornadaMilhasDbContext, DbSet<TEntity>>> expression)
        {
            _mockDbContext = new Mock<JornadaMilhasDbContext>();
            _seedObjects = seedObjects;
            _expression = expression;
        }

        public static JornadaMilhasContextMock<TEntity> CreateInstance(ICollection<TEntity> seedObjects, Expression<Func<JornadaMilhasDbContext, DbSet<TEntity>>> expression) => new(seedObjects, expression);

        public JornadaMilhasContextMock<TEntity> AddDbSet()
        {
            var dbSetMocked = GetMockDbSet().Object;
            _mockDbContext.Setup(_expression).Returns(dbSetMocked);

            return this;
        }

        public JornadaMilhasContextMock<TEntity> AddDbSetEventAddObject(TEntity entity)
        {
            var mockDbSet = GetMockDbSet();

            mockDbSet.Setup(m => m.AddAsync(entity, It.IsAny<CancellationToken>()))
                .ReturnsAsync((TEntity entity, CancellationToken cancellationToken) =>
                {
                    _seedObjects.Add(entity);
                    return null;
                });

            _mockDbContext.Setup(_expression).Returns(mockDbSet.Object);

            return this;
        }

        public Mock<JornadaMilhasDbContext> Build()
        {
            return _mockDbContext;
        }

        private Mock<DbSet<TEntity>> GetMockDbSet()
        {
            return _seedObjects.AsQueryable().BuildMockDbSet();
        }

    }
}
