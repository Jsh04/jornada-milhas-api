using API_Domains.Interfaces.Depoimentos;
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
    public class DepoimentosRepository : IDepoimentosRepository
    {
        private readonly string _indexName;
        private readonly ElasticsearchClient _client;
        public DepoimentosRepository(FactoryElastic factoryElastic)
        {
            _indexName = "depoimentos";
            _client = factoryElastic.CreateElasticCLient();
            _client.Indices.Create(_indexName);
        }
        public async Task<DepoimentosIndex> Create(DepoimentosIndex obj)
        {
            var response = await _client.IndexAsync(obj, _indexName);
            if (response.IsSuccess())
                return obj;
            throw new ApplicationException("Erro ao cadastrar o depoimento");


        }

        public async Task<bool> Delete(string id)
        {
            var response = await _client.DeleteAsync(_indexName, id);
            return response.IsValidResponse;
        }

        public async Task<IEnumerable<DepoimentosIndex>> GetAllAsync(int page, int size)
        {
            if (page != 0)
                page *= 10;


            var response = await _client.SearchAsync<DepoimentosIndex>(dep =>
            dep.Index(_indexName)
            .From(page)
            .Size(size));

            return response.Documents;
        }

        public async Task<DepoimentosIndex> GetById(string id)
        {
            var response = await _client.GetAsync<DepoimentosIndex>(id, idx => idx.Index(_indexName));

            if (response.IsValidResponse)
                return response.Source!;
            throw new Exception("Nenhum depoiemento encontrado");
        }

        public async Task<DepoimentosIndex> Update(DepoimentosIndex obj, string id)
        {
            var response = await _client.UpdateAsync<DepoimentosIndex, DepoimentosIndex>(_indexName, id, doc => doc.Doc(obj));

            if (response.IsValidResponse)
                return response.Get!.Source;

            throw new Exception("Erro na atualização");
        }
    }
}
