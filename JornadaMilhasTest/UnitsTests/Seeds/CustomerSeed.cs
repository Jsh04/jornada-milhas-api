using AutoFixture;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Util;
using JornadaMilhas.Core.Entities.Customers;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public static class CustomerSeed
{
    public static Customer GetCustomerTest(Fixture fixture)
    {
        var user = fixture.Build<Customer>()
            .FromFactory(CustomReturnCustomer(fixture))
            .OmitAutoProperties().Create();

        return user;
    }
    
    public static PaginationResult<Customer> GetAllCustomersFakeData(Fixture fixture,
        int numberToCreate, int page, int size)
    {
        var listFakeUsers = fixture.Build<Customer>()
            .FromFactory(CustomReturnCustomer(fixture))
            .OmitAutoProperties()
            .CreateMany(numberToCreate).AsQueryable();

        var paginationResult = new PaginationResult<Customer>(page, size, listFakeUsers.Count());
        paginationResult.SetData(listFakeUsers.ToList());
        return paginationResult;
    }
    
    private static Func<Customer> CustomReturnCustomer(Fixture fixture)
    {
        return () =>
        {
            var customerFake = CustomerBuilder
                .Create()
                .WithName(fixture.Create<string>())
                .WithDtOfBirth(DateTime.Parse("04-02-2004"))
                .WithDocumentation("77919691060")
                .WithPhone("(28) 97968-4227")
                .WithAddress("Rua teste", "Recife", "PE", "Boa viagem", "49045-253")
                .WithEmail(ConstantsUnitTest.EmailTest)
                .WithConfirmMail(ConstantsUnitTest.EmailTest)
                .WithPassword(EncriptarSenha.CriptografarSenha(ConstantsUnitTest.PasswordTest))
                .Build();
            return customerFake.Value;
        };
    }
}