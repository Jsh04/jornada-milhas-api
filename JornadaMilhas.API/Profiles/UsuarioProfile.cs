
using AutoMapper;
using JornadaMilhas.Core.DTO.Usuario;
using JornadaMilhas.Core.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.API;

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
