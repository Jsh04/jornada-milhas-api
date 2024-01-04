
using API_Domains.Indices;
namespace API_Domains.Interfaces;

public interface IDestinosRepository
{
    Task<IEnumerable<DestinosIndex>> GetAllAsync(int page, int size);
    Task<DestinosIndex> CreateDestino(DestinosIndex destino);
    Task<bool> DeleteDestino(string id);
    Task<DestinosIndex> UpdateDestino(DestinosIndex destino, string id);
    Task<DestinosIndex> GetDestinoById(string id);
}
