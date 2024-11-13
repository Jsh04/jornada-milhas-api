using JornadaMilhas.Infrastruture.Persistence.UOW;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Builders
{
    public class UnitOfWorkBuilder : BaseMockBuilder<IUnitOfWork>
    {
        public static UnitOfWorkBuilder CreateBuilder() => new();

        public BaseMockBuilder<IUnitOfWork> AddCompleteAsync(int numberToOperation)
        {
            _mock.Setup(unit => unit.CompleteAsync(It.IsAny<CancellationToken>())).ReturnsAsync(numberToOperation);
            return this;
        }

        public BaseMockBuilder<IUnitOfWork> AddCommitAsync(Task result)
        {
            _mock.Setup(x => x.CommitAsync(It.IsAny<CancellationToken>())).Returns(result);
            return this;
        }

        public override Mock<IUnitOfWork> Build()
        {
            return _mock;
        }
    }
}
