using API_Domains.DTO.Destinos;
using API_Domains.Indices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Configuration.Profiles;

public class DestinoProfile : Profile
{
    public DestinoProfile()
    {
        CreateMap<CreateDestinoDTO, DestinosIndex>();
    }
    
}
