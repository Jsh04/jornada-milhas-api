using API_Domains.Indices;
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
    public class DestinosRepository : IDestinosRepository
    {
        private readonly ElasticsearchClient _client;

        private readonly string IndexName = "destino";

        public DestinosRepository()
        {
            _client = FactoryElastic.CreateElasticCLient();
            _client.Indices.Create(IndexName);
        }


        public async Task<DestinosIndex> CreateDestino(DestinosIndex destino)
        {
            var response = await _client.IndexAsync(destino, IndexName);
            return destino;
        }

        public async Task<bool> DeleteDestino(string id)
        {
            var response = await _client.DeleteAsync<DestinosIndex>(id);
            if (response.IsValidResponse)
                return true;
            else
                return false;
            
        }

        public async Task<IEnumerable<DestinosIndex>> GetAllAsync(int page, int size)
        {
            var response = await _client.SearchAsync<DestinosIndex>(des =>
            des.Index(IndexName)
            .From(page)
            .Size(size));

            return response.Documents;
        }

        public async Task<DestinosIndex> GetDestinoById(string id)
        {
            var response = await _client.GetAsync<DestinosIndex>(id, idx => idx.Index(IndexName));

            if (response.IsValidResponse)
                return response.Source!;
            throw new Exception("Nenhum dado encontrado");
        }

        public async Task<DestinosIndex> UpdateDestino(DestinosIndex destino, string id)
        {
            var response = await _client.UpdateAsync<DestinosIndex, DestinosIndex>(IndexName, id, doc => doc.Doc(destino));

            if (response.IsValidResponse)
                return response.Get!.Source;

            throw new Exception("Erro na atualização");
        }
    }
}
