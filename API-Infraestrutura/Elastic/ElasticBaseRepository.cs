
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
            _clientElastic = ConfiguracaoElastic.CreateElasticCLient();
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            var response = await _clientElastic.SearchAsync<T>();

            return response.Hits.Select(hit => hit.Source).ToList();
        }

        public bool CreateIndexAsync()
        {
            var response =  _clientElastic.Indices.Create<T>();
            if(response.Acknowledged)
                return true;
            else 
                return false;
            
        }

        
    }
}
