using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Common.Entities;


namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IUserRepository : IReadableRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

}
