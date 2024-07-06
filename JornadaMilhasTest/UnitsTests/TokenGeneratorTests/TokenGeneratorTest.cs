using JornadaMilhas.Infrastruture.Security;
using JornadaMilhasTest.UnitsTests.Helper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using JornadaMilhas.Common.Entities;
using System.Security.Claims;

namespace JornadaMilhasTest.UnitsTests.TokenGeneratorTests
{
    [TestFixture]
    public class TokenGeneratorTest
    {
        private Fixture _fixture;

        public TokenGeneratorTest()
        {
            _fixture = new Fixture();
        }
        [Test]
        public void DeveraRetornarTokenQuandoPassadoUsuario()
        {
            
        }
    }
}
