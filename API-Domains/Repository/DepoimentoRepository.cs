using API_Domains.Interfaces;
using API_Infraestrutura.Elastic;
using API_Infraestrutura.Indices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Repository
{
    public class DepoimentoRepository : ElasticBaseRepository<DepoimentosIndex>, IDepoimentosRepository
    {

    }
}
