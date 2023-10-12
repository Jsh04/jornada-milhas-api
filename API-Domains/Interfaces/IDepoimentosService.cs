using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces
{
    public interface IDepoimentosService
    {
        Task<IEnumerable<DepoimentosIndex>> GetAllDepoimentosAsync();
        Task<DepoimentosIndex> CreateDepoimento(DepoimentosIndex depoimento);
        Task<bool> DeleteDepoimento(string id);
        Task<DepoimentosIndex> UpdateDepoimento(DepoimentosIndex depoimento, string id);
        Task<DepoimentosIndex> GetDepoimentoById(string id);

    }
}
