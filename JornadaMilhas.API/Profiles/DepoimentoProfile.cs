using AutoMapper;
using JornadaMilhas.Core.DTO.Depoimeto;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Indices;

namespace JornadaMilhas.API;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<DepoimentoDTO, Depoimento>();
    }
}
