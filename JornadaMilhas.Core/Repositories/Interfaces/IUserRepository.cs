using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Common.Entities;


namespace JornadaMilhas.Core.Repositories.Interfaces;


public interface IUserRepository : IReadableRepository<User>, IDeletableRepository<User>, IGetUserByEmail<User>
{
}
