using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System;
namespace API_Infraestrutura.Configuracao;

public static class FactoryElastic
{
    public static ElasticsearchClient CreateElasticCLient()
    {
        var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
            .CertificateFingerprint("19e83138368a7301b77aa8c909210985d673bd76a4f57586e165ffa731e95eef")
            .Authentication(new BasicAuthentication("elastic", "mK_AlHhHi66c8rzMAnIZ"));

        var client = new ElasticsearchClient(settings);

        return client;
    }
}
