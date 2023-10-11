
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
        Task<IEnumerable<DepoimentosIndex>> GetAllAsync();
        Task<DepoimentosIndex> CreateDepoimento(DepoimentosIndex depoimento);
    }
}
