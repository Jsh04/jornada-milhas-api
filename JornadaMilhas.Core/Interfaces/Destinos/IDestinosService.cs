
using JornadaMilhas.Core.DTO.Destinos;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Indices;

namespace JornadaMilhas.Core.Interfaces.Destinos;

public interface IDestinosService
{
    Task<IEnumerable<Destino>> GetAllAsync(int page, int size);
    Task<Destino> CreateDestino(CreateDestinoDTO destino);
    Task<bool> DeleteDestino(long id);
    Task<bool> UpdateDestino(UpdateDestinoDTO updateDestinoDto, long id);
    Task<DetailsDestinoDTO> GetDestinoById(long id);
}
