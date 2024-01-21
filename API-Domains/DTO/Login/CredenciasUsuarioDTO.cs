using API_Domains.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.DTO.Login
{
    public class CredenciasUsuarioDTO
    {
        public DetalhamentoUsuarioDTO Usuario { get; set; }
        public string Token { get; set; }
    }
}
