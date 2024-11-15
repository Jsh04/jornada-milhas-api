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
            var country = _fixture.Create<string>();
            var dateFoundation = _fixture.Create<DateTime>();

            //act 
            var result = Company.Create(name, country, dateFoundation);

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Value?.Name, Is.EqualTo(name));
                Assert.That(result.Success, Is.True);
            });
        }
    }
}
