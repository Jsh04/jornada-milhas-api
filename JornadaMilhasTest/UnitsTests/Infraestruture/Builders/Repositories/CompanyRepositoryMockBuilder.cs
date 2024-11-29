using AutoFixture.Kernel;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Repositories.Interfaces;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Builders;

public class CompanyRepositoryMockBuilder : BaseMockBuilder<ICompanyRepository>
{
    private readonly ISpecimenBuilder _fixture;

    private CompanyRepositoryMockBuilder(ISpecimenBuilder fixture)
    {
        _fixture = fixture;
    }

    public static CompanyRepositoryMockBuilder CreateBuilder(ISpecimenBuilder fixture)
    {
        return new CompanyRepositoryMockBuilder(fixture);
    }

    public CompanyRepositoryMockBuilder AddCreate(Company company)
    {
        _mock.Setup(x => x.CreateAsync(company));
        return this;
    }

    public override Mock<ICompanyRepository> Build()
    {
        return _mock;
    }
}