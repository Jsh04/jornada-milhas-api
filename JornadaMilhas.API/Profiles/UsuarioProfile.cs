
using AutoMapper;
using JornadaMilhas.Core.DTO.Usuario;
using JornadaMilhas.Core.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities;

namespace JornadaMilhas.API;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioCadastroDTO, Usuario>();
        CreateMap<UsuarioAtualizacaoDTO, Usuario>();
        CreateMap<Usuario, DetalhamentoUsuarioDTO>();
        CreateMap<List<Usuario>, IEnumerable<DetalhamentoUsuarioDTO>>();
    }
}
