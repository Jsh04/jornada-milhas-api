using API_Domains.Interfaces;
using API_Infraestrutura.Configuracao;
using API_Infraestrutura.Indices;
using Elastic.Clients.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Repository
{
    public class DepoimentoRepository : IDepoimentosRepository
    {
        private readonly ElasticsearchClient _client;

        private const string IndexName = "depoimentosindex";

        public DepoimentoRepository()
        {
            _client = FactoryElastic.CreateElasticCLient();
            _client.Indices.Create(IndexName);
        }

        public async Task<IEnumerable<DepoimentosIndex>> GetAllAsync()
        {
            var response = await _client.SearchAsync<DepoimentosIndex>(dep => dep.Index(IndexName));

            return response.Documents;
        }

        public async Task<DepoimentosIndex> CreateDepoimento(DepoimentosIndex depoimento)
        {
            var response = await _client.IndexAsync(depoimento, IndexName);
            return depoimento;
        }

        public async Task<DepoimentosIndex> GetDepoimentoById(int id)
        {
            var response = await _client.GetAsync<DepoimentosIndex>(id, idx => idx.Index(IndexName));

            if (response.IsValidResponse)
                return response.Source!;
            throw new Exception("Nenhum dado encontrado");
            
        }
    }
}
