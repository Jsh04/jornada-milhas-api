using AutoFixture;
using JornadaMilhas.Application.Querys.UserQuerys.GetAllCustomers;
using JornadaMilhas.Core.Entities.Customers;
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
        var customers = _fixture.CreateMany<Customer>(10).AsQueryable();
        var mockUserRepositoryTask =
            CustomerRepositoryMockBuilder.CreateBuilder(customers).WithGetAllCustomersAsync(1, 10);
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