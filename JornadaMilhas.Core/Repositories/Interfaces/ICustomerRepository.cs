using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities.Customers;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface ICustomerRepository : IReadableRepository<Customer>, ICreatableRepository<Customer>, IDeletableRepository<Customer>
{
    Task<bool> IsUniqueAsync(string email, string cpf, CancellationToken cancellationToken);
}