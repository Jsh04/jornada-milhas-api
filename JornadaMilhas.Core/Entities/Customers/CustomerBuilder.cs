using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Customers;

public class CustomerBuilder : UserBuilder<Customer, CustomerBuilder>
{
    private CustomerBuilder()
    { }
    
    public static CustomerBuilder Create() => new();
    
    public Result<Customer> Build()
    {
        if (_errors.Count > 0)
            return Result.Fail<Customer>(_errors);

        var customer = Customer.Create(this);
        
        return Result.Ok(customer);
    }
}