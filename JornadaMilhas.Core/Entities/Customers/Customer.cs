using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Orders;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Users;

namespace JornadaMilhas.Core.Entities.Customers;

public class Customer : User
{
    private readonly List<Depoiment> _depoiments;
    
    private readonly List<Order> _orders;

    public IReadOnlyCollection<Depoiment> Depoiments => _depoiments.AsReadOnly();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    
    private Customer(CustomerBuilder builder) : base(builder.Name, 
        builder.DtBirth, 
        builder.Genre, 
        builder.Cpf, 
        builder.Phone, 
        builder.Address, 
        builder.Mail, 
        builder.ConfirmMail, 
        builder.Password)
    {
        _depoiments = new List<Depoiment>();
        _orders = new List<Order>();
    }

    private Customer() : base()
    {
        
    }

    public static Customer Create(CustomerBuilder builder) => new(builder);

    public void AddDepoiment(Depoiment depoiment)
    {
        if (depoiment is null)
            throw new NullReferenceException("Depoimento não pode ser nulo");

        _depoiments.Add(depoiment);
    }
}