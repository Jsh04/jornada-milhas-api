
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Core.TermVectors;
using JornadaMilhas.Core.Interfaces;


namespace JornadaMilhas.Core.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly string IndexName;
        private readonly ElasticsearchClient _client;

        public Repository(string indexName, ElasticsearchClient els)
        {   
            IndexName = indexName;
            _client = els;
            _client.Indices.Create(IndexName);
        }
        public async Task<T> Create(T obj)
        {
            var response = await _client.IndexAsync(obj, IndexName);
            return obj;
        }

        public async Task<bool> Delete(string id)
        {
            var response = await _client.DeleteAsync(IndexName, id);
            if (response.IsValidResponse)
                return true;
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page, int size)
        {
            if (page != 0)
                page *= 10;


            var response = await _client.SearchAsync<T>(dep =>
            dep.Index(IndexName)
            .From(page)
            .Size(size));

            return response.Documents;
        }

        public async Task<T> SearchObjectByQuery(Action<SearchRequestDescriptor<T>> request)
        {

            var response = await _client.SearchAsync(request);

            if (!response.IsValidResponse)
                throw new Exception();

            T obj = response.Documents.FirstOrDefault();

            return obj == null ? throw new Exception() : obj;
        }

        public async Task<T> GetById(string id)
        {
            var response = await _client.GetAsync<T>(id, idx => idx.Index(IndexName));

            if (response.IsValidResponse)
                return response.Source!;
            throw new Exception("Nenhum dado encontrado");
        }

        public async Task<bool> Update(T obj, string id)
        {
            var response = await _client.UpdateAsync<T, T>(IndexName, id, doc => doc.Doc(obj));

            if (response.IsValidResponse)
                return response.Result == Result.Updated;

            return false;
        }
    }
}
