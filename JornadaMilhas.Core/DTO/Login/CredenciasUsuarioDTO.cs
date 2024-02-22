
using JornadaMilhas.Core.DTO.Usuario;


namespace JornadaMilhas.Core.DTO.Login
{
    public class CredenciasUsuarioDTO
    {
        public DetalhamentoUsuarioDTO Usuario { get; set; }
        public string Token { get; set; }
    }
}
