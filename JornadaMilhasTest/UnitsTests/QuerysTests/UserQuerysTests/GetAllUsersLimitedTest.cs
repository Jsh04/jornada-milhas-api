using AutoFixture;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetAllUsers;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetAllUsersLimited;
using JornadaMilhasTest.UnitsTests.Builders;

namespace JornadaMilhasTest.UnitsTests.QuerysTests.UserQuerysTests
{
    [TestFixture]
    public class GetAllUsersLimitedTest
    {
        private readonly Fixture _fixture;

        public GetAllUsersLimitedTest()
        {
            _fixture = SharingResources.AutoFixture;
        }

        [Test]
        public async Task DeveraRetornarUsuariosPassandoOsParametrosCorretosQuandoSolicitadoTodos()
        {
            //arrange
            var mockUserRepositoryTask = await UserLimitedRepositoryMockBuilder.CreateBuilder(_fixture).WithGetAllUsersAsync(10);
            var mockUserRepository = mockUserRepositoryTask.Build();
            var getUsersHandler = new GetAllUserLimtedQueryHandler(mockUserRepository.Object);
            var getUserRequest = new GetAllUsersLimitedQuery(1, 10);
            //act
            var result = await getUsersHandler.Handle(getUserRequest, CancellationToken.None);

            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Has.No.Empty);

        }
    }
}
