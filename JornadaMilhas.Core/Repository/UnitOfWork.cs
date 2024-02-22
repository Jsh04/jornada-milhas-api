
using Elastic.Clients.Elasticsearch;
using JornadaMilhas.Core.Indices;
using JornadaMilhas.Core.Interfaces;
using JornadaMilhas.Core.Repository;
using JornadaMilhas.Infrastruture;



namespace API_Domains.Repository;

public class UnitOfWork : IUnitOfWork
{
    private Repository<DestinosIndex>? destinoRepository = null;
    private Repository<DepoimentosIndex>? depoimentoRepository = null;
    private Repository<UsuarioIndex>? usuarioRepository = null;

    private readonly ElasticsearchClient _client;

    public UnitOfWork(FactoryElastic client)
    {
        _client = client.CreateElasticCLient();
    }

    public IRepository<DestinosIndex> DestinoRepository
    {
        get 
        {
            destinoRepository ??= new Repository<DestinosIndex>("destinos", _client);
            return destinoRepository;
        }
    }

    public IRepository<DepoimentosIndex> DepoimentoRepository
    {
        get
        {
            depoimentoRepository ??= new Repository<DepoimentosIndex>("depoimentos", _client);
            return depoimentoRepository;
        }
    }

    public IRepository<UsuarioIndex> UsuarioRepository
    {
        get
        {
            usuarioRepository ??= new Repository<UsuarioIndex>("usuarios", _client);
            return usuarioRepository;
        }
    }
}
