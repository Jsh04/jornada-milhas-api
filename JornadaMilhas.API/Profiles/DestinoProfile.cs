
using AutoMapper;
using JornadaMilhas.Core.DTO.Destinos;
using JornadaMilhas.Core.Indices;


namespace JornadaMilhas.API;

public class DestinoProfile : Profile
{
    public DestinoProfile()
    {
        CreateMap<CreateDestinoDTO, DestinosIndex>();
        CreateMap<DestinosIndex, DetailsDestinoDTO>();
        CreateMap<UpdateDestinoDTO, DestinosIndex>();
    }
}
