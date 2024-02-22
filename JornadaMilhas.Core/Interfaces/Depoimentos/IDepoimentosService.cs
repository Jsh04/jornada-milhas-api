
using JornadaMilhas.Core.DTO.Depoimeto;
using JornadaMilhas.Core.Indices;

namespace JornadaMilhas.Core.Interfaces.Depoimentos
{
    public interface IDepoimentosService
    {
        Task<IEnumerable<DepoimentosIndex>> GetAllDepoimentosAsync(int page, int size);
        Task<DepoimentosIndex> CreateDepoimento(DepoimentoDTO depoimento);
        Task<bool> DeleteDepoimento(string id);
        Task<bool> UpdateDepoimento(DepoimentoAtualizarDTO depoimento, string id);
        Task<DepoimentosIndex> GetDepoimentoById(string id);

    }
}
