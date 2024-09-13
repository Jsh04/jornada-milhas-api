﻿using JornadaMilhas.Common.Options;
using JornadaMilhas.Infrastruture.Security;
using JornadaMilhasTest.UnitsTests.Helper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Builders
{
    public class TokenGeneratorBuilder
    {
        private readonly TokenOptions _tokenOptions;

        public TokenGeneratorBuilder()
        {
            _tokenOptions = Options.Create(new TokenOptions() { SecretKey = UnitTestHelper.GenerateSecretKey() }).Value;
        }

        public static TokenGeneratorBuilder CreateInstance() => new();

        public ITokenGenerator Build()
        {
           return new TokenGenerator(Options.Create(_tokenOptions), new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler());
        }
    }
}
