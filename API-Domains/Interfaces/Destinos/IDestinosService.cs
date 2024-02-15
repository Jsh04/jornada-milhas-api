using API_Domains.DTO.Destinos;
using API_Domains.Indices;
using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces.Destinos;

public interface IDestinosService
{
    Task<IEnumerable<DestinosIndex>> GetAllAsync(int page, int size);
    Task<DestinosIndex> CreateDestino(CreateDestinoDTO destino);
    Task<bool> DeleteDestino(string id);
    Task<bool> UpdateDestino(UpdateDestinoDTO updateDestinoDto, string id);
    Task<DetailsDestinoDTO> GetDestinoById(string id);
}
