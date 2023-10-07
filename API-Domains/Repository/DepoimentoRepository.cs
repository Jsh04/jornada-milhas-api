using API_Domains.Interfaces;
using API_Infraestrutura.Elastic;
using API_Infraestrutura.Indices;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Repository
{
    public class DepoimentoRepository : ElasticBaseRepository<DepoimentosIndex>, IDepoimentosRepository
    {
        public DepoimentoRepository(IElasticClient elasticClient) : base(elasticClient)
        {
        }

        public override string IndexName => "depoimentos";
    }
}
