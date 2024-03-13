
using AutoMapper;
using JornadaMilhas.Core.DTO.Destinos;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Indices;


namespace JornadaMilhas.API;

public class DestinoProfile : Profile
{
    public DestinoProfile()
    {
        CreateMap<CreateDestinoDTO, Destino>();
        CreateMap<Destino, DetailsDestinoDTO>();
        CreateMap<UpdateDestinoDTO, Destino>();
    }
}
