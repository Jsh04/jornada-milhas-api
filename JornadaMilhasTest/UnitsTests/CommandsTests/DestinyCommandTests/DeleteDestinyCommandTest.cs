using JornadaMilhasTest.UnitsTests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.CommandsTests.DestinyCommandTests;

[TestFixture]
public class DeleteDestinyCommandTest
{
    public DeleteDestinyCommandTest()
    {
        
    }

    [Test]
    public void DeveraRetornarSucessoPassandoOIdCorretoQuandoDeletarDestino()
    {
        var unitOfWork = UnitOfWorkBuilder.CreateBuilder().Build();
    }


}
