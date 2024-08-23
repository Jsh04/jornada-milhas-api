using JornadaMilhas.Common.Entities;

namespace JornadaMilhas.Common.Data.Repository
{
    public interface IGetUserByEmail<TUser> where TUser : User
    {
        Task<TUser> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
