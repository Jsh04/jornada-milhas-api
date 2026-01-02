using AutoFixture;
using JornadaMilhas.Core.Entities.Companies;
using static NUnit.Framework.Assert;

namespace JornadaMilhasTest.UnitsTests.Domain.CompanyTests;

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
        Multiple(() =>
        {
            That(result.Value?.Name, Is.EqualTo(name));
            That(result.Success, Is.True);
        });
    }
}