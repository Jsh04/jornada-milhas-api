using AutoFixture;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Helper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Builders
{
    public class DestinyRepositoryMockBuilder : BaseMockBuilder<IRepositoryDestino>
    {
        private readonly Fixture _fixture;

        public static DestinyRepositoryMockBuilder Create(Fixture fixture) => new DestinyRepositoryMockBuilder(fixture);

        private DestinyRepositoryMockBuilder(Fixture fixture) : base()
        {
            _fixture = fixture;
        }

        public DestinyRepositoryMockBuilder AddGetDestinyById(long id)
        {
            _mock.Setup(x => x.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(UnitTestHelper.GetDestinyTest(_fixture));
            return this;
        }


        public override Mock<IRepositoryDestino> Build()
        {
            return _mock;
        }
    }
}
