using API_Domains.DTO.Login;
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
        Task<IEnumerable<DetalhamentoUsuarioDTO>> GetAllAsync(int page, int size);
        Task<DetalhamentoUsuarioDTO> CreateUsuario(UsuarioCadastroDTO usuarioCadastroDTO);
        Task<bool> DeleteUsuario(string id);
        Task<DetalhamentoUsuarioDTO> UpdateUsuario(UsuarioAtualizacaoDTO destino, string id);
        Task<DetalhamentoUsuarioDTO> GetUsuarioById(string id);
        Task<CredenciasUsuarioDTO> LoginUsuario(LoginDTO login);
    }
}
