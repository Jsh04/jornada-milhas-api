﻿
using JornadaMilhas.Core.DTO.Destinos;
using JornadaMilhas.Core.Indices;

namespace JornadaMilhas.Core.Interfaces.Destinos;

public interface IDestinosService
{
    Task<IEnumerable<DestinosIndex>> GetAllAsync(int page, int size);
    Task<DestinosIndex> CreateDestino(CreateDestinoDTO destino);
    Task<bool> DeleteDestino(string id);
    Task<bool> UpdateDestino(UpdateDestinoDTO updateDestinoDto, string id);
    Task<DetailsDestinoDTO> GetDestinoById(string id);
}
