using JornadaMilhas.Common.Entities;


namespace JornadaMilhas.Common.Data.Repository
{
    public interface IUserRepository<TUser> : 
        ICreatableRepository<TUser>,
        IUpdatableRepository<TUser> where TUser : User
    {
        Task<bool> IsUniqueAsync(string cpf, string mail, CancellationToken cancellationToken = default);
        Task<TUser> GetUserByEmail(string email, CancellationToken cancellationToken = default);
    }
}
