using AutoFixture;
using JornadaMilhas.Common.Entities;
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
    public class UserRepositoryMockBuilder : BaseMockBuilder<IUserRepository>
    {
        private readonly Fixture _fixture;

        private UserRepositoryMockBuilder(Fixture fixture) : base()
        {
            _fixture = fixture;
        }


        public static UserRepositoryMockBuilder CreateBuilder(Fixture fixture) => new(fixture);

        public UserRepositoryMockBuilder AddGetByIdAsync(long id)
        {
            _mock.Setup(repository => repository.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(UnitTestHelper.GetUserLimitedTest(_fixture));

            return this;
        }

        public UserRepositoryMockBuilder AddGetByEmailAsync(string email)
        {
            _mock.Setup(x => x.GetByEmailAsync(email, CancellationToken.None)).ReturnsAsync(UnitTestHelper.GetUserLimitedTest(_fixture));
            
            return this;
        }

        public override Mock<IUserRepository> Build()
        {
            return _mock;
        }
    }
}
