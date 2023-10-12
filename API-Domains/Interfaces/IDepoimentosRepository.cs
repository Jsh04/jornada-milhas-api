
using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces
{
    public interface IDepoimentosRepository 
    {
        Task<IEnumerable<DepoimentosIndex>> GetAllAsync(int page, int size);
        Task<DepoimentosIndex> CreateDepoimento(DepoimentosIndex depoimento);
        Task<bool> DeleteDepoimento(string id);
        Task<DepoimentosIndex> UpdateDepoimento(DepoimentosIndex depoimento,string id); 
        Task<DepoimentosIndex> GetDepoimentoById(string id);
    }
}
