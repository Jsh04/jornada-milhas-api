using API_Domains.DTO.Usuario;
using API_Domains.Indices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Configuration.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioCadastroDTO, UsuarioIndex>();
        CreateMap<UsuarioAtualizacaoDTO, UsuarioIndex>();
        CreateMap<UsuarioIndex, DetalhamentoUsuarioDTO>();
        CreateMap<List<UsuarioIndex>, IEnumerable<DetalhamentoUsuarioDTO>>();
    }
}
