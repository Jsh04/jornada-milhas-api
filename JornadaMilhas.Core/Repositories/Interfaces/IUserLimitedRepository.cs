using JornadaMilhas.Common.Entities;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Entities.Users.UserLimited;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IUserLimitedRepository : IRepository<UserLimited>
{
    Task<bool> IsUniqueAsync(string cpf, string mail, CancellationToken cancellationToken = default);
    Task<UserLimited> GetUserByEmail(string email, CancellationToken cancellationToken = default);
}

