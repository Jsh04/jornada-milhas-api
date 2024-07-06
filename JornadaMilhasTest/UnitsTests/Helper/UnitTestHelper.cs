using AutoFixture;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Helper
{
    public static class UnitTestHelper
    {

        public static UserLimited GetUserLimitedTest(Fixture fixture, string email) => UserLimited.Create(
            fixture.Create<string>(), DateOfBirth.Create(DateTime.Now).Value,
            JornadaMilhas.Common.Enums.EnumGenre.Male,
            Cpf.Create(fixture.Create<string>()).Value,
            Phone.Create(fixture.Create<string>()).Value,
            Address.Create(fixture.Create<string>(),
            fixture.Create<string>(),
            fixture.Create<string>(),
            fixture.Create<string>(), fixture.Create<string>()).ValueOrDefault,
            fixture.Create<byte[]>(),
            Email.Create(email).Value,
            Email.Create(email).Value,
            fixture.Create<string>()
            ).ValueOrDefault;
    }
}
