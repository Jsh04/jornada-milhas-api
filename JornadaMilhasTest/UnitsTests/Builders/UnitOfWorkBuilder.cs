using AutoFixture;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override IUnitOfWork Build()
        {
            return _mock.Object;
        }


    }
}
