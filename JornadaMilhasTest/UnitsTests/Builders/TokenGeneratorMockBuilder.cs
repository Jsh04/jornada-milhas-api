using AutoFixture;
using JornadaMilhas.Infrastruture.Security;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Builders
{
    public class TokenGeneratorMockBuilder : BaseMockBuilder<ITokenGenerator>
    {
        private readonly Fixture _fixture;

        public TokenGeneratorMockBuilder(Fixture fixture)
        {
            _fixture = fixture;
        }

        public TokenGeneratorMockBuilder AddGenerateToken()
        {
            _mock.Setup(x => x.GenerateToken(It.IsAny<IEnumerable<Claim>>())).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c") ;

            return this;
        }

        public override Mock<ITokenGenerator> Build()
        {
            return _mock;
        }
    }
}
