using System.Security.Claims;
using System.Security.Cryptography;
using AutoFixture;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Entity.Users.Enums;
using JornadaMilhas.Common.InputModels;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Users;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Helper;

public static class UnitTestHelper
{
    public static List<Claim> GetClaimsToTest(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email.Address),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, nameof(User))
        };
        return claims;
    }

    public static string GenerateSecretKey(int length = 32)
    {
        var ramdomNumbers = new byte[length];
        RandomNumberGenerator.Fill(ramdomNumbers);
        return Convert.ToBase64String(ramdomNumbers);
    }

   

    public static RegisterCustomerCommand GetUserCorrectDataTest(Fixture fixture)
    {
        var requestUserLimitedRegisterCommand = fixture.Build<RegisterCustomerCommand>()
            .Without(user => user.Address)
            .With(user => user.Cpf, "76135350021")
            .With(user => user.Mail, "josesilvio.bs@gmail.com")
            .With(user => user.ConfirmMail, "josesilvio.bs@gmail.com")
            .With(user => user.Phone, "(28) 97968-4227")
            .With(user => user.Address, new AddressInputModel("Recife", "PE", "95059-837", fixture.Create<string>(),fixture.Create<string>()))
            .With(user => user.DtBirth, DateTime.Parse("04-02-2004"))
            .OmitAutoProperties()
            .Create();

        return requestUserLimitedRegisterCommand;
    }


    


    
    
}