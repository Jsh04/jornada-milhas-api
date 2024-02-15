using API_Domains.DTO.Depoimeto;
using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces.Depoimentos
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
