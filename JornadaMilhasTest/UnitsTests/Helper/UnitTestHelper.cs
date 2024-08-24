using AutoFixture;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Users.UserLimited;

using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Common.InputDto;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Enums;



namespace JornadaMilhasTest.UnitsTests.Helper
{
    public static class UnitTestHelper
    {

        public static UserLimited GetUserLimitedTest(Fixture fixture) 
        {
            fixture = CustomReturnUserLimited(fixture);
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


        public static async Task<PaginationResult<UserLimited>> GetAllUsersFakeData(Fixture fixture, 
            int numberToCreate, int page, int size)
        {
            fixture = CustomReturnUserLimited(fixture);

            var listFakeUsers = fixture.Build<UserLimited>()
                .OmitAutoProperties()
                .CreateMany(numberToCreate).AsQueryable();

            var paginationResult = new PaginationResult<UserLimited>(page, size, listFakeUsers.Count());
            paginationResult.SetData(listFakeUsers.ToList());
            return paginationResult;
        }


        private static Fixture CustomReturnUserLimited(Fixture fixture)
        {
            fixture.Customize<UserLimited>(custom => custom.FromFactory(() =>
            {
                var userFake = UserLimited.Create(
                    fixture.Create<string>(),
                    DateOfBirth.Create(DateTime.Parse("04-02-2004")).Value,
                    EnumGenre.Male,
                    Cpf.Create("77919691060").Value ?? default,
                    Phone.Create("(28) 97968-4227").Value,
                    Address.Create("Recife", "PE", default, default, default).Value,
                    null,
                    Email.Create("josesilvio.bs@gmail.com").Value,
                    Email.Create("josesilvio.bs@gmail.com").Value,
                    fixture.Create<string>()).Value;

                return userFake;
            }));

            return fixture;
        }

    }
}
