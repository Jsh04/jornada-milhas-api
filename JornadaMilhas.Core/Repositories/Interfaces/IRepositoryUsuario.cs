
using JornadaMilhas.Core.Entities;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IRepositoryUsuario : IRepository<Usuario>
{
    Task<Usuario> GetUserByEmail(string email);
}

