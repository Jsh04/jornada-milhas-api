using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IRepositoryUsuario : IRepository<User>
{
    Task<bool> IsUniqueAsync(string cpf, string mail, CancellationToken cancellationToken = default);
    Task<User> GetUserByEmail(string email, CancellationToken cancellationToken = default);
}

