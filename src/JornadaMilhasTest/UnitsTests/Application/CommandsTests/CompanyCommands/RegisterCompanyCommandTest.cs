using AutoFixture;
using JornadaMilhas.Application.Commands.CompanyCommands.RegisterCompany;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhasTest.UnitsTests.Builders;
using static NUnit.Framework.Assert;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.CompanyCommands;

[TestFixture]
public class RegisterCompanyCommandTest
{
    private readonly Fixture _fixture;

    public RegisterCompanyCommandTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task Handle_DeverarRetornarOk_PassandoOsDadosCorretos()
    {
        var unitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
        var companyRepository = CompanyRepositoryMockBuilder.CreateBuilder(_fixture).Build();
        var companyHandler = new RegisterCompanyCommandHandler(companyRepository.Object, unitOfWork.Object);

        var companyCommand =
            new RegisterCompanyCommand("Company1", _fixture.Create<string>(), _fixture.Create<DateTime>());

        //act 
        var result = await companyHandler.Handle(companyCommand, CancellationToken.None);

        //assert
        That(result.Success, Is.True);
    }
    
}