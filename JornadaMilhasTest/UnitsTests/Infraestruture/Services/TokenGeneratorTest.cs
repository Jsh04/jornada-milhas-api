using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Infrastruture.Security;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Helper;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Services
{
    [TestFixture]
    public class TokenGeneratorTest
    {

        private readonly Fixture _fixture;

        public TokenGeneratorTest()
        {
            _fixture = SharingResources.AutoFixture;
        }
        
        [Test]
        public void GenerateToken_DeveraRetornarToken_PassandoOsClaims()
        {
            //assert
            var tokenGenerate = TokenGeneratorBuilder.CreateInstance().Build();
            var userLimited = UnitTestHelper.GetUserLimitedTest(_fixture);

            var claims = UnitTestHelper.GetClaimsToTest(userLimited);
            
            //act
            var token = tokenGenerate.GenerateToken(claims);
            
            //assert
            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.TypeOf<string>());

        }
    }
}
