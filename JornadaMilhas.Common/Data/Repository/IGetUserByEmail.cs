using JornadaMilhas.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Data.Repository
{
    public interface IGetUserByEmail<TUser> where TUser : User
    {
        Task<TUser> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
