using API_Domains.Indices;
using API_Domains.Interfaces.Usuarios;
using API_Infraestrutura.Configuracao;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string IndexName;
    private readonly ElasticsearchClient _client;
    public UsuarioRepository(FactoryElastic factoryElastic)
    {
        IndexName = "usuarios";
        _client = factoryElastic.CreateElasticCLient();
        _client.Indices.Create(IndexName);
    }

    public async Task<UsuarioIndex> Create(UsuarioIndex obj)
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

    public async Task<IEnumerable<UsuarioIndex>> GetAllAsync(int page, int size)
    {
        if (page != 0)
            page *= 10;


        var response = await _client.SearchAsync<UsuarioIndex>(dep =>
        dep.Index(IndexName)
        .From(page)
        .Size(size));

        return response.Documents;
    }

    public async Task<UsuarioIndex> GetById(string id)
    {
        var response = await _client.GetAsync<UsuarioIndex>(id, idx => idx.Index(IndexName));

        if (response.IsValidResponse)
            return response.Source!;
        throw new Exception("Nenhum dado encontrado");
    }

    public async Task<UsuarioIndex> GetUserByEmail(string email)
    {
        var response = await _client.SearchAsync<UsuarioIndex>(
            s =>
            s.Index(IndexName)
            .Query(
                query =>
                query.Term(t => t.Email.Suffix("keyword"), email)
                )
            );
        var usuario = response.Documents.FirstOrDefault();
        return usuario ?? throw new Exception("Usuário não encontrado com o email especificado");
    }

    public async Task<UsuarioIndex> Update(UsuarioIndex obj, string id)
    {
        var response = await _client.UpdateAsync<UsuarioIndex, UsuarioIndex>(IndexName, id, doc => doc.Doc(obj));

        if (response.IsValidResponse)
            return response.Get!.Source;

        throw new Exception("Erro na atualização");
    }
}
