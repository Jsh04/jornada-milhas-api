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

        private readonly string IndexName = "depoimento";
            

        public DepoimentoRepository()
        {
            _client = FactoryElastic.CreateElasticCLient();
            _client.Indices.Create(IndexName);
        }

        public async Task<IEnumerable<DepoimentosIndex>> GetAllAsync(int page, int size)
        {
            if (page != 0)
                page = page * 10;
                
            
            var response = await _client.SearchAsync<DepoimentosIndex>(dep => 
            dep.Index(IndexName)
            .From(page)
            .Size(size));

            return response.Documents;
        }

        public async Task<DepoimentosIndex> Create(DepoimentosIndex depoimento)
        {
            var response = await _client.IndexAsync(depoimento, IndexName);
            return depoimento;
        }

        public async Task<DepoimentosIndex> GetById(string id)
        {
            var response = await _client.GetAsync<DepoimentosIndex>(id, idx => idx.Index(IndexName));

            if (response.IsValidResponse)
                return response.Source!;
            throw new Exception("Nenhum dado encontrado");
            
        }

        public async Task<bool> Delete(string id)
        {
            var response = await _client.DeleteAsync(IndexName, id);
            if (response.IsValidResponse)
                return true;
            return false;
        }

        public async Task<DepoimentosIndex> Update(DepoimentosIndex depoimento,string id)
        {
            var response = await _client.UpdateAsync<DepoimentosIndex, DepoimentosIndex>(IndexName, id, doc => doc.Doc(depoimento));

            if (response.IsValidResponse)
                return response.Get!.Source;
            
            throw new Exception("Erro na atualização");
        }
    }
}
