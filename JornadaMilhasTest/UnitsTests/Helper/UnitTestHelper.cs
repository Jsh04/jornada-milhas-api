using AutoFixture;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Users.UserLimited;

using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Common.InputDto;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Enums;
using JornadaMilhas.Application.Util;
using System.Security.Cryptography;



namespace JornadaMilhasTest.UnitsTests.Helper
{
    public static class UnitTestHelper
    {
        public static string GenerateSecretKey(int length = 32)
        {
            var ramdomNumbers = new byte[length];
            RandomNumberGenerator.Fill(ramdomNumbers); 
            return Convert.ToBase64String(ramdomNumbers);
        }

        public static UserLimited GetUserLimitedTest(Fixture fixture) 
        {
            var user = fixture.Build<UserLimited>()
                .FromFactory(CustomReturnUserLimited(fixture))
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


        public static PaginationResult<UserLimited> GetAllUsersFakeData(Fixture fixture, 
            int numberToCreate, int page, int size)
        {
            var listFakeUsers = fixture.Build<UserLimited>()
                .FromFactory(CustomReturnUserLimited(fixture))
                .OmitAutoProperties()
                .CreateMany(numberToCreate).AsQueryable();

            var paginationResult = new PaginationResult<UserLimited>(page, size, listFakeUsers.Count());
            paginationResult.SetData(listFakeUsers.ToList());
            return paginationResult;
        }


        private static Func<UserLimited> CustomReturnUserLimited(Fixture fixture)
        {
            return () =>
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
                    EncriptarSenha.CriptografarSenha(ConstantsUnitTest.PasswordTest)).Value;
                return userFake;
            };
        }

    }
}
