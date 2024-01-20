using API_Domains.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces.Usuarios
{
    public interface IUsuarioRepository : IRepository<UsuarioIndex>
    {
        Task<UsuarioIndex> GetUserByEmail(string email);
    }
}
