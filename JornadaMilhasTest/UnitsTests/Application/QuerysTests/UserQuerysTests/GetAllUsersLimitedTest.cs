using AutoFixture;
using JornadaMilhas.Application.Querys.UserQuerys.GetAllCustomers;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;

namespace JornadaMilhasTest.UnitsTests.Application.QuerysTests.UserQuerysTests;

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
        var mockUserRepositoryTask =
            CustomerRepositoryMockBuilder.CreateBuilder(_fixture).WithGetAllCustomersAsync(10);
        var mockUserRepository = mockUserRepositoryTask.Build();
        var getUsersHandler = new GetAllCustomersQueryHandler(mockUserRepository.Object);
        var getUserRequest = new GetAllCustomersQuery(1, 10);

        //act
        var result = await getUsersHandler.Handle(getUserRequest, CancellationToken.None);

        //assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Data, Has.No.Empty);
    }
}