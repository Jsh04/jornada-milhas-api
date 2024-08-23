using AutoFixture;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Users.UserLimited;

using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Common.InputDto;

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

        public static RegisterUserLimitedCommand GetUserCorrectDataTest(Fixture fixture)
        {
            var requestUserLimitedRegisterCommand = fixture.Build<RegisterUserLimitedCommand>()
                .Without(user => user.Address)
                .With(user => user.Cpf, "76135350021")
                .With(user => user.Mail, "josesilvio.bs@gmail.com")
                .With(user => user.ConfirmMail, "josesilvio.bs@gmail.com")
                .With(user => user.Phone, "(28) 97968-4227")
                .With(user => user.Address, new AddressInputDto("Recife", "PE"))
                .With(user => user.DtBirth, DateTime.Parse("04-02-2004"))
                .OmitAutoProperties()
                .Create();

            return requestUserLimitedRegisterCommand;
        }

    }
}
