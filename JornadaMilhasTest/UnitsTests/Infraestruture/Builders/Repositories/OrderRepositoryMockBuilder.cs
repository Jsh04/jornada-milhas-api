using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Builders;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;

public class OrderRepositoryMockBuilder : BaseMockBuilder<IOrderRepository>
{
    public static OrderRepositoryMockBuilder Create() => new();
}