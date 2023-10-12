using API_Domains.DTO;
using API_Infraestrutura.Indices;
using AutoMapper;

namespace API_Configuration.Profiles;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<DepoimentoDTO, DepoimentosIndex>();
    }
}
