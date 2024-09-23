using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using JornadaMilhas.Core.Entities.Companies;
using static NUnit.Framework.Assert;

namespace JornadaMilhasTest.UnitsTests.Domain.CompanyTests
{
    [TestFixture]
    public class CompanyTest
    {
        private readonly Fixture _fixture;

        public CompanyTest()
        {
            _fixture = SharingResources.AutoFixture;
        }

        [Test]
        public void DeverarRetornarSucessoPassandoOsDadosCorretosQuandoCriarObjetoCompany()
        {
            //arrange
            var name = _fixture.Create<string>();
            var description = _fixture.Create<string>();
            var codeCompany = _fixture.Create<string>();

            //act 
            var result = Company.Create(name, description, codeCompany);

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Value?.Name, Is.EqualTo(name));
                Assert.That(result.Success, Is.True);
            });
        }
    }
}
