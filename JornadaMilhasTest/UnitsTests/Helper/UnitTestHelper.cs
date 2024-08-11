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

        public static UserLimited GetUserLimitedTest(Fixture fixture) 
        {
            var user = fixture.Build<UserLimited>()
                .With(user => user.Name, "José Silvio")
                .With(user => user.Email, Email.Create("test@email.com").Value)
                .With(user => user.Cpf, Cpf.Create("70188588442").Value)
                .OmitAutoProperties().Create();

            return user;

        }

    }
}
