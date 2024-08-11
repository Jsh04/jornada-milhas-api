using AutoFixture;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Builders
{
    public class UnitOfWorkBuilder : BaseMockBuilder<IUnitOfWork>
    {
        public static UnitOfWorkBuilder CreateBuilder() => new();
        public override IUnitOfWork Build()
        {
            return _mock.Object;
        }
    }
}
