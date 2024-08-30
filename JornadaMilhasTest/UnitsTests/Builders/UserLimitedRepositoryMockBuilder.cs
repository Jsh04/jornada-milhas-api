﻿using AutoFixture;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Helper;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Builders
{
    public class UserLimitedRepositoryMockBuilder : BaseMockBuilder<IUserLimitedRepository>
    {

        private readonly Fixture _fixture;

        private UserLimitedRepositoryMockBuilder(Fixture fixture) : base()
        {
            _fixture = fixture;
        }

        public static UserLimitedRepositoryMockBuilder CreateBuilder(Fixture fixture) => new (fixture);

        public UserLimitedRepositoryMockBuilder AddGetByIdAsync()
        {
            _mock.Setup(repository => repository.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>())).ReturnsAsync(UnitTestHelper.GetUserLimitedTest(_fixture));

            return this;
        }

        public UserLimitedRepositoryMockBuilder AddNotUniqueAsync(bool isExists)
        {
            _mock.Setup(repository => repository.IsUniqueAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(isExists);

            return this;
        }

        public async Task<UserLimitedRepositoryMockBuilder> WithGetAllUsersAsync(int numberToCreate,int size = 10, int page = 1)
        {
            _mock.Setup(x => x.GetAllAsync(page, size, It.IsAny<CancellationToken>())).ReturnsAsync(await UnitTestHelper.GetAllUsersFakeData(_fixture, 10, page, size));
            return this;
        }


        public UserLimitedRepositoryMockBuilder AddVerifyCreateMethod()
        {
            _mock.Verify(x => x.Create(It.IsAny<UserLimited>()), Times.Once);

            return this;
        }

        public override IUserLimitedRepository Build()
        {
            return _mock.Object;
        }
    }
}
