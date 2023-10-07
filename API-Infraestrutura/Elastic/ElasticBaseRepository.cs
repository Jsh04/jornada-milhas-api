using API_Infraestrutura.Indices;
using Nest;
using System.Linq;

namespace API_Infraestrutura.Elastic
{
    public abstract class ElasticBaseRepository<T> : IElasticBaseRepository<T> where T : ElasticBaseIndex
    {
        private readonly IElasticClient _elasticClient;

        public abstract string IndexName { get; }

        public ElasticBaseRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            var search = new SearchDescriptor<T>().MatchAll();

            var response = await _elasticClient.SearchAsync<T>(search);

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);
            

            return response.Hits.Select(hit => hit.Source).ToList();
        }

        public async Task<bool> InsertManyAsync(IList<T> tList)
        {
            var response = await _elasticClient.IndexManyAsync(tList, IndexName);

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);


            return true;
        }

        public async Task<bool> CreateIndexAsync()
        {
            if (!(await _elasticClient.IndexExistsAsync(IndexName)).Exists)
            {
                await _elasticClient.CreateIndexAsync(IndexName);
            }
            return true;
        }
    }
}
