
using JornadaMilhas.Core.DTO.Login;
using JornadaMilhas.Core.DTO.Usuario;

namespace JornadaMilhas.Core.Interfaces.Usuarios
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
