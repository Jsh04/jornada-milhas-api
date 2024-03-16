
using JornadaMilhas.Core.DTO.Login;
using JornadaMilhas.Core.DTO.Usuario;

namespace JornadaMilhas.Core.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<IEnumerable<DetalhamentoUsuarioDTO>> GetAllAsync(int page, int size);
        Task<DetalhamentoUsuarioDTO> CreateUsuario(UsuarioCadastroDTO usuarioCadastroDTO);
        Task<bool> DeleteUsuario(long id);
        Task<DetalhamentoUsuarioDTO> UpdateUsuario(UsuarioAtualizacaoDTO destino, long id);
        Task<DetalhamentoUsuarioDTO> GetUsuarioById(long id);
        Task<CredenciasUsuarioDTO> AuthenticateUser(LoginDTO login);
    }
}
