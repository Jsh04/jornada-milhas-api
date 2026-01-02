using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Interfaces.Repository;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IUserRepository : IDeletableRepository<User>
{
    Task<User?> GetByEmailOrCpfAsync(string emailOrCpf, CancellationToken cancellationToken = default);
}