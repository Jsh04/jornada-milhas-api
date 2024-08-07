﻿using JornadaMilhas.Common.Entities;


namespace JornadaMilhas.Common.Data.Repository;

public interface IUserGenericRepository<TUser> : 
    ICreatableRepository<TUser>,
    IReadableRepository<TUser>,
    IUpdatableRepository<TUser> where TUser : User
{
    Task<bool> IsUniqueAsync(string cpf, string mail, CancellationToken cancellationToken = default);
    
}
