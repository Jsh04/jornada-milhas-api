using API_Domains.Indices;
using API_Domains.Interfaces.Destinos;
using API_Infraestrutura.Configuracao;
using Elastic.Clients.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Repository
{
    public class DestinosRepository : IDestinosRepository
    {
        private readonly string _indexName;
        private const string NameIndex = "destinos";
        private readonly ElasticsearchClient _client;
        public DestinosRepository(FactoryElastic factoryElastic)
        {
            _indexName = NameIndex;
            _client = factoryElastic.CreateElasticCLient();
            _client.Indices.Create(_indexName);
        }
        public async Task<DestinosIndex> Create(DestinosIndex obj)
        {
            var response = await _client.IndexAsync(obj, _indexName);
            if(response.IsSuccess())
                return obj;
            throw new Exception("Erro ao cadastrar destino");
        }

        public async Task<bool> Delete(string id)
        {
            var response = await _client.DeleteAsync(_indexName, id);
            return response.IsValidResponse;
        }

        public async Task<IEnumerable<DestinosIndex>> GetAllAsync(int page, int size)
        {
            if (page != 0)
                page *= 10;


            var response = await _client.SearchAsync<DestinosIndex>(dep =>
            dep.Index(_indexName)
            .From(page)
            .Size(size));

            return response.Documents;
        }

        public async Task<DestinosIndex> GetById(string id)
        {
            var response = await _client.GetAsync<DestinosIndex>(id, idx => idx.Index(_indexName));

            if (response.IsValidResponse)
                return response.Source!;
            throw new Exception("Nenhum dado encontrado");
        }

        public async Task<DestinosIndex> Update(DestinosIndex obj, string id)
        {
            var response = await _client.UpdateAsync<DestinosIndex, DestinosIndex>(_indexName, id, doc => doc.Doc(obj));

            if (response.IsValidResponse)
                return response.Get!.Source;

            throw new Exception("Erro na atualização");
        }
    }
}
