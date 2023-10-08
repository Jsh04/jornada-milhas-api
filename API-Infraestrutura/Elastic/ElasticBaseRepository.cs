using API_Configuracao.Configuracao;
using API_Infraestrutura.Configuracao;
using API_Infraestrutura.Indices;
using Elastic.Clients.Elasticsearch;
using System.Linq;

namespace API_Infraestrutura.Elastic
{
    public abstract class ElasticBaseRepository<T> : IElasticBaseRepository<T> where T : ElasticBaseIndex
    {
        private readonly ElasticsearchClient _clientElastic;

        public  ElasticBaseRepository()
        {
            _clientElastic = API_Configuracao.Configuracao.ConfiguracaoElastic.CreateElasticCLient();
            _clientElastic.Indices.Create<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var response = await _clientElastic.SearchAsync<T>();

            return response.Hits.Select(hit => hit.Source).ToList();
        }
    }
}
