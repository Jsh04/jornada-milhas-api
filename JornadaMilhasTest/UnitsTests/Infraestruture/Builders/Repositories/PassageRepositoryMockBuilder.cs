using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Builders;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;

public class PassageRepositoryMockBuilder : BaseMockBuilder<IPassageRepository>
{
    public static PassageRepositoryMockBuilder Create() => new();
    
}