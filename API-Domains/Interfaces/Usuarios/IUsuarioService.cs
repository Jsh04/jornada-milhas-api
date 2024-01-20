using API_Domains.DTO.Usuario;
using API_Domains.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioIndex>> GetAllAsync(int page, int size);
        Task<UsuarioIndex> CreateUsuario(UsuarioCadastroDTO usuarioCadastroDTO);
        Task<bool> DeleteDestino(string id);
        Task<UsuarioIndex> UpdateDestino(UsuarioAtualizacaoDTO destino, string id);
        Task<UsuarioIndex> GetDestinoById(string id);
    }
}
