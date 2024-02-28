
using JornadaMilhas.Core.DTO.Usuario;


namespace JornadaMilhas.Core.DTO.Login
{
    public class CredenciasUsuarioDTO
    {
        public DetalhamentoUsuarioDTO User { get; set; }
        public string Token { get; set; }
    }
}
