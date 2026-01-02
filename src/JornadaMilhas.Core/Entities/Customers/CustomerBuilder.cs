using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Events;

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
        
        customer.ThrowEvent(new CustomerRegisteredEvent(customer.Name, customer.Email.Address, customer.DtCreated));
        
        return Result.Ok(customer);
    }
}