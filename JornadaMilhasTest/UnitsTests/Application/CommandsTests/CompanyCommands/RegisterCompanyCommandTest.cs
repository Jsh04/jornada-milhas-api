using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using JornadaMilhas.Application.Commands.CompanyCommands.RegisterCompany;
using JornadaMilhasTest.UnitsTests.Builders;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.CompanyCommands
{
    [TestFixture]
    public class RegisterCompanyCommandTest
    {
        private readonly Fixture _fixture;

        private RegisterCompanyCommandValidator _validator;

        public RegisterCompanyCommandTest()
        {
            _fixture = SharingResources.AutoFixture;
            _validator = new RegisterCompanyCommandValidator();
        }




        [Test]
        public async Task DeverarRetornarOkPassandoOsDadosCorretosQuandoNaoExistirRegistroNoBanco()
        {
            var unitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
            var companyRepository = CompanyRepositoryMockBuilder.CreateBuilder(_fixture).Build();
            var companyHandler = new RegisterCompanyCommandHandler(companyRepository.Object, unitOfWork.Object);

            var companyCommand = new RegisterCompanyCommand("Company1", "Company Description", _fixture.Create<string>());

            //act 
            var result = await companyHandler.Handle(companyCommand, CancellationToken.None);

            //assert
            Assert.That(result.Success, Is.True);
        }

        [Test]
        public async Task DeverarRetornarFalhaPassandoONomeNuloOuVazioQuandoNaoExistirRegistroNoBanco()
        {
            var unitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
            var companyRepository = CompanyRepositoryMockBuilder.CreateBuilder(_fixture).Build();
            var companyHandler = new RegisterCompanyCommandHandler(companyRepository.Object, unitOfWork.Object);

            var companyCommand = new RegisterCompanyCommand("", "Company Description", _fixture.Create<string>());

            //act 
            var resulted = await _validator.ValidateAsync(companyCommand);

            //assert
            Assert.That(resulted.IsValid, Is.False);
        }
    }
}
