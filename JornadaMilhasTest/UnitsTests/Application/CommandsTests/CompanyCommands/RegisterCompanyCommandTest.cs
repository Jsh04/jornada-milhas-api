using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using JornadaMilhas.Application.Commands.CompanyCommands.RegisterCompany;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhasTest.UnitsTests.Builders;
using static NUnit.Framework.Assert;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.CompanyCommands
{
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

            var companyCommand = new RegisterCompanyCommand("Company1", _fixture.Create<string>(), _fixture.Create<DateTime>());

            //act 
            var result = await companyHandler.Handle(companyCommand, CancellationToken.None);

            //assert
            That(result.Success, Is.True);
        }

        [Test]
        public async Task Handle_DeverarRetornarFalha_PassandoONomeNuloOuVazio()
        {
            var unitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
            var companyRepository = CompanyRepositoryMockBuilder.CreateBuilder(_fixture).Build();
            var companyHandler = new RegisterCompanyCommandHandler(companyRepository.Object, unitOfWork.Object);

            var companyCommand = new RegisterCompanyCommand("", _fixture.Create<string>(), _fixture.Create<DateTime>());

            //act 
            var resulted = await companyHandler.Handle(companyCommand, CancellationToken.None);
            
            //assert
            Assert.Multiple(() =>
            {
                That(resulted.Success, Is.False);
                That(resulted.Errors, Has.Count);
                That(resulted.Errors[0].Type, Is.EqualTo(ErrorType.Validation));
            });
            
        }
    }
}
