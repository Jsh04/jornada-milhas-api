using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IUserRepository : IDeletableRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}